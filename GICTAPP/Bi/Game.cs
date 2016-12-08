using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace GICTAPP
{
    public class Game
    {
        private readonly string _connectionString;
        private readonly List<string> _matchedCards = new List<string>();
        private readonly Random _rnd = new Random();
        private readonly MyViewModel _viewModel;
        private StateEnum _cardsOpened = StateEnum.TwoOpened;

        public Game(int players, int boards)
        {
        }

        public Game(MyViewModel viewModel)
        {
            _viewModel = viewModel;

            _viewModel.CommandSwapCard = new RelayCommand(CanExecuteSwapCard, ExecuteSwapCard);


            var path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            _connectionString = string.Concat("Data Source=(LocalDB)\\v11.0; AttachDbFilename=", path,
                "\\GICTAPPDATA.mdf; Integrated Security=True");
        }

        private bool CanExecuteSwapCard(object obj)
        {
            if (!(obj is ImageModel)) return false;
            return !_matchedCards.Contains(((ImageModel) obj).Id);
        }

        private void ExecuteSwapCard(object o)
        {
            if (!(o is ImageModel)) return;
            var image = _viewModel.Images.FirstOrDefault(x => x.Id == ((ImageModel) o).Id);
            if (image == null) return;
            switch (_cardsOpened)
            {
                // 2 cards opened but not mathed - close previous 2
                case StateEnum.TwoOpened:
                    _viewModel.Images
                        .Where(x => x.IsCoverVisible == false && !_matchedCards.Contains(x.Id))
                        .ToList()
                        .ForEach(x => x.IsCoverVisible = true);
                    _cardsOpened = StateEnum.AllClosed;
                    break;
                // no cards opened - open this one
                case StateEnum.AllClosed:
                    image.IsCoverVisible = false;
                    _cardsOpened = StateEnum.OneOpened;
                    break;
                // 1 card opened - compare current card
                case StateEnum.OneOpened:
                    var compare = _viewModel.Images.FirstOrDefault(x => x.IsCoverVisible == false && !_matchedCards.Contains(x.Id));
                    image.IsCoverVisible = false;
                    if (compare != null)
                    {
                        if (image.ImageSource == compare.ImageSource)
                        {
                            _matchedCards.Add(image.Id);
                            _matchedCards.Add(compare.Id);
                            _cardsOpened = StateEnum.AllClosed;
                        }
                        else
                        {
                            _cardsOpened = StateEnum.TwoOpened;
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        public void FillGameBoard()
        {
            var halfCards = _viewModel.NumberOfCards/2;
            var path = Directory.GetCurrentDirectory() + "/Resources/";
            // get images from folder
            var images = Directory
                .GetFiles(path, "*.jpg", SearchOption.AllDirectories)
                .Take(halfCards)
                .ToList();
            // duplicate set
            images.AddRange(images);
            // shuffle set
            images = images.OrderBy(x => _rnd.Next()).ToList();
            // assign to viewmodel
            foreach (var image in images)
            {
                _viewModel.Images.Add(new ImageModel {ImageSource = image});
            }
        }
    }
}