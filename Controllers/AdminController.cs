﻿using TTTN.Helpers;
using TTTN.Models;
using TTTN.Models.ReportModel;
using TTTN.ViewModel;
using LanguageExt;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.Json;
using TTTN.Service;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static TTTN.Service.MilkService;

namespace TTTN.Controllers
{
    public class AdminController : Controller
    {

        db dbo = new db();

        private MilkService _milkSvc;

        public AdminController(MilkService milkService)
        {
            _milkSvc = milkService;
        }

        public bool CheckKMHopLe(DateTime NgayKM)
        {
            var rs = dbo.CheckNgayKMGanNhat(NgayKM);
            return rs;
        }

        public int TaoKhuyenMai(string arrPtGiamGia, string arrMaDoChoi, DateTime timeto, DateTime timefrom, string tenkm, string lydokm, int manv)
        {
            int idKm = 0;
            try
            {
                var arrToy = arrMaDoChoi.TrimStart('[')
                 .TrimEnd(']').Replace("\"", "")
                 .Split(',').Select(n => Convert.ToInt32(n)).ToArray();

                var arrDis = arrPtGiamGia.TrimStart('[')
                 .TrimEnd(']').Replace("\"", "")
                 .Split(',').Select(n => Convert.ToInt32(n)).ToArray();

                idKm = dbo.themKhuyenMai(tenkm, timefrom, timeto, lydokm, manv);

                if (idKm > 0)
                {
                    var count = 0;
                    foreach (var item in arrToy)
                    {
                        dbo.themChitietkhuyenmai(idKm, arrToy[count], arrDis[count]);
                        count++;
                    }
                }

            }
            catch (Exception e)
            {
                var b = e.ToString();
            }
            return idKm;
        }



        public ActionResult DiscountVoice()
        {
            return PartialView("~/Views/Admin/Partial/_DiscountVoice.cshtml");
        }

        public ActionResult KhuyenMai()
        {
            var nv = HttpContext.Session.Get<NHANVIEN>("NhanVien");
            if (nv == null)
            {
                return View("~/Views/Admin/Index.cshtml");
            }
            var vm = new AdminPageViewModel();
            vm.nv = nv;
            vm.listKM = dbo.layTatCaDotKM();

            return View("~/Views/Admin/KhuyenMai.cshtml", vm);
        }

        public void XemHoaDon(int magh, string mahd)
        {

            CartPageViewModel vm = new CartPageViewModel();

            vm.listctgh = dbo.layCTDHtheoMaGH(magh);
            vm.gh = dbo.layDHtheoMaGH(magh);

            vm.hd = dbo.layHoaDonTheoMa(mahd);

            var enumerator = vm.listctgh.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;

                item.DoChoi = _milkSvc.layChiTietSua(item.DoChoi.MaSua);

                item.DoChoi.DSHINHANH = dbo.layAnhChiTiet(item.DoChoi.MaSua);
            }

            HttpContext.Session.Set("HoaDonPage", vm);

        }

        public void InHoaDon(int magh, int manvtaohd, string cmnd)
        {
            decimal tongTien = 0;
            var maHoaDon = DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace(" ", "");

            CartPageViewModel vm = new CartPageViewModel();

            var mstKH = dbo.layKHTheoCMND(cmnd).masothue;
            vm.listctgh = dbo.layCTDHtheoMaGH(magh);
            vm.gh = dbo.layDHtheoMaGH(magh);

            foreach (var item in vm.listctgh)
            {
                tongTien = tongTien + item.Gia;

            }
            dbo.taoHoaDon(maHoaDon, tongTien, magh, mstKH, manvtaohd);
            vm.hd = dbo.layHoaDonTheoMa(maHoaDon);

            var enumerator = vm.listctgh.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;

                item.DoChoi = _milkSvc.layChiTietSua(item.DoChoi.MaSua);

                item.DoChoi.DSHINHANH = dbo.layAnhChiTiet(item.DoChoi.MaSua);
            }

