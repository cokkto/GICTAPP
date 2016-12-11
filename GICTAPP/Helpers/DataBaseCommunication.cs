using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Media.Imaging;

namespace GICTAPP
{
    public class DataBaseCommunication : IDisposable
    {
        private readonly SqlConnection _connection;

        public DataBaseCommunication(string path)
        {
            _connection = new SqlConnection(path);
        }


        public void Dispose()
        {
            if (_connection != null)
            {
                Connection_Close();
            }
        }

        public BitmapImage Get_Images(int num)
        {
            var query = "select content from GameObject where object_id=" + num;
            var createCommand = new SqlCommand(query, _connection);
            createCommand.ExecuteNonQuery();
            var myAdapter1 = new SqlDataAdapter(createCommand);
            var dt = new DataTable();
            myAdapter1.Fill(dt);

            foreach (DataRow row in dt.Rows)
            {
                // Get the byte array from image file
                var imgBytes = (byte[]) row["content"];
                var stream = new MemoryStream();
                stream.Write(imgBytes, 0, imgBytes.Length);
                stream.Position = 0;

                var img = Image.FromStream(stream);
                var bi = new BitmapImage();
                bi.BeginInit();

                var ms = new MemoryStream();
                img.Save(ms, ImageFormat.Bmp);
                ms.Seek(0, SeekOrigin.Begin);
                bi.StreamSource = ms;
                bi.EndInit();
                return bi;
                //image1.Source = bi;
            }
            return null;
        }

        public List<BitmapImage> Get_Images()
        {
            var query = "select content from GameObject";
            var createCommand = new SqlCommand(query, _connection);
            createCommand.ExecuteNonQuery();
            var myAdapter1 = new SqlDataAdapter(createCommand);
            var dt = new DataTable();
            myAdapter1.Fill(dt);

            var images = new List<BitmapImage>();

            foreach (DataRow row in dt.Rows)
            {
                // Get the byte array from image file
                var imgBytes = (byte[])row["content"];
                var stream = new MemoryStream();
                stream.Write(imgBytes, 0, imgBytes.Length);
                stream.Position = 0;

                var img = Image.FromStream(stream);
                var bi = new BitmapImage();
                bi.BeginInit();

                var ms = new MemoryStream();
                img.Save(ms, ImageFormat.Bmp);
                ms.Seek(0, SeekOrigin.Begin);
                bi.StreamSource = ms;
                bi.EndInit();
                images.Add(bi);
                //image1.Source = bi;
            }
            return images;
        }

        public void Connection_Open()
        {
            if (_connection.State != ConnectionState.Open)
                try
                {
                    _connection.Open();
                }
                catch (Exception e)
                {
                    var t = e;
                }
        }

        public void Connection_Close()
        {
            _connection.Close();
        }

        public int Execute(string id)
        {
            using (SqlCommand cmd = _connection.CreateCommand())
            {
                // Добавить параметры
                cmd.Parameters.AddWithValue("@object_id", 10);
                cmd.Parameters.AddWithValue("@game_id", id);
                cmd.CommandText = "INSERT INTO CurrentGame(object_id,game_id)VALUES (@object_id, @game_id);";
                //данные добавляются в базу, которая находится в папке Debag. И считываются из нее же.
                Connection_Open();
                cmd.ExecuteNonQuery();

                var sql = "SELECT MAX(id) FROM CurrentGame;";
                var command = new SqlCommand(sql, _connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine(String.Format("{0}", reader[0]));
                }
                

                Connection_Close();
            }

            return Convert.ToInt32(0);
        }

        public List<PlayerModel> GetPlayer()
        {
            var sql = "Select name From Player";
            var cmd = new SqlCommand(sql, _connection);
            Connection_Open();
            SqlDataReader dataReader = cmd.ExecuteReader();

            List<PlayerModel> name = new List<PlayerModel>();
            while (dataReader.Read())
            {
                name.Add(new PlayerModel { Name = dataReader.GetString(0).ToString() });
            }
            dataReader.Close();

            Connection_Close();

            return name;
        }
    }
}