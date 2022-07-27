using System.ComponentModel.DataAnnotations.Schema;

namespace BT2MWG.Models
{
    [Table("TAIKHOAN")]
    public class TAIKHOAN
    {
        public string USERNAME { get; set; }
        public string MAQUYEN { get; set; }
        public string PASSWORD { get; set; }
    }
}
