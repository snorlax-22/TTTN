using BT2MWG.Helpers;
using BT2MWG.Models;
using BT2MWG.Repository;
using BT2MWG.ViewModel;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BT2MWG.Controllers
{
    [EnableCors("AllowAllHeaders")]
    public class HomeController : Controller
    {
        private readonly PaypalController _PController;
        db dbo = new db();
        ServiceHelper apiHelper = new ServiceHelper();

        public HomeController(PaypalController pController)
        {
            _PController = pController;
        }



        public void GetProfile(string username)
        {
            var curCus = dbo.getCusByUser(username);
            if (curCus != null)
            {
                HttpContext.Session.Set("CurrentCus", curCus);
            }

        }

        public ActionResult Profile()
        {
            var kh = HttpContext.Session.Get<KHACHHANG>("CurrentCus");
            return View("~/Views/Home/Profile.cshtml", kh);
        }

        public int Login(string pw, string username)
        {
            var kh = new TAIKHOAN()
            {
                PASSWORD = pw,
                USERNAME = username,
                MAQUYEN = 2
            };

            var rs = dbo.LoginCheckKH(kh);
            var curCus = dbo.getCusByUser(username);
            if (rs == 1)
            {
                HttpContext.Session.Set("CurrentCus", curCus);
            }

            return rs;
        }


        public ActionResult SignIn()
        {

            return View("~/Views/Home/SignIn.cshtml");
        }

        public ActionResult SignUp()
        {

            return View("~/Views/Home/SignUp.cshtml");
        }

        public int ThemKhachHang(string tenKh, string mk, string acc, string mst, string add, string email, string phone, string gioitinh, string cmnd)
        {
            var rs = dbo.themTaiKhoan(tenKh, mk, acc, mst, add, email, phone, gioitinh, cmnd);

            var curCus = dbo.getCusByUser(acc);

            HttpContext.Session.Set("CurrentCus", curCus);

            return rs;
        }

        public int SuaKhachHang(string username, string tenKh, string mk, string mst, string add, string email, string phone, string gioitinh, string cmnd)
        {


            var curCus = HttpContext.Session.Get<KHACHHANG>("CurrentCus");

            var rs = dbo.suaTaiKhoan(username, tenKh, mk, mst, add, email, phone, gioitinh, cmnd);

            var curCusNext = dbo.getCusByUser(curCus.taikhoan.USERNAME);
            HttpContext.Session.Set("CurrentCus", curCus);

            return rs;
        }

        public IActionResult Index()
        {

            var DoChoi = new DOCHOI(16);

            db dbo = new db();

            PageHomeViewModel vm = new PageHomeViewModel();

            vm.listDoChoi = dbo.layTatCaDoChoiV3();
            vm.currentCus = HttpContext.Session.Get<KHACHHANG>("CurrentCus");

            return View("~/Views/Home/Index.cshtml", vm);
        }

        [Route("advancedsearch")]
        public IActionResult AdvancedSearch()
        {
            var vm = new SearchViewModel()
            {
                hangDoChoi = dbo.layTatCaHang(),
            };

            return View("~/Views/Home/AdvancedSearch.cshtml", vm);
        }

        public async Task<IActionResult> GetProductList(Search query)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var e = query.StrListManuId.Split(',')?.Select(Int32.Parse)?.ToList();
            var b = dbo.layTatCaDoChoiV3().Where(x => e.Contains(x.HANGDOCHOI.MAHANGDOCHOI)).ToList();
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            return View("~/Views/Shared/Partial/ProductList.cshtml",b);
        }

    }
}
