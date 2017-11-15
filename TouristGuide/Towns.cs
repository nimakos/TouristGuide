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
    public partial class Towns : MenuBar
    {
        public Towns()
        {
            InitializeComponent();
        }

        private void Towns_Load(object sender, EventArgs e)
        {
            panel11.SendToBack();  //στο παρασκήνιο           

            string query = null;
            query = @"SELECT * FROM History";
            sql_queries.ExecuteTownsquery(query, richTextBox1, pictureBox2, pictureBox3);
        }

        private void richTextBox1_MouseEnter(object sender, EventArgs e)
        {
            panel10.Visible = false;
            panel5.Visible = false;
            panel7.Visible = false;
            panel6.Visible = false;
        }

        private void panel11_MouseEnter(object sender, EventArgs e)
        {
            panel10.Visible = false;
            panel5.Visible = false;
            panel7.Visible = false;
            panel6.Visible = false;
        }
    }
}
