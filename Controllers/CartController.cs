using AutoMapper;
using TTTN.Helpers;
using TTTN.Models;
using TTTN.ViewModel;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TTTN.Service;

namespace TTTN.Controllers
{
    [EnableCors("AllowAllHeaders")]
    public class CartController : Controller
    {
        db dbo = new db();

        private MilkService _milkSvc;

        private readonly string _clientId;
        private readonly string _secretKey;
        public double TyGiaUSD = 23300;
        CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");

        public CartController(IConfiguration config, MilkService milkService)
        {
            _milkSvc = milkService;
            _clientId = config["PaypalSettings:ClientId"];
            _secretKey = config["PaypalSettings:SecretKey"];
        }
       

        public List<CartItem> Carts
        {
            get
            {
                var carts = HttpContext.Session.Get<List<CartItem>>("GioHang");
                var loginfailed = HttpContext.Session.GetInt32("loginfailed");
                
                if (carts == null)
                {
                    carts = new List<CartItem>();
                }
                if (loginfailed == -1)
                {
                    carts.ForEach(x => x.loginfailed = true);
                }
                return carts;
            }
        }

        public IActionResult Index()
        {
            var vm = new ClientCartPageViewModel();
            
            vm.cartItems = Carts;
            foreach (var item in vm.cartItems)
            {
                item.DoChoi.DSHINHANH = _milkSvc.layChiTietSua(item.DoChoi.MaSua).DSHINHANH;
            }
            vm.curCus = HttpContext.Session.Get<KHACHHANG>("CurrentCus");
            return View(vm);
        }

        public int DeleteFromCart(int idDoChoi)
        {
            var myCart = Carts;

            foreach(var item in myCart)
            {
               if(item.DoChoi.MaSua == idDoChoi)
               {
                    item.qty = 0;
                    myCart.Remove(item);
                    HttpContext.Session.Set("GioHang", myCart);
                    return 1;
               }
            }

            return 0;
        }

        public void ThemVaoGio(int id, int qty = 1)
        {
            //lấy giỏ hàng hiện tại
            var myCart = Carts;

            //kiểm tra hàng đã có trong giỏ
            var item = myCart.SingleOrDefault(it => it.DoChoi.MaSua == id);
            if (item != null)//đã có
            {
                item.qty = item.qty + 1;
            }
            else
            {
                var hh = dbo.layTatCaDoChoiV2().FirstOrDefault(p => p.MaSua == id);

                myCart.Add(new CartItem()
                {
                    qty = qty,
                    DoChoi = hh
                }); ;
            }

            HttpContext.Session.Set("GioHang", myCart);

            //return RedirectToAction("Index");
        }


        public string calTotal()
        {
            var myCart = Carts;
            decimal total = 0;
            

            foreach(var item in myCart)
            {
                var gia = item.DoChoi.ThayDoiGia.Gia;
                var km = item.DoChoi.KHUYENMAI.CTKM.PTGiamGia;
                var giaSauGiam = gia - (gia * km / 100);
                
                total = total + (item.qty* giaSauGiam);
            }

            string tongTienFormat = total.ToString("#,###", cul.NumberFormat) + "₫";


            return tongTienFormat;
        }

        public int plusminusCart(int id, string key = "+", int qty = 1)
        {
            //lấy giỏ hàng hiện tại

            var myCart = Carts;
            
            //kiểm tra hàng đã có trong giỏ
            var item = myCart.SingleOrDefault(it => it.DoChoi.MaSua == id);


            if (item != null && key.Equals("+"))//đã có
            {
                item.qty = item.qty + 1;
            }
            else
            {
                item.qty = item.qty - 1;
            }

            HttpContext.Session.Set("GioHang", myCart);

            //return RedirectToAction("Index");
            return item.qty;
        }

        
    }
}
