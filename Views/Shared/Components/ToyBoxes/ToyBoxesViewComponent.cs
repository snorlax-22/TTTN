using TTTN.Controllers;
using TTTN.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace TTTN.Views.Shared.Components.ToyBoxes
{
    public class ToyBoxesHomePage : ViewComponent
    {
        DataHelper dataHelper = new DataHelper();


        public IViewComponentResult Invoke(int inputId)
        {

            var products = dataHelper.initProducts();

            var productsSearched = (from product in products
                                   where product.ProductID == inputId
                                   select product).ToList();

            Product productA = productsSearched.First(); 



            return View<Product> (productA); //mặc định sẽ chạy Default.cshtml
        }
    }
}
