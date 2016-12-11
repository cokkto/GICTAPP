using LiteDB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace GICTAPP
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string[] Phones { get; set; }
        public bool IsActive { get; set; }
    }



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


            // Open database (or create if not exits)
            var path_ = Directory.GetCurrentDirectory() + "/Data/";
            bool exists = Directory.Exists(path_);
            if (!exists) { Directory.CreateDirectory(path_); }
            using (var db = new LiteDatabase(path_ + "MyData.db"))
            {
                // Get customer collection
                var customers = db.GetCollection<Customer>("customers");

                // Create your new customer instance
                var customer = new Customer
                {
                    Name = "John Doe2",
                    Phones = new string[] { "8000-0000", "9000-0000" },
                    IsActive = true
                };

                // Insert new customer document (Id will be auto-incremented)
                customers.Insert(customer);

                // Update a document inside a collection
                customer.Name = "Joana Doe";

                customers.Update(customer);

                // Index document using a document property
                customers.EnsureIndex(x => x.Name);

                // Use Linq to query documents
                var results = customers.Find(x => x.Name.StartsWith("Jo"));
            }
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
            return ((ImageModel)obj).IsCoverVisible && !_matchedCards.Contains(((ImageModel)obj).Id);
        }

        private void ExecuteSwapCard(object o)
        {
            if (!(o is ImageModel)) return;
            var image = _viewModel.Images.FirstOrDefault(x => x.Id == ((ImageModel)o).Id);
            if (image == null) return;
            _isStarted = false;
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

        /// <summary>
        ///     Populate gameboard with cards
        /// </summary>
        public void FillGameBoard()
        {
            var halfCards = _viewModel.NumberOfCards / 2;
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
                _viewModel.Images.Add(new ImageModel { ImageSource = image });
            }
        }
    }
}