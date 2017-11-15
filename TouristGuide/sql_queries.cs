using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TouristGuide
{
    class sql_queries
    {    
        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }//τέλος της ResizeImage


        public static void Executequery(string query, RichTextBox textbox, PictureBox picbox1, PictureBox picbox2)  //σαν παράμετροι είναι το ερώτημα και το textbox που θα εμφανιστούν οι πληροφορίες
        {
            List<storeData> subscriptions = new List<storeData>();
            OleDbConnection connection = new OleDbConnection();
            OleDbCommand command;
            OleDbDataReader dataReader;
            connection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Tourist_Guide.mdb";

            command = new OleDbCommand();
            OleDbCommand commmand1 = new OleDbCommand();
            try
            {
                connection.Open();
                command.CommandText = query;
                command.Connection = connection;
                dataReader = command.ExecuteReader();


                while (dataReader.Read())
                {
                    string Sdetail = dataReader.GetString(1);
                    string Sphoto_path = dataReader.GetString(2);
                    string Sphoto_path1 = dataReader.GetString(3);

                    //---------------1ος τροπος---------
                    //textbox.Text = Sdetail ;
                    //picbox1.Image = Image.FromFile(Sphoto_path);
                    picbox2.Image = Image.FromFile(Sphoto_path1);

                    //---------------2ος τροπος---------
                    Image img = Image.FromFile(Sphoto_path);
                    Clipboard.SetImage(img);
                    textbox.Paste();
                    textbox.AppendText(Sdetail);
                }

            }
            catch (System.Exception exception)
            {
                MessageBox.Show(exception.Message, "Error occurred");

            }
            finally
            {
                command.Dispose();
                connection.Dispose();
            }
        }//τελος 1 ερωτηματος



        public static void Executehistoryquery(string query, RichTextBox textbox, PictureBox picbox1, PictureBox picbox2)  //σαν παράμετροι είναι το ερώτημα και το textbox που θα εμφανιστούν οι πληροφορίες
        {
            List<storeData> subscriptions = new List<storeData>();

            OleDbConnection connection = new OleDbConnection();
            OleDbCommand command;
            OleDbDataReader dataReader;
            connection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Tourist_Guide.mdb";

            command = new OleDbCommand();
            OleDbCommand commmand1 = new OleDbCommand();
            try
            {
                connection.Open();
                command.CommandText = query;
                command.Connection = connection;
                dataReader = command.ExecuteReader();


                while (dataReader.Read())
                {
                    subscriptions.Add(
                        new storeData((int)dataReader["Id"], (string)dataReader["Report"], (string)dataReader["Photo_ID_1"], (string)dataReader["Photo_ID_2"], (string)dataReader["Photo_ID_3"], (string)dataReader["Photo_ID_4"], (string)dataReader["Photo_ID_5"])
                        {

                        });

                }

                foreach (storeData i in subscriptions)
                {
                    if (i.storeId() == 1)
                    {
                        textbox.Text = i.getText();   //τοποθέτησε 1 κείμενο

                        string Sphoto_path = i.getphotoId1();   // πάρε τη φωτογραφία από τη λίστα
                        Image img = Image.FromFile(Sphoto_path); //μετετρεψε την απο string σε img
                        Image img_new = ResizeImage(img, 500, 350);  //αλλαξε το μέγεθος της φωτογραφίας
                        Clipboard.SetImage(img_new);        //βάλτην στο clipboad                
                        textbox.Select(0, 0);   //πήγαινε τον δείκτη στην αρχη του textbox
                        textbox.Paste();    //τοποθετησέ την στην αρχη

                        string Sphoto_path1 = i.getphotoId2();       // τοποθέτησε 2η φωτογραφία κάτω από τα 2 κείμενα                 
                        Image img1 = Image.FromFile(Sphoto_path1);
                        Image img_new1 = ResizeImage(img1, 1000, 500);  //αλλαξε το μέγεθος της φωτογραφίας
                        Clipboard.SetImage(img_new1);
                        textbox.Select(textbox.Text.Length, 0);  //πήγαινε τον δείκτη στο τέλος του textbox
                        textbox.Paste();

                        /*string Sphoto_path2 = i.getphotoId3();
                        Image img2 = Image.FromFile(Sphoto_path2);                        
                        Image img_new2 = ResizeImage(img2, 200, 200);  //αλλαξε το μέγεθος της φωτογραφίας
                        Clipboard.SetImage(img_new2);
                        textbox.Select(textbox.Text.Length -350, 0);  //πήγαινε τον δείκτη στο τέλος του textbox
                        textbox.Paste();*/

                        string Sphoto_path3 = i.getphotoId4();
                        picbox1.Image = Image.FromFile(Sphoto_path3);

                        string Sphoto_path4 = i.getphotoId5();
                        picbox2.Image = Image.FromFile(Sphoto_path4);

                    }


                }//close foreach          
            }
            catch (System.Exception exception)
            {
                MessageBox.Show(exception.Message, "Error occurred");
            }
            finally
            {
                command.Dispose();
                connection.Dispose();
            }
        }//τελος 2 ερωτηματος

        public static void Executemusicquery(string query, RichTextBox textbox, PictureBox picbox1, PictureBox picbox2)  //σαν παράμετροι είναι το ερώτημα και το textbox που θα εμφανιστούν οι πληροφορίες
        {
            List<storeData> subscriptions = new List<storeData>();

            OleDbConnection connection = new OleDbConnection();
            OleDbCommand command;
            OleDbDataReader dataReader;
            connection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Tourist_Guide.mdb";

            command = new OleDbCommand();
            OleDbCommand commmand1 = new OleDbCommand();
            try
            {
                connection.Open();
                command.CommandText = query;
                command.Connection = connection;
                dataReader = command.ExecuteReader();


                while (dataReader.Read())
                {
                    subscriptions.Add(
                        new storeData((int)dataReader["Id"], (string)dataReader["Report"], (string)dataReader["Photo_ID_1"], (string)dataReader["Photo_ID_2"], (string)dataReader["Photo_ID_3"], (string)dataReader["Photo_ID_4"], (string)dataReader["Photo_ID_5"])
                        {

                        });

                }

                foreach (storeData i in subscriptions)
                {
                    if (i.storeId() == 5)
                    {
                        textbox.Text = i.getText();   //τοποθέτησε 1 κείμενο

                        string Sphoto_path = i.getphotoId1();   // πάρε τη φωτογραφία από τη λίστα
                        Image img = Image.FromFile(Sphoto_path); //μετετρεψε την απο string σε img
                        Image img_new = ResizeImage(img, 500, 350);  //αλλαξε το μέγεθος της φωτογραφίας
                        Clipboard.SetImage(img_new);        //βάλτην στο clipboad                
                        textbox.Select(0, 0);   //πήγαινε τον δείκτη στην αρχη του textbox
                        textbox.Paste();    //τοποθετησέ την στην αρχη

                        string Sphoto_path1 = i.getphotoId2();       // τοποθέτησε 2η φωτογραφία κάτω από τα 2 κείμενα                 
                        Image img1 = Image.FromFile(Sphoto_path1);
                        Image img_new1 = ResizeImage(img1, 1000, 500);  //αλλαξε το μέγεθος της φωτογραφίας
                        Clipboard.SetImage(img_new1);
                        textbox.Select(textbox.Text.Length, 0);  //πήγαινε τον δείκτη στο τέλος του textbox
                        textbox.Paste();

                        string Sphoto_path3 = i.getphotoId4();
                        picbox1.Image = Image.FromFile(Sphoto_path3);

                        string Sphoto_path4 = i.getphotoId5();
                        picbox2.Image = Image.FromFile(Sphoto_path4);

                    }


                }//close foreach          
            }
            catch (System.Exception exception)
            {
                MessageBox.Show(exception.Message, "Error occurred");
            }
            finally
            {
                command.Dispose();
                connection.Dispose();
            }
        }//τελος 3 ερωτηματος

        public static void ExecuteArhitectquery(string query, RichTextBox textbox, PictureBox picbox1, PictureBox picbox2)  //σαν παράμετροι είναι το ερώτημα και το textbox που θα εμφανιστούν οι πληροφορίες
        {
            List<storeData> subscriptions = new List<storeData>();

            OleDbConnection connection = new OleDbConnection();
            OleDbCommand command;
            OleDbDataReader dataReader;
            connection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Tourist_Guide.mdb";

            command = new OleDbCommand();
            OleDbCommand commmand1 = new OleDbCommand();
            try
            {
                connection.Open();
                command.CommandText = query;
                command.Connection = connection;
                dataReader = command.ExecuteReader();


                while (dataReader.Read())
                {
                    subscriptions.Add(
                        new storeData((int)dataReader["Id"], (string)dataReader["Report"], (string)dataReader["Photo_ID_1"], (string)dataReader["Photo_ID_2"], (string)dataReader["Photo_ID_3"], (string)dataReader["Photo_ID_4"], (string)dataReader["Photo_ID_5"])
                        {

                        });
                }

                foreach (storeData i in subscriptions)
                {
                    if (i.storeId() == 6)
                    {
                        textbox.Text = i.getText();   //τοποθέτησε 1 κείμενο

                        string Sphoto_path = i.getphotoId1();   // πάρε τη φωτογραφία από τη λίστα
                        Image img = Image.FromFile(Sphoto_path); //μετετρεψε την απο string σε img
                        Image img_new = ResizeImage(img, 500, 350);  //αλλαξε το μέγεθος της φωτογραφίας
                        Clipboard.SetImage(img_new);        //βάλτην στο clipboad                
                        textbox.Select(0, 0);   //πήγαινε τον δείκτη στην αρχη του textbox
                        textbox.Paste();    //τοποθετησέ την στην αρχη

                        string Sphoto_path1 = i.getphotoId2();       // τοποθέτησε 2η φωτογραφία κάτω από τα 2 κείμενα                 
                        Image img1 = Image.FromFile(Sphoto_path1);
                        Image img_new1 = ResizeImage(img1, 1000, 500);  //αλλαξε το μέγεθος της φωτογραφίας
                        Clipboard.SetImage(img_new1);
                        textbox.Select(textbox.Text.Length, 0);  //πήγαινε τον δείκτη στο τέλος του textbox
                        textbox.Paste();                        

                        string Sphoto_path3 = i.getphotoId4();
                        picbox1.Image = Image.FromFile(Sphoto_path3);

                        string Sphoto_path4 = i.getphotoId5();
                        picbox2.Image = Image.FromFile(Sphoto_path4);

                    }
                }//close foreach          
            }
            catch (System.Exception exception)
            {
                MessageBox.Show(exception.Message, "Error occurred");
            }
            finally
            {
                command.Dispose();
                connection.Dispose();
            }
        }//τελος 4 ερωτηματος

        public static void ExecuteTownsquery(string query, RichTextBox textbox, PictureBox picbox1, PictureBox picbox2)  //σαν παράμετροι είναι το ερώτημα και το textbox που θα εμφανιστούν οι πληροφορίες
        {
            List<storeData> subscriptions = new List<storeData>();

            OleDbConnection connection = new OleDbConnection();
            OleDbCommand command;
            OleDbDataReader dataReader;
            connection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Tourist_Guide.mdb";

            command = new OleDbCommand();
            OleDbCommand commmand1 = new OleDbCommand();
            try
            {
                connection.Open();
                command.CommandText = query;
                command.Connection = connection;
                dataReader = command.ExecuteReader();


                while (dataReader.Read())
                {
                    subscriptions.Add(
                        new storeData((int)dataReader["Id"], (string)dataReader["Report"], (string)dataReader["Photo_ID_1"], (string)dataReader["Photo_ID_2"], (string)dataReader["Photo_ID_3"], (string)dataReader["Photo_ID_4"], (string)dataReader["Photo_ID_5"])
                        {

                        });
                }

                foreach (storeData i in subscriptions)
                {
                    if (i.storeId() == 7)
                    {
                        textbox.Text = i.getText();   //τοποθέτησε 1 κείμενο

                        string Sphoto_path = i.getphotoId1();   // πάρε τη φωτογραφία από τη λίστα
                        Image img = Image.FromFile(Sphoto_path); //μετετρεψε την απο string σε img
                        Image img_new = ResizeImage(img, 500, 350);  //αλλαξε το μέγεθος της φωτογραφίας
                        Clipboard.SetImage(img_new);        //βάλτην στο clipboad                
                        textbox.Select(0, 0);   //πήγαινε τον δείκτη στην αρχη του textbox
                        textbox.Paste();    //τοποθετησέ την στην αρχη

                        string Sphoto_path1 = i.getphotoId2();       // τοποθέτησε 2η φωτογραφία κάτω από τα 2 κείμενα                 
                        Image img1 = Image.FromFile(Sphoto_path1);
                        Image img_new1 = ResizeImage(img1, 1000, 500);  //αλλαξε το μέγεθος της φωτογραφίας
                        Clipboard.SetImage(img_new1);
                        textbox.Select(textbox.Text.Length, 0);  //πήγαινε τον δείκτη στο τέλος του textbox
                        textbox.Paste();                        

                        string Sphoto_path3 = i.getphotoId4();
                        picbox1.Image = Image.FromFile(Sphoto_path3);

                        string Sphoto_path4 = i.getphotoId5();
                        picbox2.Image = Image.FromFile(Sphoto_path4);

                    }
                }//close foreach          
            }
            catch (System.Exception exception)
            {
                MessageBox.Show(exception.Message, "Error occurred");
            }
            finally
            {
                command.Dispose();
                connection.Dispose();
            }
        }//τελος 5 ερωτηματος

        public static void ExecuteArtssquery(string query, RichTextBox textbox, PictureBox picbox1, PictureBox picbox2, PictureBox picbox3)  //σαν παράμετροι είναι το ερώτημα και το textbox που θα εμφανιστούν οι πληροφορίες
        {
            List<storeData> subscriptions = new List<storeData>();

            OleDbConnection connection = new OleDbConnection();
            OleDbCommand command;
            OleDbDataReader dataReader;
            connection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Tourist_Guide.mdb";

            command = new OleDbCommand();
            OleDbCommand commmand1 = new OleDbCommand();
            try
            {
                connection.Open();
                command.CommandText = query;
                command.Connection = connection;
                dataReader = command.ExecuteReader();


                while (dataReader.Read())
                {
                    subscriptions.Add(
                        new storeData((int)dataReader["Id"], (string)dataReader["Report"], (string)dataReader["Photo_ID_1"], (string)dataReader["Photo_ID_2"], (string)dataReader["Photo_ID_3"], (string)dataReader["Photo_ID_4"], (string)dataReader["Photo_ID_5"])
                        {

                        });
                }

                foreach (storeData i in subscriptions)
                {
                    if (i.storeId() == 8)
                    {
                        textbox.Text = i.getText();   //τοποθέτησε 1 κείμενο

                        string Sphoto_path = i.getphotoId1();   // πάρε τη φωτογραφία από τη λίστα
                        Image img = Image.FromFile(Sphoto_path); //μετετρεψε την απο string σε img
                        Image img_new = ResizeImage(img, 500, 350);  //αλλαξε το μέγεθος της φωτογραφίας
                        Clipboard.SetImage(img_new);        //βάλτην στο clipboad                
                        textbox.Select(0, 0);   //πήγαινε τον δείκτη στην αρχη του textbox
                        textbox.Paste();    //τοποθετησέ την στην αρχη

                        string Sphoto_path1 = i.getphotoId2();       // τοποθέτησε 2η φωτογραφία κάτω από τα 2 κείμενα                 
                        Image img1 = Image.FromFile(Sphoto_path1);
                        Image img_new1 = ResizeImage(img1, 1000, 500);  //αλλαξε το μέγεθος της φωτογραφίας
                        Clipboard.SetImage(img_new1);
                        textbox.Select(textbox.Text.Length, 0);  //πήγαινε τον δείκτη στο τέλος του textbox
                        textbox.Paste();

                        string Sphoto_path5 = i.getphotoId3();
                        picbox3.Image = Image.FromFile(Sphoto_path5);

                        string Sphoto_path3 = i.getphotoId4();
                        picbox1.Image = Image.FromFile(Sphoto_path3);

                        string Sphoto_path4 = i.getphotoId5();
                        picbox2.Image = Image.FromFile(Sphoto_path4);

                    }
                }//close foreach          
            }
            catch (System.Exception exception)
            {
                MessageBox.Show(exception.Message, "Error occurred");
            }
            finally
            {
                command.Dispose();
                connection.Dispose();
            }
        }//τελος 6 ερωτηματος

        public static void ExecuteKichenssquery(string query, RichTextBox textbox, PictureBox picbox1, PictureBox picbox2, PictureBox picbox3)  //σαν παράμετροι είναι το ερώτημα και το textbox που θα εμφανιστούν οι πληροφορίες
        {
            List<storeData> subscriptions = new List<storeData>();

            OleDbConnection connection = new OleDbConnection();
            OleDbCommand command;
            OleDbDataReader dataReader;
            connection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Tourist_Guide.mdb";

            command = new OleDbCommand();
            OleDbCommand commmand1 = new OleDbCommand();
            try
            {
                connection.Open();
                command.CommandText = query;
                command.Connection = connection;
                dataReader = command.ExecuteReader();


                while (dataReader.Read())
                {
                    subscriptions.Add(
                        new storeData((int)dataReader["Id"], (string)dataReader["Report"], (string)dataReader["Photo_ID_1"], (string)dataReader["Photo_ID_2"], (string)dataReader["Photo_ID_3"], (string)dataReader["Photo_ID_4"], (string)dataReader["Photo_ID_5"])
                        {

                        });
                }

                foreach (storeData i in subscriptions)
                {
                    if (i.storeId() == 9)
                    {
                        textbox.Text = i.getText();   //τοποθέτησε 1 κείμενο

                        string Sphoto_path = i.getphotoId1();   // πάρε τη φωτογραφία από τη λίστα
                        Image img = Image.FromFile(Sphoto_path); //μετετρεψε την απο string σε img
                        Image img_new = ResizeImage(img, 500, 350);  //αλλαξε το μέγεθος της φωτογραφίας
                        Clipboard.SetImage(img_new);        //βάλτην στο clipboad                
                        textbox.Select(0, 0);   //πήγαινε τον δείκτη στην αρχη του textbox
                        textbox.Paste();    //τοποθετησέ την στην αρχη

                        string Sphoto_path1 = i.getphotoId2();       // τοποθέτησε 2η φωτογραφία κάτω από τα 2 κείμενα                 
                        Image img1 = Image.FromFile(Sphoto_path1);
                        Image img_new1 = ResizeImage(img1, 1000, 500);  //αλλαξε το μέγεθος της φωτογραφίας
                        Clipboard.SetImage(img_new1);
                        textbox.Select(textbox.Text.Length, 0);  //πήγαινε τον δείκτη στο τέλος του textbox
                        textbox.Paste();                       

                        string Sphoto_path5 = i.getphotoId3();
                        picbox3.Image = Image.FromFile(Sphoto_path5);

                        string Sphoto_path3 = i.getphotoId4();
                        picbox1.Image = Image.FromFile(Sphoto_path3);

                        string Sphoto_path4 = i.getphotoId5();
                        picbox2.Image = Image.FromFile(Sphoto_path4);

                    }
                }//close foreach          
            }
            catch (System.Exception exception)
            {
                MessageBox.Show(exception.Message, "Error occurred");
            }
            finally
            {
                command.Dispose();
                connection.Dispose();
            }
        }//τελος 7 ερωτηματος

        public static void ExecuteEarthssquery(string query, RichTextBox textbox, PictureBox picbox1, PictureBox picbox2, PictureBox picbox3)  //σαν παράμετροι είναι το ερώτημα και το textbox που θα εμφανιστούν οι πληροφορίες
        {
            List<storeData> subscriptions = new List<storeData>();

            OleDbConnection connection = new OleDbConnection();
            OleDbCommand command;
            OleDbDataReader dataReader;
            connection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Tourist_Guide.mdb";

            command = new OleDbCommand();
            OleDbCommand commmand1 = new OleDbCommand();
            try
            {
                connection.Open();
                command.CommandText = query;
                command.Connection = connection;
                dataReader = command.ExecuteReader();


                while (dataReader.Read())
                {
                    subscriptions.Add(
                        new storeData((int)dataReader["Id"], (string)dataReader["Report"], (string)dataReader["Photo_ID_1"], (string)dataReader["Photo_ID_2"], (string)dataReader["Photo_ID_3"], (string)dataReader["Photo_ID_4"], (string)dataReader["Photo_ID_5"])
                        {

                        });
                }

                foreach (storeData i in subscriptions)
                {
                    if (i.storeId() == 10)
                    {
                        textbox.Text = i.getText();   //τοποθέτησε 1 κείμενο

                        string Sphoto_path = i.getphotoId1();   // πάρε τη φωτογραφία από τη λίστα
                        Image img = Image.FromFile(Sphoto_path); //μετετρεψε την απο string σε img
                        Image img_new = ResizeImage(img, 500, 350);  //αλλαξε το μέγεθος της φωτογραφίας
                        Clipboard.SetImage(img_new);        //βάλτην στο clipboad                
                        textbox.Select(0, 0);   //πήγαινε τον δείκτη στην αρχη του textbox
                        textbox.Paste();    //τοποθετησέ την στην αρχη

                        string Sphoto_path1 = i.getphotoId2();       // τοποθέτησε 2η φωτογραφία κάτω από τα 2 κείμενα                 
                        Image img1 = Image.FromFile(Sphoto_path1);
                        Image img_new1 = ResizeImage(img1, 1000, 500);  //αλλαξε το μέγεθος της φωτογραφίας
                        Clipboard.SetImage(img_new1);
                        textbox.Select(textbox.Text.Length, 0);  //πήγαινε τον δείκτη στο τέλος του textbox
                        textbox.Paste();

                        string Sphoto_path5 = i.getphotoId3();
                        picbox3.Image = Image.FromFile(Sphoto_path5);

                        string Sphoto_path3 = i.getphotoId4();
                        picbox1.Image = Image.FromFile(Sphoto_path3);

                        string Sphoto_path4 = i.getphotoId5();
                        picbox2.Image = Image.FromFile(Sphoto_path4);

                    }
                }//close foreach          
            }
            catch (System.Exception exception)
            {
                MessageBox.Show(exception.Message, "Error occurred");
            }
            finally
            {
                command.Dispose();
                connection.Dispose();
            }
        }//τελος 8 ερωτηματος

        public static void ExecuteSeassquery(string query, RichTextBox textbox, PictureBox picbox1, PictureBox picbox2, PictureBox picbox3)  //σαν παράμετροι είναι το ερώτημα και το textbox που θα εμφανιστούν οι πληροφορίες
        {
            List<storeData> subscriptions = new List<storeData>();

            OleDbConnection connection = new OleDbConnection();
            OleDbCommand command;
            OleDbDataReader dataReader;
            connection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Tourist_Guide.mdb";

            command = new OleDbCommand();
            OleDbCommand commmand1 = new OleDbCommand();
            try
            {
                connection.Open();
                command.CommandText = query;
                command.Connection = connection;
                dataReader = command.ExecuteReader();


                while (dataReader.Read())
                {
                    subscriptions.Add(
                        new storeData((int)dataReader["Id"], (string)dataReader["Report"], (string)dataReader["Photo_ID_1"], (string)dataReader["Photo_ID_2"], (string)dataReader["Photo_ID_3"], (string)dataReader["Photo_ID_4"], (string)dataReader["Photo_ID_5"])
                        {

                        });
                }

                foreach (storeData i in subscriptions)
                {
                    if (i.storeId() == 11)
                    {
                        textbox.Text = i.getText();   //τοποθέτησε 1 κείμενο

                        string Sphoto_path = i.getphotoId1();   // πάρε τη φωτογραφία από τη λίστα
                        Image img = Image.FromFile(Sphoto_path); //μετετρεψε την απο string σε img
                        Image img_new = ResizeImage(img, 500, 350);  //αλλαξε το μέγεθος της φωτογραφίας
                        Clipboard.SetImage(img_new);        //βάλτην στο clipboad                
                        textbox.Select(0, 0);   //πήγαινε τον δείκτη στην αρχη του textbox
                        textbox.Paste();    //τοποθετησέ την στην αρχη

                        string Sphoto_path1 = i.getphotoId2();       // τοποθέτησε 2η φωτογραφία κάτω από τα 2 κείμενα                 
                        Image img1 = Image.FromFile(Sphoto_path1);
                        Image img_new1 = ResizeImage(img1, 1000, 500);  //αλλαξε το μέγεθος της φωτογραφίας
                        Clipboard.SetImage(img_new1);
                        textbox.Select(textbox.Text.Length, 0);  //πήγαινε τον δείκτη στο τέλος του textbox
                        textbox.Paste();

                        string Sphoto_path5 = i.getphotoId3();
                        picbox3.Image = Image.FromFile(Sphoto_path5);

                        string Sphoto_path3 = i.getphotoId4();
                        picbox1.Image = Image.FromFile(Sphoto_path3);

                        string Sphoto_path4 = i.getphotoId5();
                        picbox2.Image = Image.FromFile(Sphoto_path4);

                    }
                }//close foreach          
            }
            catch (System.Exception exception)
            {
                MessageBox.Show(exception.Message, "Error occurred");
            }
            finally
            {
                command.Dispose();
                connection.Dispose();
            }
        }//τελος 9 ερωτηματος

        public static void ExecuteBeachnssquery(string query, RichTextBox textbox, PictureBox picbox1, PictureBox picbox2, PictureBox picbox3)  //σαν παράμετροι είναι το ερώτημα και το textbox που θα εμφανιστούν οι πληροφορίες
        {
            List<storeData> subscriptions = new List<storeData>();

            OleDbConnection connection = new OleDbConnection();
            OleDbCommand command;
            OleDbDataReader dataReader;
            connection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Tourist_Guide.mdb";

            command = new OleDbCommand();
            OleDbCommand commmand1 = new OleDbCommand();
            try
            {
                connection.Open();
                command.CommandText = query;
                command.Connection = connection;
                dataReader = command.ExecuteReader();


                while (dataReader.Read())
                {
                    subscriptions.Add(
                        new storeData((int)dataReader["Id"], (string)dataReader["Report"], (string)dataReader["Photo_ID_1"], (string)dataReader["Photo_ID_2"], (string)dataReader["Photo_ID_3"], (string)dataReader["Photo_ID_4"], (string)dataReader["Photo_ID_5"])
                        {

                        });
                }

                foreach (storeData i in subscriptions)
                {
                    if (i.storeId() == 12)
                    {
                        textbox.Text = i.getText();   //τοποθέτησε 1 κείμενο

                        string Sphoto_path = i.getphotoId1();   // πάρε τη φωτογραφία από τη λίστα
                        Image img = Image.FromFile(Sphoto_path); //μετετρεψε την απο string σε img
                        Image img_new = ResizeImage(img, 500, 350);  //αλλαξε το μέγεθος της φωτογραφίας
                        Clipboard.SetImage(img_new);        //βάλτην στο clipboad                
                        textbox.Select(0, 0);   //πήγαινε τον δείκτη στην αρχη του textbox
                        textbox.Paste();    //τοποθετησέ την στην αρχη

                        string Sphoto_path1 = i.getphotoId2();       // τοποθέτησε 2η φωτογραφία κάτω από τα 2 κείμενα                 
                        Image img1 = Image.FromFile(Sphoto_path1);
                        Image img_new1 = ResizeImage(img1, 1000, 500);  //αλλαξε το μέγεθος της φωτογραφίας
                        Clipboard.SetImage(img_new1);
                        textbox.Select(textbox.Text.Length, 0);  //πήγαινε τον δείκτη στο τέλος του textbox
                        textbox.Paste();

                        string Sphoto_path5 = i.getphotoId3();
                        picbox3.Image = Image.FromFile(Sphoto_path5);

                        string Sphoto_path3 = i.getphotoId4();
                        picbox1.Image = Image.FromFile(Sphoto_path3);

                        string Sphoto_path4 = i.getphotoId5();
                        picbox2.Image = Image.FromFile(Sphoto_path4);

                    }
                }//close foreach          
            }
            catch (System.Exception exception)
            {
                MessageBox.Show(exception.Message, "Error occurred");
            }
            finally
            {
                command.Dispose();
                connection.Dispose();
            }
        }//τελος 10 ερωτηματος

        public static void ExecuteKsenonesssquery(string query, RichTextBox textbox, PictureBox picbox1, PictureBox picbox2, PictureBox picbox3)  //σαν παράμετροι είναι το ερώτημα και το textbox που θα εμφανιστούν οι πληροφορίες
        {
            List<storeData> subscriptions = new List<storeData>();

            OleDbConnection connection = new OleDbConnection();
            OleDbCommand command;
            OleDbDataReader dataReader;
            connection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Tourist_Guide.mdb";

            command = new OleDbCommand();
            OleDbCommand commmand1 = new OleDbCommand();
            try
            {
                connection.Open();
                command.CommandText = query;
                command.Connection = connection;
                dataReader = command.ExecuteReader();


                while (dataReader.Read())
                {
                    subscriptions.Add(
                        new storeData((int)dataReader["Id"], (string)dataReader["Report"], (string)dataReader["Photo_ID_1"], (string)dataReader["Photo_ID_2"], (string)dataReader["Photo_ID_3"], (string)dataReader["Photo_ID_4"], (string)dataReader["Photo_ID_5"])
                        {

                        });
                }

                foreach (storeData i in subscriptions)
                {
                    if (i.storeId() == 13)
                    {
                        textbox.Text = i.getText();   //τοποθέτησε 1 κείμενο

                        string Sphoto_path = i.getphotoId1();   // πάρε τη φωτογραφία από τη λίστα
                        Image img = Image.FromFile(Sphoto_path); //μετετρεψε την απο string σε img
                        Image img_new = ResizeImage(img, 500, 350);  //αλλαξε το μέγεθος της φωτογραφίας
                        Clipboard.SetImage(img_new);        //βάλτην στο clipboad                
                        textbox.Select(0, 0);   //πήγαινε τον δείκτη στην αρχη του textbox
                        textbox.Paste();    //τοποθετησέ την στην αρχη

                        string Sphoto_path1 = i.getphotoId2();       // τοποθέτησε 2η φωτογραφία κάτω από τα 2 κείμενα                 
                        Image img1 = Image.FromFile(Sphoto_path1);
                        Image img_new1 = ResizeImage(img1, 1000, 500);  //αλλαξε το μέγεθος της φωτογραφίας
                        Clipboard.SetImage(img_new1);
                        textbox.Select(textbox.Text.Length, 0);  //πήγαινε τον δείκτη στο τέλος του textbox
                        textbox.Paste();

                        string Sphoto_path5 = i.getphotoId3();
                        picbox3.Image = Image.FromFile(Sphoto_path5);

                        string Sphoto_path3 = i.getphotoId4();
                        picbox1.Image = Image.FromFile(Sphoto_path3);

                        string Sphoto_path4 = i.getphotoId5();
                        picbox2.Image = Image.FromFile(Sphoto_path4);

                    }
                }//close foreach          
            }
            catch (System.Exception exception)
            {
                MessageBox.Show(exception.Message, "Error occurred");
            }
            finally
            {
                command.Dispose();
                connection.Dispose();
            }
        }//τελος 11 ερωτηματος

        public static void ExecuteKsenodoxeiassquery(string query, RichTextBox textbox, PictureBox picbox1, PictureBox picbox2, PictureBox picbox3)  //σαν παράμετροι είναι το ερώτημα και το textbox που θα εμφανιστούν οι πληροφορίες
        {
            List<storeData> subscriptions = new List<storeData>();

            OleDbConnection connection = new OleDbConnection();
            OleDbCommand command;
            OleDbDataReader dataReader;
            connection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Tourist_Guide.mdb";

            command = new OleDbCommand();
            OleDbCommand commmand1 = new OleDbCommand();
            try
            {
                connection.Open();
                command.CommandText = query;
                command.Connection = connection;
                dataReader = command.ExecuteReader();


                while (dataReader.Read())
                {
                    subscriptions.Add(
                        new storeData((int)dataReader["Id"], (string)dataReader["Report"], (string)dataReader["Photo_ID_1"], (string)dataReader["Photo_ID_2"], (string)dataReader["Photo_ID_3"], (string)dataReader["Photo_ID_4"], (string)dataReader["Photo_ID_5"])
                        {

                        });
                }

                foreach (storeData i in subscriptions)
                {
                    if (i.storeId() == 14)
                    {
                        textbox.Text = i.getText();   //τοποθέτησε 1 κείμενο

                        string Sphoto_path = i.getphotoId1();   // πάρε τη φωτογραφία από τη λίστα
                        Image img = Image.FromFile(Sphoto_path); //μετετρεψε την απο string σε img
                        Image img_new = ResizeImage(img, 500, 350);  //αλλαξε το μέγεθος της φωτογραφίας
                        Clipboard.SetImage(img_new);        //βάλτην στο clipboad                
                        textbox.Select(0, 0);   //πήγαινε τον δείκτη στην αρχη του textbox
                        textbox.Paste();    //τοποθετησέ την στην αρχη

                        string Sphoto_path1 = i.getphotoId2();       // τοποθέτησε 2η φωτογραφία κάτω από τα 2 κείμενα                 
                        Image img1 = Image.FromFile(Sphoto_path1);
                        Image img_new1 = ResizeImage(img1, 1000, 500);  //αλλαξε το μέγεθος της φωτογραφίας
                        Clipboard.SetImage(img_new1);
                        textbox.Select(textbox.Text.Length, 0);  //πήγαινε τον δείκτη στο τέλος του textbox
                        textbox.Paste();

                        string Sphoto_path5 = i.getphotoId3();
                        picbox3.Image = Image.FromFile(Sphoto_path5);

                        string Sphoto_path3 = i.getphotoId4();
                        picbox1.Image = Image.FromFile(Sphoto_path3);

                        string Sphoto_path4 = i.getphotoId5();
                        picbox2.Image = Image.FromFile(Sphoto_path4);

                    }
                }//close foreach          
            }
            catch (System.Exception exception)
            {
                MessageBox.Show(exception.Message, "Error occurred");
            }
            finally
            {
                command.Dispose();
                connection.Dispose();
            }
        }//τελος 12 ερωτηματος

        public static void ExecuteDwmatiasquery(string query, RichTextBox textbox, PictureBox picbox1, PictureBox picbox2, PictureBox picbox3)  //σαν παράμετροι είναι το ερώτημα και το textbox που θα εμφανιστούν οι πληροφορίες
        {
            List<storeData> subscriptions = new List<storeData>();

            OleDbConnection connection = new OleDbConnection();
            OleDbCommand command;
            OleDbDataReader dataReader;
            connection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Tourist_Guide.mdb";

            command = new OleDbCommand();
            OleDbCommand commmand1 = new OleDbCommand();
            try
            {
                connection.Open();
                command.CommandText = query;
                command.Connection = connection;
                dataReader = command.ExecuteReader();


                while (dataReader.Read())
                {
                    subscriptions.Add(
                        new storeData((int)dataReader["Id"], (string)dataReader["Report"], (string)dataReader["Photo_ID_1"], (string)dataReader["Photo_ID_2"], (string)dataReader["Photo_ID_3"], (string)dataReader["Photo_ID_4"], (string)dataReader["Photo_ID_5"])
                        {

                        });
                }

                foreach (storeData i in subscriptions)
                {
                    if (i.storeId() == 15)
                    {
                        textbox.Text = i.getText();   //τοποθέτησε 1 κείμενο

                        string Sphoto_path = i.getphotoId1();   // πάρε τη φωτογραφία από τη λίστα
                        Image img = Image.FromFile(Sphoto_path); //μετετρεψε την απο string σε img
                        Image img_new = ResizeImage(img, 500, 350);  //αλλαξε το μέγεθος της φωτογραφίας
                        Clipboard.SetImage(img_new);        //βάλτην στο clipboad                
                        textbox.Select(0, 0);   //πήγαινε τον δείκτη στην αρχη του textbox
                        textbox.Paste();    //τοποθετησέ την στην αρχη

                        string Sphoto_path1 = i.getphotoId2();       // τοποθέτησε 2η φωτογραφία κάτω από τα 2 κείμενα                 
                        Image img1 = Image.FromFile(Sphoto_path1);
                        Image img_new1 = ResizeImage(img1, 1000, 500);  //αλλαξε το μέγεθος της φωτογραφίας
                        Clipboard.SetImage(img_new1);
                        textbox.Select(textbox.Text.Length, 0);  //πήγαινε τον δείκτη στο τέλος του textbox
                        textbox.Paste();

                        string Sphoto_path5 = i.getphotoId3();
                        picbox3.Image = Image.FromFile(Sphoto_path5);

                        string Sphoto_path3 = i.getphotoId4();
                        picbox1.Image = Image.FromFile(Sphoto_path3);

                        string Sphoto_path4 = i.getphotoId5();
                        picbox2.Image = Image.FromFile(Sphoto_path4);

                    }
                }//close foreach          
            }
            catch (System.Exception exception)
            {
                MessageBox.Show(exception.Message, "Error occurred");
            }
            finally
            {
                command.Dispose();
                connection.Dispose();
            }
        }//τελος 13 ερωτηματος

        public static void ExecuteGenikasquery(string query, RichTextBox textbox, PictureBox picbox1, PictureBox picbox2, PictureBox picbox3)  //σαν παράμετροι είναι το ερώτημα και το textbox που θα εμφανιστούν οι πληροφορίες
        {
            List<storeData> subscriptions = new List<storeData>();

            OleDbConnection connection = new OleDbConnection();
            OleDbCommand command;
            OleDbDataReader dataReader;
            connection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Tourist_Guide.mdb";

            command = new OleDbCommand();
            OleDbCommand commmand1 = new OleDbCommand();
            try
            {
                connection.Open();
                command.CommandText = query;
                command.Connection = connection;
                dataReader = command.ExecuteReader();


                while (dataReader.Read())
                {
                    subscriptions.Add(
                        new storeData((int)dataReader["Id"], (string)dataReader["Report"], (string)dataReader["Photo_ID_1"], (string)dataReader["Photo_ID_2"], (string)dataReader["Photo_ID_3"], (string)dataReader["Photo_ID_4"], (string)dataReader["Photo_ID_5"])
                        {

                        });
                }

                foreach (storeData i in subscriptions)
                {
                    if (i.storeId() == 16)
                    {
                        textbox.Text = i.getText();   //τοποθέτησε 1 κείμενο

                        string Sphoto_path = i.getphotoId1();   // πάρε τη φωτογραφία από τη λίστα
                        Image img = Image.FromFile(Sphoto_path); //μετετρεψε την απο string σε img
                        Image img_new = ResizeImage(img, 500, 350);  //αλλαξε το μέγεθος της φωτογραφίας
                        Clipboard.SetImage(img_new);        //βάλτην στο clipboad                
                        textbox.Select(0, 0);   //πήγαινε τον δείκτη στην αρχη του textbox
                        textbox.Paste();    //τοποθετησέ την στην αρχη

                        string Sphoto_path1 = i.getphotoId2();       // τοποθέτησε 2η φωτογραφία κάτω από τα 2 κείμενα                 
                        Image img1 = Image.FromFile(Sphoto_path1);
                        Image img_new1 = ResizeImage(img1, 1000, 500);  //αλλαξε το μέγεθος της φωτογραφίας
                        Clipboard.SetImage(img_new1);
                        textbox.Select(textbox.Text.Length, 0);  //πήγαινε τον δείκτη στο τέλος του textbox
                        textbox.Paste();

                        string Sphoto_path5 = i.getphotoId3();
                        picbox3.Image = Image.FromFile(Sphoto_path5);

                        string Sphoto_path3 = i.getphotoId4();
                        picbox1.Image = Image.FromFile(Sphoto_path3);

                        string Sphoto_path4 = i.getphotoId5();
                        picbox2.Image = Image.FromFile(Sphoto_path4);

                    }
                }//close foreach          
            }
            catch (System.Exception exception)
            {
                MessageBox.Show(exception.Message, "Error occurred");
            }
            finally
            {
                command.Dispose();
                connection.Dispose();
            }
        }//τελος 14 ερωτηματος

    }
}
