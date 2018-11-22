using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialBusinessApp
{
    public class PerfilUsuario
    {
        public string Nombre { get; set; }
        public string Inmobiliaria { get; set; }
        public string Nit { get; set; }
        public string FotografiaPersonal { get; set; }
        public string FotografiaInmobiliaria { get; set; }
        public string Celular { get; set; }
        public string Correo { get; set; }
        public string Codigo { get; set; }

        public string Posicion { get; set; }
        public string Puntaje { get; set; }


        public override string ToString()
        {
            return base.ToString();
        }
    }
}