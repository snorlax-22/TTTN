using BT2MWG.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BT2MWG.Controllers
{
    public class ProductCateController : Controller
    {

        DataHelper dataHelper = new DataHelper();
        private object productsSearchedBrand;

        public IActionResult Toy(string searchedBrand)
        {
            var products = dataHelper.initProducts();

            if (searchedBrand != null)
            {
                products = (from product in products
                            where product.Brand == searchedBrand.Trim()
                            select product).ToList();
            }
            return View(products);
        }

        public IActionResult ToyQuery(QuerySearch qry)
        {
            // ajax -> post/get -> map fiel to qry -> exeute search

            var products = dataHelper.initProducts();
            // products.Where(e => e.Price > qry.priceFrom)
            //truy van theo dieu kien
            //order

            return View(products);
        }

        //task: chuyển cái này qua controller khác
        public IActionResult LoadToyBoxes(List<Product> aPList)
        {
            return PartialView("_OthersToy_Toy", aPList);
        }

        [HttpGet]
        public ActionResult SearchFilter(string jsonprd)
        {
            QuerySearch qry = JsonConvert.DeserializeObject<QuerySearch>(jsonprd);

            var products = dataHelper.initProducts();
            try
            {
                productsSearchedBrand = (from product in products
                                         where qry.brand.Contains(product.Brand)
                                         && qry.kind.Intersect(product.Kind).Any()
                                         select product);
            }
            catch (ArgumentNullException)
            {
                return Json("Nothing");
            }

            string value = string.Empty;
            value = JsonConvert.SerializeObject(productsSearchedBrand, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            return Json(value);
        }
    }
}
