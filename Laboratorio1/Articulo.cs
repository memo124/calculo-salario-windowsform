using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio1
{
    public class Articulo
    {
        public  Articulo(int id, string articulo,double precio) {
            this.id = id;
            this.articulo = articulo;
            this.precio = precio;
        }
        public int id { get; set; }
        public string articulo { get; set; }
        public double precio { get; set; }
    }
}
