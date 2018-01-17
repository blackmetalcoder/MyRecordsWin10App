using CDMOLNET_Final.ServiceCD;
using CDMOLNETCDMOLNET_Final.Model;
using Newtonsoft.Json;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace CDMOLNET_Final.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MinaPlattorDetail : Page
    {
        public MinaPlattorDetail()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
        }
            protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            String ID = string.Empty;
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
            CDServiceSoapClient klient = new CDServiceSoapClient();
            var A = await klient.getAlbum10Async(ID, e.Parameter.ToString());
            string albums = A.Body.getAlbum10Result;
            var j = JsonConvert.DeserializeObject<List<Album>>(albums);
            listAlbums.ItemsSource = j;
        }
    }

}
