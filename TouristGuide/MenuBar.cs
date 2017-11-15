using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace TouristGuide
{
    public partial class MenuBar : Form
    {
       
       
        public MenuBar()
        {
            InitializeComponent();
            
        }

        private void button2_MouseEnter(object sender, EventArgs e)  //γνώρισε την κρήτη (κουμπί)
        {                      
               panel10.Visible = true;  //το dropdown να γινει εμφανίσιμο
               panel5.Visible = false;  //και τα υπόλοιπα να μην εμφανίζονται
               panel7.Visible = false;
        }

        private void button10_MouseEnter(object sender, EventArgs e)//πολιτισμός (κουμπί)
        {
            panel7.Visible = false;
            panel5.Visible = true;                 
        }

        private void MenuBar_MouseEnter(object sender, EventArgs e) //εαν μπει στη περιοχή του menu να εξαφανιστουν τα dropdown menou
        {
            panel10.Visible = false;
            panel5.Visible = false;
            panel7.Visible = false;
            panel6.Visible = false;
        }
       

        private void panel2_MouseEnter(object sender, EventArgs e) //εαν μπει στη άλλη περιοχή να εξαφανιστουν τα dropdown menou
        {
            panel10.Visible = false;
            panel5.Visible = false;
            panel7.Visible = false;
            panel6.Visible = false;

        }


        private void button1_MouseEnter(object sender, EventArgs e)
        {
            panel10.Visible = false;
            panel5.Visible = false;
            panel7.Visible = false;
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            panel10.Visible = false;
            panel5.Visible = false;
            panel7.Visible = true;
            panel6.Visible = false;

        }

        private void button11_MouseEnter(object sender, EventArgs e)
        {
            panel5.Visible = false;
        }

        private void button9_MouseEnter(object sender, EventArgs e)
        {
            panel5.Visible = false;
        }

        private void button8_MouseEnter(object sender, EventArgs e)
        {
            panel5.Visible = false;
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            panel7.Visible = false;
            panel6.Visible = true;

        }

        private void button5_MouseEnter(object sender, EventArgs e)
        {
            panel6.Visible = false;
        }

        private void button15_Click(object sender, EventArgs e)  //μουσικη παράδοση
        {
            ButtonClicked.music = true;           

            Music music = new Music();
            music.Show(this);
            this.Hide();
        }

        private void button14_Click(object sender, EventArgs e) //αρχιτεκτονική
        {
            ButtonClicked.arhitekt = true;            

            Arhitekt arh = new Arhitekt();
            arh.Show(this);
            this.Hide();
        }

        private void button13_Click(object sender, EventArgs e)  //τέχνες
        {
            ButtonClicked.texnes = true;
            panel10.Visible = false;
            panel5.Visible = false;
            panel7.Visible = false;

            Arts art = new Arts();
            art.Show(this);
            this.Hide();
        }

        private void button11_Click(object sender, EventArgs e)  //ιστορια
        {
            ButtonClicked.historyButton = true;            

            History history = new History();
            history.Show(this);
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)  //πόλεις
        {
            ButtonClicked.towns = true;

            Towns town = new Towns();
            town.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)  //κουζίνα
        {
            ButtonClicked.kichen = true;           

            Kitchen kitchen = new Kitchen();
            kitchen.Show(this);
            this.Hide();
        }      

        private void button5_Click(object sender, EventArgs e)  //φαγητό
        {
            ButtonClicked.fagito = true;

            Plirofories plirofories = new Plirofories();
            plirofories.Show(this);
            this.Hide();
        }

        private void button21_Click(object sender, EventArgs e)  //γη
        {
            ButtonClicked.gh = true;

            Earth earth = new Earth();
            earth.Show();
            this.Hide();
        }

        private void button20_Click(object sender, EventArgs e)  //θάλασσες
        {
            ButtonClicked.thalassa = true;

            Sea sea = new Sea();
            sea.Show(this);
            this.Hide();
        }

        private void button19_Click(object sender, EventArgs e)  //παραλίες
        {
            ButtonClicked.parallies = true;

            Beach beach = new Beach();
            beach.Show(this);
            this.Hide();
        }

        private void button18_Click(object sender, EventArgs e)  //ξενώνες
        {
            ButtonClicked.ksenones = true;

            Ksenones ksenones = new Ksenones();
            ksenones.Show(this);
            this.Hide();
        }

        private void button17_Click(object sender, EventArgs e)  //ξενοδοχεια
        {
            ButtonClicked.ksenodoxeia = true;

            Ksenodoxeia ksenodoxeia = new Ksenodoxeia();
            ksenodoxeia.Show(this);
            this.Hide();
        }

        private void button16_Click(object sender, EventArgs e)  //δωμάτια
        {
            ButtonClicked.dwmatia = true;

            Domatia domatia = new Domatia();
            domatia.Show(this);
            this.Hide();
        }

        private void MenuBar_Load(object sender, EventArgs e)   
        {
           
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            label1.Text = "Καλώς ήρθες : " + ButtonClicked.storeUsername;

            if (!string.IsNullOrEmpty(ButtonClicked.buttonClicked))  //εαν η μεταβλητή μας δεν είναι άδεια (δηλαδή έχει πατηθεί το κουμπί "απλός επισκέπτης" )
            {     // κρύψε κάποια αντικείμενα στη φόρμα
                button12.Visible = false; //κουμπι διαγραφης Ιστορικού
                button23.Visible = false;  //ημερολόγιο
               

            }
            else  //εαν υπάρχει σύνδεση χρήστη
            {
                label1.Visible = true;  //εμφάνησε το label με το όνομα του χρήστη

                //εαν η μεταβλητή είναι true, τότε χρωμάτισε κάποια αντικείμενα στη φόρμα
                if (ButtonClicked.historyButton)
                {                    
                    button11.BackColor = Color.Green;
                }
                if (ButtonClicked.photos)
                {
                    button7.BackColor = Color.Green;
                }
                if (ButtonClicked.about)
                {
                    button22.BackColor = Color.Green;
                }
                if (ButtonClicked.music)
                {
                    button15.BackColor = Color.Green;
                }
                if (ButtonClicked.arhitekt)
                {
                    button14.BackColor = Color.Green;
                }
                if (ButtonClicked.dwmatia)
                {
                    button16.BackColor = Color.Green;
                }
                if (ButtonClicked.fagito)
                {
                    button5.BackColor = Color.Green;
                }
                if (ButtonClicked.kichen)
                {
                    button8.BackColor = Color.Green;
                }
                if (ButtonClicked.ksenodoxeia)
                {
                    button17.BackColor = Color.Green;
                }
                if (ButtonClicked.ksenones)
                {
                    button18.BackColor = Color.Green;
                }
                if (ButtonClicked.texnes)
                {
                    button13.BackColor = Color.Green;
                }
                if (ButtonClicked.towns)
                {
                    button9.BackColor = Color.Green;
                }
                if (ButtonClicked.gh)
                {
                    button21.BackColor = Color.Green;
                }
                if (ButtonClicked.thalassa)
                {
                    button20.BackColor = Color.Green;
                }
                if (ButtonClicked.parallies)
                {
                    button19.BackColor = Color.Green;
                }
                if (ButtonClicked.calendari)
                {
                    button23.BackColor = Color.Green;
                }
            }
        }

        //private Calendar newCalendar;
        private void button23_Click(object sender, EventArgs e)  //ημερολόγιο
        {
            ButtonClicked.calendari = true;
            Calendar cal = new Calendar();
            cal.Show();            
        }

        private void button1_Click(object sender, EventArgs e)  //αρχική
        {
            Main main = new Main();
            main.Show(this);
            this.Hide();
            
        }

        private void button7_Click(object sender, EventArgs e) //φωτογραφίες
        {
            ButtonClicked.photos = true;
            Photos x = new Photos();
            x.Show();        
        }

        private void button12_Click(object sender, EventArgs e) //διαγραφή ιστορικού
        {
            ButtonClicked.photos = false;
            ButtonClicked.historyButton = false;
            ButtonClicked.about = false;
            ButtonClicked.music = false;
            ButtonClicked.arhitekt = false;
            ButtonClicked.dwmatia = false;
            ButtonClicked.fagito = false;
            ButtonClicked.kichen = false;
            ButtonClicked.ksenodoxeia = false;
            ButtonClicked.ksenones = false;
            ButtonClicked.texnes = false;
            ButtonClicked.towns = false;
            ButtonClicked.gh = false;
            ButtonClicked.thalassa = false;
            ButtonClicked.parallies = false;
            ButtonClicked.calendari = false;

            Main myForm = new Main();
            myForm.Show(this);
            this.Hide();

        }

        private void button24_Click(object sender, EventArgs e)  //έξοδος
        {
            Application.Exit();
        }

        private void MenuBar_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();    //οταν πατήσουμε το κουμπί χ στο παράθυρο να κλείσει ολοκληρωτικά το πρόγραμμα
        }

        private void button22_Click(object sender, EventArgs e)  //Σχετικά...
        {
            ButtonClicked.about = true;
            AboutBox about = new AboutBox();
            about.Show(this);
        }

        
    }
}
