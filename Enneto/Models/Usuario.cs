using System;
using System.Collections.Generic;
using System.Text;

namespace Enneto.Models
{
    public class Usuario
    {

        public int idUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Email { get; set; }
        public string Contraseña { get; set; }
        public int Edad { get; set; }

    }
}
