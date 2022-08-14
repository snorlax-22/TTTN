namespace BT2MWG.Models
{
    public class KHACHHANG
    {
        public string cmnd { get; set; }
        public string hotenkh { get; set; }
        public string email { get; set; }
        public string gioitinh { get; set; }
        public string diachi { get; set; }
        public string sdt { get; set; }
        public bool tinhtrang { get; set; }
        public string masothue { get; set; }
        public TAIKHOAN? taikhoan { get; set; }

    }
}
