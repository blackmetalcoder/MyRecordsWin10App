using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDMOLNETCDMOLNET_Final.Model
{
    public class Lat
    {
        public string Nr { get; set; }
        public string Title { get; set; }
        public string Id { get; set; }
    }

    public class RootAlbum
    {
        public string Id { get; set; }
        public string Album { get; set; }
        public string Ar { get; set; }
        public string Coverart { get; set; }
        public string Genre { get; set; }
        public List<Lat> Lat { get; set; }
    }
}
