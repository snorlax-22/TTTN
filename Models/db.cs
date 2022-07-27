using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BT2MWG.Models
{
    public class db
    {
        SqlConnection conn = new SqlConnection("Data Source=SNORLAX;Initial Catalog=TTTN;User ID=sa;Password=123;Integrated Security=true;Connect Timeout=300;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
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

        public int themDoChoi(string manv, string tenDoChoi, double giaMoi, string slAnh, string listAnh)
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
        
        public DOCHOI layDoChoiTheoMa(int idDoChoi)
        {
            var listDoChoi = new List<DOCHOI>();
            try
            {
                SqlCommand cmd = new SqlCommand("layDoChoiTheoId", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idDoChoi", idDoChoi);
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

            return listDoChoi[0];
        }

        public int suaHangDoChoi(string tenHang, int maHang)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("suaHangDoChoi", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
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

    }
}
