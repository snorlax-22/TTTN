using TTTN.Models;
using System;
using System.Collections.Generic;

namespace TTTN.ViewModel
{
    public class CartItem
    {
        public DOCHOI DoChoi { get; set; }

        public int qty { get; set; }

        public bool? loginfailed { get; set; }


    }
}
