using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace TouristGuide
{
    public partial class Calendar : Form
    {
        List<Calendar_Item> myList = new List<Calendar_Item>();
        List<Calendar_Item> myList2 = new List<Calendar_Item>();     
        BindingSource mySource = new BindingSource(); 


        public Calendar()
        {
            InitializeComponent();

            open("file.xml");
            mySource.DataSource = myList2; //αποθήκευσε στο mysource τα δεδομένα της δέυτερης λίστας
            dataGridView1.DataSource = mySource; // και στη συνέχεια εμφανισετα στο datagridview            
        }       

        private void button1_Click(object sender, EventArgs e)
        {
            //αποθήκευσε στην αρχική λίστα την ημ/νια που έχει επιλεγεί μαζί με το κείμενο του textbox
            myList.Add(new Calendar_Item(monthCalendar1.SelectionStart.ToString(), textBox1.Text));
            textBox1.Text = "";            
        }

        //επιλέγoντας την ημ/νια
        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            dataGridView1.Rows.Clear(); //σβήσε όποιες γραμμές υπάρχουν στο datagridview
            
            foreach (Calendar_Item i in myList)
            {
                //εαν η ημ/νια που υπάρχει στη λίστα μας ταυτιστεί με την ημ/νια του ημερολογίου
                if (i.Date.Equals(monthCalendar1.SelectionStart.ToString())) 
                {    //πρόσθεσε την ημ/νια της λίστας σε καινούρια λίστα (mylist2) μαζι με το κείμενο                 
                    myList2.Add(new Calendar_Item(i.Date, i.Text));
                    //και εμφανισέτα στο datagridview
                    mySource.ResetBindings(true);
                } 
            }         
        }
      

        private void Calendar_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.FixedToolWindow; //συγκεκριμενες διαστασεις φόρμας       

        }
        //save to file
        internal void save(string filename, List<Calendar_Item> myData)  
        {
            try
            {
                var xml = new XElement("DataStore", myData.Select(x => new XElement("Element",
                                                                           new XAttribute("Date", x.Date),
                                                                           new XAttribute("Text", x.Text))));
                xml.Save(filename);
            }catch(Exception )
            {
                MessageBox.Show("Κατί πήγε στραβά, Προσπάθησε ξανά");
            }        
        }

        //load from file
        internal List<Calendar_Item> open(string filename)  
        {
            try
            {
                XElement xe = XElement.Load(filename);

                myList = new List<Calendar_Item>(from x in xe.Descendants("Element")
                                                 select new Calendar_Item(
                                x.Attribute("Date").Value.ToString(),
                                x.Attribute("Text").Value.ToString()));
                
            }
            catch (Exception)
            {
                MessageBox.Show("Κατί πήγε στραβά, Προσπάθησε ξανά");
            }
            return myList;
        }

        //όταν κλείσει η φόρμα αποθήκευσε τα στοιχεία στο αρχείο
        private void Calendar_FormClosing(object sender, FormClosingEventArgs e)
        {
            save("file.xml", myList);
        }
    }
}
