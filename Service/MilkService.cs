using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

            foreach (var item in listmilk)
            {
                if (listNutri.Any(x => x.id == item.Nutris.id))
                {
                    item.Nutris = listNutri.Where(x => x.id == item.Nutris.id).FirstOrDefault();
                }
                item.KHUYENMAI = _milkRepo.layKmTheoSua(item.MaSua);
                item.DSHINHANH = _milkRepo.layTatCaAnhTheoSua(item.MaSua);
                item.loHang = _milkRepo.layLoHangTheoSua(item.MaSua);
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

        /// <summary>
        /// type = 1: thêm
        /// type = 2: sửa
        /// type = 3: xóa
        /// </summary>
        /// <param name="type"></param>
        /// <param name="idSua"></param>
        /// <param name="tenDotuoi"></param>
        /// <returns></returns>
        public int crudDotuoi(string tenDotuoi, int idSua = -1, int type = 1)
        {
            switch (type)
            {
                case 1:
                    return _milkRepo.themDoTuoi(tenDotuoi);
                case 2:
                    return _milkRepo.suaDoTuoi(tenDotuoi, idSua);
                case 3:
                    return _milkRepo.xoaDoTuoi(idSua);
            }
            return -1;
        }

        public List<DoTuoi> layTatCaDoTuoi()
        {
            return _milkRepo.layTatCaDoTuoi();
        }

        public int nhapHang(int manv, List<LoHang> lstLoHang)
        {
            var mapn = _milkRepo.taoPhieuNhap(manv);
            if(mapn > 0)
            {
                foreach(var item in lstLoHang)
                {
                    _milkRepo.nhaphang(item.masua, mapn, item.sl, item.ngaysx, item.ngayhethan, item.ngaysdtotnhat, item.mota);
                }
            }

            return 0;
        }

        public class LoHang
        {
            public int masua { get; set; }
            public int sl { get; set; }
            public DateTime ngaysx { get; set;}
            public DateTime ngayhethan { get; set; }
            public DateTime ngaysdtotnhat { get; set; }
            public string strngaysx { get; set;}
            public string strngayhethan { get; set; }
            public string strngaysdtotnhat { get; set; }
            public string mota { get; set;} 
        }
    }
}
