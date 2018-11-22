using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialBusinessApp
{

    public class Lugares
    {

        public String Nombre { get; set; }
        public String Direccion { get; set; }
        public String Postal { get; set; }
        public String Telefono { get; set; }
        
    }
    public class RootObject
    {
        public List<Lugares> Dato { get; set; }
    }
}
