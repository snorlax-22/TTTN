using TTTN.Helpers;
using TTTN.Models;
using TTTN.ViewModel;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TTTN.Service;

namespace TTTN.Controllers
{
    [EnableCors("AllowAllHeaders")]
    public class HomeController : Controller
    {
        private readonly PaypalController _PController;
        private MilkService _milkSvc;
        db dbo = new db();
        ServiceHelper apiHelper = new ServiceHelper();

        public HomeController(PaypalController pController, MilkService milkService)
        {
            _PController = pController;
            _milkSvc = milkService;
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
            PageHomeViewModel vm = new PageHomeViewModel();
            vm.listDoChoi = _milkSvc.layTatCaSua();
            vm.currentCus = HttpContext.Session.Get<KHACHHANG>("CurrentCus");

            return View("~/Views/Home/Index.cshtml", vm);
        }

        [Route("advancedsearch")]
        public IActionResult AdvancedSearch()
        {
            var vm = new SearchViewModel()
            {
                listDoChoi = _milkSvc.layTatCaSua(),
                hangDoChoi = dbo.layTatCaHang(),
                lstdoTuoi = _milkSvc.layTatCaDoTuoi()
            };

            return View("~/Views/Home/AdvancedSearch.cshtml", vm);
        }


        public async Task<IActionResult> GetProductList(Search query)
        {
            var ssort = query.Sort;
            var result = new List<SUA>();
            var listManu = query.StrListManuId.ToListInt();
            var listOrigin = query.StrOrigin.ToListInt();
            var listAge = query.StrListAge.ToListInt();

            var listToys = _milkSvc.layTatCaSua().AsQueryable();

            if (listAge.IsValidList())
                listToys = listToys.Where(x => listAge.Contains(x.DoTuoi.MaDoTuoi));

            if (listManu.IsValidList())
                listToys = listToys.Where(x => listManu.Contains(x.HANGDOCHOI.MAHANGDOCHOI));

            if (listOrigin.IsValidList())
                listToys = listToys.Where(x => listOrigin.Contains(x.HANGDOCHOI.MAXUATXU));

            result = listToys.ToList().GetListWithNutris(query);

            if (ssort > 0)
                switch (ssort)
                {
                    case 3:
                        result = result.OrderByDescending(x => x.ThayDoiGia.Gia).ToList();
                        break;
                    case 2:
                        result = result.OrderBy(x => x.ThayDoiGia.Gia).ToList();
                        break;
                }

            return View("~/Views/Shared/Partial/ProductList.cshtml", result);
        }




    }
}
