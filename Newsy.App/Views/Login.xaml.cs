using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Newsy.App.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Login : Page
    {
        private UserAuth auth = new UserAuth();
        public Login()
        {
            this.InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Enabled;
            this.cancelbtn.Click += cancelbtn_Click;
            this.loginbtn.Click += Loginbtn_OnClick;

        }

        private void cancelbtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private async void Loginbtn_OnClick(object sender, RoutedEventArgs e)
        {
            string email = this.emailinput.Text.ToString();
            string password = this.passwordinput.Text.ToString();
            this.loading.IsActive = true;

            if (!await auth.LoginAuth(email, password)) 
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
