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

        #region đồ chơi
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
        public int ThemDoChoi(string manv, string tenDoChoi, double giaMoi, string slAnh, string listAnh, string moTa, int maNhaCC,string cates, int brands)
        {
            int isSuccess = dbo.themDoChoi(manv, tenDoChoi, giaMoi, slAnh, listAnh, moTa, maNhaCC, cates, brands);
            return isSuccess;
        }

        public IActionResult SuaDoChoi(string idDoChoi)
        {
            var maDC = Int32.Parse(idDoChoi);

            DOCHOI lstdoChoi = dbo.layDoChoiTheoMa(Int32.Parse(idDoChoi));

            return View("~/Views/Admin/ToyDetail.cshtml", lstdoChoi);
        }
        #endregion
        
        #region hãng
        public ActionResult Brand()
        {
            var res = dbo.layTatCaHang();

            var vm = new AdminPageViewModel();

            vm.listHang = res;
            return View("~/Views/Admin/Brand.cshtml", vm);
        }

        public int SuaHang(int idHang, string tenHang)
        {
            var rs = dbo.suaHangDoChoi(tenHang, idHang);
            return rs;
        }
        
        public int XoaHang(int idHang)
        {
            var rs = dbo.xoaHangDoChoi(idHang);
            return rs;
        }

        public int ThemHang(string tenHang)
        {
            var rs = dbo.themHangDoChoi(tenHang);
            return rs;
        }
        #endregion

        #region nhà CC
        public ActionResult Suppliers()
        {
            var res = dbo.layTatCaNhaCC();

            var vm = new AdminPageViewModel();

            vm.listNhaCC = res;

            return View("~/Views/Admin/Suppliers.cshtml", vm);
        }

        public int themNhaCC(string tenNhaCC, string sdtNhaCC, string emailNhaCC, string diaChiNhaCC)
        {
            var rs = dbo.themNhaCC(tenNhaCC, sdtNhaCC, emailNhaCC, diaChiNhaCC);
            return rs;
        }
        #endregion

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

        public int SuaAnh(int idAnh, string anh)
        {
            var rs = dbo.SuaAnh(idAnh,anh);
            return rs; 
        }
        
        public int themAnh(int maDoChoi, string anh)
        {
            var rs = dbo.ThemAnh(maDoChoi, anh);
            return rs; 
        }
        
        public int xoaAnh(int idAnh)
        {
            var rs = dbo.xoaAnh(idAnh);
            return rs; 
        }
    }
}
