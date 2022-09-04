using System;
using System.Collections.Generic;

namespace BT2MWG.Models
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
}
