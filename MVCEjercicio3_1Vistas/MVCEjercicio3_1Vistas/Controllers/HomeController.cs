using MVCEjercicio3_1Vistas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCEjercicio3_1Vistas.Controllers
{
    public class HomeController : Controller
    {
        Persona persona = new Persona
        {
            IdPersona = 1,
            Nombre = "Pepe",
            Edad = 25,
            Profesion = "Programador",
            Sueldo = 3500
        };
        // GET: Home
        public ActionResult Index()
        {
            return View(persona);
        }
        public ViewResult Impuestos()
        {
            ViewBag.Hijo = true;
            ViewBag.Porcentaje = 10;
            return View(persona);
        }
        public ViewResult ArrayPersona()
        {
            Persona[] array =
            {
                new Persona{IdPersona=2, Nombre="Juan", Edad=31, Profesion="Informatico", Sueldo=1200},
                new Persona{IdPersona=3, Nombre="Felipe", Edad=35, Profesion="Cocinero", Sueldo=1100},
                new Persona{IdPersona=4, Nombre="Pablo", Edad=41, Profesion="Profesor", Sueldo=1400},
                new Persona{IdPersona=5, Nombre="Daniel", Edad=24, Profesion="Director", Sueldo=1450}
            };
            return View(array);
        }
       
    }
}