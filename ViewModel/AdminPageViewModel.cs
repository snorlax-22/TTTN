using BT2MWG.Models;
using System.Collections.Generic;

namespace BT2MWG.ViewModel
{
    public class AdminPageViewModel
    {
        public TAIKHOAN taikhoan { get; set; }
        public List<DOCHOI> listDoChoi { get; set; }
        public List<HANGDOCHOI> listHang { get; set; }
        public List<NHACUNGCAP> listNhaCC { get; set; }
    }
}
