using System;
using System.Collections.Generic;

namespace TTTN.Models
{
    
    public class SUA
    {

        public int MaSua { get; set; }
        public string TenSua { get; set; }
        public NHACUNGCAP NHACUNGCAP { get; set; }
        public bool TrangThai { get; set; }
        public string MoTa { get; set; }

        public int SLTon { get; set; }
        public ThayDoiGia ThayDoiGia { get; set; }
        public HANGDOCHOI HANGDOCHOI { get; set; }

        public List<HINHANH> DSHINHANH { get; set; }

        public Nutri Nutris { get; set; } 
        public KHUYENMAI KHUYENMAI { get; set; }

        public List<DANHMUC> listDanhMuc { get; set; }
        public SUA()
        {
        }
       
        
        public SUA(NHACUNGCAP NhaCC, HANGDOCHOI hang)
        {
            NHACUNGCAP = NhaCC;
            HANGDOCHOI = hang;
        }

        public SUA(string tenDoChoi,int maDoChoi, KHUYENMAI km)
        {
            TenSua = tenDoChoi;
            MaSua = maDoChoi;
        }
    }

    public class Nutri
    {
            public int id { get; set; }
            public double Protein { get; set; }
            public double TotalFat { get; set; }
            public double TotalCarbon { get; set; }
            public double Calcium { get; set; }
            public double Sodium { get; set; }
            public double Magnesium { get; set; }
            public double Iron { get; set; }
            public double Copper { get; set; }
            public double Potassium { get; set; }
            public double VitaminD3 { get; set; }
            public double VitaminB1 { get; set; }
            public double VitaminB2 { get; set; }
            public double Iodine { get; set; }
            public double Zinc { get; set; }
    }
}
