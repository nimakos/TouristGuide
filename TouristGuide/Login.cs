using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TouristGuide;

namespace WindowsFormsApp1
{
    public partial class LoginForm : Form
    {
        System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"sounds\login.wav");

        String connectionstring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Tourist_Guide.mdb";
        OleDbConnection conn;
        

        public LoginForm()
        {           
            InitializeComponent();
        }       
        

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            conn = new OleDbConnection(connectionstring);
        }

        private void LognButton_Click(object sender, EventArgs e)
        {
            
            conn.Open();       

            String query = "SELECT * FROM [user] WHERE User_Name='"+ userCBox.Text +"' and Password='"+ passBox.Text+"' ";
            OleDbCommand cmd = new OleDbCommand(query, conn);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);

            if(dt.Rows.Count == 1)  //εαν βρεθεί 1 χρήστης...
            {
               
                ButtonClicked.storeUsername = userCBox.Text;
                Main myForm = new Main();
                myForm.Show(this);
                this.Hide();
                player.Play();
            }
            else
            {
                MessageBox.Show("Λάθος Εισαγωγή δεδομένων");
            }
            conn.Close();
          
        }

        private void Register_Btn_Click(object sender, EventArgs e)
        {
            Register regform = new Register();
            regform.Show(this);
            this.Hide();
        }      


        private void button2_Click(object sender, EventArgs e) //απλός επισκέπτης
        {
            ButtonClicked.buttonClicked = (sender as Button).Text;  //δώσε τιμή στην μεταβλητή buttonClicked της κλάσης ButtonClicked
            
            Main episk = new Main();
            episk.Show(this);
            this.Hide();
        }       
    }
}
