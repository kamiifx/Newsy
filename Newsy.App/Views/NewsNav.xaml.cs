using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Newsy.App.DataService;
using Newsy.Model;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Newsy.App.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NewsNav : Page
    {
        UserAuth auth = new UserAuth();

        public NewsNav()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.userEmail.Text = auth.EmailUser;
            this.mainframe.Navigate(typeof(DailyNews));
            this.Daily.TextDecorations = TextDecorations.Underline;
        }

        private void DailyButton_OnClick(object sender, RoutedEventArgs e)
        {
            this.mainframe.Navigate(typeof(DailyNews));
            this.Daily.TextDecorations = TextDecorations.Underline;
            this.Search.TextDecorations = TextDecorations.None;
            this.Favorites.TextDecorations = TextDecorations.None;
        }

        private void FavoriteButton_OnClick(object sender, RoutedEventArgs e)
        {
            this.mainframe.Navigate(typeof(Favorite));
            this.Daily.TextDecorations = TextDecorations.None;
            this.Search.TextDecorations = TextDecorations.None;
            this.Favorites.TextDecorations = TextDecorations.Underline;
        }

        private void SearchButton_OnClick(object sender, RoutedEventArgs e)
        {
            this.mainframe.Navigate(typeof(Favorite));         
            this.Daily.TextDecorations = TextDecorations.None;
            this.Search.TextDecorations = TextDecorations.Underline;
            this.Favorites.TextDecorations = TextDecorations.None;
        }
    }
}
