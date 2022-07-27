using BT2MWG.Models;
using BT2MWG.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace BT2MWG.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            db dbo = new db();
            
            var b = dbo.layDoChoiKMKhung();
            PageHomeViewModel vm = new PageHomeViewModel();
            vm.listDoChoiKMKhung = b;

            return View("~/Views/Home/Index.cshtml",vm);
        }
    }
}
