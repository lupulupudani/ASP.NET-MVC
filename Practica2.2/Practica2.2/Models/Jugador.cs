using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practica2._2.Models
{
    public class Jugador
    {
        public int JugadorId { get; set; }
        public string NombreApellidos { get; set; }
        public string Posicion { get; set; }
        public decimal Sueldo { get; set; }

    }
}