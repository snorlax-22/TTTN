using AutoMapper;
using Newtonsoft.Json.Linq;

namespace BT2MWG.Models
{
    public class NHANVIEN
    {
        public int? MaNV { get; set; }
        public string TenNV { get;set; }
        public string Email { get; set; }
        public bool GioiTinh { get; set; }
        public string SDT { get; set; }
        public string DiaChi { get; set; }
        public bool TinhTrang { get; set; }
        public string MaSoThue { get; set; }
        public TAIKHOAN TAIKHOAN { get; set; }
    }

    public class NHANVIENProfile : Profile
    {
        public NHANVIENProfile()
        {
            CreateMap<JToken, TAIKHOAN>()
                .ForMember("USERNAME", cfg => { cfg.MapFrom(jo => jo["USERNAME"]); })
                .ForMember("MAQUYEN", cfg => { cfg.MapFrom(jo => jo["MAQUYEN"]); })
                .ForMember("PASSWORD", cfg => { cfg.MapFrom(jo => jo["PASSWORD"]); });

            CreateMap<JToken, NHANVIEN>()
                .ForMember("MaNV", cfg => { cfg.MapFrom(jo => jo["MaNV"]); })
                .ForMember("TenNV", cfg => { cfg.MapFrom(jo => jo["TenNV"]); })
                .ForMember("Email", cfg => { cfg.MapFrom(jo => jo["Email"]); })
                .ForMember("GioiTinh", cfg => { cfg.MapFrom(jo => jo["GioiTinh"]); })
                .ForMember("SDT", cfg => { cfg.MapFrom(jo => jo["SDT"]); })
                .ForMember("TinhTrang", cfg => { cfg.MapFrom(jo => jo["TinhTrang"]); })
                .ForMember("MaSoThue", cfg => { cfg.MapFrom(jo => jo["MaSoThue"]); });
        }
    }
}