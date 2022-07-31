using BT2MWG.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BT2MWG.Controllers
{
    public class ProductController : Controller
    {
        db dbo = new db();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detail(int id)
        {
            var dochoi = dbo.layDoChoiTheoMa(id);

            return View(dochoi);
        }
        
    }
}
