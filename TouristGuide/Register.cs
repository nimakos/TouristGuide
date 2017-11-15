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

namespace WindowsFormsApp1
{
    public partial class Register : Form
    {
        string errormessage;
        string successmessage;

        String connectionstring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Tourist_Guide.mdb";
        OleDbConnection conn;
        OleDbCommand cmd;

        public Register()
        {
            InitializeComponent();
        }

        public Boolean err(string errormessage) //εαν η μεταβλητή έχει τιμή
        {
            return (errormessage != null);
        }

        public Boolean succ(string successmessage)  //εαν η μεταβλητή έχει τιμή
        {
            return (successmessage != null);
        }

        private void Register_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show();
        }

        private void Register_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            conn = new OleDbConnection(connectionstring);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (userBox.Text == string.Empty || passBox.Text == string.Empty || passBox2.Text == string.Empty ||
                UserName.Text == string.Empty || phoneBox.Text == string.Empty || mailBox.Text==string.Empty ||
                addressBox.Text == string.Empty || townBox.Text == string.Empty || countryBox.Text == string.Empty)
            {
                errormessage = "Συμπλήρωσε όλα τα πεδία";                
            }
            else
            {
                errormessage = null;
            }

            /*foreach (Control c in this.Controls)
          {
                TextBox t = c as TextBox;
            if(c is TextBox)
            {
                if (t == null)
                {
                    errormessage = "Συμπλήρωσε όλα τα πεδία";
                    break;
                }
                else
                {
                    errormessage = null;
                }
            }
          }*/
            

            if (!err(errormessage)) //εαν η μεταβλητή errormessage δεν εχει τιμη
            {
                //ελεγχος κωδικών
                if (passBox.Text != passBox2.Text)
                {
                    errormessage = "Οι κωδικοί δεν ταιριάζουν";
                }

                //ελεγχος mail
                try
                {
                    var addr = new System.Net.Mail.MailAddress(mailBox.Text);
                    if (addr.Address != mailBox.Text)
                    {
                      

                    }
                }catch(Exception)
                {
                    errormessage = "Λανθασμένη διεύθυνση Email";
                }

                //έλεγχος τηλεφώνου
                string phoneNumber = phoneBox.Text.Trim();

                for (int i = 0; i < phoneNumber.Length; i++)
                {
                    if (!char.IsNumber(phoneNumber[i]))
                    {
                        errormessage = "Το τηλέφωνο θα πρέπει να περιέχει μόνο αριθμούς";
                    }
                }

                if(phoneBox.TextLength < 10 || phoneBox.TextLength > 10)
                {
                    errormessage = "Τα ψηφία του αριθμού τηλεφώνου θα πρέπει να είναι 10";
                }

                //Έλεγχος εαν υπάρχει ο χρήστης
                conn.Open();
                cmd = new OleDbCommand("SELECT * FROM [user] WHERE User_Name='" + userBox.Text + "'", conn);

                OleDbDataReader rd = cmd.ExecuteReader();
                    
                    while (rd.Read())
                    {
                        if(rd.HasRows== true)
                        {
                            errormessage = "Αυτή η εγγραφή υπάρχει ήδη. Προσπάθησε ξανά!";
                        }
                        
                    }
                conn.Close();
            }

            if (!err(errormessage))  //insert τιμές (εαν δεν υπάρχει σφάλμα)
            {        
                    try
                    {
                        conn.Open();
                        String query = "INSERT INTO [user]([User_Name],[Password],[Address],[Country],[City],[Phone],[Mail],[NameSurname]) VALUES(@username, @password, @address, @country, @city, @phone, @mail, @name) ";

                        cmd = new OleDbCommand(query, conn);
                        cmd.Parameters.AddWithValue("@username", userBox.Text);
                        cmd.Parameters.AddWithValue("@password", passBox.Text);
                        cmd.Parameters.AddWithValue("@address", addressBox.Text);
                        cmd.Parameters.AddWithValue("@country", countryBox.Text);
                        cmd.Parameters.AddWithValue("@city", townBox.Text);
                        cmd.Parameters.AddWithValue("@phone", phoneBox.Text);
                        cmd.Parameters.AddWithValue("@mail", mailBox.Text);
                        cmd.Parameters.AddWithValue("@name", UserName.Text);                

                        cmd.ExecuteNonQuery();
                        successmessage = "Η εγγραφή σου ολοκληρώθηκε επιτυχώς!";

                        conn.Close();
                    }                  

                    catch (Exception)
                    {
                        MessageBox.Show("Πρόβλημα στην εγγραφή");
                    }                  
                
            }

            if (err(errormessage))  //εαν υπάρχει τιμη στην μεταβλητη errormessage
            {
                MessageBox.Show(errormessage);
            }
            else if (succ(successmessage))
            {
                MessageBox.Show(successmessage);
            }
        }
    }
}
