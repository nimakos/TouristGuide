using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouristGuide
{
    
    class Calendar_Item
    {
        public string date;
        public string text;


        public Calendar_Item(string date, string text) 
        {
            this.date = date;
            this.text = text;
        }       

        public string Date
        {
            get
            {
                return date;
            }
           
        }
        public string Text
        {
            get
            {
                return text;
            }
            
        }
    }
}
