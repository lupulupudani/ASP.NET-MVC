using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCEjercicio3_1Vistas.Models
{
    public class Persona
    {
        public int IdPersona { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Profesion { get; set; }
        public int Sueldo { get; set; }
    }
}