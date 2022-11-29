using System.ComponentModel.DataAnnotations.Schema;

namespace TTTN.Models
{
    [Table("TAIKHOAN")]
    public class TAIKHOAN
    {
        public string USERNAME { get; set; }
        public int MAQUYEN { get; set; }
        public string PASSWORD { get; set; }
    }
}
