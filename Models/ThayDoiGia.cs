using System;

namespace TTTN.Models
{
    public class ThayDoiGia
    {
        public ThayDoiGia(ThayDoiGia a)
        {
            this.MaDoChoi = a.MaDoChoi;
            this.MaNV = a.MaNV;
            this.NgayApDung = a.NgayApDung;
            this.Gia = a.Gia;
        }

        public ThayDoiGia()
        {

        }
        public int MaDoChoi { get; set; }
        public DateTime NgayApDung { get; set; }
        public int MaNV { get; set; }
        public decimal Gia { get; set; }
      
    }
}
