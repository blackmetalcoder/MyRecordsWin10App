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
using CDMOLNETCDMOLNET_Final.Model;
using CDMOLNET_Final.ServiceCD;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Animation;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace CDMOLNET_Final.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MinaPlattor : Page
    {
        private string ID;
        private Task<ObservableCollection<Artist>> Artister;
        private Artist _lastSelectedItem;
        public MinaPlattor()
        {
            this.InitializeComponent();
        }
        private Task<ObservableCollection<Artist>> GetA()
        {
            Artister = Artist.GetArtister();
            return Artister;
        }
        private void OnCurrentStateChanged(object sender, VisualStateChangedEventArgs e)
        {
            bool isNarrow = e.NewState == NarrowState;
            if (isNarrow)
            {
                Frame.Navigate(typeof(MinaPlattorDetail), _lastSelectedItem.artist, new SuppressNavigationTransitionInfo());
            }
        }

        private async void gArtist_SelectionChanged(object sender, Syncfusion.UI.Xaml.Grid.GridSelectionChangedEventArgs e)
        {
            var row = this.gArtist.SelectedItem;
            if (row != null)
            {
                var R = row as Artist;
                string s = R.artist;
                CDServiceSoapClient klient = new CDServiceSoapClient();
                var A = await klient.getAlbum10Async(ID, s);
                string albums = A.Body.getAlbum10Result;
                var j = JsonConvert.DeserializeObject<List<Album>>(albums);
                _lastSelectedItem = R;
                GridAlbum.ItemsSource = j;

                if(Frame.ActualWidth < 720)
                 {
                     Frame.Navigate(typeof(MinaPlattorDetail), _lastSelectedItem.artist, new SuppressNavigationTransitionInfo());
                 }
            }
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var j = await GetA();
            gArtist.ItemsSource = j;
            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            Object valueKonto = localSettings.Values["id"];
            if (valueKonto == null)
            {
                // No data
            }
            else
            {
                ID = valueKonto.ToString();
            }
        }
    }
    
}
