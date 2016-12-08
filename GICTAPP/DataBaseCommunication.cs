using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace GICTAPP
{
    public class DataBaseCommunication : IDisposable
    {
        SqlConnection connection;

        public DataBaseCommunication(string path)
        {
            connection = new SqlConnection(path);
        }

        public BitmapImage Get_Images(int num)
        {

            string Query = "select content from GameObject where object_id="+num;
            SqlCommand createCommand = new SqlCommand(Query, connection);
            createCommand.ExecuteNonQuery();
            SqlDataAdapter myAdapter1 = new SqlDataAdapter(createCommand);
            DataTable dt = new DataTable();
            myAdapter1.Fill(dt);

            foreach (DataRow row in dt.Rows)
            {
                // Get the byte array from image file
                byte[] imgBytes = (byte[])row["content"];
                MemoryStream stream = new MemoryStream();
                stream.Write(imgBytes, 0, imgBytes.Length);
                stream.Position = 0;

                System.Drawing.Image img = System.Drawing.Image.FromStream(stream);
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();

                MemoryStream ms = new MemoryStream();
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                ms.Seek(0, SeekOrigin.Begin);
                bi.StreamSource = ms;
                bi.EndInit();
                return bi;
                //image1.Source = bi;
            }
            return null;
        }

        public void Connection_Open()
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();
        }

        public void Connection_Close()
        {
            connection.Close();
        }


    
public void Dispose()
{
    if(connection !=null)
 	{Connection_Close();}
}
}
}
