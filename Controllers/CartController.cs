using AutoMapper;
using BT2MWG.Helpers;
using BT2MWG.Models;
using BT2MWG.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BT2MWG.Controllers
{
    public class CartController : Controller
    {
        db dbo = new db();
        private readonly string _clientId;
        private readonly string _secretKey;
        public double TyGiaUSD = 23300;

        public CartController(IConfiguration config)
        {
            _clientId = config["PaypalSettings:ClientId"];
            _secretKey = config["PaypalSettings:SecretKey"];
        }

        public List<CartItem> Carts
        {
            get
            {
                var carts = HttpContext.Session.Get<List<CartItem>>("GioHang");
                if (carts == null)
                {
                    carts = new List<CartItem>();
                }
                return carts;
            }
        }

        public IActionResult Index()
        {
            return View(Carts);
        }

        public void ThemVaoGio(int id, int qty = 1)
        {
            //lấy giỏ hàng hiện tại
            var myCart = Carts;

            //kiểm tra hàng đã có trong giỏ
            var item = myCart.SingleOrDefault(it => it.DoChoi.MaDoChoi == id);
            if (item != null)//đã có
            {
                item.qty += qty;
            }
            else
            {
                var hh = dbo.layTatCaDoChoi().FirstOrDefault(p => p.MaDoChoi == id);
                var gia = dbo.layGiaTheoMaSanPham(hh.MaDoChoi);
                hh.ThayDoiGia = new ThayDoiGia(gia);

                myCart.Add(new CartItem()
                {
                    qty = qty,
                    DoChoi = hh
                }); ;
            }

            HttpContext.Session.Set("GioHang", myCart);

            //return RedirectToAction("Index");
        }

        
    }
}
