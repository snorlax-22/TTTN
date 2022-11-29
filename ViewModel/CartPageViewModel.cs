using TTTN.Models;
using System.Collections.Generic;

namespace TTTN.ViewModel
{
    public class CartPageViewModel
    {
        public HoaDon hd { get; set; }
        public GIOHANG gh { get; set; }

        public List<CTGH> listctgh { get; set; }
             
    }
}
