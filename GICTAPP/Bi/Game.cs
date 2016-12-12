using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace GICTAPP
{
    /// <summary>
    ///     Game logic
    /// </summary>
    public class Game
    {
        // connection string to database
        private readonly string _connectionString;
        // collection of already found matching cards
        private readonly List<string> _matchedCards = new List<string>();
        // random number generator
        private readonly Random _rnd = new Random();
        // game viewmodel
        private readonly MyViewModel _viewModel;
        // game state
        private StateEnum _cardsOpened = StateEnum.TwoOpened;
        // game is just started
        private bool _isStarted = true;

        /// <summary>
        ///     Default constructor
        /// </summary>
        /// <param name="viewModel"></param>
        public Game(MyViewModel viewModel)
        {
            // assign viewmodel
            _viewModel = viewModel;

            // assign command
            _viewModel.CommandSwapCard = new RelayCommand(CanExecuteSwapCard, ExecuteSwapCard);

            // set path to local database
            var path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            _connectionString = string.Concat("Data Source=(LocalDB)\\v11.0; AttachDbFilename=", path,
                "\\GICTAPPDATA.mdf; Integrated Security=True");  
        }

        /// <summary>
        ///     Validate click
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private bool CanExecuteSwapCard(object obj)
        {
            if (!(obj is ImageModel)) return false;
            if (_isStarted) return true;
            return ((ImageModel) obj).IsCoverVisible && !_matchedCards.Contains(((ImageModel) obj).Id);
        }

        private void ExecuteSwapCard(object o)
        {
            if (!(o is ImageModel)) return;
            var image = _viewModel.Images.FirstOrDefault(x => x.Id == ((ImageModel) o).Id);
            if (image == null) return;
            _isStarted = false;
            //TODO записать вбазу данных game_ig, game_object(images)
            switch (_cardsOpened)
            {
                // 2 cards opened but not mathed - close previous 2
                case StateEnum.TwoOpened:
                    // close all not-matched cards
                    _viewModel.Images
                        .Where(x => x.IsCoverVisible == false && !_matchedCards.Contains(x.Id))
                        .ToList()
                        .ForEach(x => x.IsCoverVisible = true);
                    
                    _cardsOpened = StateEnum.AllClosed;
                    break;
                // no cards opened - open this one
                case StateEnum.AllClosed:
                    // open selected card
                    image.IsCoverVisible = false;
                    _cardsOpened = StateEnum.OneOpened;
                    break;
                // 1 card opened - compare current card
                case StateEnum.OneOpened:
                    // get card to compare with
                    var compare = _viewModel.Images.FirstOrDefault(x => x.IsCoverVisible == false && !_matchedCards.Contains(x.Id));
                    // open selected card
                    image.IsCoverVisible = false;
                    // perform matching logic
                    if (compare != null)
                    {
                        if (image.ImageSource == compare.ImageSource)
                        {
                            _matchedCards.Add(image.Id);
                            _matchedCards.Add(compare.Id);
                            _cardsOpened = StateEnum.AllClosed;
                            if (isEndGame())
                            {
                                EndGame();
                            }
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
            //записать ход в базу данных: gameEvent++, записать images

        }

        private void EndGame()
        {
            System.Windows.MessageBox.Show("Endgame");
        }

        private bool isEndGame()
        {
            return _matchedCards.Count == _viewModel.NumberOfCards;
        }

        public void DataBaseRecordGameObject()
        {

        }
        
        public void DataBaseRecordCurrentGame()
        {
            string id = DateTime.Today.Ticks.ToString();
            
            using (var db = new DataBaseCommunication(_connectionString))
            {
                db.Execute(id); // МЕТОД ВОЗВРАЩАЕТ INT ЗАЧЕМ НАМ ЭТО НАДО БЫЛО??
            }
        }
        
        public void DataBaseRecordPlayer(PlayerModel player)
        {
            using (var db = new DataBaseCommunication(_connectionString))
            {
                db.ExecutePlayer(player.Name);
            }
        }

        /// <summary>
        ///     Populate gameboard with cards
        /// </summary>
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

        public void StartGame()
        {
            //var player = new PlayerModel();
            DataBaseRecordCurrentGame();
            

            _viewModel.Players.Clear();
            foreach (var item in _viewModel.PlayerSelector)
            {
                 _viewModel.Players.Add(new PlayerModel { Name = item.Name });   
            }

            //добавление игроков в базу данных но не происходит сровнение на уже существующих в базе((
            foreach (var item in _viewModel.Players)
            {
                if ((!_viewModel.RecordedPlayers.Contains(item)) || (!_viewModel.Players.Contains(item)))
                    DataBaseRecordPlayer(item);
            }
            FillGameBoard();
        }


        public void PrepareGame()
        {
            DataBaseGetRecordedPlayers();
        }

        private void DataBaseGetRecordedPlayers()
        {
             using (var db = new DataBaseCommunication(_connectionString))
            {
                 var name = db.GetPlayer();
                 _viewModel.RecordedPlayers = _viewModel.SetRecordedPlayers(name);
            }

        }
    }
}