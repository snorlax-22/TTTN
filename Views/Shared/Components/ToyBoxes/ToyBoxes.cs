using BT2MWG.Controllers;
using BT2MWG.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BT2MWG.Views.Shared.Components.ToyBoxes
{
    public class ToyBoxes : ViewComponent
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
