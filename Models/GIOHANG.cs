using System;

namespace BT2MWG.Models
{
    public class GIOHANG
    {
        public int MaGioHang { get; set; }
        public int? NvDuyet { get; set; }
        public int? NvGiao { get; set; }
        public string CMNDKH { get; set; }
        public DateTime NgayGiao { get; set; }

        public string MaHoaDon { get; set; }

        public TrangThai TrangThai { get; set; }

    }
    public class TrangThai
    {
        public int MaTrangThai { get; set; }
        public string TenTrangThai { get; set; }
    }
}