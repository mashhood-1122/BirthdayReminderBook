using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;
using System.Windows.Media.Imaging;
using Microsoft.Phone.Scheduler;
using System.Windows.Media;
using System.IO.IsolatedStorage;
using System.IO;

namespace BirthDayBook
{
    public partial class details : PhoneApplicationPage
    {
        private contactInfo obj;
        private String[] list = null;
        private string[] words = null;
        private string str1;
        private int min1 = 1;
        private int hr1 = 1;

        public details()
        {
            InitializeComponent();
            list = new String[] 
            {
                "http://en.wikipedia.org/wiki/Aquarius_%28astrology%29",
                "http://en.wikipedia.org/wiki/Pisces_%28astrology%29",
                "http://en.wikipedia.org/wiki/Aries_%28astrology%29",
                "http://en.wikipedia.org/wiki/Taurus_%28astrology%29",
                "http://en.wikipedia.org/wiki/Gemini_%28astrology%29",
                "http://en.wikipedia.org/wiki/Cancer_%28astrology%29",
                "http://en.wikipedia.org/wiki/Leo_%28astrology%29",
                "http://en.wikipedia.org/wiki/Virgo_%28astrology%29",
                "http://en.wikipedia.org/wiki/Libra_%28astrology%29",
                "http://en.wikipedia.org/wiki/Scorpio_%28astrology%29",
                "http://en.wikipedia.org/wiki/Sagittarius_%28astrology%29",
                "http://en.wikipedia.org/wiki/Capricorn_%28astrology%29"
            };
         //   min.Text = min1.ToString();
         //   hr.Text = hr1.ToString();

        }


        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
                string id = NavigationContext.QueryString["id"];
                string name = NavigationContext.QueryString["name"];
                string phone = NavigationContext.QueryString["phone"];
                string email = NavigationContext.QueryString["email"];
                string address = NavigationContext.QueryString["address"];
                string date = NavigationContext.QueryString["date"];
                ImageSource imgSource = null;//=// (ImageSource)NavigationContext.QueryString["img"];

                BitmapImage bi = new BitmapImage();

