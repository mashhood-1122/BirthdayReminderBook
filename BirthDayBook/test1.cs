using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace BirthDayBook
{
    public class contactInfo
    {
        public String pId { get; set; }
        public String pName { get; set; }
        public String pAddress { get; set; }
        public String pPhone { get; set; }
        public String pDate { get; set; }
        public String pEmail { get; set; }
        public ImageSource pImage { get; set; }
        public int dl { get; set; }

        public contactInfo(String id, String name, String address, String phone, String date, String email, ImageSource ppimage , int a )
        {
            this.pId = id;
            this.pName = name;
            this.pAddress = address;
            this.pPhone = phone;
            this.pDate= date;
            this.pEmail = email;
            this.pImage = ppimage;
            this.dl = a;

        }

    }
}
