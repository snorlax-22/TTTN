namespace BT2MWG.Models
{
    public class NHANVIEN
    {
        public int? MaNV { get; set; }
        public string TenNV { get;set; }
        public string Email { get; set; }
        public bool GioiTinh { get; set; }
        public string SDT { get; set; }
        public string DiaChi { get; set; }
        public bool TinhTrang { get; set; }
        public string MaSoThue { get; set; }
        public TAIKHOAN TAIKHOAN { get; set; }
    }
}