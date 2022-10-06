using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuinielasMundial.Models
{
    public class Usuario
    {
        public int idUsuario { get; set; } 
        public string nombreUsuario { get; set; }
        public string contrasena { get; set; }
        public int idPersona { get; set; }
    }
}