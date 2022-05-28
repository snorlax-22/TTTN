using BT2MWG.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BT2MWG.Views.Shared.Components.ProductDetailBox
{
    public class ProductDetailBox : ViewComponent
    {


        public IViewComponentResult Invoke()
        {

            var products = new List<Product>();

            List<string> Image1 = new List<string>();
            List<string> Image2 = new List<string>();
            Image1.Add("/public/image/lego-canh-sat.jpg");
            Image1.Add("/public/image/lego-canh-sat-2.jpg");
            Image1.Add("/public/image/lego-canh-sat-3.jpg");
            Image1.Add("/public/image/lego-canh-sat-4.jpg");
            Image1.Add("/public/image/lego-canh-sat-5.jpg");
            Image1.Add("/public/image/lego-canh-sat-6.jpg");
            Image1.Add("/public/image/lego-canh-sat-7.jpg");
            Image2.Add("/public/image/xe-dia-hinh.jpg");
            Image2.Add("/public/image/xe-dia-hinh2.jpg");
            Image2.Add("/public/image/xe-dia-hinh3.jpg");
            Image2.Add("/public/image/xe-dia-hinh4.jpg");
            Image2.Add("/public/image/xe-dia-hinh5.jpg");
            Image2.Add("/public/image/xe-dia-hinh6.jpg");
            Image2.Add("/public/image/xe-dia-hinh7.jpg");
            products.Add(new Product { ProductID = 1, Name = "Đồ chơi trạm cảnh sát tuần tra và cứu hỏa biển Lego City 60308 (297 chi tiết)", Image = Image1, Price = 1119200 });
            products.Add(new Product { ProductID = 2, Name = "Đồ chơi xe địa hình cứu hộ Lego City 60301 (157 chi tiết)", Image = Image2, Price = 993200 });



            return View<List<Product>>(products); //mặc định sẽ chạy Default.cshtml
        }
    }
}
