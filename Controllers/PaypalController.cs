using BT2MWG.Models;
using Microsoft.AspNetCore.Mvc;
using PayPal.Api;

namespace BT2MWG.Controllers
{
    public class PaypalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //public ActionResult PaymentWithPaypal()
        //{
        //    APIContext apiContext = Configuration.GetAPIContext();
        //    try
        //    {
        //        //string payerId = "1";
        //        string payerId = Request.Url;

        //    }

        //}
    }
}
