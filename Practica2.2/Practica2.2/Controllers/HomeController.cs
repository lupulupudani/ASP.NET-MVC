using Practica2._2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Practica2._2.Controllers
{
    public class HomeController : Controller
    {
        public String Index()
        {
            return "Página de Inicio de Jugadores";
        }
        public List<Jugador> CrearJugadores()
        {
            List<Jugador> listaJugadores = new List<Jugador>
            {
                new Jugador { JugadorId= 1, NombreApellidos= "Gerard Piqué", Posicion= "Defensa", Sueldo=375M},
                new Jugador { JugadorId= 2, NombreApellidos= "Iker Kasillas", Posicion= "Portero", Sueldo=156M},
                new Jugador { JugadorId= 3, NombreApellidos= "Andrés Iniesta", Posicion= "Medio Centro", Sueldo=276M},
                new Jugador { JugadorId= 4, NombreApellidos= "Alvaro Morata", Posicion= "Delantero", Sueldo=310M},
            };
            return listaJugadores;
        }

        public List<Jugador> InsertarJugador()
        {
            List<Jugador> lista = CrearJugadores();

            Jugador nuevojugador = new Jugador();
            nuevojugador.JugadorId = 5;
            nuevojugador.NombreApellidos = "Diego Costa";
            nuevojugador.Posicion = "Delantero";
            nuevojugador.Sueldo = 430M;
            lista.Add(nuevojugador);

            return lista;
        }

        public ActionResult MostrarJugadores()
        {
            List<Jugador> lista = CrearJugadores();
            var query =
                lista
                .Select(j => j)
                .OrderByDescending(j => j.NombreApellidos);

            StringBuilder result = new StringBuilder();
            foreach (var j in query)
            {
                //No me hace el salto de linea averiguar porque
                result.AppendLine(String.Format("Jugador : {0}",j.NombreApellidos + "," + j.Posicion + "," + j.Sueldo));
                //valor += result.ToString() + "\n\r";
                //result.Clear();
                //result.Insert(result.Length, String.Format("\n"));
            }
            return View("Index", (object)result.ToString());
        }
        public ActionResult MostrarMasGana()
        {
            List<Jugador> lista = CrearJugadores();
           
            var masgana =
                lista
                .Where(j => j.Sueldo.Equals(lista
                .Select(ju => ju.Sueldo)
                .Max()))
                .Select(j=>j.NombreApellidos)
                .FirstOrDefault();

            return View("Index", (object)String.Format("El que más gana es {0}", masgana.ToString()));
        }
        public ActionResult MostrarTotalSueldos()
        {
            List<Jugador> lista = CrearJugadores();

            var total =
                lista
                .Sum(j => j.Sueldo);

            return View("Index", (object)String.Format("El total de sueldos es {0}$", total.ToString()));
            
        }
        public ActionResult NuevoyMenosGanan()
        {
            List<Jugador> lista = InsertarJugador();
            var menosganan =
                lista
                .OrderBy(j => j.Sueldo)
                .Take(3)
                .Select(j => new { 
                    j.NombreApellidos,
                    j.Sueldo
                }).ToList();

            StringBuilder result = new StringBuilder();
            foreach (var p in menosganan)
            {
                result.AppendLine(String.Format("Jugador: {0}", p.NombreApellidos + " " + p.Sueldo));
            }
            return View("Index", (object)result.ToString());
        }

        public ActionResult MenorMedia()
        {
            List<Jugador> lista = InsertarJugador();

            var menormedia =
                lista
                .Where(j => j.Sueldo < lista
                    .Select(ju => ju.Sueldo)
                    .Average())
                .Select(j => new
                {
                    Jugador = j.NombreApellidos
                }).ToList();

            StringBuilder result = new StringBuilder();
            foreach (var p in menormedia)
            {
                result.AppendLine(String.Format("Jugador: {0}", p.Jugador));
            }
            return View("Index", (object)result.ToString());
        }
	}
}