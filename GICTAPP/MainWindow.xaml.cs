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
            //Start();
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            _dataContext = new MyViewModel();
            DataContext = _dataContext;
            //_dataContext.MyCommand = new RelayCommand(p => true, ImageClick);

            ViewStart.Visibility = Visibility.Visible;
            ViewGame.Visibility = Visibility.Collapsed;

            _dataContext.PlayersOptions.AddRange(new List<int> {1, 2, 3, 4, 5});
            _dataContext.NumberOfPlayers = _dataContext.PlayersOptions.FirstOrDefault();
            _dataContext.CardsOptions.AddRange(new List<int> {20, 24, 30});
            _dataContext.NumberOfCards = _dataContext.CardsOptions.FirstOrDefault();

            _myGame = new Game(_dataContext);

            _dataContext.CommandStart = new RelayCommand(c => true, StartGame);

        }

        private void StartGame(object obj)
        {
            ViewStart.Visibility = Visibility.Collapsed;
            ViewGame.Visibility = Visibility.Visible;

            _myGame.FillGameBoard();
        }

        private void ImageClick(object obj)
        {
            var index = Convert.ToInt32(obj);
            var item = _myImages.ElementAtOrDefault(index);
            if (item == null)
            {
            }
        }

        //    NumPlayers.Items.Add("4");
        //    NumPlayers.Items.Add("3");
        //    NumPlayers.Items.Add("2");
        //    NumPlayers.Items.Add("1");
        //    Form1.Visibility = Visibility.Hidden;
        //{

        //private void Start()
        //    NumPlayers.Items.Add("5");

        //    BoardSize.Items.Add("20");
        //    BoardSize.Items.Add("24");
        //    BoardSize.Items.Add("30");
        //}

        //private void Button_Start_Click(object sender, RoutedEventArgs e)
        //{
        //    var boardSize = Convert.ToInt32(BoardSize.SelectedItem);
        //    var selectedItem = Convert.ToInt32(NumPlayers.SelectedItem);

        //    _myGame = new Game(selectedItem, boardSize);
        //    SecondWindow(boardSize, selectedItem);
        //    GameBoard(boardSize);

        //    Step3();
        //}

        //private void NumPlayers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //}

        //private void BoardSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //}

        //private void SecondWindow(int size, int players)
        //{
        //    Form1.Visibility = Visibility.Visible;
        //    NumPlayers.IsEnabled = true;
        //    BoardSize.IsEnabled = true;
        //    Button_Start.IsEnabled = true;
        //    switch (players)
        //    {
        //        case 1:
        //            lb_player2.Visibility = Visibility.Hidden;
        //            lb_score_pl2.Visibility = Visibility.Hidden;
        //            lb_player3.Visibility = Visibility.Hidden;
        //            lb_score_pl3.Visibility = Visibility.Hidden;
        //            lb_player4.Visibility = Visibility.Hidden;
        //            lb_score_pl4.Visibility = Visibility.Hidden;
        //            lb_player5.Visibility = Visibility.Hidden;
        //            lb_score_pl5.Visibility = Visibility.Hidden;
        //            break;
        //        case 2:
        //            lb_player3.Visibility = Visibility.Hidden;
        //            lb_score_pl3.Visibility = Visibility.Hidden;
        //            lb_player4.Visibility = Visibility.Hidden;
        //            lb_score_pl4.Visibility = Visibility.Hidden;
        //            lb_player5.Visibility = Visibility.Hidden;
        //            lb_score_pl5.Visibility = Visibility.Hidden;
        //            break;
        //        case 3:
        //            lb_player4.Visibility = Visibility.Hidden;
        //            lb_score_pl4.Visibility = Visibility.Hidden;
        //            lb_player5.Visibility = Visibility.Hidden;
        //            lb_score_pl5.Visibility = Visibility.Hidden;
        //            break;
        //        case 4:
        //            lb_player5.Visibility = Visibility.Hidden;
        //            lb_score_pl5.Visibility = Visibility.Hidden;
        //            break;
        //        default:
        //            break;
        //    }
        //}

        //private void GameBoard(int size)
        //{
        //    switch (size)
        //    {
        //        case 20:
        //            _myImages.AddRange(new List<Image>
        //            {
        //                image1,
        //                image2,
        //                image3,
        //                image4,
        //                image5,
        //                image6,
        //                image7,
        //                image8,
        //                image9,
        //                image10,
        //                image11,
        //                image12,
        //                image13,
        //                image14,
        //                image15,
        //                image16,
        //                image17,
        //                image18,
        //                image19,
        //                image20
        //            });
        //            btn_img21.Visibility = Visibility.Hidden;

        //            btn_img22.Visibility = Visibility.Hidden;
        //            btn_img23.Visibility = Visibility.Hidden;
        //            btn_img24.Visibility = Visibility.Hidden;
        //            btn_img25.Visibility = Visibility.Hidden;
        //            btn_img26.Visibility = Visibility.Hidden;
        //            btn_img27.Visibility = Visibility.Hidden;
        //            btn_img28.Visibility = Visibility.Hidden;
        //            btn_img29.Visibility = Visibility.Hidden;
        //            btn_img30.Visibility = Visibility.Hidden;
        //            break;
        //        case 24:
        //            _myImages.AddRange(new List<Image>
        //            {
        //                image1,
        //                image2,
        //                image3,
        //                image4,
        //                image6,
        //                image7,
        //                image8,
        //                image9,
        //                image11,
        //                image12,
        //                image13,
        //                image14,
        //                image16,
        //                image17,
        //                image18,
        //                image19,
        //                image21,
        //                image22,
        //                image23,
        //                image24,
        //                image26,
        //                image27,
        //                image28,
        //                image29
        //            });
        //            btn_img5.Visibility = Visibility.Hidden;
        //            btn_img10.Visibility = Visibility.Hidden;
        //            btn_img15.Visibility = Visibility.Hidden;
        //            btn_img20.Visibility = Visibility.Hidden;
        //            btn_img25.Visibility = Visibility.Hidden;
        //            btn_img30.Visibility = Visibility.Hidden;
        //            break;
        //        default:
        //            _myImages.AddRange(new List<Image>
        //            {
        //                image1,
        //                image2,
        //                image3,
        //                image4,
        //                image5,
        //                image6,
        //                image7,
        //                image8,
        //                image9,
        //                image10,
        //                image11,
        //                image12,
        //                image13,
        //                image14,
        //                image15,
        //                image16,
        //                image17,
        //                image18,
        //                image19,
        //                image20,
        //                image21,
        //                image22,
        //                image23,
        //                image24,
        //                image25,
        //                image26,
        //                image27,
        //                image28,
        //                image29,
        //                image30
        //            });
        //            break;
        //    }
        //}

        //public void Step3()
        //{
        //    _myGame.FillGameBoard(_myImages);
        //}
    }
}