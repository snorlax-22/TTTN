using BT2MWG.Helpers;
using BT2MWG.Models;
using BT2MWG.ViewModel;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BT2MWG.Controllers
{
    [EnableCors("AllowAllHeaders")]
    public class HomeController : Controller
    {
        private readonly PaypalController _PController;

        public HomeController(PaypalController pController)
        {
            _PController = pController;
        }
        public IActionResult Index()
        {

            
             db dbo = new db();

            //var a = dbo.layDoanhThuTheoThang(DateTime.Parse("2022-06-12"), DateTime.Parse("2022-08-21"));

            var b = dbo.layTatCaDoChoiV3();
            b = b.Where(x => x.KHUYENMAI.CTKM.PTGiamGia > 50).Distinct().ToList();
            PageHomeViewModel vm = new PageHomeViewModel();
            vm.listDoChoiKMKhung = b;

            var c = dbo.layDoChoiTheoHang(7);
            c = c.GroupBy(x => x.MaDoChoi).Select(y => y.First()).Distinct().ToList();
            vm.listDoChoiVB = c;
            return View("~/Views/Home/Index.cshtml", vm);
        }
    }
}
