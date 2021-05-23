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
using Newsy.Model;
using Newtonsoft.Json;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Newsy.App.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Register : Page
    {
        public Register()
        {
            this.InitializeComponent();
            this.cancelbtn.Click += cancelbtn_Click;
            this.regibtn.Click += Regibtn_OnClick;

        }

        private void cancelbtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void Regibtn_OnClick(object sender, RoutedEventArgs e)
        {
            UserAuth auth = new UserAuth();
            string email = this.email.Text.ToString();
            string password = this.password.Text.ToString();

            User newuser = new User()
            {
                Email = email,
                Password = password
            };

            if (this.password.Text.Length < 6)
            {
                this.errormsg.Text = "Password to Short";
            }
            else
            {
                auth.RegisterUser(newuser);
            }

        }
    }
}
