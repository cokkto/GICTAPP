using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Media.Imaging;

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
            var path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            _connectionString = string.Concat("Data Source=(LocalDB)\\v11.0; AttachDbFilename=", path,
                "\\GICTAPPDATA.mdf; Integrated Security=True");
        }

        public void FillGameBoard()
        {
            //rndForDB = Random(numOfGO / 2);
            //places = Random(numOfGO);

            List<BitmapImage> images;
            using (var myDb = new DataBaseCommunication(_connectionString))
            {
                myDb.Connection_Open();

                //for (int i = 0; i < rndForDB.Length; i++)
                //{
                //	myImages[places[i]].Source = myDb.Get_Images(rndForDB[i]);
                //}

                //for (int i = 0; i < rndForDB.Length; i++)
                //{
                //	myImages[places[i + numOfGO / 2]].Source = myDb.Get_Images(rndForDB[i]);
                //}

                //myImages[0].Source = myDB.Get_Images(15);

                images = myDb.Get_Images();

                myDb.Connection_Close();
            }
            foreach (var image in images)
            {
                _viewModel.Images.Add(new ImageModel {BitmapImage = image});
            }
        }


        public int[] Random(int size)
        {
            var array = new int[size];
            int k = 0, x;
            for (var i = 0; k < size; i++)
            {
                x = _rnd.Next(size);
                if (k == 0) //добавление 1-го элемента массива
                {
                    array[k] = x;
                    k = k + 1;
                }
                else //добавление остальных элементов массива
                {
                    var m = 0;
                    for (var j = 0; j < k; j++) // проверка совпадений
                    {
                        if (array[j] == x) m = m + 1; // счетчик совпадений
                    }
                    if (m == 0) // добавление нового элемента при отсутствии совпадений
                    {
                        array[k] = x;
                        k = k + 1;
                    }
                }
            }
            return array;
        }
    }
}