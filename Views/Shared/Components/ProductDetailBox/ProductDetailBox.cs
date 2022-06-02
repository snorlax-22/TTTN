using BT2MWG.Controllers;
using BT2MWG.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BT2MWG.Views.Shared.Components.ProductDetailBox
{
    public class ProductDetailBox : ViewComponent
    {
        DataHelper dataHelper = new DataHelper();


        public IViewComponentResult Invoke()
        {
            
            var products = dataHelper.initProducts();

            return View<List<Product>>(products); //mặc định sẽ chạy Default.cshtml
        }
    }
}
