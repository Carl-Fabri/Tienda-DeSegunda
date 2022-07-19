using System;
using System.Collections.Generic;
using System.Text;


namespace Enneto
{
    public class Producto
    {

        public int id { get; set; }

        public int idCategoria { get; set; }

        public string NombreProducto { get; set; }

        public string Descripcion { get; set; }

        public string categoria { get; set; }

        public double Precio { get; set; }

        public float Oferta { get; set; }
        public float Calificacion { get; set; }

        public string Imagen { get; set; }

        public string Estado { get; set; }

        public bool EstaEnOferta
        {
            get
            {
                return Oferta < Precio;
            }
        }

    }
}
