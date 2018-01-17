using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDMOLNETCDMOLNET_Final.Model
{
    public class Skiva
    {
       /* public Skiva(String id, String album, String ar)
        {
            this.Album = album;
            this.Ar = ar;
            this.Id = id;
            this.Lat = new List<Latar>();
        }*/
        public string Id { get; set; }
        public string Album { get; set; }
        public string Ar { get; set; }
        public string Coverart { get; set; }
        public string Genre { get; set; }
        public List<Latar> Lat { get; private set; }

    }
    public class Latar
    {
       /* public Latar(String nr, String title, String id)
        {
            this.Id = id;
            this.Nr = nr;
            this.Title = title;
        }*/
        public string Nr { get; set; }
        public string Title { get; set; }
        public string Id { get; set; }
    }
}
