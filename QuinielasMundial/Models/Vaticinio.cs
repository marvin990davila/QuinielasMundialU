using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuinielasMundial.Models
{
    public class Vaticinio
    {
        public int idVaticinio { get; set; }
        public int idPersona { get; set; }
        public int idQui { get; set; }
        public int idEquipo1 { get; set; }
        public int idEquipo2 { get; set; }
        public int resultado1 { get; set; }
        public int resultado2 { get; set; }
        public DateTime fechaVaticinio { get; set; }
    }
}