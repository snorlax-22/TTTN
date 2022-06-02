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


        public IActionResult Index()
        {
            var products = dataHelper.initProducts();

            return View(products);
        }

        [HttpGet]
        public ActionResult Search()
        {
            var products = dataHelper.initProducts();

            

            string value = string.Empty;
            value = JsonConvert.SerializeObject(products, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            return Json(value);
        }
    }
}
