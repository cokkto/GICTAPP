using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace GICTAPP
{
    public class Game
    {
        private readonly string _connectionString;
        private readonly Random _rnd = new Random();
        private readonly MyViewModel _viewModel;

        public Game(int players, int boards)
        {
        }

        public Game(MyViewModel viewModel)
        {
            _viewModel = viewModel;

            _viewModel.CommandSwapCard = new RelayCommand(c => true, ExecuteSwapCard);


            var path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            _connectionString = string.Concat("Data Source=(LocalDB)\\v11.0; AttachDbFilename=", path,
                "\\GICTAPPDATA.mdf; Integrated Security=True");
        }

        private void ExecuteSwapCard(object o)
        {
            var t = o;
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