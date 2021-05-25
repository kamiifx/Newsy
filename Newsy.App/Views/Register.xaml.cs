using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public sealed partial class Register : Page, INotifyPropertyChanged
    {
        UserAuth auth = new UserAuth();

        public event PropertyChangedEventHandler PropertyChanged;

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
            "Text", typeof(string), typeof(MainPage), new PropertyMetadata(default(string)));


        public string ErrorMessage
        {
            get { return (string) GetValue(TextProperty);}
            set
            {
                SetValue(TextProperty,value);
                OnPropertyChanged("ErrorMessage");
            }
            
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public Register()
        {
            this.InitializeComponent();
            //ErrorMessage = auth.ErrorMsg;
            this.cancelbtn.Click += cancelbtn_Click;
            this.regibtn.Click += Regibtn_OnClick;

        }

        private void cancelbtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private async void Regibtn_OnClick(object sender, RoutedEventArgs e)
        {
            string email = this.email.Text.ToString();
            string password = this.password.Password.ToString();
            User newuser = new User()
            {
                Email = email,
                Password = password
            };
            this.loading.IsActive = true;
            if (!await auth.RegisterUser(newuser))
            {
                this.loading.IsActive = false;
                this.errormsg.Text = "User Already Exsist";
            }
            else
            {
                this.Frame.Navigate(typeof(Login));
            }
        }
    }
}
