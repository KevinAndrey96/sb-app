using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialBusinessApp
{
    public class Oferta
    {
        public string ID { get; set; }
        public string UserId { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public string Precio { get; set; }
        public string Area { get; set; }
        public string Banos { get; set; }
        public string Parqueaderos { get; set; }
        public string Habitaciones{ get; set; }
        public string ABHP { get; set; }
        public string Ciudad { get; set; }
        public string Fotografia { get; set; }

        public string Direccion { get; set; }
        public string Barrio { get; set; }
        public string Departamento { get; set; }
        public string Tipo { get; set; }
        public string Ubicacion { get; set; }
        public string Estrato { get; set; }
        public string Antiguedad { get; set; }
        public string Descripcion { get; set; }

        public string Lat{ get; set; }
        public string Long { get; set; }

        public string Youtube { get; set; }
        public string Categoria { get; set; }
        public string Terceria { get; set; }

        public string Number { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
        private void OnClick_u()
        {
            //DisplayAlert("1", "2", "3");
        }
    }
}
