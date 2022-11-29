using TTTN.Controllers;
using TTTN.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TTTN.Views.Shared.Components.ProductDetailBox
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
