using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TouristGuide
{
    public partial class Ksenodoxeia : MenuBar
    {
        public Ksenodoxeia()
        {
            InitializeComponent();
        }

        private void Ksenodoxeia_Load(object sender, EventArgs e)
        {
            panel11.SendToBack();  //στο παρασκήνιο

            if (!string.IsNullOrEmpty(ButtonClicked.buttonClicked))  //εαν η μεταβλητή μας δεν είναι άδεια (δηλαδή έχει πατηθεί το κουμπί "απλός επισκέπτης" )
            {     // κρύψε κάποια το κουμπί save της φόρμας
                Save2PDF.Visible = false;
            }

            string query = null;
            query = @"SELECT * FROM History";
            sql_queries.ExecuteKsenodoxeiassquery(query, richTextBox1, pictureBox2, pictureBox3, pictureBox4);
        }

        private void Save2PDF_Click(object sender, EventArgs e)
        {
            SaveFile.SaveMyFile(richTextBox1);
        }

        private void panel11_MouseEnter(object sender, EventArgs e)
        {
            panel10.Visible = false;
            panel5.Visible = false;
            panel7.Visible = false;
            panel6.Visible = false;
        }

        private void richTextBox1_MouseEnter(object sender, EventArgs e)
        {
            panel10.Visible = false;
            panel5.Visible = false;
            panel7.Visible = false;
            panel6.Visible = false;
        }
    }
}
