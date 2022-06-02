﻿using BT2MWG.Models;
using System.Collections.Generic;

namespace BT2MWG.Controllers
{
    public class DataHelper
    {
        public List<Product> initProducts()
        {
            var listProduct = new List<Product>();
            List<string> Image1 = new List<string>();
            List<string> Image2 = new List<string>();
            List<string> Image3 = new List<string>();
            List<string> Image4 = new List<string>();
            List<string> Image5 = new List<string>();
            List<string> Image6 = new List<string>();
            List<string> Image7 = new List<string>();

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


            List<string> Promotions1 = new List<string>();
            Promotions1.Add(" Nhập mã AVAKID giảm 10% tối đa 100.000đ cho đơn hàng từ 300.000đ trở lên khi thanh toán qua Ví Moca trên ứng dụng Grab (click xem chi tiết)");
            List<string> Promotions2 = new List<string>();
            Promotions2.Add(" Nhập mã AVAKID giảm 10% tối đa 100.000đ cho đơn hàng từ 300.000đ trở lên khi thanh toán qua Ví Moca trên ứng dụng Grab (click xem chi tiết)");

            List<string> Kinds1 = new List<string>();
            Kinds1.Add("Đồ chơi bé trai");
            Kinds1.Add("Đồ chơi lắp ráp");
            List<string> Kinds2 = new List<string>();
            Kinds2.Add("Đồ chơi bé trai");
            Kinds2.Add("Đồ chơi lắp ráp");

            List<string> Features1 = new List<string>();
            Features1.Add("Đồ chơi trạm cảnh sát tuần tra và cứu hỏa biển Lego City 60308 bao gồm 297 chi tiết.");
            Features1.Add("Bé có thể sáng tạo và tưởng tượng câu chuyện của mình.");
            Features1.Add("Đồ chơi lắp ráp giúp rèn luyện tính rỉ mỉ, sáng tạo của bé khi lắp ráp.");
            Features1.Add("Đồ chơi Lego City không có góc nhọn, thành phần độc hại nên an toàn cho bé.");

            List<string> Features2 = new List<string>();
            Features2.Add("Đồ chơi trạm cảnh sát tuần tra và cứu hỏa biển Lego City 60308 bao gồm 297 chi tiết.");
            Features2.Add("Bé có thể sáng tạo và tưởng tượng câu chuyện của mình.");
            Features2.Add("Đồ chơi lắp ráp giúp rèn luyện tính rỉ mỉ, sáng tạo của bé khi lắp ráp.");
            Features2.Add("Đồ chơi Lego City không có góc nhọn, thành phần độc hại nên an toàn cho bé.");

            List<string> Instructions1 = new List<string>();
            Instructions1.Add("Đồ chơi không dùng pin.");
            Instructions1.Add("Lắp ráp các khớp nối với nhau theo hình trên bao bì.");
            Instructions1.Add("Có thể sáng tạo theo trí tưởng tượng của bé.");
            List<string> Instructions2 = new List<string>();
            Instructions2.Add("Đồ chơi không dùng pin.");
            Instructions2.Add("Lắp ráp các khớp nối với nhau theo hình trên bao bì.");
            Instructions2.Add("Có thể sáng tạo theo trí tưởng tượng của bé.");
           
            listProduct.Add(new Product { ProductID = 1, Name = "Đồ chơi trạm cảnh sát tuần tra và cứu hỏa biển Lego City 60308 (297 chi tiết)", Image = Image1, Price = 1399000, Discount = 20, Promotion = Promotions1, Brand = "Lego (Đan Mạch)", Kind = Kinds1, AgeLimit = "Từ 5 tuổi trở lên", Material = "Nhựa", Size = "38x26x6", Weight = 724, Warn = "Có các chi tiết nhỏ, không dùng cho trẻ dưới 3 tuổi, tránh nguy cơ tiềm ẩn khi trẻ sử dụng sai", Origin = "Trung Quốc",Features = Features1, Instructions = Instructions1 });
            listProduct.Add(new Product { ProductID = 2, Name = "Đồ chơi xe địa hình cứu hộ Lego City 60301 (157 chi tiết)", Image = Image2, Price = 993200, Discount = 13, Promotion = Promotions2, Brand = "Lego (Đan Mạch)", Kind = Kinds2, AgeLimit = "Từ 5 tuổi trở lên", Material = "Nhựa", Size = "38x26x6", Weight = 724, Warn = "Có các chi tiết nhỏ, không dùng cho trẻ dưới 3 tuổi, tránh nguy cơ tiềm ẩn khi trẻ sử dụng sai", Origin = "Trung Quốc",Features = Features2,Instructions = Instructions2 });
            return listProduct;
        }
    }
}