using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace BT2MWG.Models
{
    public class db
    {
        public int? SafeGetInt(SqlDataReader reader, int colIndex)
        {
            try
            {
                if (!reader.IsDBNull(colIndex))
                    return reader.GetInt32(colIndex);
            }
            catch (Exception e)
            {
                return null;
            }
            return null;
        }

        SqlConnection conn = new SqlConnection("Data Source=188263-NMCUONG;Initial Catalog=TTTN;User ID=sa;Password=123;Integrated Security=true;Connect Timeout=300;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        #region login
        public KHACHHANG getCusByUser(string username)
        {
            var kh = new KHACHHANG();
            try
            {
                SqlCommand cmd = new SqlCommand("getCusByUser", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                cmd.Parameters.AddWithValue("@username", username);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    kh = new KHACHHANG()
                    {
                        cmnd = dr.GetString(0),
                        hotenkh = dr.GetString(1),
                        email = dr.GetString(2),
                        gioitinh = dr.GetString(3),
                        sdt = dr.GetString(4),
                        diachi = dr.GetString(5),
                        tinhtrang = dr.GetBoolean(6),
                        masothue = dr.GetString(7)
                    };
                }
                conn.Close();
            }
            catch (Exception e)
            {
                throw new Exception();
            }

            return kh;
        }

        public int LoginCheck(TAIKHOAN account)
        {
            SqlCommand cmd = new SqlCommand("dangNhap", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@username", account.USERNAME);
            cmd.Parameters.AddWithValue("@password", account.PASSWORD);
            SqlParameter oblLogin = new SqlParameter();
            oblLogin.ParameterName = "@Isvalid";
            oblLogin.SqlDbType = System.Data.SqlDbType.Bit;
            oblLogin.Direction = System.Data.ParameterDirection.Output;
            cmd.Parameters.Add(oblLogin);
            conn.Open();
            cmd.ExecuteNonQuery();
            int res = Convert.ToInt32(oblLogin.Value);
            conn.Close();
            return res;
        }

        public int LoginCheckKH(TAIKHOAN account)
        {
            SqlCommand cmd = new SqlCommand("dangNhapKH", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@username", account.USERNAME);
            cmd.Parameters.AddWithValue("@password", account.PASSWORD);
            cmd.Parameters.AddWithValue("@maquyen", account.MAQUYEN);
            SqlParameter oblLogin = new SqlParameter();
            oblLogin.ParameterName = "@Isvalid";
            oblLogin.SqlDbType = System.Data.SqlDbType.Bit;
            oblLogin.Direction = System.Data.ParameterDirection.Output;
            cmd.Parameters.Add(oblLogin);
            conn.Open();
            cmd.ExecuteNonQuery();
            int res = Convert.ToInt32(oblLogin.Value);
            conn.Close();
            return res;
        }

        #endregion

        #region campaign
        public List<DOCHOI> layDoChoiKMKhung()
        {
            var listDoChoiKM = new List<DOCHOI>();
            try
            {
                SqlCommand cmd = new SqlCommand("layDoChoiKMLon", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (conn.State.ToString().Equals(System.Data.ConnectionState.Closed.ToString()))
                {
                    conn.Open();
                }
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    int idDoChoi = dr.GetInt32(0);

                    var ctkm = new CTKM();
                    ctkm.IdKM = dr.GetInt32(4);
                    ctkm.IdDoChoi = idDoChoi;
                    ctkm.PTGiamGia = dr.GetInt32(2);

                    var khuyenMai = new KHUYENMAI(ctkm);
                    khuyenMai.Id = dr.GetInt32(4);
                    khuyenMai.Name = dr.GetString(3);
                    khuyenMai.NgayBatDau = dr.GetDateTime(5);
                    khuyenMai.NgayKetThuc = dr.GetDateTime(6);
                    string tenDoChoi = dr.GetString(1);

                    var doChoi = new DOCHOI(tenDoChoi, idDoChoi, khuyenMai);

                    listDoChoiKM.Add(doChoi);
                }

                conn.Close();


            }
            catch (Exception e)
            {
                e.ToString();
                conn.Close();
            }

            return listDoChoiKM;
        }

        public List<DOCHOI> layTatCaDoChoiV2()
        {
            var listDoChoiKM = new List<DOCHOI>();
            try
            {
                SqlCommand cmd = new SqlCommand("layDoChoiKMLonV2", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (conn.State.ToString().Equals(System.Data.ConnectionState.Closed.ToString()))
                {
                    conn.Open();
                }
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    int idDoChoi = dr.GetInt32(0);

                    ThayDoiGia gia = new ThayDoiGia()
                    {
                        Gia = dr.GetDecimal(1),
                        NgayApDung = dr.GetDateTime(2)
                    };

                    HANGDOCHOI hang = new HANGDOCHOI()
                    {
                        TENHANGDOCHOI = dr.GetString(6)
                    };

                    CTKM ctkm = new CTKM()
                    {
                        IdDoChoi = idDoChoi,
                        PTGiamGia = 0,
                        IdKM = 0
                    };

                    KHUYENMAI km = new KHUYENMAI()
                    {
                        Id = 0,
                        CTKM = ctkm,
                        NgayBatDau = null
                    };

                    if (dr.GetDateTime(8) >= DateTime.Now)
                    {
                        ctkm = new CTKM()
                        {
                            IdDoChoi = idDoChoi,
                            PTGiamGia = dr.GetInt32(3),
                            IdKM = dr.GetInt32(4)
                        };

                        km = new KHUYENMAI()
                        {
                            Id = dr.GetInt32(4),
                            CTKM = ctkm,
                            NgayBatDau = dr.GetDateTime(5)
                        };
                    }


                    DOCHOI doChoi = new DOCHOI()
                    {
                        TenDoChoi = dr.GetString(7),
                        MaDoChoi = idDoChoi,
                        ThayDoiGia = gia,
                        KHUYENMAI = km
                    };

                    listDoChoiKM.Add(doChoi);
                }
                conn.Close();
            }
            catch (Exception e)
            {
                e.ToString();
                conn.Close();
            }
            listDoChoiKM = listDoChoiKM.GroupBy(x => x.MaDoChoi).Select(y => y.FirstOrDefault()).ToList();
            return listDoChoiKM;
        }

        public List<DOCHOI> layDoChoiTheoHang(int maHang)
        {
            var listDoChoiKM = new List<DOCHOI>();
            try
            {
                SqlCommand cmd = new SqlCommand("layDoChoiTheoHang", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@brandId", maHang);
                if (conn.State.ToString().Equals(System.Data.ConnectionState.Closed.ToString()))
                {
                    conn.Open();
                }
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    int idDoChoi = dr.GetInt32(0);

                    string tenDoChoi = dr.GetString(1);

                    var doChoi = new DOCHOI();

                    doChoi.MaDoChoi = idDoChoi;
                    doChoi.TenDoChoi = tenDoChoi;

                    doChoi.ThayDoiGia = new ThayDoiGia()
                    {
                        NgayApDung = dr.GetDateTime(2),
                        Gia = dr.GetDecimal(3)
                    };

                    listDoChoiKM.Add(doChoi);
                }

                conn.Close();


            }
            catch (Exception e)
            {
                e.ToString();
                conn.Close();
            }

            return listDoChoiKM;
        }
        #endregion

        #region đồ chơi
        public DOCHOI layDoChoiTheoMa(int idDoChoi)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("layDoChoiTheoId", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                cmd.Parameters.AddWithValue("@idDoChoi", idDoChoi);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    var hangPH = new HANGDOCHOI();
                    hangPH.TENHANGDOCHOI = dr.GetString(5);

                    var nhaCC = new NHACUNGCAP();
                    nhaCC.TENNHACC = dr.GetString(6);

                    var doChoi = new DOCHOI(nhaCC, hangPH);
                    doChoi.MaDoChoi = dr.GetInt32(0);
                    doChoi.TenDoChoi = dr.GetString(1);
                    doChoi.TrangThai = dr.GetBoolean(2);
                    doChoi.MoTa = dr.GetString(3);
                    doChoi.SLTon = dr.GetInt32(4);
                    conn.Close();
                    return doChoi;
                }
                else
                {
                    var DoChoi = new DOCHOI();
                    return DoChoi;
                }
            }
            catch (Exception e)
            {
                e.ToString();
                conn.Close();
                var DoChoi = new DOCHOI();
                return DoChoi;
            }
        }
        public List<DOCHOI> layTatCaDoChoi()
        {
            var listDoChoi = new List<DOCHOI>();
            try
            {
                SqlCommand cmd = new SqlCommand("layTatCaDoChoi", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    var hangPH = new HANGDOCHOI();
                    hangPH.TENHANGDOCHOI = dr.GetString(5);

                    var nhaCC = new NHACUNGCAP();
                    nhaCC.TENNHACC = dr.GetString(6);

                    var doChoi = new DOCHOI(nhaCC, hangPH);
                    doChoi.MaDoChoi = dr.GetInt32(0);
                    doChoi.TenDoChoi = dr.GetString(1);
                    doChoi.TrangThai = dr.GetBoolean(2);
                    doChoi.MoTa = dr.GetString(3);
                    doChoi.SLTon = dr.GetInt32(4);


                    listDoChoi.Add(doChoi);
                }
                conn.Close();

            }
            catch (Exception e)
            {
                e.ToString();
                conn.Close();
            }

            return listDoChoi;
        }

        public int themDoChoi(string manv, string tenDoChoi, double giaMoi, string slAnh, string listAnh, string moTa, int maNhaCC, string cates, int brands)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("themDochoi", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@tenDocChoi", tenDoChoi);
                cmd.Parameters.AddWithValue("@idNV", manv);
                cmd.Parameters.AddWithValue("@giaMoi", giaMoi);
                cmd.Parameters.AddWithValue("@slAnh", slAnh);
                cmd.Parameters.AddWithValue("@listHinhAnh", listAnh);
                cmd.Parameters.AddWithValue("@moTa", moTa);
                cmd.Parameters.AddWithValue("@maNhaCC", maNhaCC);
                cmd.Parameters.AddWithValue("@listIdCate", cates);
                cmd.Parameters.AddWithValue("@maHangDoChoi", brands);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return 1;
            }
            catch (Exception e)
            {
                e.ToString();
                conn.Close();
                return 0;
            }

        }

        #endregion

        #region get all
        public List<GIOHANG> layTatCaGH()
        {
            var listCarts = new List<GIOHANG>();
            try
            {
                SqlCommand cmd = new SqlCommand("layTatCaGioHang", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    var cart = new GIOHANG()
                    {
                        MaGioHang = dr.GetInt32(0),
                        NvDuyet = SafeGetInt(dr, 1),
                        NvGiao = SafeGetInt(dr, 2),
                        CMNDKH = dr.GetString(3),
                        NgayGiao = dr.GetDateTime(4),
                        MaHoaDon = dr.GetString(6),
                        TrangThai = new TrangThai()
                        {
                            MaTrangThai = dr.GetInt32(5),
                            TenTrangThai = dr.GetString(7)
                        }

                    };
                    listCarts.Add(cart);
                }
                conn.Close();

            }
            catch (Exception e)
            {
                e.ToString();
                conn.Close();
            }

            return listCarts;
        }

        public List<NHACUNGCAP> layTatCaNhaCC()
        {
            var listSuppliers = new List<NHACUNGCAP>();
            try
            {
                SqlCommand cmd = new SqlCommand("layTatCaNhaCC", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    var supplier = new NHACUNGCAP();
                    supplier.MANHACC = dr.GetInt32(0);
                    supplier.TENNHACC = dr.GetString(1);
                    supplier.SDT = dr.GetString(2);
                    supplier.EMAIL = dr.GetString(3);
                    supplier.DIACHI = dr.GetString(4);


                    listSuppliers.Add(supplier);
                }
                conn.Close();

            }
            catch (Exception e)
            {
                e.ToString();
                conn.Close();
            }

            return listSuppliers;
        }

        public List<DANHMUC> layDanhMucTheoDoChoi(int idDoChoi)
        {
            var listcate = new List<DANHMUC>();
            try
            {
                SqlCommand cmd = new SqlCommand("layDanhMucTheoDoChoi", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                cmd.Parameters.AddWithValue("@idDoChoi", idDoChoi);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    var cate = new DANHMUC();
                    cate.ID = dr.GetInt32(0);
                    cate.Name = dr.GetString(1);

                    listcate.Add(cate);
                }
                conn.Close();
            }
            catch (Exception e)
            {
                throw new Exception();
            }
            return listcate;
        }

        public List<DANHMUC> layTatCaDanhMuc()
        {
            var listcate = new List<DANHMUC>();
            try
            {
                SqlCommand cmd = new SqlCommand("layTatCaDanhMuc", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    var cate = new DANHMUC();
                    cate.ID = dr.GetInt32(0);
                    cate.Name = dr.GetString(1);

                    listcate.Add(cate);
                }
                conn.Close();
            }
            catch (Exception e)
            {
                throw new Exception();
            }
            return listcate;
        }
        #endregion

        #region by toy id

        public ThayDoiGia layGiaTheoMaSanPham(int idDoChoi)
        {
            var gia = new ThayDoiGia();
            try
            {
                SqlCommand cmd = new SqlCommand("layGiaById", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                cmd.Parameters.AddWithValue("@idDoChoi", idDoChoi);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    gia.Gia = dr.GetDecimal(0);
                    gia.NgayApDung = dr.GetDateTime(1);
                    gia.MaNV = dr.GetInt32(2);
                }
                conn.Close();
            }
            catch (Exception e)
            {
                throw new Exception();
            }
            return gia;
        }

        public KHUYENMAI layKM(int idDoChoi)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("layCTKMtheoDoChoi", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                cmd.Parameters.AddWithValue("@idDoChoi", idDoChoi);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    var ctkm = new CTKM();
                    ctkm.IdKM = dr.GetInt32(4);
                    ctkm.PTGiamGia = dr.GetInt32(2);
                    ctkm.IdDoChoi = dr.GetInt32(0);

                    var km = new KHUYENMAI(ctkm);
                    km.Id = dr.GetInt32(4);
                    km.Name = dr.GetString(3);
                    km.NgayBatDau = dr.GetDateTime(5);
                    km.NgayKetThuc = dr.GetDateTime(6);
                    conn.Close();

                    return km;
                }
                else
                {
                    var km = new KHUYENMAI();
                    return km;
                }

            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }
        #endregion

        #region crud hãng
        public List<HANGDOCHOI> layTatCaHang()
        {
            var listBrands = new List<HANGDOCHOI>();
            try
            {
                SqlCommand cmd = new SqlCommand("layTatCaHang", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    var brand = new HANGDOCHOI();
                    brand.MAHANGDOCHOI = dr.GetInt32(0);
                    brand.TENHANGDOCHOI = dr.GetString(1);
                    listBrands.Add(brand);
                }
                conn.Close();

            }
            catch (Exception e)
            {
                e.ToString();
                conn.Close();
            }

            return listBrands;
        }
        public int suaHangDoChoi(string tenHang, int maHang)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("suaHangDoChoi", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                cmd.Parameters.AddWithValue("@tenHang", tenHang);
                cmd.Parameters.AddWithValue("@idHang", maHang);

                cmd.ExecuteNonQuery();
                conn.Close();
                return 1;
            }
            catch (Exception e)
            {
                e.ToString();
                conn.Close();
                return 0;
            }
        }

        public int xoaHangDoChoi(int maHang)
        {
            try
            {

                SqlCommand cmd = new SqlCommand("xoaHang", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                cmd.Parameters.AddWithValue("@maHang", maHang);

                cmd.ExecuteNonQuery();
                conn.Close();
                return 1;
            }
            catch (Exception e)
            {
                e.ToString();
                conn.Close();
                return 0;
            }
        }

        public int themHangDoChoi(string tenHang)
        {
            try
            {

                SqlCommand cmd = new SqlCommand("themHangDoChoi", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                cmd.Parameters.AddWithValue("@tenHang", tenHang);

                cmd.ExecuteNonQuery();
                conn.Close();
                return 1;
            }
            catch (Exception e)
            {
                e.ToString();
                conn.Close();
                return 0;
            }
        }
        #endregion

        #region crud nhà cung cấp ?? xóa nhà cung cấp
        public int suaNhaCC(string tenHang, int maHang)
        {
            try
            {

                SqlCommand cmd = new SqlCommand("suaHangDoChoi", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                cmd.Parameters.AddWithValue("@tenHang", tenHang);
                cmd.Parameters.AddWithValue("@idHang", maHang);

                cmd.ExecuteNonQuery();
                conn.Close();
                return 1;
            }
            catch (Exception e)
            {
                e.ToString();
                conn.Close();
                return 0;
            }
        }

        public int themNhaCC(string tenNhaCC, string sdtNhaCC, string emailNhaCC, string diaChiNhaCC)
        {
            try
            {

                SqlCommand cmd = new SqlCommand("themNhaCC", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                cmd.Parameters.AddWithValue("@tenNhaCC", tenNhaCC);
                cmd.Parameters.AddWithValue("@sdtNhaCC", sdtNhaCC);
                cmd.Parameters.AddWithValue("@emailNhaCC", emailNhaCC);
                cmd.Parameters.AddWithValue("@diaChiNhaCC", diaChiNhaCC);

                cmd.ExecuteNonQuery();
                conn.Close();
                return 1;
            }
            catch (Exception e)
            {
                e.ToString();
                conn.Close();
                return 0;
            }
        }
        #endregion

        #region ảnh
        public int SuaAnh(int maHinhAnh, string anh)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("suaAnh", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                cmd.Parameters.AddWithValue("@idHinhAnh", maHinhAnh);
                cmd.Parameters.AddWithValue("@hinhAnh", anh);


                cmd.ExecuteNonQuery();
                conn.Close();
                return 1;
            }
            catch (Exception e)
            {
                conn.Close();
                return 0;
            }
        }

        public int ThemAnh(int maDoChoi, string anh)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("themHinhAnh", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                cmd.Parameters.AddWithValue("@idDoChoi", maDoChoi);
                cmd.Parameters.AddWithValue("@hinhAnh", anh);


                cmd.ExecuteNonQuery();
                conn.Close();
                return 1;
            }
            catch (Exception e)
            {
                conn.Close();
                return 0;
            }
        }

        public int xoaAnh(int maAnh)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("xoaAnh", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                cmd.Parameters.AddWithValue("@maAnh", maAnh);


                cmd.ExecuteNonQuery();
                conn.Close();
                return 1;
            }
            catch (Exception e)
            {
                conn.Close();
                return 0;
            }
        }


        public List<HINHANH> layTatCaAnhTheoDoChoi(int? maDoChoi)
        {
            var listImages = new List<HINHANH>();
            if (maDoChoi > 0 || maDoChoi != null)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("layTatCaAnhTheoDoChoi", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();
                    cmd.Parameters.AddWithValue("@idDoChoi", maDoChoi);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        var supplier = new HINHANH();
                        supplier.Id = dr.GetInt32(0);
                        supplier.HinhAnh = dr.GetString(1);
                        supplier.IdDoChoi = dr.GetInt32(2);

                        listImages.Add(supplier);
                    }
                    conn.Close();
                }
                catch (Exception e)
                {

                }
            }

            return listImages;
        }
        #endregion

        #region cart

        public int thanhtoanGioHang(string cmnd, decimal tongtien, string masothue)
        {
            try
            {
                //@cmnd = N'025971880',
                //@mahoadon = N'HD1534531',
                //@tongtien = 500000,
                //@masothue = N'03882874'
                var mahoadon = "HD" + DateTime.Now.ToString().Replace(" ", "").Replace(":", "").Replace("/", "");
                SqlCommand cmd = new SqlCommand("thanhtoanGioHang", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                cmd.Parameters.AddWithValue("@cmnd", cmnd);
                cmd.Parameters.AddWithValue("@mahoadon", mahoadon);
                cmd.Parameters.AddWithValue("@tongtien", tongtien);
                cmd.Parameters.AddWithValue("@masothue", masothue);

                int ID = (int)cmd.ExecuteScalar();
                conn.Close();
                return ID;
            }
            catch (Exception e)
            {
                e.ToString();
                conn.Close();
                return 0;
            }
        }

        public int themCTGH(int maGioHang, int maDoChoi, int? maPhieuTra, decimal giaMua, int? slTra, int slMua)
        {

            try
            {
                SqlCommand cmd = new SqlCommand("themCTGH", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                cmd.Parameters.AddWithValue("@maGioHang", maGioHang);
                cmd.Parameters.AddWithValue("@maDoChoi", maDoChoi);
                cmd.Parameters.AddWithValue("@maPhieuTra", maPhieuTra != null ? maPhieuTra : DBNull.Value);
                cmd.Parameters.AddWithValue("@giaMua", giaMua);
                cmd.Parameters.AddWithValue("@soLuongTra", slTra != null ? slTra : DBNull.Value);
                cmd.Parameters.AddWithValue("@soLuongMua", slMua);

                cmd.ExecuteNonQuery();

                conn.Close();
                return 1;
            }
            catch (Exception e)
            {
                e.ToString();
                conn.Close();
                return 0;
            }
        }
        #endregion


    }
}
