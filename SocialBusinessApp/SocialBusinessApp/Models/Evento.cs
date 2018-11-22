using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialBusinessApp.Models
{
    public class Evento
    {
        public string Nombre { get; set; }
        public string HoraI { get; set; }
        public string HoraF { get; set; }
        public string Departamento { get; set; }
        public string Ciudad { get; set; }
        public string Direccion { get; set; }
        public string Puntos { get; set; }
        public string Cupos { get; set; }
        public string Fecha { get; set; }
        public string Descripcion { get; set; }
        public string Creacion { get; set; }
        public string CuposDisponibles { get; set; }
        public string Fotografia { get; set; }
        

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
