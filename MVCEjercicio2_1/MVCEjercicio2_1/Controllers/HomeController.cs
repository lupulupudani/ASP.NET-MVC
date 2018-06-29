using MVCEjercicio2_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MVCEjercicio2_1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        //public ActionResult Index()
        //{
        //    return View();
        //}
        public string Index()
        {
            return "Ejercicio 2.1 MVC";
        }
        public ViewResult CrearCoche()
        {
            Coche cocheNuevo = new Coche
            {
                Marca = "Seat",
                Modelo = "Leon",
                Color = "Negro"
            };
            return View("Index", (object)String.Format("Coche Nuevo: Marca: {0}\n Modelo: {1}\n Color: {2}",cocheNuevo.Marca, cocheNuevo.Modelo, cocheNuevo.Color));
        }
        public ViewResult CrearCliente()
        {
            string[] stringArray = { "Juan", "Miguel", "Javier" };
            return View("Index", (object)stringArray[1].ToString());
        }
        public ViewResult CrearArrayCoche()
        {
            Coche[] cocheArray =
            {
                new Coche{Marca="Opel", Modelo="Astra", Color="Negro"},
                new Coche{Marca="Citroen", Modelo="C4", Color="Blanco"},
                new Coche{Marca="Renault", Modelo="Clio", Color="Rojo"}
            };
            
            var coche = from c in cocheArray
                        orderby c.Marca descending
                        select c;
            StringBuilder result = new StringBuilder();
            foreach (var c in coche)
            {
                result.AppendFormat("{0}, {1}, {2}", c.Marca, c.Modelo, c.Color);
            }
            return View("Index", (object)result.ToString());
        }
        public ViewResult CalcularMedia()
        {
            Coche[] cocheArray =
            {
                new Coche{Marca="Opel", Modelo="Astra", Color="Negro", Precio=16500M},
                new Coche{Marca="Citroen", Modelo="C4", Color="Blanco", Precio=18750M},
                new Coche{Marca="Renault", Modelo="Clio", Color="Rojo", Precio=15400M}
            };
            var resultado = cocheArray.Average(c => c.Precio);
            return View("Index", (object)resultado.ToString());
        }
    }
}