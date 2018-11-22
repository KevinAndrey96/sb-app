using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SocialBusinessApp
{
    public class RankI
    {
        public string Posicion { get; set; }
        public string Nombre { get; set; }
        public string Puntaje { get; set; }
        public string Medalla { get; set; }
        public string Fotografia { get; set; }
        public string Departamento { get; set; }
        public string Nit { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }

    }
}
