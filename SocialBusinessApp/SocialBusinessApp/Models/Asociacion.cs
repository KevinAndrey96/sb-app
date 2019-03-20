using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialBusinessApp.Models
{
    public class Asociacion
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Departamento { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }
        public string Afiliados { get; set; }

        public string Fotografia { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }

    }
}
