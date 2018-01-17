using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Contacts;
using CDMOLNET_Final.ServiceCD;
using CDMOLNETCDMOLNET_Final.Model;
using Newtonsoft.Json;

namespace CDMOLNETCDMOLNET_Final.Model
{
    public class Artist
    {
        public string artist { get; set; }

        public Artist()
        {
            artist = string.Empty;
        }

        public static Artist GetNewArtist(string A)
        {
            return new Artist()
            {
                artist = A
            };
        }
        public static async Task<ObservableCollection<Artist>> GetArtister()
        {
            ObservableCollection<Artist> Artister = new ObservableCollection<Artist>();
            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            CDServiceSoapClient klient = new CDServiceSoapClient();
            //Konto
            Object valueKonto = localSettings.Values["id"];
            if (valueKonto == null)
            {
                // No data
            }
            else
            {
                string ID = valueKonto.ToString();
                var ArtistLista = await klient.getArtist10Async(ID);
                string s = ArtistLista.Body.getArtist10Result;
                var j = JsonConvert.DeserializeObject<List<Artist>>(s);
                foreach (var item in j)
                {
                    Artister.Add(GetNewArtist(item.artist));
                }
            }
           
            return Artister;
        }
    }
}
