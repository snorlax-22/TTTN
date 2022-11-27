using BT2MWG.Models;
using BT2MWG.Models.ReportModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace BT2MWG.Repository
{
    public class db
    {


        #region nhân viên
        public int themNhanVien(string tenNV, string email, string diachi, bool gioitinh, string sdt, string mst,
            string username, int maquyen, string password)
        {
            try
            {

                SqlCommand cmd = new SqlCommand("themNhanVien", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                cmd.Parameters.AddWithValue("@tenNV", tenNV);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@gioiTinh", gioitinh);
                cmd.Parameters.AddWithValue("@SDT", sdt);
                cmd.Parameters.AddWithValue("@msThue", mst);
                cmd.Parameters.AddWithValue("@userName", username);
                cmd.Parameters.AddWithValue("@maQuyen", maquyen);
                cmd.Parameters.AddWithValue("@diaChi", diachi);
                cmd.Parameters.AddWithValue("@passWord", password);


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

        public int XoaNV(int manv)
        {
            try
            {

                SqlCommand cmd = new SqlCommand("XoaNV", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                cmd.Parameters.AddWithValue("@manv", manv);

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

        #region khách hàng

        public KHACHHANG layKHTheoCMND(string cmnd)
        {
            var hd = new KHACHHANG();
            try
            {
                SqlCommand cmd = new SqlCommand("layKHtheoCMND", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                cmd.Parameters.AddWithValue("@cmnd", cmnd);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    hd.cmnd = cmnd;
                    hd.hotenkh = dr.GetString(1);
                    hd.email = dr.GetString(2);
                    hd.gioitinh = dr.GetString(3);
                    hd.sdt = dr.GetString(4);
                    hd.diachi = dr.GetString(5);
                    hd.tinhtrang = dr.GetBoolean(6);
                    hd.masothue = dr.GetString(7);
                    hd.taikhoan = new TAIKHOAN()
                    {
                        USERNAME = dr.GetString(8)
                    };
                }
                conn.Close();
            }
            catch (Exception e)
            {
                throw new Exception();
            }
            return hd;

        }



        public int themKhuyenMai(string tenkm, DateTime timefrom, DateTime timeto, string lydokm, int manv)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("themDotKhuyenMai", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                cmd.Parameters.AddWithValue("@tenKM", tenkm);
                cmd.Parameters.AddWithValue("@ngayBatDau", timefrom);
                cmd.Parameters.AddWithValue("@ngayKetThuc", timeto);
                cmd.Parameters.AddWithValue("@lydoKM", lydokm);
                cmd.Parameters.AddWithValue("@maNVTaoKM", manv);

                int ID = (int)cmd.ExecuteScalar();
                conn.Close();
                return ID;
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public void themChitietkhuyenmai(int makm, int madochoi, int ptkm)
        {
            try
            {

                SqlCommand cmd = new SqlCommand("themCTKM", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                cmd.Parameters.AddWithValue("@makm", makm);
                cmd.Parameters.AddWithValue("@madochoi", madochoi);
                cmd.Parameters.AddWithValue("@ptgiamgia", ptkm);


                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
            {
                e.ToString();
                conn.Close();
            }
        }

        public int themTaiKhoan(string tenKh, string mk, string acc, string mst, string add, string email, string phone, string gioitinh, string cmnd)
        {
            try
            {

                SqlCommand cmd = new SqlCommand("themTaiKhoan", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                cmd.Parameters.AddWithValue("@username", acc);
                cmd.Parameters.AddWithValue("@pass", mk);
                cmd.Parameters.AddWithValue("@cmnd", cmnd);
                cmd.Parameters.AddWithValue("@hotenKH", tenKh);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@gioitinh", gioitinh);
                cmd.Parameters.AddWithValue("@sdt", phone);
                cmd.Parameters.AddWithValue("@diachi", add);
                cmd.Parameters.AddWithValue("@mst", mst);


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

        public int suaTaiKhoan(string username, string tenKh, string mk, string mst, string add, string email, string phone, string gioitinh, string cmnd)
        {
            try
            {

                SqlCommand cmd = new SqlCommand("suaTaiKhoan", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                cmd.Parameters.AddWithValue("@pass", mk);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@cmnd", cmnd.Trim());
                cmd.Parameters.AddWithValue("@hotenKH", tenKh);
                cmd.Parameters.AddWithValue("@email", email.Trim());
                cmd.Parameters.AddWithValue("@sdt", phone);
                cmd.Parameters.AddWithValue("@diachi", add.Trim());
                cmd.Parameters.AddWithValue("@mst", mst.Trim());


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

        #region utility
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
        public string SafeGetString(SqlDataReader reader, int colIndex)
        {
            try
            {
                if (!reader.IsDBNull(colIndex))
                    return reader.GetString(colIndex);
            }
            catch (Exception e)
            {
                return null;
            }
            return null;
        }

        public decimal SafeGetDecimal(SqlDataReader reader, int colIndex)
        {
            try
            {
                if (!reader.IsDBNull(colIndex))
                    return reader.GetDecimal(colIndex);
            }
            catch (Exception e)
            {
                return 0;
            }
            return 0;
        }
        #endregion

        #region hóa đơn
        public HoaDon layHoaDonTheoMa(string MaHD)
        {
            var hd = new HoaDon();
            try
            {
                SqlCommand cmd = new SqlCommand("layHoaDonTheoMa", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                cmd.Parameters.AddWithValue("@MaHD", MaHD);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    hd.MaHoaDon = dr.GetString(0);
                    hd.TongTien = dr.GetDecimal(1);
                    hd.NgayTaoHD = dr.GetDateTime(2);
                    hd.Mst = dr.GetString(3);
                    hd.MaNV = dr.GetInt32(4);
                }
                conn.Close();
            }
            catch (Exception e)
            {
                throw new Exception();
            }
            return hd;

        }

        public int taoHoaDon(string maHoaDon, decimal tongTien, int magh, string masothue, int manv)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("taoHoaDon", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                cmd.Parameters.AddWithValue("@maHD", maHoaDon);
                cmd.Parameters.AddWithValue("@tongTien", tongTien);
                cmd.Parameters.AddWithValue("@magh", magh);
                cmd.Parameters.AddWithValue("@mst", masothue);
                cmd.Parameters.AddWithValue("@manv", manv);

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

        #region login
        public KHACHHANG getCusByUser(string username)
        {
            var kh = new KHACHHANG();
            try
            {
                SqlCommand cmd = new SqlCommand("getCusByUser", conn);
                cmd.CommandType = CommandType.StoredProcedure;
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
                        masothue = dr.GetString(7),
                        taikhoan = new TAIKHOAN()
                        {
                            USERNAME = username,
                            PASSWORD = dr.GetString(11),
                            MAQUYEN = dr.GetInt32(10)
                        }
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

        public int hoanthanhDonHang(int maDonHang)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("hoanthanhDonHang", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                cmd.Parameters.AddWithValue("@maGioHang", maDonHang);


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

        public int duyetDonHang(int maDonHang, int maNVDuyet, int maNVGiao)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("duyetDonHang", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                cmd.Parameters.AddWithValue("@maNvDuyet", maNVDuyet);
                cmd.Parameters.AddWithValue("@maNvGiao", maNVGiao);
                cmd.Parameters.AddWithValue("@maGioHang", maDonHang);


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

        public NHANVIEN getEmpByUser(TAIKHOAN acc)
        {
            var kh = new NHANVIEN();
            try
            {
                SqlCommand cmd = new SqlCommand("getEmpByUser", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                cmd.Parameters.AddWithValue("@username", acc.USERNAME);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    kh = new NHANVIEN()
                    {
                        MaNV = dr.GetInt32(0),
                        TenNV = dr.GetString(1),
                        Email = dr.GetString(2),
                        GioiTinh = dr.GetBoolean(3),
                        SDT = dr.GetString(4),
                        DiaChi = dr.GetString(5),
                        TinhTrang = dr.GetBoolean(6),
                        MaSoThue = dr.GetString(7),
                        TAIKHOAN = new TAIKHOAN()
                        {
                            USERNAME = dr.GetString(8),
                            MAQUYEN = dr.GetInt32(10),
                            PASSWORD = dr.GetString(11)
                        },
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
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@username", account.USERNAME);
            cmd.Parameters.AddWithValue("@password", account.PASSWORD);
            SqlParameter oblLogin = new SqlParameter();
            oblLogin.ParameterName = "@Isvalid";
            oblLogin.SqlDbType = SqlDbType.Bit;
            oblLogin.Direction = ParameterDirection.Output;
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
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@username", account.USERNAME);
            cmd.Parameters.AddWithValue("@password", account.PASSWORD);
            cmd.Parameters.AddWithValue("@maquyen", account.MAQUYEN);
            SqlParameter oblLogin = new SqlParameter();
            oblLogin.ParameterName = "@Isvalid";
            oblLogin.SqlDbType = SqlDbType.Bit;
            oblLogin.Direction = ParameterDirection.Output;
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
                cmd.CommandType = CommandType.StoredProcedure;
                if (conn.State.ToString().Equals(ConnectionState.Closed.ToString()))
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
                cmd.CommandType = CommandType.StoredProcedure;
                if (conn.State.ToString().Equals(ConnectionState.Closed.ToString()))
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
                        //KHUYENMAI = km
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
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@brandId", maHang);
                if (conn.State.ToString().Equals(ConnectionState.Closed.ToString()))
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

                if (conn.State.ToString().Equals(ConnectionState.Closed.ToString()))
                {
                    conn.Open();
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
        public int suaDoChoi(int madochoi, int manv, int gia, string tendochoi, string mota)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("suaDoChoi", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@madochoi", madochoi);
                cmd.Parameters.AddWithValue("@manv", manv);
                cmd.Parameters.AddWithValue("@gia", gia);
                cmd.Parameters.AddWithValue("@tendochoi", tendochoi);
                cmd.Parameters.AddWithValue("@mota", mota);

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
        public DOCHOI layDoChoiTheoMa(int idDoChoi)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("layDoChoiTheoId", conn);
                cmd.CommandType = CommandType.StoredProcedure;
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
                    var doChoi = new DOCHOI();
                    conn.Close();
                    return doChoi;
                }
            }
            catch (Exception e)
            {
                var a = e.Message;
                var doChoi = new DOCHOI();
                conn.Close();
                return doChoi;

            }
        }
        public List<DOCHOI> layTatCaDoChoi()
        {
            var listDoChoi = new List<DOCHOI>();
            try
            {
                SqlCommand cmd = new SqlCommand("layTatCaDoChoi", conn);
                cmd.CommandType = CommandType.StoredProcedure;

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
                cmd.CommandType = CommandType.StoredProcedure;
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

        public bool CheckNgayKMGanNhat(DateTime ThoiGianKMMoi)
        {
            int datediff = 0;
            bool isValid = false;
            try
            {
                SqlCommand cmd = new SqlCommand("CheckNgayKMGanNhat", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                cmd.Parameters.AddWithValue("@ThoiGianKMMoi", ThoiGianKMMoi);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    datediff = dr.GetInt32(0);
                }

                isValid = datediff >= 0 ? true : false;

                conn.Close();
            }
            catch (Exception e)
            {
                throw new Exception();
            }
            return isValid;
        }

        public List<KHUYENMAI> layTatCaDotKM()
        {
            var listSuppliers = new List<KHUYENMAI>();
            try
            {
                SqlCommand cmd = new SqlCommand("layTatCaDotKM", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    var supplier = new KHUYENMAI();
                    supplier.Id = dr.GetInt32(0);
                    supplier.Name = dr.GetString(1);
                    supplier.NgayBatDau = dr.GetDateTime(2);
                    supplier.NgayKetThuc = dr.GetDateTime(3);
                    supplier.LyDoKM = dr.GetString(4);
                    supplier.NVTaoKM = new NHANVIEN()
                    {
                        MaNV = dr.GetInt32(5),
                        TenNV = dr.GetString(6)
                    };

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

        public KHUYENMAI layKmTheoDoChoi(int MaDoChoi)
        {
            var km = new KHUYENMAI();
            try
            {
                SqlCommand cmd = new SqlCommand("layKmTheoDoChoi", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                if (conn.State.ToString().Equals(ConnectionState.Closed.ToString()))
                {
                    conn.Open();
                }
                cmd.Parameters.AddWithValue("@MaDoChoi", MaDoChoi);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        var ctkm = new CTKM()
                        {
                            IdDoChoi = MaDoChoi,
                            PTGiamGia = dr.GetInt32(2),
                            IdKM = dr.GetInt32(3)
                        };

                        km = new KHUYENMAI()
                        {
                            Id = dr.GetInt32(0),
                            CTKM = ctkm,
                            NgayBatDau = dr.GetDateTime(5),
                            NgayKetThuc = dr.GetDateTime(6)
                        };
                    }

                }
                else
                {
                    var ctkm = new CTKM()
                    {
                        IdDoChoi = MaDoChoi,
                        PTGiamGia = 0,
                        IdKM = 0
                    };

                    km = new KHUYENMAI()
                    {
                        Id = 0,
                        CTKM = ctkm,
                        NgayBatDau = null,
                        NgayKetThuc = null
                    };

                }
                conn.Close();
            }
            catch (Exception e)
            {

            }

            return km;
        }

        public List<DOCHOI> layTatCaDoChoiV3()
        {
            var listDoChoiKM = new List<DOCHOI>();
            try
            {
                SqlCommand cmd = new SqlCommand("layTatCaDoChoiV2", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                if (conn.State.ToString().Equals(ConnectionState.Closed.ToString()))
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
                        TENHANGDOCHOI = dr.GetString(6),
                        MAHANGDOCHOI = dr.GetInt32(10)
                    };

                    //CTKM ctkm = new CTKM()
                    //{
                    //    IdDoChoi = idDoChoi,
                    //    PTGiamGia = 0,
                    //    IdKM = 0
                    //};

                    //KHUYENMAI km = new KHUYENMAI()
                    //{
                    //    Id = 0,
                    //    CTKM = ctkm,
                    //    NgayBatDau = null
                    //};

                    //ctkm = new CTKM()
                    //{
                    //    IdDoChoi = idDoChoi,
                    //    PTGiamGia = dr.GetInt32(3),
                    //    IdKM = dr.GetInt32(4)
                    //};

                    //km = new KHUYENMAI()
                    //{
                    //    Id = dr.GetInt32(4),
                    //    CTKM = ctkm,
                    //    NgayBatDau = dr.GetDateTime(5)
                    //};

                    //if (dr.GetDateTime(8) < DateTime.Now)
                    //{
                    //    ctkm = new CTKM()
                    //    {
                    //        IdDoChoi = idDoChoi,
                    //        PTGiamGia = 0,
                    //        IdKM = dr.GetInt32(4)
                    //    };

                    //    km = new KHUYENMAI()
                    //    {
                    //        Id = dr.GetInt32(4),
                    //        CTKM = ctkm,
                    //        NgayBatDau = dr.GetDateTime(5)
                    //    };
                    //}

                    DOCHOI doChoi = new DOCHOI(idDoChoi)
                    {
                        TenDoChoi = dr.GetString(7),
                        MaDoChoi = idDoChoi,
                        ThayDoiGia = gia,
                        //KHUYENMAI = km,
                        HANGDOCHOI = hang
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
        public List<GIOHANG> layTatCaGH()
        {
            var listCarts = new List<GIOHANG>();
            try
            {
                SqlCommand cmd = new SqlCommand("layTatCaGioHang", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    var cart = new GIOHANG()
                    {
                        MaGioHang = dr.GetInt32(0),
                        NvDuyet = new NHANVIEN()
                        {
                            MaNV = SafeGetInt(dr, 1),
                            TenNV = SafeGetString(dr, 14)
                        },
                        NvGiao = new NHANVIEN()
                        {
                            MaNV = SafeGetInt(dr, 2),
                            TenNV = SafeGetString(dr, 15)
                        },
                        KhachHang = new KHACHHANG()
                        {
                            cmnd = dr.GetString(3),
                            hotenkh = dr.GetString(16)
                        },

                        NgayGiao = dr.GetDateTime(4),
                        HoaDon = new HoaDon()
                        {
                            MaHoaDon = SafeGetString(dr, 6),
                        },
                        TrangThai = new TrangThai()
                        {
                            MaTrangThai = dr.GetInt32(5),
                            TenTrangThai = dr.GetString(13)
                        },
                        SDTNguoiNhan = dr.GetString(7),
                        ThoiGianNhanHang = dr.GetDateTime(8),
                        HoTenNguoiNhan = dr.GetString(9),
                        CMNDNguoNhan = dr.GetString(10),
                        DiaChiNhan = dr.GetString(11),
                        GhiChu = SafeGetString(dr, 12)
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
                cmd.CommandType = CommandType.StoredProcedure;

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
                cmd.CommandType = CommandType.StoredProcedure;
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
                cmd.CommandType = CommandType.StoredProcedure;
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

        public List<NHANVIEN> layTatCaNV()
        {
            var listNV = new List<NHANVIEN>();
            try
            {
                SqlCommand cmd = new SqlCommand("layTatCaNV", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    var nv = new NHANVIEN()
                    {
                        MaNV = dr.GetInt32(0),
                        TenNV = dr.GetString(1),
                        Email = dr.GetString(2),
                        GioiTinh = dr.GetBoolean(3),
                        SDT = dr.GetString(4),
                        DiaChi = dr.GetString(5),
                        TinhTrang = dr.GetBoolean(6),
                        MaSoThue = dr.GetString(7),
                        TAIKHOAN = new TAIKHOAN()
                        {
                            USERNAME = dr.GetString(8),
                            MAQUYEN = dr.GetInt32(10),
                            PASSWORD = dr.GetString(11)
                        }
                    };


                    listNV.Add(nv);
                }
                conn.Close();
            }
            catch (Exception e)
            {
                var ed = e.ToString();
            }
            return listNV;
        }

        public List<QUYEN> layTatCaQuyen()
        {
            var listNV = new List<QUYEN>();
            try
            {
                SqlCommand cmd = new SqlCommand("layTatCaQuyen", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    var nv = new QUYEN()
                    {
                        MaQuyen = dr.GetInt32(0),
                        TenQuyen = dr.GetString(1)
                    };


                    listNV.Add(nv);
                }
                conn.Close();
            }
            catch (Exception e)
            {
                var ed = e.ToString();
            }
            return listNV;
        }
        #endregion

        #region by toy id

        public ThayDoiGia layGiaTheoMaSanPham(int idDoChoi)
        {
            var gia = new ThayDoiGia();
            try
            {
                SqlCommand cmd = new SqlCommand("layGiaById", conn);
                cmd.CommandType = CommandType.StoredProcedure;
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
                cmd.CommandType = CommandType.StoredProcedure;
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

        #region crud cate
        public int themLoaiDoChoi(string tenHang)
        {
            try
            {

                SqlCommand cmd = new SqlCommand("themLoaiDoChoi", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                cmd.Parameters.AddWithValue("@tenLoai", tenHang);

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

        public int suaLoaiDoChoi(string tenHang, int maHang)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("suaLoaiDoChoi", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                cmd.Parameters.AddWithValue("@tenLoai", tenHang);
                cmd.Parameters.AddWithValue("@maLoai", maHang);

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

        public int xoaLoaiDoChoi(int maHang)
        {
            try
            {

                SqlCommand cmd = new SqlCommand("xoaDanhMuc", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                cmd.Parameters.AddWithValue("@maDanhMuc", maHang);

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

        #region crud hãng
        public List<HANGDOCHOI> layTatCaHang()
        {
            var listBrands = new List<HANGDOCHOI>();
            try
            {
                SqlCommand cmd = new SqlCommand("layTatCaHang", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    var brand = new HANGDOCHOI();
                    brand.MAHANGDOCHOI = dr.GetInt32(0);
                    brand.TENHANGDOCHOI = dr.GetString(1);
                    brand.HINHANH = SafeGetString(dr, 2);
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
                cmd.CommandType = CommandType.StoredProcedure;
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
                cmd.CommandType = CommandType.StoredProcedure;
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
                cmd.CommandType = CommandType.StoredProcedure;
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
                cmd.CommandType = CommandType.StoredProcedure;
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
                cmd.CommandType = CommandType.StoredProcedure;
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
                cmd.CommandType = CommandType.StoredProcedure;
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
                cmd.CommandType = CommandType.StoredProcedure;
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
                cmd.CommandType = CommandType.StoredProcedure;
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
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    cmd.Parameters.AddWithValue("@idDoChoi", maDoChoi);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        var supplier = new HINHANH();
                        supplier.HinhAnh = dr.GetString(1);
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

        public List<HINHANH> layAnhChiTiet(int? maDoChoi)
        {
            var supplier = new List<HINHANH>();
            if (maDoChoi > 0 || maDoChoi != null)
            {

                try
                {
                    SqlCommand cmd = new SqlCommand("layAnhChiTiet", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    cmd.Parameters.AddWithValue("@idDoChoi", maDoChoi);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        var a = new HINHANH();
                        a.HinhAnh = dr.GetString(1);
                        supplier.Add(a);
                    }
                    conn.Close();
                }
                catch (Exception e)
                {

                }
            }

            return supplier;
        }
        #endregion

        #region cart

        public GIOHANG layDHtheoMaGH(int maGH)
        {
            var cart = new GIOHANG();

            try
            {
                SqlCommand cmd = new SqlCommand("layDHtheoMaGH", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                cmd.Parameters.AddWithValue("@maGH", maGH);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    cart = new GIOHANG()
                    {
                        MaGioHang = dr.GetInt32(0),
                        NvDuyet = new NHANVIEN()
                        {
                            MaNV = SafeGetInt(dr, 1),
                            TenNV = SafeGetString(dr, 14)
                        },
                        NvGiao = new NHANVIEN()
                        {
                            MaNV = SafeGetInt(dr, 2),
                            TenNV = SafeGetString(dr, 15)
                        },
                        KhachHang = new KHACHHANG()
                        {
                            cmnd = dr.GetString(3),
                        },
                        NgayGiao = dr.GetDateTime(4),
                        HoaDon = new HoaDon()
                        {
                            MaHoaDon = SafeGetString(dr, 6),
                        },
                        TrangThai = new TrangThai()
                        {
                            MaTrangThai = dr.GetInt32(5),
                            TenTrangThai = dr.GetString(13)
                        },
                        SDTNguoiNhan = dr.GetString(7),
                        ThoiGianNhanHang = dr.GetDateTime(8),
                        HoTenNguoiNhan = dr.GetString(9),
                        CMNDNguoNhan = dr.GetString(10),
                        DiaChiNhan = dr.GetString(11),
                        GhiChu = SafeGetString(dr, 12)
                    };
                }
                conn.Close();
            }
            catch (Exception e)
            {
                throw new Exception();
            }
            return cart;
        }

        public List<CTGH> layCTDHtheoMaGH(int maGH)
        {
            var listCTGH = new List<CTGH>();

            try
            {
                SqlCommand cmd = new SqlCommand("layCTDHtheoMaGH", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                cmd.Parameters.AddWithValue("@maGH", maGH);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    var ctgh = new CTGH();
                    ctgh.MaGioHang = maGH;
                    ctgh.DoChoi = new DOCHOI()
                    {
                        MaDoChoi = dr.GetInt32(1)
                    };
                    ctgh.Gia = dr.GetDecimal(3);
                    ctgh.SoLuongMua = dr.GetInt32(5);




                    listCTGH.Add(ctgh);
                }
                conn.Close();
            }
            catch (Exception e)
            {
                throw new Exception();
            }
            return listCTGH;
        }

        public int KiemTraTon(int madochoi, int sldochoi)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("kiemtraTon", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                cmd.Parameters.AddWithValue("@maDoChoi", madochoi);
                cmd.Parameters.AddWithValue("@slDoChoi", sldochoi);
                var returnParameter = cmd.Parameters.Add("@return_value", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;
                cmd.ExecuteNonQuery();
                var result = returnParameter.Value;
                conn.Close();
                return (int)result;
            }
            catch (Exception e)
            {
                e.ToString();
                conn.Close();
                return 0;
            }

        }

        public int thanhtoanGioHang(string cmnd, decimal tongtien, string sdtnguoinhan, DateTime thoigian,
            string hotennguoinhan, string cmndnguoinhan, string diachi, string ghichu)
        {
            try
            {
                //@cmnd = N'025971880',
                //@mahoadon = N'HD1534531',
                //@tongtien = 500000,
                //@masothue = N'03882874'
                SqlCommand cmd = new SqlCommand("thanhtoanGioHang", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                cmd.Parameters.AddWithValue("@cmnd", cmnd);
                cmd.Parameters.AddWithValue("@tongtien", tongtien);
                cmd.Parameters.AddWithValue("@sdtnguoinhan", sdtnguoinhan);
                cmd.Parameters.AddWithValue("@thoigian", thoigian);
                cmd.Parameters.AddWithValue("@hotennguoinhan", hotennguoinhan);
                cmd.Parameters.AddWithValue("@cmndnguoinhan", cmndnguoinhan);
                cmd.Parameters.AddWithValue("@diachi", diachi);
                cmd.Parameters.AddWithValue("@ghichu", ghichu);

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
                cmd.CommandType = CommandType.StoredProcedure;
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

        #region report

        public List<Revenue> layDoanhThuTheoThang(DateTime datefrom, DateTime dateto)
        {
            var doanhThu = new List<Revenue>();
            try
            {
                SqlCommand cmd = new SqlCommand("layDoanhThu", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                cmd.Parameters.AddWithValue("@datefrom", datefrom.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@dateto", dateto.ToString("yyyy-MM-dd"));

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    var dt = new Revenue()
                    {
                        thang = dr.GetString(1),
                        year = dr.GetString(0),
                        revenue = SafeGetDecimal(dr, 2)
                    };

                    doanhThu.Add(dt);
                }
                conn.Close();
            }
            catch (Exception e)
            {
                throw new Exception();
            }
            return doanhThu;
        }

        #endregion
    }
}
