using System;
using System.Collections.Generic;

namespace TTTN.Models
{
    
    public class DOCHOI
    {
        db dbo = new db();
        public int MaDoChoi { get; set; }
        public string TenDoChoi { get; set; }
        public NHACUNGCAP NHACUNGCAP { get; set; }
        public bool TrangThai { get; set; }
        public string MoTa { get; set; }

        public int SLTon { get; set; }
        public ThayDoiGia ThayDoiGia { get; set; }
        public HANGDOCHOI HANGDOCHOI { get; set; }

        public List<HINHANH> DSHINHANH { get; set; }

        public Nutri Nutris { get; set; } 
        public KHUYENMAI KHUYENMAI { get; set; }

        public DOCHOI()
        {
        }
        
        //public DOCHOI(List<HINHANH> dsHA)
        //{
        //    DSHINHANH = dsHA;
        //}
        
        public DOCHOI(NHACUNGCAP NhaCC, HANGDOCHOI hang)
        {
            NHACUNGCAP = NhaCC;
            HANGDOCHOI = hang;
        }

        public DOCHOI(string tenDoChoi,int maDoChoi, KHUYENMAI km)
        {
            TenDoChoi = tenDoChoi;
            MaDoChoi = maDoChoi;
        }

        public DOCHOI(int maDoChoi, string tenDoChoi, NHACUNGCAP nHACUNGCAP, bool trangThai, string moTa, HANGDOCHOI hANGDOCHOI, KHUYENMAI kHUYENMAI)
        {
            MaDoChoi = maDoChoi;
            TenDoChoi = tenDoChoi;
            NHACUNGCAP = nHACUNGCAP;
            TrangThai = trangThai;
            MoTa = moTa;
            HANGDOCHOI = hANGDOCHOI;
            DSHINHANH = dbo.layTatCaAnhTheoDoChoi(maDoChoi);       
        }

        public DOCHOI(int maDoChoi)
        {
            MaDoChoi = maDoChoi;
            DSHINHANH = dbo.layTatCaAnhTheoDoChoi(maDoChoi);
            KHUYENMAI = dbo.layKmTheoDoChoi(maDoChoi);
        }
    }

    public class Nutri
    {
            public int id { get; set; }
            public float Protein { get; set; }
            public float TotalFat { get; set; }
            public float TotalCarbon { get; set; }
            public float Calcium { get; set; }
            public float Sodium { get; set; }
            public float Magnesium { get; set; }
            public float Iron { get; set; }
            public float Copper { get; set; }
            public float Potassium { get; set; }
            public float VitaminD3 { get; set; }
            public float VitaminB1 { get; set; }
            public float VitaminB2 { get; set; }
            public float Iodine { get; set; }
            public float Zinc { get; set; }
    }
}
