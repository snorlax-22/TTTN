using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BT2MWG.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public List<string> Image { get; set; }
        public decimal Price { get; set; }
        public int Discount { get; set; }
        public List<string> Promotion { get; set; }

        public string Brand { get; set; }

        public List<string> Kind { get; set; }

        public string AgeLimit { get; set; }
        public string Size { get; set; }
        public string Material { get; set; }
        public float Weight { get; set; }

        public string Warn { get; set; }

        public string Origin { get; set; }

        public List<string> Features { get; set; }

        public List<string> Instructions { get; set; }

        public int maxPage { get; set; }
    }
}
