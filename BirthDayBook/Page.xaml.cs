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
using Microsoft.Phone;
using System.Windows.Media.Imaging;
using System.IO.IsolatedStorage;
using System.Windows.Resources;
using Microsoft.Xna.Framework.Media;
using System.IO;
using System.Windows.Media;

namespace BirthDayBook
{
    public partial class Page : PhoneApplicationPage
    {
        private CameraCaptureTask ccTask;
        private const string strConnectionString = @"isostore:/DB.sdf";

        //private String[] Months = { "January","February","March","April","May","June","July","August","September","October","November","December"};
        //private int Date = 1;
        //int year = 2013;
        private int id = 0;

        int i = 0;
        public Page()
        {
            InitializeComponent();
            //month.Text = Months[i];
            //Date1.Text = ""+this.Date;
            ccTask = new CameraCaptureTask();
            ccTask.Completed += ccTaskCompleted;

            using (BdDataContext db = new BdDataContext(strConnectionString))
            {
                if (db.DatabaseExists() == false)
                {
                    db.CreateDatabase();
                //    MessageBox.Show("Database Created Successfully!!!");
                }
                else
                {
               //     MessageBox.Show("Database already exists!!!");
                }
            }
            
        }

        //private void MonthtapDown(object sender, System.Windows.Input.GestureEventArgs e)
        //{
        //    if (i==11)
        //    {
        //        this.i = 0;
        //        month.Text = Months[i];

        //    }
        //    else
        //    {
        //        month.Text = Months[i++];

        //    }
        //}


        private void selectphoto_Completed(object sender, PhotoResult e)
        {
            if (e.TaskResult == TaskResult.OK)
            {
                Uri backgroundUri = new Uri(e.OriginalFileName, UriKind.Absolute);
                var bitmap = new BitmapImage(backgroundUri);
                ImageBrush imageBrush = new ImageBrush();
                imageBrush.ImageSource = bitmap;
                this.Camera.Source = bitmap;
            }
          popupMessage.IsOpen = false;
        }

        private void ccTaskCompleted(object sender, PhotoResult pr)
        {
            byte[] imgLocal;
            if (pr.ChosenPhoto != null)
            {
                imgLocal = new byte[(int)pr.ChosenPhoto.Length];
                pr.ChosenPhoto.Read(imgLocal, 0, imgLocal.Length);
                pr.ChosenPhoto.Seek(0, System.IO.SeekOrigin.Begin);
                var bitmapImage = PictureDecoder.DecodeJpeg(pr.ChosenPhoto);
                this.Camera.Source = bitmapImage;
            }
            popupMessage.IsOpen = false;
        }

 
        //private void MonthtapUp(object sender, System.Windows.Input.GestureEventArgs e)
        //{
        //    if (i == 0)
        //    {
        //        this.i = 11;
        //        month.Text = Months[i];
        //    }
        //    else
        //    {
        //        month.Text = Months[i--];
        //    }
        //}


        //private void tapUp(object sender, System.Windows.Input.GestureEventArgs e)
        //{
        //    if (Date == 1)
        //    {
        //        this.Date = 31;
        //        Date1.Text = ""+this.Date;

        //    }
        //    else
        //    {
        //        Date--;
        //        Date1.Text = "" + this.Date;
        //    }
        //}

        //private void tapDown(object sender, System.Windows.Input.GestureEventArgs e)
        //{
        //    if (Date == 31)
        //    {
        //        this.Date = 1;
        //        Date1.Text = "" + this.Date;

        //    }
        //    else
        //    {
        //        Date++;
        //        Date1.Text = "" + this.Date;
        //    }
        //}
        //private void klk(object sender, RoutedEventArgs e)
        //{

       

        //}

        private void cancel_tap(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
            // NavigationService.RemoveBackEntry();
            //NavigationService.Navigate(new Uri("MainPage.xaml", UriKind.RelativeOrAbsolute));

        }
          
        private void Image_SizeChanged(object sender, SizeChangedEventArgs e)
        {

        }

        private void test_tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (tb_name.Text=="")
            {
                MessageBox.Show("Name is Missing");
            }
            else if (DateCheck.Value== null)
            { 
                MessageBox.Show("Must Enter D.O.B");
            }
            else 
            {
                //"2013 12:00:00 AM"
                String[] str = DateCheck.Text.ToString().Split('/');
                String Month11 = str[0];
                String Date11 = str[1];

                String []str1 = str[2].Split(' ');
                String year = str1[0];

                IList<DbClass> EmployeesList = this.GetList();
                foreach (DbClass emp in EmployeesList)
                {
                    id = emp.Bd_Id;
                    // strBuilder.AppendLine("Name - " + emp.EmployeeName + " Age - " + emp.EmployeeAge);
                }
                id++;
                using (BdDataContext db = new BdDataContext(strConnectionString))
                {
                    DbClass newMember = new DbClass
                    {
                        Bd_Id = id,
                        Bd_Name = tb_name.Text.ToString(),
                        bd_phone = tb_mob.Text.ToString(),
                        bd_address = tb_address.Text.ToString(),
                        bd_email = tb_Email.Text.ToString(),
                        bd_month = Month11,
                        bd_day = Date11,
                        bd_year = year,
                        Bd_ImageS = tb_name.Text.ToString() + ".jpg"
                    };

                    try
                    {
                        using (var isf = IsolatedStorageFile.GetUserStoreForApplication())
                        {
                            if (isf.FileExists(tb_name.Text.ToString() + ".jpg"))
                                isf.DeleteFile(tb_name.Text.ToString() + ".jpg");
                            using (var isfs = isf.CreateFile(tb_name.Text.ToString() + ".jpg"))
                            {
                                var bmp = new WriteableBitmap(Camera,
                                                Camera.RenderTransform);
                                bmp.SaveJpeg(isfs, bmp.PixelWidth, bmp.PixelHeight, 0, 100);
                            }
                        }
                    }
                    catch (Exception exc)
                    {
                        //  MessageBox.Show(exc.Message);
                    }
                    db.Member.InsertOnSubmit(newMember);
                    db.SubmitChanges();
                    MessageBox.Show("Added Successfully!!!");
                    tb_name.Text = "";
                    tb_mob.Text = "";
                    tb_address.Text = "";
                    tb_Email.Text = "";
                    DateCheck.Value = null;
                    Camera.Source = new BitmapImage(new Uri("/snip.png", UriKind.Relative)); ;


                }
            }
        }
    
            

            // Create virtual store and file stream. Check for duplicate tempJPEG files.

        public IList<DbClass> GetList()
        {
            IList<DbClass> bdlist = null;
            using (BdDataContext context = new BdDataContext(strConnectionString))
            {
                IQueryable<DbClass> query = from c in context.Member select c;
                bdlist = query.ToList();
            }
            return bdlist;
        }

        private void Cam_tap(object sender, RoutedEventArgs e)
        {
            ccTask.Show();
        }

        private void taP_cam(object sender, System.Windows.Input.GestureEventArgs e)
        {
            popupMessage.IsOpen = true;
           // ccTask.Show();
        }

        private void c_clk(object sender, RoutedEventArgs e)
        {
            ccTask.Show();
        }

        private void L_clk(object sender, RoutedEventArgs e)
        {
            PhotoChooserTask selectphoto = new PhotoChooserTask();
            selectphoto.Completed += new EventHandler<PhotoResult>(selectphoto_Completed);
            selectphoto.Show();

        }

        }

}
      

       