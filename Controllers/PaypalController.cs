using BT2MWG.Helpers;
using BT2MWG.Models;
using BT2MWG.ViewModel;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PayPal.Api;
using System;
using System.Collections.Generic;

namespace BT2MWG.Controllers
{
    [EnableCors("AllowAllHeaders")]
    public class PaypalController : Controller
    {
        APIContext apiContext = Configuration.GetAPIContext();
        private Payment payment;
        db dbo = new db();
        string payerid = "";
        public IActionResult Index()
        {

            return View();
        }

        public Payment ExecutePayment(string payerId, string paymentId)
        {
            var paymentExecution = new PaymentExecution()
            {
                payer_id = payerId
            };
            this.payment = new Payment() { id = paymentId };
            return this.payment.Execute(apiContext, paymentExecution);
        }

        //public void loginCustomer(string id, string password)
        //{
        //    TAIKHOAN tk = new TAIKHOAN();
        //    tk.USERNAME = id;
        //    tk.PASSWORD = password;
        //    tk.MAQUYEN = 2;

        //    HttpContext.Session.Set("TaiKhoan", tk);
        //    PaymentWithPaypal();
        //}

        public string checkIsLoginCustomer()
        {
            var account = HttpContext.Session.Get<TAIKHOAN>("TaiKhoanKhachHang");
            var carts = HttpContext.Session.Get<List<CartItem>>("GioHang");

            foreach (var cart in carts)
            {
               var slTon = dbo.KiemTraTon(cart.DoChoi.MaDoChoi, cart.qty);
               if(slTon == -1)
               {
                    return "Sản phẩm " + cart.DoChoi.TenDoChoi + " đã hết hàng";
               }
               else if(slTon > 0)
               {
                    return "Sản phẩm " + cart.DoChoi.TenDoChoi + " chỉ còn lại "+slTon.ToString();
               }
            }


            if (account != null && account.MAQUYEN == 2)
            {
                return "1";
            }

            return "0";
        }

        public void login(string username, string password)
        {
            HttpContext.Session.Remove("KhachHang");
            var kh = dbo.getCusByUser(username);
            HttpContext.Session.Set("KhachHang", kh);

        }

        [EnableCors("AllowAllHeaders")]
        public ActionResult PaymentWithPaypal(string username, string pw)
        {
            var kh = new TAIKHOAN()
            {
                PASSWORD = pw,
                USERNAME = username,
                MAQUYEN = 2
            };

            Payment createdPayment = null;
            
            var rs = dbo.LoginCheckKH(kh);

            if(rs == 1)
            {
                try
                {
                    login(username, pw);
                    var guid = Convert.ToString((new Random()).Next(100000));

                    createdPayment = this.CreatePayment(apiContext, "http://localhost:3423/Paypal/PaymentWithPayPal?guid=" + guid);

                    var links = createdPayment.links.GetEnumerator();

                    string paypalRedirectUrl = null;


                    while (links.MoveNext())
                    {
                        Links lnk = links.Current;

                        if (lnk.rel.ToLower().Equals("approval_url"))
                        {
                            paypalRedirectUrl = lnk.href;
                        }
                    }

                    HttpContext.Session.Set(guid, createdPayment.id);
                    HttpContext.Session.Set("guid", createdPayment.id);

                    return Redirect(paypalRedirectUrl);
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
            }
            else
            {
                HttpContext.Session.SetInt32("loginfailed", -1);
                return RedirectToAction("Index", "Cart");
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Success()
        {

            string payerid = HttpContext.Request.Query["PayerID"];
            var paymentId = HttpContext.Session.Get<string>("guid");
            var carts = HttpContext.Session.Get<List<CartItem>>("GioHang");
            //var listDetail = HttpContext.Session.Get<List<CTGH>>("CTGioHang");
            var currentCus = HttpContext.Session.Get<KHACHHANG>("KhachHang");
            var tongtien = HttpContext.Session.Get<decimal>("TongTien");

            if (!string.IsNullOrEmpty(paymentId))
            {
                int IDGioHang = dbo.thanhtoanGioHang(currentCus.cmnd, tongtien, currentCus.masothue);
                foreach(var item in carts)
                {
                    var giamua = item.DoChoi.ThayDoiGia.Gia - ((item.DoChoi.ThayDoiGia.Gia*item.DoChoi.KHUYENMAI.CTKM.PTGiamGia)/100);
                    dbo.themCTGH(IDGioHang, item.DoChoi.MaDoChoi, null, giamua, null, item.qty);
                }
                var payerId = HttpContext.Session.GetString("payerid");
                ExecutePayment(payerid, paymentId);
                if (carts != null)
                {
                    HttpContext.Session.Remove("GioHang");
                }
            }

            return View("~/Views/Success.cshtml");
        }

        private Payment CreatePayment(APIContext apiContext, string redirectUrl)
        {
            var carts = HttpContext.Session.Get<List<CartItem>>("GioHang");

            decimal tongTien = 0;

            var itemList = new ItemList()
            {
                items = new List<Item>()
            };

            foreach (CartItem item in carts)
            {
                //tongTien = tongTien + item.DoChoi.ThayDoiGia.Gia * item.qty;
                var ptGiam = item.DoChoi.KHUYENMAI.CTKM.PTGiamGia;
                var gia = item.DoChoi.ThayDoiGia.Gia;
                var giaPro = gia - ((gia * ptGiam) / 100);
                var itemPrice = Math.Round(giaPro / 23300, 2).ToString().Replace(",", ".");
                tongTien = tongTien + (giaPro * item.qty);

                itemList.items.Add(new Item()
                {
                    name = item.DoChoi.TenDoChoi,
                    currency = "USD",
                    price = itemPrice,
                    quantity = item.qty.ToString(),
                    sku = "sku"
                });
            }
            HttpContext.Session.Set<decimal>("TongTien", tongTien);
            tongTien = Math.Round(tongTien / 23300, 2);
            var tongTienFormated = tongTien.ToString().Replace(",", ".");

            var payer = new Payer()
            {
                payment_method = "paypal"
            };

            var redirUrls = new RedirectUrls()
            {
                cancel_url = "http://localhost:3423/" + "&Cancel=true",
                return_url = "http://localhost:3423/Paypal/Success"
            };

            var details = new Details
            {
                tax = "0",
                shipping = "0",
                subtotal = tongTienFormated
            };
            
            tongTienFormated = tongTien.ToString().Replace(",", ".");

            var amount = new Amount()
            {
                currency = "USD",
                total = tongTienFormated,
                details = details
            };

            var transactionList = new List<Transaction>();

            transactionList.Add(new Transaction()
            {
                description = "trans des",
                invoice_number = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"),
                amount = amount,
                item_list = itemList
            });

            this.payment = new Payment()
            {
                intent = "sale",
                payer = payer,
                transactions = transactionList,
                redirect_urls = redirUrls
            };

            return this.payment.Create(apiContext);
        }
    }
}
