using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Newsy.App.DataService;
using Newsy.App.Views;
using DailyNews = Newsy.App.DataAccess.DailyNews;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Newsy.App
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private UserAuth auth = new UserAuth();
        private DailyNews news = new DailyNews();
        public MainPage()
        {
            this.InitializeComponent();
            //news.LoadNews();
            this.registerbtn.Click += registerbtn_Click;
            this.loginbtn.Click += Loginbtn_OnClick;
        }

        private void registerbtn_Click(object sender, RoutedEventArgs e) { this.Frame.Navigate(typeof(Register)); }
        private void Loginbtn_OnClick(object sender, RoutedEventArgs e) { this.Frame.Navigate(typeof(Login)); }

        private async void outlookbtn_Click(object sender, RoutedEventArgs e)
        {
            this.loading.IsActive = true;
            if (!await auth.OutlookLogin())
            {
                System.Diagnostics.Debug.WriteLine("Something Went Wrong..");
                this.loading.IsActive = false;

            }
            else
            {
                this.Frame.Navigate(typeof(NewsNav));
            }
            
        }
    }
}
