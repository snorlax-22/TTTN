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
        private List<Product> productsSearchedBrand;

        public ActionResult Toy(string searchedBrand)
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
            productsSearchedBrand = products;
            try
            {

                if (qry.brand.Count != 0 || qry.kind.Count != 0)
                {
                    productsSearchedBrand = (from product in products
                                             where qry.brand.Contains(product.Brand)
                                             || qry.kind.Intersect(product.Kind).Any()
                                             select product).ToList();
                    switch (qry.orderType)
                    {
                        case "discountAsc":
                            productsSearchedBrand = productsSearchedBrand.OrderByDescending(x => x.Discount).ToList();
                            break;
                        case "priceAsc":
                            productsSearchedBrand = productsSearchedBrand.OrderBy(x => x.Price).ToList();
                            break;
                        case "priceDesc":
                            productsSearchedBrand = productsSearchedBrand.OrderByDescending(x => x.Price).ToList();
                            break;
                        default:
                            productsSearchedBrand = productsSearchedBrand.ToList();
                            break;
                    }
                }
                else
                {
                    productsSearchedBrand = (from product in products select product).ToList();
                    switch (qry.orderType)
                    {
                        case "discountAsc":
                            productsSearchedBrand = productsSearchedBrand.OrderByDescending(x => x.Discount).ToList();
                            break;
                        case "priceAsc":
                            productsSearchedBrand = productsSearchedBrand.OrderBy(x => x.Price).ToList();
                            break;
                        case "priceDesc":
                            productsSearchedBrand = productsSearchedBrand.OrderByDescending(x => x.Price).ToList();
                            break;
                        default:
                            productsSearchedBrand = productsSearchedBrand.ToList();
                            break;
                    }
                }
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
