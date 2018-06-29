using MVCEjemplo1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MVCEjemplo1.Controllers
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
            return "He navegado a una URL para mostrar un ejemplo";
        }
        public ViewResult Autoproperty()
        {
            Product myProduct = new Product();
            myProduct.Name = "Kayak";
            string productName=myProduct.Name;
            return View("Index", (object)String.Format("Product Name: {0}", productName));
        }
        public ViewResult CreateProduct()
        {
            Product myProduct = new Product
            {
                ProductId = 1,
                Name = "Kayak",
                Description = "Un barco para una persona",
                Price = 275M,
                Category = "Watersport"
            };
            return View("Index", (object)String.Format("Description: {0}", myProduct.Description));
        }
        public ViewResult CreateCollection()
        {
            string[] stringArray = { "apple", "orange", "plum" };
            List<int> intList = new List<int> { 10, 20, 30, 40 };

            Dictionary<string, int> MyDic = new Dictionary<string, int>
            {
                {"apple",10},
                {"orange",20},
                {"plum",30}
            };
            //return View("Index", (object)stringArray[1]);
            return View("Index", (object)MyDic["apple"].ToString());
        }
        public ViewResult CreateList()
        {
            Product[] productArray =
            {
                new Product{Name="Kayak",Price=275M,Category="Watersports"},
                new Product{Name="Lifejaket",Price=48.95M,Category="Watersports"},
                new Product{Name="Soccer Ball",Price=19.50M,Category="Soccer"},
                new Product{Name="Corner Flag",Price=34.95M,Category="Soccer"},
            };
            decimal total = 0;
            foreach (Product prod in productArray.Where(prod=>prod.Category == "Soccer" && prod.Price>20))
            {
                total += prod.Price;
            }
            return View("Index", (object)String.Format("El total de Soccer es : {0}", total));
        }
        public ViewResult CreateAnonArray()
        {
            var oddsAndEnds = new[]
            {
                new {Name="MVC", Category="Pattern"},
                new {Name="Hat", Category="Cloting"},
                new {Name="Apple", Category="Fruit"}
            };
            StringBuilder result = new StringBuilder();
            foreach(var item in oddsAndEnds)
            {
                result.Append(item.Name).Append(" ");
            }
            return View("Index", (object)result.ToString());
        }
        public ViewResult FindProducts()
        {
            Product[] productArray =
            {
                new Product{Name="Kayak",Price=275M,Category="Watersports"},
                new Product{Name="Lifejaket",Price=48.95M,Category="Watersports"},
                new Product{Name="Soccer Ball",Price=19.50M,Category="Soccer"},
                new Product{Name="Corner Flag",Price=34.95M,Category="Soccer"},
            };
            //var foundProducts = from match in productArray
            //                    orderby match.Price descending
            //                    select new
            //                    {
            //                        match.Name,
            //                        match.Price
            //                    };
            //int count = 0;
            //StringBuilder result = new StringBuilder();
            //foreach(var p in foundProducts)
            //{
            //    result.AppendFormat("Price {0}", p.Price);
            //    if(++count == 3)
            //    {
            //        break;
            //    }
            //}
            //StringBuilder result = new StringBuilder();
            //var foundProducts1 = productArray.OrderByDescending(p => p.Price).Take(3)
            //    .Select(p => new
            //    {
            //        p.Name,
            //        p.Price
            //    });
            var results = productArray.Sum(p => p.Price);
            productArray[2] = new Product { Name = "Stadium", Price = 79600M };
            //foreach(var p in foundProducts1)
            //{
            //    result.AppendFormat("Price {0}", p.Price).Append(", ");
            //}

            return View("Index",(object)results.ToString());
        }
    }
}