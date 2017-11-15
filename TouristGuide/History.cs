using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TouristGuide
{
    public partial class History : MenuBar
    {
     
        public History()
        {
            InitializeComponent();
            
        }

        private void History_Load(object sender, EventArgs e)
        {
            panel11.SendToBack();  //στο παρασκήνιο

            if (!string.IsNullOrEmpty(ButtonClicked.buttonClicked))  //εαν η μεταβλητή μας δεν είναι άδεια (δηλαδή έχει πατηθεί το κουμπί "απλός επισκέπτης" )
            {     // κρύψε κάποια το κουμπί save της φόρμας
                Save2PDF.Visible = false; 
            }



            //string query1 = null;
            //query1 = @"SELECT * FROM History INNER JOIN Photos ON History.ID = Photos.Id_history WHERE History.ID = 1";

            //string query = null;
            string query2 = null;

            //query = @"SELECT * FROM History WHERE id = 1";
            query2 = @"SELECT * FROM History";

            //sql_queries.Executequery(query, richTextBox1, pictureBox2, pictureBox3);
            sql_queries.Executehistoryquery(query2, richTextBox1, pictureBox2, pictureBox3);

        }


        private void panel11_MouseEnter(object sender, EventArgs e)
        {
            panel10.Visible = false;
            panel5.Visible = false;
            panel7.Visible = false;
            panel6.Visible = false;

        }       

        private void button24_Click(object sender, EventArgs e)
        {
            
        }

        private void richTextBox1_MouseEnter(object sender, EventArgs e)
        {
            panel10.Visible = false;
            panel5.Visible = false;
            panel7.Visible = false;
            panel6.Visible = false;
        }     
        private void Save2PDF_Click_1(object sender, EventArgs e)
        {
            SaveFile.SaveMyFile(richTextBox1);
        }
    }
}
