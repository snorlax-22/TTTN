using PayPal.Api;
using System.Collections.Generic;
using System.Linq;
using TTTN.Controllers;
using TTTN.Helpers;
using TTTN.Models;
using TTTN.Repository;

namespace TTTN.Service
{
    public class MilkService
    {


        private MilkRepository _milkRepo;


        public MilkService(MilkRepository milkRepository)
        {
            _milkRepo = milkRepository;
        }

        public List<SUA> layTatCaSua()
        {
            var listmilk = _milkRepo.layTatCaDoChoiV3();
            var listNutri = _milkRepo.getAllNutritions();

            foreach(var item in listmilk)
            {
                if (listNutri.Any(x => x.id == item.Nutris.id))
                {
                    item.Nutris = listNutri.Where(x => x.id == item.Nutris.id).FirstOrDefault();
                }
                item.KHUYENMAI = _milkRepo.layKmTheoSua(item.MaSua);
                item.DSHINHANH = _milkRepo.layTatCaAnhTheoSua(item.MaSua);
            }
            //get nutri
            
            return listmilk;
        }

        public SUA layChiTietSua(int idSua)
        {

            var milk = _milkRepo.laySuaTheoMa(idSua);
            milk.ThayDoiGia = _milkRepo.layGiaTheoMaSanPham(milk.MaSua);
            milk.KHUYENMAI = _milkRepo.layKmTheoSua(milk.MaSua);
            milk.DSHINHANH = _milkRepo.layTatCaAnhTheoSua(milk.MaSua);
            return milk;
        }
    }
}
