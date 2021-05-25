using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Newsy.App.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DailyNews : Page
    {
        public ObservableCollection<Model.DailyNews> Daily { get; set; }
        private DataAccess.DailyNews news = new DataAccess.DailyNews();
        public DailyNews()
        {
            this.InitializeComponent();
            Daily = new ObservableCollection<Model.DailyNews>();
            Loaded += Page_Loaded;
        }

        public async Task initNews()
        {
            DataAccess.DailyNews news = new DataAccess.DailyNews();
            var dailyNews = await news.LoadNews();

            foreach (var dailnew in dailyNews)
            {
                Daily.Add(dailnew);
            }
        }


        private async void Page_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            await initNews();
        }
    }
}
