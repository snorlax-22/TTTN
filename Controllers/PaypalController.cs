using BT2MWG.Helpers;
using BT2MWG.Models;
using BT2MWG.ViewModel;
using Microsoft.AspNetCore.Mvc;
using PayPal.Api;
using System;
using System.Collections.Generic;

namespace BT2MWG.Controllers
{
    public class PaypalController : Controller
    {

        private Payment payment;
        public IActionResult Index()
        {

            return View();
        }

        private Payment ExecutePayment(APIContext context, string payerId, string paymentId)
        {
            var paymentExecution = new PaymentExecution()
            {
                payer_id = payerId,
            };
            this.payment = new Payment() { id = paymentId };
            return this.payment.Execute(context, paymentExecution);
        }

        public ActionResult PaymentWithPaypal()
        {
            
            APIContext apiContext = Configuration.GetAPIContext();
            try
            {
                var guid = Convert.ToString((new Random()).Next(100000000));

                var createdPayment = this.CreatePayment(apiContext, "http://localhost:3423/Paypal/PaymentWithPayPal?guid=" + guid);

                var paymentExecution = new PaymentExecution()
                {
                    payer_id = "1"
                };

                //var executedPayment = ExecutePayment(apiContext, "1", guid); 

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

                return Redirect(paypalRedirectUrl);
            }
            catch(Exception ex)
            {
                ex.ToString();
            }
            return RedirectToAction("Index", "Home");
        }

        private Payment CreatePayment(APIContext apiContext, string redirectUrl)
        {
            var carts = HttpContext.Session.Get<List<CartItem>>("GioHang");
            int maNguoiMua = 1;
            decimal tongTien = 0;

            var itemList = new ItemList()
            {
                items = new List<Item>()
            };

            foreach(CartItem item in carts)
            {
                tongTien = item.DoChoi.ThayDoiGia.Gia * item.qty;
                tongTien = Math.Round(tongTien / 23300,2);
                
                var itemPrice = Math.Round(item.DoChoi.ThayDoiGia.Gia/23300,2).ToString().Replace(",",".");
                itemList.items.Add(new Item()
                {
                    name = item.DoChoi.TenDoChoi,
                    currency = "USD",
                    price = itemPrice,
                    quantity = item.qty.ToString(),
                    sku = "sku" 
                });
            }
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
