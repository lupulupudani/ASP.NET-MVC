using MVCEjemplo2Vistas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCEjemplo2Vistas.Controllers
{
    public class HomeController : Controller
    {
        Product myProduct = new Product
        {
            ProductId = 1,
            Name = "Kayak",
            Description = "Bote",
            Category = "Watersport",
            Price = 275M
        };
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.ProductCount = 5;
            ViewBag.ExpressShip = true;
            ViewBag.ApplyDiscount = false;
            ViewBag.Supplaier = null;
            return View(myProduct);
        }
        public ViewResult NameAndPrice()
        {
            return View(myProduct);
        }
        public ViewResult DemoArray()
        {
            Product[] array =
            {
                new Product{Name="Kayak", Price=275M},
                new Product{Name="LifeJaket", Price=49.95M},
                new Product{Name="Soccer Ball", Price=19.95M},
                new Product{Name="Corner Flag", Price=34.95M}
            };
            return View(array);
        }
    }
}