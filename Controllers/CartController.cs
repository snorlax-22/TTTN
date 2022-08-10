﻿using AutoMapper;
using BT2MWG.Helpers;
using BT2MWG.Models;
using BT2MWG.ViewModel;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace BT2MWG.Controllers
{
    [EnableCors("AllowAllHeaders")]
    public class CartController : Controller
    {
        db dbo = new db();
        private readonly string _clientId;
        private readonly string _secretKey;
        public double TyGiaUSD = 23300;
        CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");

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
                var hh = dbo.layTatCaDoChoiV2().FirstOrDefault(p => p.MaDoChoi == id);

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
            var item = myCart.SingleOrDefault(it => it.DoChoi.MaDoChoi == id);


            if (item != null && key.Equals("+"))//đã có
            {
                item.qty += qty;
            }
            else
            {
                item.qty -= qty;
            }

            HttpContext.Session.Set("GioHang", myCart);

            //return RedirectToAction("Index");
            return item.qty;
        }

        
    }
}
