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
        

        public IActionResult Index()
        {
            //var product = new Product();

            var products = new List<Product>();

            products.Add(new Product { ProductID = 1,Name = "Đồ chơi trạm cảnh sát tuần tra và cứu hỏa biển Lego City 60308 (297 chi tiết)", Image= "/public/image/lego-canh-sat.jpg", Price = 1119200 });
            products.Add(new Product { ProductID = 2,Name = "Đồ chơi xe địa hình cứu hộ Lego City 60301 (157 chi tiết)", Image= "/public/image/xe-dia-hinh.jpg", Price = 993200 });

            return View(products);
        }

        [HttpGet]
        public ActionResult Search()
        {
            var products = new List<Product>();

            products.Add(new Product { ProductID = 1, Name = "Đồ chơi trạm cảnh sát tuần tra và cứu hỏa biển Lego City 60308 (297 chi tiết)", Image = "/public/image/lego-canh-sat.jpg", Price = 1119200 });
            products.Add(new Product { ProductID = 2, Name = "Đồ chơi xe địa hình cứu hộ Lego City 60301 (157 chi tiết)", Image = "/public/image/xe-dia-hinh.jpg", Price = 993200 });

            string value = string.Empty;
            value = JsonConvert.SerializeObject(products, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            //return Json(value, System.Web.Mvc.JsonRequestBehavior.AllowGet);
            return Json(value);
            //return Json("Response from Create");
        }
    }
}
