using BT2MWG.Helpers;
using BT2MWG.Models;
using BT2MWG.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public ActionResult Order()
        {
            var nv = HttpContext.Session.Get<NHANVIEN>("NhanVien");
            if (nv == null)
            {
                return View("~/Views/Admin/Index.cshtml");
            }
            var vm = new AdminPageViewModel();
            vm.nv = nv;

            vm.listNV = dbo.layTatCaNV();
            vm.listGioHang = dbo.layTatCaGH();

            return View("~/Views/Admin/Order.cshtml", vm);
        }

        public IActionResult ChooseListOrder(int matrangthai)
        {
            var vm = new AdminPageViewModel();
            var nv = HttpContext.Session.Get<NHANVIEN>("NhanVien");
            vm.nv = nv;

            vm.listNV = dbo.layTatCaNV().Where(x => x.MaNV != 4).ToList();
            vm.listGioHang = dbo.layTatCaGH().Where(x => x.TrangThai.MaTrangThai == matrangthai).ToList();

            return PartialView("~/Views/Admin/Partial/ListCart.cshtml", vm);
        }

        public void duyetDonHang(int maDonHang, int maNVDuyet, int maNVGiao)
        {
            dbo.duyetDonHang(maDonHang, maNVDuyet, maNVGiao);
        }

        public ActionResult Admin()
        {
            var nv = HttpContext.Session.Get<NHANVIEN>("NhanVien");
            if (nv == null)
            {
                return View("~/Views/Admin/Index.cshtml");
            }
            var vm = new AdminPageViewModel();
            vm.nv = nv;

            var dsDoChoi = dbo.layTatCaDoChoi();
            
            vm.listDoChoi = dsDoChoi;


            return View("~/Views/Admin/Admin.cshtml", vm);
        }

        [HttpPost]
        public int ThemDoChoi(string manv, string tenDoChoi, double giaMoi, string slAnh, string listAnh, string moTa, int maNhaCC, string cates, int brands)
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
            var nv = HttpContext.Session.Get<NHANVIEN>("NhanVien");
            if (nv == null)
            {
                return View("~/Views/Admin/Index.cshtml");
            }
            var vm = new AdminPageViewModel();
            vm.nv = nv;
            var res = dbo.layTatCaHang();

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
            var nv = HttpContext.Session.Get<NHANVIEN>("NhanVien");
            if (nv == null)
            {
                return View("~/Views/Admin/Index.cshtml");
            }
            var vm = new AdminPageViewModel();
            vm.nv = nv;

            var res = dbo.layTatCaNhaCC();
            vm.listNhaCC = res;

            return View("~/Views/Admin/Suppliers.cshtml", vm);
        }

        public int themNhaCC(string tenNhaCC, string sdtNhaCC, string emailNhaCC, string diaChiNhaCC)
        {
            var rs = dbo.themNhaCC(tenNhaCC, sdtNhaCC, emailNhaCC, diaChiNhaCC);
            return rs;
        }
        #endregion

        public int DangNhap(string username, string password)
        {
            var vm = new AdminPageViewModel();
            TAIKHOAN account = new TAIKHOAN();
            account.USERNAME = username;
            account.PASSWORD = password;


            int res = dbo.LoginCheck(account);
            if (res == 1 || res == 2002)
            {
                vm.nv = dbo.getEmpByUser(account);
                HttpContext.Session.Set("NhanVien", vm.nv);
                var dsDoChoi = dbo.layTatCaDoChoi();

                vm.listDoChoi = dsDoChoi;
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int SuaAnh(int idAnh, string anh)
        {
            var rs = dbo.SuaAnh(idAnh, anh);
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
