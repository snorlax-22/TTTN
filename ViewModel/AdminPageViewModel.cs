using TTTN.Models;
using System.Collections.Generic;

namespace TTTN.ViewModel
{
    public class AdminPageViewModel
    {
        public NHANVIEN nv { get; set; }
        public List<DOCHOI> listDoChoi { get; set; }
        public List<HANGDOCHOI> listHang { get; set; }
        public List<NHACUNGCAP> listNhaCC { get; set; }
        public List<GIOHANG> listGioHang { get; set; }
        public List<NHANVIEN> listNV { get; set; }
        public List<KHUYENMAI> listKM { get; set; }
        public List<QUYEN> listQuyen { get; set; }
        public List<DANHMUC> listDanhMuc { get; set; }
        public DOCHOI EditDoCHoi { get; set; }
    }
}
