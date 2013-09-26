
using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Data.Linq.Mapping;
using System.Data.Linq;

namespace BirthDayBook
{
  
        [Table]
        public class DbClass
        {
            [Column(IsPrimaryKey = true)]
            public int Bd_Id 
            {
                get;
                set;
            }
           
            [Column(CanBeNull = false)]
             public string Bd_Name
            {
                get;
                set;
            }
            
            [Column(CanBeNull = false)]
            public string bd_phone
            {
                get;
                set;
            }

            [Column(CanBeNull = false)]
            public string bd_address
            {
                get;
                set;
            }


            [Column(CanBeNull = false)]
            public string bd_email
            {
                get;
                set;
            }

            [Column(CanBeNull = false)]
            public string bd_month
            {
                get;
                set;
            }

            [Column(CanBeNull = false)]
            public string bd_day
            {
                get;
                set;
            }

            [Column(CanBeNull = false)]
            public string bd_year
            {
                get;
                set;
            }

            [Column(CanBeNull = false)]
            public String  Bd_ImageS
            {
                get;
                set;
            }


        }
    
}
