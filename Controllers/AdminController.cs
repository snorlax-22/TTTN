using BT2MWG.Models;
using BT2MWG.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;

namespace BT2MWG.Controllers
{
    public class AdminController : Controller
    {
        db dbo = new db();

        public IActionResult Index()
        {
            return View();
        }
        public ActionResult Admin()
        {
            var tk = new TAIKHOAN();
            var dsDoChoi = dbo.layTatCaDoChoi();
            var vm = new AdminPageViewModel();

            vm.taikhoan = tk;
            vm.listDoChoi = dsDoChoi;


            return View("~/Views/Admin/Admin.cshtml", vm);
        }

        [HttpPost]
        public int ThemDoChoi(string manv, string tenDoChoi, double giaMoi, string slAnh, string listAnh)
        {
            int isSuccess = dbo.themDoChoi(manv, tenDoChoi, giaMoi, slAnh, listAnh);
            return isSuccess;
        }


        public ActionResult Brand()
        {
            var res = dbo.layTatCaHang();

            var vm = new AdminPageViewModel();

            vm.listHang = res;
            return View("~/Views/Admin/Brand.cshtml", vm);
        }

        public ActionResult Suppliers()
        {
            var res = dbo.layTatCaNhaCC();

            var vm = new AdminPageViewModel();

            vm.listNhaCC = res;

            return View("~/Views/Admin/Suppliers.cshtml", vm);
        }

        public IActionResult DangNhap(string username, string password)
        {

            var vm = new AdminPageViewModel();
            TAIKHOAN account = new TAIKHOAN();
            account.USERNAME = username;
            account.PASSWORD = password;

            vm.taikhoan = account;
            var dsDoChoi = dbo.layTatCaDoChoi();

            vm.listDoChoi = dsDoChoi;
            int res = dbo.LoginCheck(account);
            if (res == 1)
            {
                return View("~/Views/Admin/Admin.cshtml", vm);
            }
            else
            {
                return View("~/Views/Admin/Index.cshtml");
            }
        }

        public IActionResult SuaDoChoi(string idDoChoi)
        {
            var maDC = Int32.Parse(idDoChoi);

            DOCHOI lstdoChoi = dbo.layDoChoiTheoMa(Int32.Parse(idDoChoi));

            return View("~/Views/Admin/ToyDetail.cshtml", lstdoChoi);
        }

  
        public int SuaHang(int idHang, string tenHang)
        {
            //var maDC = Int32.Parse(idHang);

            //DOCHOI lstdoChoi = dbo.layDoChoiTheoMa(Int32.Parse(idDoChoi));

            var rs = dbo.suaHangDoChoi(tenHang, idHang);

            return rs;
        }

    }
}
