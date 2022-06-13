using BT2MWG.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BT2MWG.Controllers
{
    public class ProductController : Controller
    {

        DataHelper dataHelper = new DataHelper();
        private object productsSearched;
        private object productsSearchedBrand;

        public IActionResult Index()
        {
            var products = dataHelper.initProducts();

            return View(products);
        }

        public IActionResult Toy()
        {
            var products = dataHelper.initProducts();

            return View(products);
        }


        //public IActionResult Toy(string searchedBrand)
        //{
        //    var products = dataHelper.initProducts();

        //    var productsSearchedBrand = (from product in products
        //                                where product.Brand == searchedBrand.Trim()
        //                                select product).ToList();



        //    return View(productsSearchedBrand);
        //}

        [HttpGet]
        public ActionResult Search(string searchText)
        {
            if(searchText == null) { return View(); }
            var products = dataHelper.initProducts();
            try
            {
                productsSearched = from product in products
                                   where product.Name.StartsWith(searchText)
                                   || product.Name.EndsWith(searchText)
                                   || product.Name.Contains(searchText)
                                   select product;
                
            }
            catch(ArgumentNullException)
            {
                return Json("Nothing");
            }


            string value = string.Empty;
            value = JsonConvert.SerializeObject(productsSearched, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            return Json(value);
        }
        
       
    }
}
