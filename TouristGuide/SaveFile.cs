using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TouristGuide
{
    class SaveFile
    {
        public static void SaveMyFile(RichTextBox textbox)  //σώσε σε αρχείο PDF
        {
            // Δημιουργία SaveFileDialog  (προτρέπει τον χρήστη να δηλώσει μια τοποθεσία για να σώσει το αρχείο).
            SaveFileDialog saveFile1 = new SaveFileDialog();

            // Αρχικοποίηση του SaveFileDialog για να δηλώσουμε την κατάληξη που θα έχει το αρχείο.
            saveFile1.DefaultExt = "*.pdf";
            saveFile1.Filter = "(*.pdf)|*.pdf";

            // Καθορίζουμε (ελέγχουμε) εαν ο χρήστης έχει επιλέξει ένα όνομα αρχείου από το saveFileDialog.
            if (saveFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK && saveFile1.FileName.Length > 0)
            {
                // σώσιμο των περιεχομένων του RichTextBox στο αρχείο.  // iTextSharp : βιβλιοθήκη του VS -> την χρειαζόμαστε
                iTextSharp.text.Document doc = new iTextSharp.text.Document();
                PdfWriter.GetInstance(doc, new FileStream(saveFile1.FileName, FileMode.Create));

                //UTF8  ->Ελληνικοί χαρακτήρες
                string sylfaenpath = Environment.GetEnvironmentVariable("SystemRoot") + "\\fonts\\sylfaen.ttf";
                BaseFont sylfaen = BaseFont.CreateFont(sylfaenpath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                iTextSharp.text.Font head = new iTextSharp.text.Font(sylfaen, 12f);

                doc.Open();
                doc.Add(new iTextSharp.text.Paragraph(textbox.Text, head));
                doc.Close();

            }
        }
    }
}