            HttpContext.Session.Set("HoaDonPage", vm);

        }

        public ActionResult GoToPrint()
        {
            var cpv = HttpContext.Session.Get<CartPageViewModel>("HoaDonPage");
            return View("~/Views/Admin/Partial/InvoicePrint.cshtml", cpv);
        }

        public ActionResult LayChiTietGioHang(int maGH)
        {

            CartPageViewModel vm = new CartPageViewModel();

            vm.listctgh = dbo.layCTDHtheoMaGH(maGH);
            vm.gh = dbo.layDHtheoMaGH(maGH);
            var enumerator = vm.listctgh.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;

                item.DoChoi = _milkSvc.layChiTietSua(item.DoChoi.MaSua);

                item.DoChoi.DSHINHANH = dbo.layAnhChiTiet(item.DoChoi.MaSua);
            }
            return PartialView("~/Views/Admin/Partial/ListOrderDetail.cshtml", vm);
        }


        public ActionResult thongKeDoanhThu(string datefrom, string dateto)
        {
            CultureInfo provider = new CultureInfo("en-GB");
            var df = DateTime.Parse(datefrom, provider, DateTimeStyles.NoCurrentDateDefault);
            var dt = DateTime.Parse(dateto, provider, DateTimeStyles.NoCurrentDateDefault);
            var strFr = df.ToString("yyyy-MM-dd");
            var strTo = dt.ToString("yyyy-MM-dd");
            var monthNo = (((dt.Year - df.Year) * 12) + dt.Month - df.Month) + 1;
            var doanhthu = dbo.layDoanhThuTheoThang(DateTime.Parse(strFr), DateTime.Parse(strTo));

            return PartialView("~/Views/Admin/Partial/Revenue.cshtml", doanhthu);
        }

        public ActionResult DoanhThu()
        {
            var nv = HttpContext.Session.Get<NHANVIEN>("NhanVien");
            if (nv == null)
            {
                return View("~/Views/Admin/Index.cshtml");
            }
            var vm = new AdminPageViewModel();
            vm.nv = nv;

            return View("~/Views/Admin/DoanhThu.cshtml", vm);
        }
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
            if (nv.TAIKHOAN.MAQUYEN == 1002)
            {
                var tk = new TAIKHOAN();
                tk.USERNAME = nv.TAIKHOAN.USERNAME;
                vm.listGioHang = dbo.layTatCaGH().Where(x => x.NvGiao.MaNV == vm.nv.MaNV).ToList();
                foreach (var item in vm.listGioHang)
                {
                    item.NvGiao = dbo.getEmpByUser(tk);
                }
            }


            return View("~/Views/Admin/Order.cshtml", vm);
        }

        public IActionResult ChooseListOrder(int matrangthai)
        {
            var vm = new AdminPageViewModel();
            var nv = HttpContext.Session.Get<NHANVIEN>("NhanVien");
            vm.nv = nv;

            vm.listNV = dbo.layTatCaNV().Where(x => x.MaNV != 4).ToList();
            vm.listGioHang = dbo.layTatCaGH().Where(x => x.TrangThai.MaTrangThai == matrangthai).ToList();

            if (nv.TAIKHOAN.MAQUYEN == 1002)
            {
                var tk = new TAIKHOAN();
                tk.USERNAME = nv.TAIKHOAN.USERNAME;
                vm.listGioHang = vm.listGioHang.Where(x => x.NvGiao.MaNV == vm.nv.MaNV).ToList();
                foreach (var item in vm.listGioHang)
                {
                    item.NvGiao = dbo.getEmpByUser(tk);
                }
            }

            return PartialView("~/Views/Admin/Partial/ListCart.cshtml", vm);
        }

        public void duyetDonHang(int maDonHang, int maNVDuyet, int maNVGiao)
        {
            dbo.duyetDonHang(maDonHang, maNVDuyet, maNVGiao);
        }

        public void hoanthanhDonHang(int maDonHang)
        {
            dbo.hoanthanhDonHang(maDonHang);
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

            var dsDoChoi = dbo.layTatCaDoChoiV3();

            vm.listDoChoi = dsDoChoi;

            if (nv.TAIKHOAN.MAQUYEN == 1002)
            {
                var tk = new TAIKHOAN();
                tk.USERNAME = nv.TAIKHOAN.USERNAME;
                var curNv = dbo.getEmpByUser(tk);
                vm.listGioHang = dbo.layTatCaGH().Where(x => x.NvGiao.MaNV == curNv.MaNV).ToList();
                return View("~/Views/Admin/Order.cshtml", vm);
            }


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
            var nv = HttpContext.Session.Get<NHANVIEN>("NhanVien");
            if (nv == null)
            {
                return View("~/Views/Admin/Index.cshtml");
            }
            var vm = new AdminPageViewModel();
            vm.nv = nv;
            var maDC = Int32.Parse(idDoChoi);

            vm.listDanhMuc = dbo.layTatCaDanhMuc();

            vm.EditDoCHoi = _milkSvc.layChiTietSua(Int32.Parse(idDoChoi));

            return View("~/Views/Admin/ToyDetail.cshtml", vm);
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

                if (vm.nv.TAIKHOAN.MAQUYEN == 1002)
                {
                    return 1002;
                }

                return 1;
            }
            else
            {
                return 0;
            }
        }

        #region ảnh
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

        #region tuổi

        public ActionResult Age()
        {
            var nv = HttpContext.Session.Get<NHANVIEN>("NhanVien");
            if (nv == null)
            {
                return View("~/Views/Admin/Index.cshtml");
            }
            var vm = new AdminPageViewModel();
            vm.nv = nv;
            var res = _milkSvc.layTatCaDoTuoi();

            vm.lstDoTuoi = res;
            return View("~/Views/Admin/Age.cshtml", vm);
        }
        public int CrudDoTuoi(int idDoTuoi, string doTuoi, int type)
        {
            return _milkSvc.crudDotuoi(doTuoi, idDoTuoi, type);
        }
        #endregion

        public ActionResult Import()
        {
            var nv = HttpContext.Session.Get<NHANVIEN>("NhanVien");
            if (nv == null)
            {
                return View("~/Views/Admin/Index.cshtml");
            }
            var vm = new AdminPageViewModel();
            vm.nv = nv;
            var res = _milkSvc.layTatCaDoTuoi();

            vm.lstDoTuoi = res;
            return View("~/Views/Admin/Import.cshtml", vm);
        }

        public ActionResult RowImport()
        {
            return PartialView("~/Views/Admin/Partial/RowImport.cshtml");
        }


        public class ImportPayload{
            public int manv { get; set; }
            public string StrListQtt { get; set; }
            public string StrListIdP { get; set; }
            public string StrListEx { get; set; }
            public string StrListManu { get; set; }
            public string StrBestUse { get; set; }
        }

        public int nhapHang(ImportPayload payload)
        {
            var StrListQtt = payload.StrListQtt.ToListInt();
            var StrListIdP = payload.StrListIdP.ToListInt();
            var StrListManu = payload.StrListManu.ToListString();
            var StrListEx = payload.StrListEx.ToListString();
            var manv = payload.manv;

            var lstLH = new List<LoHang>();
            int count = 0;
            foreach(var item in StrListIdP)
            {
                var lh = new LoHang()
                {
                    masua = StrListIdP[count],
                    sl = StrListQtt[count],
                    strngaysx = StrListManu[count],
                    strngayhethan = StrListEx[count]
                };
                lstLH.Add(lh);
            }
            var rs = _milkSvc.nhapHang( manv, lstLH);

            return -1;
        }

    }


}