                using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    using (IsolatedStorageFileStream fileStream = myIsolatedStorage.OpenFile(name+".jpg", FileMode.Open, FileAccess.Read))
                    {
                        bi.SetSource(fileStream);
                        this.imgSet.Height = bi.PixelHeight;
                        this.imgSet.Width = bi.PixelWidth;
                    }
                }
                imgSource = bi;
                //MessageBox.Show(id + name + address + phone + date + email);
                this.obj = new contactInfo(id, name, address, phone, date, email, imgSource,0);
                tb_name.Text = obj.pName;
                tb_dob.Text = obj.pDate;
                words = date.Split('/');
                imgSet.Source = this.obj.pImage;
                //MessageBox.Show("1" + words[0]);
                Load(words[0], Convert.ToInt32(words[1]));
        }

        private void call_clk(object sender, RoutedEventArgs e)
        {
            PhoneCallTask pct = new PhoneCallTask();  
            pct.DisplayName = obj.pName;  
            pct.PhoneNumber = obj.pPhone;  
            pct.Show();
        }

        private void sms_clk(object sender, RoutedEventArgs e)
        {
            SmsComposeTask composeSMS = new SmsComposeTask();
            composeSMS.Body = "";
            composeSMS.To = obj.pPhone;
            composeSMS.Show();
        }

        private void email_clk(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Email.xaml?email=" +obj.pEmail+"&name="+obj.pName , UriKind.RelativeOrAbsolute)); 
        }

        private void Load(String str , int month) 
        {
            

            if (str.Equals( "1") && month < 20)
            {
                im_Zo.Source = new BitmapImage(new Uri("/Zodic/a12.png",UriKind.Relative));
                str1 = list[11];
            }
            else if ((str.Equals( "1") && month >= 20)|| (str.Equals("2") && month < 20))
            {
                im_Zo.Source = new BitmapImage(new Uri("/Zodic/a1.png", UriKind.Relative));
                str1 = list[0];
            }
            else if ((str.Equals("2") && month >= 20) || (str.Equals("3") && month < 21))
            {
                im_Zo.Source = new BitmapImage(new Uri("/Zodic/a2.png", UriKind.Relative));
                str1 = list[1];
            }
            else if ( (str.Equals("3") && month >= 21) || (str.Equals("4") && month < 21))
            {
                im_Zo.Source = new BitmapImage(new Uri("/Zodic/a3.png", UriKind.Relative));
                str1 = list[2];
            }
            else if ( (str.Equals("4") && month >= 21) || (str.Equals("5") && month < 21))
            {
                im_Zo.Source = new BitmapImage(new Uri("/Zodic/a4.png", UriKind.Relative));
                str1 = list[3];
            }
            else if ((str.Equals("5") && month >= 21) || (str.Equals("6") && month < 21))
            {
                im_Zo.Source = new BitmapImage(new Uri("/Zodic/a5.png", UriKind.Relative));
                str1 = list[4];
            }
            else if ((str.Equals("6") && month >= 21) || (str.Equals("7") && month < 23))
            {
                im_Zo.Source = new BitmapImage(new Uri("/Zodic/a6.png", UriKind.Relative));
                str1 = list[5];
            }
            else if ((str.Equals("7") && month >= 23) || (str.Equals("8") && month < 23))
            {
                im_Zo.Source = new BitmapImage(new Uri("/Zodic/a7.png", UriKind.Relative));
                str1 = list[6];
            }
            else if ( (str.Equals("8") && month >= 23) ||( str.Equals("9") && month < 23))
            {
                im_Zo.Source = new BitmapImage(new Uri("/Zodic/a8.png", UriKind.Relative));
                str1 = list[7];
             }
            else if (( str.Equals("9") && month >= 23) || (str.Equals("10") && month < 23))
            {
                im_Zo.Source = new BitmapImage(new Uri("/Zodic/a9.png", UriKind.Relative));
                str1 = list[8];
            }
            else if ((str.Equals("10") && month >= 23) || ( str.Equals("11") && month < 23))
            {
                im_Zo.Source = new BitmapImage(new Uri("/Zodic/a10.png", UriKind.Relative));
                str1 = list[9];
            }
            else 
            {
                im_Zo.Source = new BitmapImage(new Uri("/Zodic/a11.png", UriKind.Relative));
                str1 = list[10];
            }

           // MessageBox.Show(str + month);
        }

        private void b_Back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void asd(object sender, System.Windows.Input.GestureEventArgs e)
        {
           
        }

        private void tap_test(object sender, System.Windows.Input.GestureEventArgs e)
        {
         //  MessageBox.Show(""+str1);
           WebBrowserTask wbTask = new WebBrowserTask();
           wbTask.Uri = new Uri(str1, UriKind.RelativeOrAbsolute);
           wbTask.Show();
           
        }

        //private void tapUp1(object sender, System.Windows.Input.GestureEventArgs e)
        //{
        //}

        //private void tapDown1(object sender, System.Windows.Input.GestureEventArgs e)
        //{

        //    if (hr.Text == "12")
        //    {
        //        this.hr1 = 1;
        //        hr.Text = "" + this.hr1;

        //    }
        //    else
        //    {
        //        hr1++;
        //        hr.Text = "" + this.hr1;
        //    }
        //}

        //private void tapUp(object sender, System.Windows.Input.GestureEventArgs e)
        //{

        //    if (min1 == 1)
        //    {
        //        this.min1 = 12;
        //        min.Text = "" + this.min1;

        //    }
        //    else
        //    {
        //        hr1--;
        //        min.Text = "" + this.min1;
        //    }
        //}

        //private void tapDown2(object sender, System.Windows.Input.GestureEventArgs e)
        //{

        //    if (min1 == 60)
        //    {
        //        this.min1 = 1;
        //        min.Text = "" + this.min1;

        //    }
        //    else
        //    {
        //        min1++;
        //        min.Text = "" + this.min1;
        //    }

        //}

        //private void b_clk(object sender, RoutedEventArgs e)
        //{
        //    if (b_c.Content.Equals( "AM"))
        //    {
        //        b_c.Content = "PM";
        //    }
        //    else
        //    {
        //        b_c.Content ="AM";
        //    }
        //}

        private void Reminderclk(object sender, RoutedEventArgs e)
        {



            if (timeDate.Value == null)
            {
                MessageBox.Show("Invalid Time ..!! ");
            }
            else
            {

                String[] str = timeDate.Text.ToString().Split(' ');
                String[] str1 = str[1].Split(':');

                String Hr = str1[0];
                String Min = str1[1];
                String am_pm = str[2];

                // 9/16/2013 7:11:58 pm
                String[] bd = this.obj.pDate.Split('/');
                int mon = DateTime.Parse(bd[0] + " " + bd[1] + "," + bd[2]).Month;

                string date = mon + "/" + bd[1] + "/" + DateTime.Now.Year;

                int a = 0;
                // int year = DateTime.Now.Year;
                DateTime nextBday = new DateTime(DateTime.Now.Year, mon, Convert.ToInt32(bd[1]));

                if (DateTime.Today > nextBday)
                {
                    ///   nextBday = nextBday.AddYears(1);
                    a = DateTime.Now.Year;
                    a++;
                    date = mon + "/" + bd[1] + "/" + a;

                }

                 String tm = Hr+ ":" +Min + ":00 " + am_pm;

               // String tm = hr.Text.ToString() + ":" + min.Text.ToString() + ":00 " + b_c.Content.ToString();
                 MessageBox.Show(date + " " + tm);

                 if (ScheduledActionService.Find(this.obj.pName) != null)
                     ScheduledActionService.Remove(this.obj.pName);

                 Alarm alr = new Alarm(this.obj.pName)
                 {
                     Content = this.obj.pName,
                     BeginTime = Convert.ToDateTime(date + " " + tm)

                 };

                 //MessageBox.Show(alr.BeginTime.ToString());
                 ScheduledActionService.Add(alr);

                 //MessageBox.Show(str[0] + "   " + str[1] + " ");
                 //MessageBox.Show("" + nextBday);
               //  int monthno = DateTime.Parse(contact.bd_month + " " + contact.bd_day + "," + contact.bd_year).Month;
            }
        }

        //private void hrup(object sender, System.Windows.Input.GestureEventArgs e)
        //{

        //    if (hr.Text.Equals("1"))
        //    {
        //        this.hr1 = 12;
        //        hr.Text = "" + this.hr1;

        //    }
        //    else
        //    {
        //        hr1--;
        //        hr.Text = "" + this.hr1;
        //    }
        //}
    }
}