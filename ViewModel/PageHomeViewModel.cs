using TTTN.Models;
using System.Collections.Generic;

namespace TTTN.ViewModel
{
    public class PageHomeViewModel
    {
        public List<SUA> listDoChoiKMKhung { get; set; }
        public List<SUA> listDoChoiVB { get; set; }
        public List<SUA> listDoChoi { get; set; }
        public KHACHHANG currentCus { get; set; }
    }
}
