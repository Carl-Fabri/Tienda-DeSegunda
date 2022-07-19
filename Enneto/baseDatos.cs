using Enneto.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Enneto
{
    public static class baseDatos
    {
        public static UsuarioResponse Perfil = new UsuarioResponse() {
            Username = "Invitado@Correo.com",
            Password = "",
            FirstName = "Invitado",
            LastName = "",
            Avatar = "ImagenEjemplo.png"
        };

        private static List<Carrito> productos;




        public static List<Carrito> Productos
        {
            get
            {
                if (productos == null) productos = new List<Carrito>();

                return productos;
            }
            set
            {
                productos = value;
            }
        }

        private static List<HistorialDeCompras> carritos;
        public static List<HistorialDeCompras> Carritos 
        {
            get
            {
                if (carritos == null) carritos = new List<HistorialDeCompras>();

                return carritos;
            }
            set
            {
                carritos = value;
            }
        }

        public static bool EstaAutenticado { get; set; }



    }

}

