using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouristGuide
{
    public partial class storeData
    {
        public int Id;
        public string text;
        public string photoId1;
        public string photoId2;
        public string photoId3;
        public string photoId4;
        public string photoId5;

        public storeData(int Id, string text, string photoId1, string photoId2, string photoId3, string photoId4, string photoId5)
        {
            this.Id = Id;
            this.text = text;
            this.photoId1 = photoId1;
            this.photoId2 = photoId2;
            this.photoId3 = photoId3;
            this.photoId4 = photoId4;
            this.photoId5 = photoId5;
        }



        public storeData()
        {
        }

        public int storeId()
        {
            return Id;
        }

        public string getText()
        {
            return text;
        }

        public string getphotoId1()
        {
            return photoId1;
        }

        public string getphotoId2()
        {
            return photoId2;
        }

        public string getphotoId3()
        {
            return photoId3;
        }

        public string getphotoId4()
        {
            return photoId4;
        }

        public string getphotoId5()
        {
            return photoId5;
        }

    }
}
