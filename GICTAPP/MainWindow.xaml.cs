using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
//using System.Data.OleDb;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.ComponentModel;




namespace GICTAPP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private System.Windows.Controls.Image[] myImages;
        private Game myGame;
        public MainWindow()
        {
            InitializeComponent();
            Start();
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
                    myImages = new System.Windows.Controls.Image[20] { image1, image2, image3, image4, image5, image6, image7, image8, image9, image10, image11, image12, image13, image14, image15, image16, image17, image18, image19, image20 };
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
                    myImages = new System.Windows.Controls.Image[24] { image1, image2, image3, image4, image6, image7, image8, image9, image11, image12, image13, image14, image16, image17, image18, image19, image21, image22, image23, image24, image26, image27, image28, image29 };
                    btn_img5.Visibility = Visibility.Hidden;
                    btn_img10.Visibility = Visibility.Hidden;
                    btn_img15.Visibility = Visibility.Hidden;
                    btn_img20.Visibility = Visibility.Hidden;
                    btn_img25.Visibility = Visibility.Hidden;
                    btn_img30.Visibility = Visibility.Hidden;
                    break;
                default:
                    myImages = new System.Windows.Controls.Image[30] { image1, image2, image3, image4, image5, image6, image7, image8, image9, image10, image11, image12, image13, image14, image15, image16, image17, image18, image19, image20, image21, image22, image23, image24, image25, image26, image27, image28, image29, image30 };
                    break;
            }
        }

        public void Step3()
        {
            myGame.FillGameBoard(myImages);

        }







        //private void Image1Button_Click(object sender, RoutedEventArgs e)
        //{
        //    image1.Visibility = Visibility.Hidden;
        //}
        private void Image2Button_Click(object sender, RoutedEventArgs e)
        {
            image2.Visibility = Visibility.Hidden;
        }
        private void Image3Button_Click(object sender, RoutedEventArgs e)
        {
            image3.Visibility = Visibility.Hidden;
        }
        private void Image4Button_Click(object sender, RoutedEventArgs e)
        {
            image4.Visibility = Visibility.Hidden;
        }
        private void Image5Button_Click(object sender, RoutedEventArgs e)
        {
            image5.Visibility = Visibility.Hidden;
        }
        private void Image6Button_Click(object sender, RoutedEventArgs e)
        {
            image6.Visibility = Visibility.Hidden;
        }
        private void Image7Button_Click(object sender, RoutedEventArgs e)
        {
            image7.Visibility = Visibility.Hidden;
        }
        private void Image8Button_Click(object sender, RoutedEventArgs e)
        {
            image8.Visibility = Visibility.Hidden;
        }
        private void Image9Button_Click(object sender, RoutedEventArgs e)
        {
            image9.Visibility = Visibility.Hidden;
        }
        private void Image10Button_Click(object sender, RoutedEventArgs e)
        {
            image10.Visibility = Visibility.Hidden;
        }


        private void Image11Button_Click(object sender, RoutedEventArgs e)
        {
            image11.Visibility = Visibility.Hidden;
        }
        private void Image12Button_Click(object sender, RoutedEventArgs e)
        {
            image12.Visibility = Visibility.Hidden;
        }
        private void Image13Button_Click(object sender, RoutedEventArgs e)
        {
            image13.Visibility = Visibility.Hidden;
        }
        private void Image14Button_Click(object sender, RoutedEventArgs e)
        {
            image14.Visibility = Visibility.Hidden;
        }
        private void Image15Button_Click(object sender, RoutedEventArgs e)
        {
            image15.Visibility = Visibility.Hidden;
        }
        private void Image16Button_Click(object sender, RoutedEventArgs e)
        {
            image16.Visibility = Visibility.Hidden;
        }
        private void Image17Button_Click(object sender, RoutedEventArgs e)
        {
            image17.Visibility = Visibility.Hidden;
        }
        private void Image18Button_Click(object sender, RoutedEventArgs e)
        {
            image18.Visibility = Visibility.Hidden;
        }
        private void Image19Button_Click(object sender, RoutedEventArgs e)
        {
            image19.Visibility = Visibility.Hidden;
        }
        private void Image20Button_Click(object sender, RoutedEventArgs e)
        {
            image20.Visibility = Visibility.Hidden;
        }


        private void Image21Button_Click(object sender, RoutedEventArgs e)
        {
            image21.Visibility = Visibility.Hidden;
        }
        private void Image22Button_Click(object sender, RoutedEventArgs e)
        {
            image22.Visibility = Visibility.Hidden;
        }
        private void Image23Button_Click(object sender, RoutedEventArgs e)
        {
            image23.Visibility = Visibility.Hidden;
        }
        private void Image24Button_Click(object sender, RoutedEventArgs e)
        {
            image24.Visibility = Visibility.Hidden;
        }
        private void Image25Button_Click(object sender, RoutedEventArgs e)
        {
            image25.Visibility = Visibility.Hidden;
        }
        private void Image26Button_Click(object sender, RoutedEventArgs e)
        {
            image26.Visibility = Visibility.Hidden;
        }
        private void Image27Button_Click(object sender, RoutedEventArgs e)
        {
            image27.Visibility = Visibility.Hidden;
        }
        private void Image28Button_Click(object sender, RoutedEventArgs e)
        {
            image28.Visibility = Visibility.Hidden;
        }
        private void Image29Button_Click(object sender, RoutedEventArgs e)
        {
            image29.Visibility = Visibility.Hidden;
        }
        private void Image30Button_Click(object sender, RoutedEventArgs e)
        {
            image30.Visibility = Visibility.Hidden;
        }

    }

}
