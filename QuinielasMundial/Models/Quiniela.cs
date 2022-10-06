using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuinielasMundial.Models
{
    public class Quiniela
    {
        public int idQui { get; set; }
        public string quiniela { get; set; }
        public int idLiga { get; set; }
        public int idUsuario { get; set; }
    }
}