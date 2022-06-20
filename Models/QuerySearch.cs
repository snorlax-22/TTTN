using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BT2MWG.Models
{
    public class QuerySearch
    {
        public List<Product> Product { get; set; }

        public int? CurrentPageIndex { get; set; }

        public int PageCount { get; set; }

        public List<string> brand { get; set; }

        public List<string> kind { get; set; }

        public string orderType { get; set; }
    }
}
