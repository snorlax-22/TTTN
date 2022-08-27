using BT2MWG.Models;
using System.Collections.Generic;

namespace BT2MWG.ViewModel
{
    public class CartPageViewModel
    {
        public HoaDon hd { get; set; }
        public GIOHANG gh { get; set; }

        public List<CTGH> listctgh { get; set; }
             
    }
}
