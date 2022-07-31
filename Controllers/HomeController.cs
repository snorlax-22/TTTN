using BT2MWG.Models;
using BT2MWG.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BT2MWG.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            db dbo = new db();
            
            var b = dbo.layDoChoiKMKhung();
            b = b.GroupBy(x => x.MaDoChoi).Select(y => y.First()).Distinct().ToList();
            PageHomeViewModel vm = new PageHomeViewModel();
            vm.listDoChoiKMKhung = b;

            var c = dbo.layDoChoiTheoHang(7);
            c = c.GroupBy(x => x.MaDoChoi).Select(y => y.First()).Distinct().ToList();
            vm.listDoChoiVB = c;
            return View("~/Views/Home/Index.cshtml",vm);
        }
    }
}
