using BT2MWG.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace BT2MWG.Controllers
{
    public class ProductController : Controller
    {
        db dbo = new db();
        public IActionResult Index()
        {
            return View();
        }

        [Route("/cate")]
        public IActionResult Cate(string brand)
        {
            var listDoChoi = dbo.layTatCaDoChoiV3().Where(x=> x.HANGDOCHOI.TENHANGDOCHOI == brand);
            return View("~/Views/Home/Cate.cshtml",listDoChoi);
        }


        public IActionResult Detail(int id)
        {
            var dochoi = dbo.layDoChoiTheoMa(id);

            return View(dochoi);
        }

        private string ConvertToUnSign(string input)
        {
            input = input.Trim();
            for (int i = 0x20; i < 0x30; i++)
            {
                input = input.Replace(((char)i).ToString(), " ");
            }
            Regex regex = new Regex(@"\p{IsCombiningDiacriticalMarks}+");
            string str = input.Normalize(NormalizationForm.FormD);
            string str2 = regex.Replace(str, string.Empty).Replace('đ', 'd').Replace('Đ', 'D');
            while (str2.IndexOf("?") >= 0)
            {
                str2 = str2.Remove(str2.IndexOf("?"), 1);
            }
            return str2;
        }

        [HttpGet]
        public ActionResult Search(string searchText)
        {
            string value = string.Empty;
            var products = dbo.layTatCaDoChoiV2();
            var listDoChoi = new List<DOCHOI>();
            foreach (var item in products)
            {
                item.DSHINHANH = dbo.layTatCaAnhTheoDoChoi(item.MaDoChoi);
            }
            try
            {
                listDoChoi = (from product in products
                                   where ConvertToUnSign(product.TenDoChoi).ToLower().Replace(" ","").Contains(ConvertToUnSign(searchText).ToLower().Replace(" ", ""))
                                   select product).ToList();
            }
            catch (ArgumentNullException)
            {
                return Json("Nothing");
            }
            return PartialView("~/Views/Product/Partial/_ItemSearch.cshtml",listDoChoi);
        }

        //   [HttpGet]
        //   public ActionResult Search(string searchText)
        //   {
        //       string value = string.Empty;
        //       if (string.IsNullOrEmpty(searchText)) { return Json(" "); }
        //       var products = dbo.layTatCaDoChoiV2();

        //      foreach(var item in products)
        //       {
        //           item.DSHINHANH = dbo.layTatCaAnhTheoDoChoi(item.MaDoChoi);
        //       }

        //       try
        //       {
        //           productsSearched = from product in products
        //                              where product.TenDoChoi.Contains(searchText)
        //                              select product;
        //       }
        //       catch (ArgumentNullException)
        //       {
        //           return Json("Nothing");
        //       }

        //       value = JsonConvert.SerializeObject(productsSearched, Formatting.Indented, new JsonSerializerSettings
        //       {
        //           ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        //       });

        //       return Json(value);
        //}
    }
}
