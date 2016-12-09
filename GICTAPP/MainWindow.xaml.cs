using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

//using System.Data.OleDb;
//using System.Drawing;

namespace GICTAPP
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly List<Image> _myImages = new List<Image>();
        private MyViewModel _dataContext;
        private Game _myGame;

        public MainWindow()
        {
            InitializeComponent();
            Loaded += OnLoaded;
        }

        /// <summary>
        ///     Initial game UI setup
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            // assign datacontext
            _dataContext = new MyViewModel();
            DataContext = _dataContext;

            // set visibility of views
            ViewStart.Visibility = Visibility.Visible;
            ViewGame.Visibility = Visibility.Collapsed;

            // populate selectors
            _dataContext.PlayersOptions.Add(1);
            _dataContext.PlayersOptions.Add(2);
            _dataContext.PlayersOptions.Add(3);
            _dataContext.PlayersOptions.Add(4);
            _dataContext.PlayersOptions.Add(5);
            _dataContext.NumberOfPlayers = _dataContext.PlayersOptions.FirstOrDefault();
            _dataContext.CardsOptions.Add(20);
            _dataContext.CardsOptions.Add(24);
            _dataContext.CardsOptions.Add(30);
            _dataContext.NumberOfCards = _dataContext.CardsOptions.FirstOrDefault();

            // attach game logic
            _myGame = new Game(_dataContext);

            // assign start button
            _dataContext.CommandStart = new RelayCommand(c => true, StartGame);

        }

        /// <summary>
        ///     Start game sequence
        /// </summary>
        /// <param name="obj"></param>
        private void StartGame(object obj)
        {
            ViewStart.Visibility = Visibility.Collapsed;
            ViewGame.Visibility = Visibility.Visible;
            _myGame.StartGame();
            
        }
    }
}