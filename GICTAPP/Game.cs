using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GICTAPP
{
    public class Game
    {
        //private Players[] player;

		private Random _rnd = new Random();
		private string _connectionString;
        private int numOfGO;
        private int[] rndForDB;
        private int[] places;

        public Game(int players, int boards)
        {
            //player = new Players[players];
            numOfGO = boards;
            var path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            _connectionString = string.Concat("Data Source=(LocalDB)\\v11.0; AttachDbFilename=", path, "\\GICTAPPDATA.mdf; Integrated Security=True");
        }

        public void FillGameBoard(List<Image> myImages)
        {
            rndForDB = Random(numOfGO / 2);
            places = Random(numOfGO);
			using(var myDb = new DataBaseCommunication(_connectionString))
			{
				myDb.Connection_Open();

				for (int i = 0; i < rndForDB.Length; i++)
				{
					myImages[places[i]].Source = myDb.Get_Images(rndForDB[i]);
				}

				for (int i = 0; i < rndForDB.Length; i++)
				{
					myImages[places[i + numOfGO / 2]].Source = myDb.Get_Images(rndForDB[i]);
				}

				//myImages[0].Source = myDB.Get_Images(15);

				myDb.Connection_Close();
			}
        }


        public int[] Random(int size)
        {
            int[] array = new int[size];
            int k = 0, x;
            for (int i = 0; k < size; i++)
            {
                x = _rnd.Next(size);
                if (k == 0)  //добавление 1-го элемента массива
                {
                    array[k] = x;
                    k = k + 1;
                }
                else  //добавление остальных элементов массива
                {
                    int m = 0;
                    for (int j = 0; j < k; j++)  // проверка совпадений
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
