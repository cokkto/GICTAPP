using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
//using System.Data.OleDb;
using System.IO;
using System.Data.SqlClient;
using System.Data;
//using System.Drawing;
using System.Drawing.Imaging;
using System.ComponentModel;
using System.Windows.Controls;



namespace GICTAPP
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private List<Image> _myImages = new List<Image>();
        private Game myGame;
        private MyViewModel _dataContext;
        public MainWindow()
        {
            InitializeComponent();
            _dataContext = new MyViewModel();
            DataContext = _dataContext;
            _dataContext.MyCommand = new RelayCommand(p => true, p => ImageClick(p));
            Start();
        }
        private void ImageClick(object obj)
        {
            var index = Convert.ToInt32(obj);
            if (_myImages.)
            {
                
            }
        }
        private void Start()
        {
            Form1.Visibility = Visibility.Hidden;
            NumPlayers.Items.Add("1");
            NumPlayers.Items.Add("2");
            NumPlayers.Items.Add("3");
            NumPlayers.Items.Add("4");
            NumPlayers.Items.Add("5");

            this.BoardSize.Items.Add("20");
            this.BoardSize.Items.Add("24");
            this.BoardSize.Items.Add("30");
        }

        private void Button_Start_Click(object sender, RoutedEventArgs e)
        {
			var boardSize = Convert.ToInt32(BoardSize.SelectedItem);
			var selectedItem = Convert.ToInt32(NumPlayers.SelectedItem);
			
            myGame = new Game(selectedItem, boardSize);
            SecondWindow(boardSize, selectedItem);
            GameBoard(boardSize);
            
            Step3();
        }

        private void NumPlayers_SelectionChanged(object sender, SelectionChangedEventArgs e) { }
        private void BoardSize_SelectionChanged(object sender, SelectionChangedEventArgs e) { }

        private void SecondWindow(int size, int players)
        {
            Form1.Visibility = Visibility.Visible;
            this.NumPlayers.IsEnabled = true;
            BoardSize.IsEnabled = true;
            Button_Start.IsEnabled = true;
            switch (players)
            {
                case (1):
                    lb_player2.Visibility = Visibility.Hidden;
                    lb_score_pl2.Visibility = Visibility.Hidden;
                    lb_player3.Visibility = Visibility.Hidden;
                    lb_score_pl3.Visibility = Visibility.Hidden;
                    lb_player4.Visibility = Visibility.Hidden;
                    lb_score_pl4.Visibility = Visibility.Hidden;
                    lb_player5.Visibility = Visibility.Hidden;
                    lb_score_pl5.Visibility = Visibility.Hidden;
                    break;
                case (2):
                    lb_player3.Visibility = Visibility.Hidden;
                    lb_score_pl3.Visibility = Visibility.Hidden;
                    lb_player4.Visibility = Visibility.Hidden;
                    lb_score_pl4.Visibility = Visibility.Hidden;
                    lb_player5.Visibility = Visibility.Hidden;
                    lb_score_pl5.Visibility = Visibility.Hidden;
                    break;
                case (3):
                    lb_player4.Visibility = Visibility.Hidden;
                    lb_score_pl4.Visibility = Visibility.Hidden;
                    lb_player5.Visibility = Visibility.Hidden;
                    lb_score_pl5.Visibility = Visibility.Hidden;
                    break;
                case (4):
                    lb_player5.Visibility = Visibility.Hidden;
                    lb_score_pl5.Visibility = Visibility.Hidden;
                    break;
                default:
                    break;

            }


        }

        private void GameBoard(int size)
        {
            
            switch (size)
            {
                case 20:
                    _myImages.AddRange(new List<Image> { image1, image2, image3, image4, image5, image6, image7, image8, image9, image10, image11, image12, image13, image14, image15, image16, image17, image18, image19, image20 });
                    btn_img21.Visibility = Visibility.Hidden;
                    
                    btn_img22.Visibility = Visibility.Hidden;
                    btn_img23.Visibility = Visibility.Hidden;
                    btn_img24.Visibility = Visibility.Hidden;
                    btn_img25.Visibility = Visibility.Hidden;
                    btn_img26.Visibility = Visibility.Hidden;
                    btn_img27.Visibility = Visibility.Hidden;
                    btn_img28.Visibility = Visibility.Hidden;
                    btn_img29.Visibility = Visibility.Hidden;
                    btn_img30.Visibility = Visibility.Hidden;
                    break;
                case 24:
                    _myImages.AddRange(new List<Image> { image1, image2, image3, image4, image6, image7, image8, image9, image11, image12, image13, image14, image16, image17, image18, image19, image21, image22, image23, image24, image26, image27, image28, image29 });
                    btn_img5.Visibility = Visibility.Hidden;
                    btn_img10.Visibility = Visibility.Hidden;
                    btn_img15.Visibility = Visibility.Hidden;
                    btn_img20.Visibility = Visibility.Hidden;
                    btn_img25.Visibility = Visibility.Hidden;
                    btn_img30.Visibility = Visibility.Hidden;
                    break;
                default:
                    _myImages.AddRange(new List<Image>  { image1, image2, image3, image4, image5, image6, image7, image8, image9, image10, image11, image12, image13, image14, image15, image16, image17, image18, image19, image20, image21, image22, image23, image24, image25, image26, image27, image28, image29, image30 });
                    break;
            }
        }

        public void Step3()
        {
            myGame.FillGameBoard(_myImages);

        }

        

    }

}
