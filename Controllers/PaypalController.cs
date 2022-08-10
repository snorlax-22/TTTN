using BT2MWG.Helpers;
using BT2MWG.Models;
using BT2MWG.ViewModel;
using Microsoft.AspNetCore.Cors;
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

        public IActionResult Index()
        {

            return View();
        }

        public Payment ExecutePayment(string payerId, string paymentId)
        {
            var paymentExecution = new PaymentExecution()
            {
                payer_id = "GBWULDBPHSDYG"
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

        public int checkIsLogin()
        {
            var account = HttpContext.Session.Get<TAIKHOAN>("TaiKhoan");

            if (account != null && account.MAQUYEN == 2)
            {
                return 1;
            }

            return 0;
        }

        [EnableCors("AllowAllHeaders")]
        public ActionResult PaymentWithPaypal()
        {
            Payment createdPayment = null;
 
            try
            {
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
                HttpContext.Session.Set("payerid", createdPayment.token);
                
                return Redirect(paypalRedirectUrl);
            }
            catch(Exception ex)
            {
                ex.ToString();
            }

            
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Success()
        {
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

            foreach(CartItem item in carts)
            {
                //tongTien = tongTien + item.DoChoi.ThayDoiGia.Gia * item.qty;
                var ptGiam = item.DoChoi.KHUYENMAI.CTKM.PTGiamGia;
                var gia = item.DoChoi.ThayDoiGia.Gia;
                var giaPro = gia - ((gia*ptGiam)/100);
                var itemPrice = Math.Round(giaPro / 23300,2).ToString().Replace(",",".");
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
            tongTien = Math.Round(tongTien / 23300,2);
            var tongTienFormated = tongTien.ToString().Replace(",", ".");

            var payer = new Payer()
            {
                payment_method = "paypal"
            };

            var redirUrls = new RedirectUrls()
            {
                cancel_url = "http://localhost:3423/",
                return_url = "http://localhost:3423/"
            };

            var details = new Details
            {
                tax = "1",
                shipping = "1",
                subtotal = tongTienFormated
            };

            tongTien = tongTien + 2;
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
