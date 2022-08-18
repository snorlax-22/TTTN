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
        db dbo = new db();

        private object productsSearched;
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detail(int id)
        {
            var dochoi = dbo.layDoChoiTheoMa(id);

            return View(dochoi);
        }

        [HttpGet]
        public ActionResult Search(string searchText)
        {
            string value = string.Empty;
            if (string.IsNullOrEmpty(searchText)) { return Json(" "); }
            var products = dbo.layTatCaDoChoiV2();

            foreach(var item in products)
            {
                item.DSHINHANH = dbo.layTatCaAnhTheoDoChoi(item.MaDoChoi);
            }

            try
            {
                productsSearched = from product in products
                                   where product.TenDoChoi.StartsWith(searchText)
                                   || product.TenDoChoi.EndsWith(searchText)
                                   || product.TenDoChoi.Contains(searchText)
                                   select product;
            }
            catch (ArgumentNullException)
            {
                return Json("Nothing");
            }
            
            value = JsonConvert.SerializeObject(productsSearched, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            return Json(value);
     }
    }
}
