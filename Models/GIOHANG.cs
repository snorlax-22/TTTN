using System;

namespace BT2MWG.Models
{
    public class GIOHANG
    {
        public int MaGioHang { get; set; }
        public NHANVIEN NvDuyet { get; set; }
        public NHANVIEN NvGiao { get; set; }
        //public string CMNDKH { get; set; }
        public KHACHHANG KhachHang { get; set; }
        public DateTime NgayGiao { get; set; }

        public HoaDon HoaDon { get; set; }

        public TrangThai TrangThai { get; set; }

        public DateTime ThoiGianNhanHang { get; set; }
        public string HoTenNguoiNhan { get; set; }
        public string CMNDNguoNhan { get; set; }
        public string DiaChiNhan { get; set; }
        public string GhiChu { get; set; }
        public string SDTNguoiNhan { get; set; }

    }
    public class TrangThai
    {
        public int MaTrangThai { get; set; }
        public string TenTrangThai { get; set; }
    }
}