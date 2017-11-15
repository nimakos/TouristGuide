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
    public partial class Main : MenuBar
    {
       
        public Main()
        {
            InitializeComponent();
           
        }

        private void Main_Load(object sender, EventArgs e)
        {
            panel11.SendToBack();  //στο παρασκήνιο
           
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            panel10.Visible = false;
            panel5.Visible = false;
            panel7.Visible = false;
            panel6.Visible = false;
            pictureBox2.Size = new Size(264, 255);
            
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Size = new Size(264, 126);
        }

        private void button26_Click(object sender, EventArgs e)
        {
            ButtonClicked.ksenones = true;

            Ksenones ksen = new Ksenones();
            ksen.Show(this);
            this.Hide();
        }

        private void panel11_MouseEnter(object sender, EventArgs e)
        {
          
            panel10.Visible = false;
            panel5.Visible = false;
            panel7.Visible = false;
            panel6.Visible = false;
        }

        private void pictureBox5_MouseEnter(object sender, EventArgs e)
        {
            pictureBox5.Size = new Size(264, 255);
            panel10.Visible = false;
            panel5.Visible = false;
            panel7.Visible = false;
            panel6.Visible = false;
        }

        private void panel12_MouseEnter(object sender, EventArgs e)
        {
            panel10.Visible = false;
            panel5.Visible = false;
            panel7.Visible = false;
            panel6.Visible = false;
        }

        private void button27_Click(object sender, EventArgs e)
        {
            ButtonClicked.towns = true;

            Towns towns = new Towns();
            towns.Show();
            this.Hide();
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            pictureBox5.Size = new Size(264, 126);
        }

        private void button28_Click(object sender, EventArgs e)
        {
            Kitchen kitchen = new Kitchen();
            kitchen.Show(this);
            this.Hide();
        }
    }
}
