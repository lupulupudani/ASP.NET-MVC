using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Practica2._1.Models;
using System.Text;

namespace Practica2._1.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public string Index()
        {
            return "Navigate to a URL to show an example";
        }
        
        public ViewResult CreateProduct()
        {
            // create a new Car object
            Coche myCar = new Coche();
            myCar.Color = "Rojo";
            myCar.Marca = "Audi";
            myCar.Modelo = "Tata";
            
            return View("Result",
            (object)String.Format("Coche: {0}", myCar.Color + ","+ myCar.Modelo));
        }

        public ViewResult CrearClientes()
        {
            string[] cliente = { "Juan", "Andrés", "Julián" };
            return View("Result", (object)cliente[1]);
        }
        public ViewResult CrearArrayCoches()
        { 
            Coche[] coches = {
                new Coche {Color="Rojo",Marca="Fiat",Modelo="Panda"},
                new Coche {Color="Verde",Marca="Seat",Modelo="Ibiza"},
                new Coche {Color="Amarillo",Marca="Peugot",Modelo="205"}
                             };
            var cocheselegidos = coches.OrderByDescending(c => c.Marca)
                .Take(3)
                .Select(c => new
                {
                    c.Color,
                    c.Modelo,
                    c.Marca
                });
            StringBuilder resultado = new StringBuilder();
            foreach (var r in cocheselegidos)
            {
                resultado.AppendFormat("Color: {0} ", r.Color).Append(" ");
                resultado.AppendFormat("Marca: {0} ", r.Marca).Append(" ");
                resultado.AppendFormat("Modelo: {0} ", r.Modelo).Append(" ");
                
            }
            return View("Result", (object)resultado.ToString());
        }
        public ViewResult MediaCoches()
        {
            Coche[] coches ={
                                new Coche {Color="Rojo",Marca="Fiat",Modelo="Panda",precio=30000},
                                new Coche {Color="Verde",Marca="Seat",Modelo="Ibiza",precio=34000},
                                new Coche {Color="Amarillo",Marca="Peugot",Modelo="205",precio=26000}
                           };
            var media = coches.Average(c => c.precio);
            return View("Result", (object)media.ToString());
        }

    }
}
