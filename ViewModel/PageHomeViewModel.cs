using TTTN.Models;
using System.Collections.Generic;

namespace TTTN.ViewModel
{
    public class PageHomeViewModel
    {
        public List<DOCHOI> listDoChoiKMKhung { get; set; }
        public List<DOCHOI> listDoChoiVB { get; set; }
        public List<DOCHOI> listDoChoi { get; set; }
        public KHACHHANG currentCus { get; set; }
    }
}
