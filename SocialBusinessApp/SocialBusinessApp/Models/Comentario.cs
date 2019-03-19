using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialBusinessApp.Models
{
    public class Comentario
    {
        public string Autor { get; set; }
        public string Texto { get; set; }
        public string Fotografia { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
