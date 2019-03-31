using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialBusinessApp.Models
{
    public class InmobiliariaO
    {
        public string Nombre { get; set; }

        public override string ToString()
        {
            return Nombre.ToString();
        }
    }
}
