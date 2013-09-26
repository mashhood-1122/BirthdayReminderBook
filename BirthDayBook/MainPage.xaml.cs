using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Text;
using Microsoft.Phone.Tasks;
using System.Windows.Media.Imaging;
using System.IO.IsolatedStorage;
using System.IO;
using System.Windows.Navigation;

namespace BirthDayBook
{
    public partial class MainPage : PhoneApplicationPage
    {
        private const string strConnectionString = @"isostore:/DB.sdf";
        //   private contactInfo obj;
        // Constructor
        List<contactInfo> te;
        public MainPage()
        {
            InitializeComponent();
            using (BdDataContext db = new BdDataContext(strConnectionString))
            {
                if (db.DatabaseExists() == true)
                {
                    test();
                }
            }
        }


        private void clk(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Email.xaml", UriKind.RelativeOrAbsolute));
        }

        private void asd(object sender, RoutedEventArgs e)
        {

        }

        private void tap(object sender, GestureEventArgs e)
        {

        }

        private void tap1(object sender, GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Page.xaml", UriKind.RelativeOrAbsolute));
        }


        void test()
        {
            try
            {
                te = new List<contactInfo>();
                List<DbClass> ContactList = this.GetList();

                foreach (DbClass contact in ContactList)
                {

                    String str = contact.bd_month + "/" + contact.bd_day + "/" + contact.bd_year;

                    int day = Convert.ToInt32(contact.bd_day);
                    int monthno = DateTime.Parse(contact.bd_month + " " + contact.bd_day + "," + contact.bd_year).Month;

                    DateTime nextBday = new DateTime(DateTime.Now.Year, monthno, day);
                    if (DateTime.Today > nextBday)
                        nextBday = nextBday.AddYears(1);

                    BitmapImage bi = new BitmapImage();

                    using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
                    {
                        using (IsolatedStorageFileStream fileStream = myIsolatedStorage.OpenFile(contact.Bd_ImageS, FileMode.Open, FileAccess.Read))
                        {
                            bi.SetSource(fileStream);
                            this.img.Height = bi.PixelHeight;
                            this.img.Width = bi.PixelWidth;
                        }
                    }


                    te.Add(new contactInfo(contact.Bd_Id.ToString(), contact.Bd_Name, contact.bd_address, contact.bd_phone, str, contact.bd_email, bi, (nextBday - DateTime.Today).Days));

                }
                this.DataContext = te;
            }
            catch (Exception e)
            {
                //  MessageBox.Show("" + e);
            }

        }

        public List<DbClass> GetList()
        {
            List<DbClass> bdlist = null;
            using (BdDataContext context = new BdDataContext(strConnectionString))
            {
                IQueryable<DbClass> query = from c in context.Member select c;
                bdlist = query.ToList();
            }
            return bdlist;
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            contactInfo data = (sender as ListBox).SelectedItem as contactInfo;
            ListBoxItem selectedItem = this.LB.ItemContainerGenerator.ContainerFromItem(data) as ListBoxItem;
            // MessageBox.Show(""+data.email);
            NavigationService.Navigate(new Uri("/details.xaml?id=" + data.pId + "&name=" + data.pName + "&email=" + data.pEmail + "&phone=" + data.pPhone + "&address=" + data.pAddress + "&date=" + data.pDate, UriKind.Relative));

        }

        private void tapa(object sender, GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/about.xaml", UriKind.RelativeOrAbsolute));
        }

        private void tap12(object sender, GestureEventArgs e)
        {
            EmailComposeTask emailComposeTask = new EmailComposeTask();
            emailComposeTask.To = "mashhood85@gmail.com";
            emailComposeTask.Subject = "Windows Phone 7 app - Feedback";
            emailComposeTask.Show();
        }

        private void rate(object sender, GestureEventArgs e)
        {
            MarketplaceReviewTask marketplaceReviewTask = new MarketplaceReviewTask();
            marketplaceReviewTask.Show();
        }

        private void asdasdasd(object sender, GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Page1.xaml", UriKind.RelativeOrAbsolute));
        }

        private void share_tap(object sender, GestureEventArgs e)
        {
            //NavigationService.Navigate(new Uri("/about.xaml", UriKind.RelativeOrAbsolute));
            popupMessage.IsOpen = true;
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.Back)
            {
                using (BdDataContext db = new BdDataContext(strConnectionString))
                {
                    if (db.DatabaseExists() == true)
                    {
                        Sorting1();
                    }
                }
            }
        }


        public static Exception Exception { get; set; }

        private void Via_Sms(object sender, RoutedEventArgs e)
        {

        }

        private void Via_email(object sender, RoutedEventArgs e)
        {

        }

        private void via_cancel(object sender, RoutedEventArgs e)
        {
            popupMessage.IsOpen = false;
        }

        private void Next_click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;  // sender is the button user clicked
            // MyDataObject data = b.DataContext as MyDataObject;
            contactInfo data = b.DataContext as contactInfo;
            ListBoxItem selectedItem = this.LB.ItemContainerGenerator.ContainerFromItem(data) as ListBoxItem;
            // MessageBox.Show(""+data.email);
            NavigationService.Navigate(new Uri("/details.xaml?id=" + data.pId + "&name=" + data.pName + "&email=" + data.pEmail + "&phone=" + data.pPhone + "&address=" + data.pAddress + "&date=" + data.pDate, UriKind.Relative));

        }

        private void Sorting(object sender, GestureEventArgs e)
        {
            Sorting1();
        }

        private void Sorting1()
        {
            using (BdDataContext db = new BdDataContext(strConnectionString))
            {
                if (db.DatabaseExists() == true)
                {
                    test();
                    var sortedMyObjects = te;

                    this.DataContext = sortedMyObjects.OrderBy(i => i.pName).ToList(); ;
                }
            }
        }

        private void Sorting2()
        {
            using (BdDataContext db = new BdDataContext(strConnectionString))
            {
                if (db.DatabaseExists() == true)
                {
                    test();
                    var sortedMyObjects = te;

                    this.DataContext = sortedMyObjects.OrderBy(i => i.dl).ToList(); ;
                }
            }
        }

        private void DaysLeft(object sender, GestureEventArgs e)
        {
            Sorting2();
        }
    }
}