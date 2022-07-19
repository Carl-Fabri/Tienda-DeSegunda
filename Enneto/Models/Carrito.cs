using System;
using System.Collections.Generic;
using System.Text;

namespace Enneto.Models
{
    public class Carrito
    {
        public int IdProducto { get; set; }
        public String NombreProducto { get; set; }
        public String ImagenProducto { get; set; }
        public int CantidaProducto { get; set; }
        public decimal Precio { get; set; }
        public bool HayOferta { get; set; }
        public decimal PrecioOferta { get; set; }
    }
}
