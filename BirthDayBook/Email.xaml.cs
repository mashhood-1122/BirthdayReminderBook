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

namespace BirthDayBook
{
    public partial class Email : PhoneApplicationPage
    {
        private string name="";
        private string email="";
        private string[] ecard1;
        private int i = 0;
        private string file = "";

        public Email()
        {
            InitializeComponent();
            ecard1 = new string[]{
                "png/card_1.png",
                "png/card_2.png",
                "png/card_3.png",
                "png/card_4.png",
                "png/card_5.png",
                "png/card_6.png",
                "png/card_7.png",
                "png/card_8.png",
                "png/card_9.png",
                "png/card_10.png",
                "png/card_11.png",
                "png/card_12.png",
                "png/card_13.png",
                "png/card_14.png",
                "png/card_15.png",               
            };

        }


        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
             name = NavigationContext.QueryString["name"];
             email = NavigationContext.QueryString["email"];
             tb1.Text = email;
             tb2.Text = name + "  Happy BirthDay";
           
         //   MessageBox.Show( name +  email);
          
        }

        private void send_mail(object sender, RoutedEventArgs e)
        {
            //MailMessage message = new MailMessage(
            //   "jane@contoso.com",
            //   "ben@contoso.com",
            //   "Quarterly data report.",
            //   "See the attached spreadsheet.");
            //Attachment data = new Attachment(file, MediaTypeNames.Application.Octet);

            EmailComposeTask emailcomposer = new EmailComposeTask();
 	        emailcomposer.To = tb1.Text.ToString();
            emailcomposer.Subject = tb2.Text.ToString();
             BitmapImage obj = new BitmapImage(new Uri(ecard1[i], UriKind.Relative));
            emailcomposer.Body = tb3.Text.ToString() + obj ;
 	        emailcomposer.Show();
        }

        //private void click(object sender, RoutedEventArgs e)
        //{
        //    NavigationService.GoBack(); 
        //}

        private void click(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.GoBack(); 
        }

        private void tapssas(object sender, System.Windows.Input.GestureEventArgs e)
        {
            popupMessage.IsOpen = true;
        }

        private void previous(object sender, RoutedEventArgs e)
        {
            if (i == 0)
            {
                i = 14;

            }
            else
            {
                i--;
            }
            ecard.Source = new BitmapImage(new Uri(ecard1[i], UriKind.Relative)); 

        }

        private void next(object sender, RoutedEventArgs e)
        {
            if (i==14)
            {
                i = 0;
            }
            else 
            {
                i++;
            }
            ecard.Source = new BitmapImage(new Uri(ecard1[i], UriKind.Relative)); 
        }

        private void sele(object sender, RoutedEventArgs e)
        {
            file = ecard1[i];
            popupMessage.IsOpen = false;


        }

        private void canc(object sender, RoutedEventArgs e)
        {
            popupMessage.IsOpen = false;
        }
    }
}