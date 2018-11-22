using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialBusinessApp
{

    public class Dato
    {
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Postal { get; set; }
        public string Telefono { get; set; }
    }

    public class PlacesResult
    {
        public List<Dato> Dato { get; set; }
    }
}
