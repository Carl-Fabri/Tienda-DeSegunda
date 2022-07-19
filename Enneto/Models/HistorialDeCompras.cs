using System;
using System.Collections.Generic;
using System.Text;

namespace Enneto.Models
{
    public class HistorialDeCompras
    {
        public int IdCarrito { get; set; }
        public int IdProducto { get; set; }
        public String NombreProducto { get; set; }
        public string Direccion1 { get; set; }
        public string Direccion2 { get; set; }
        public string Direccion3 { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioFinal { get; set; }
        public DateTime Fecha { get; set; }
    }
}
