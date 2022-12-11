using System.Collections.Generic;
using System;
using System.Data.SqlClient;
using TTTN.Models;
using static TTTN.Models.SUA;

namespace TTTN.Repository
{
    public class MilkRepository
    {
        SqlConnection conn = new SqlConnection("Data Source=188263-NMCUONG;Initial Catalog=TTTN;User ID=sa;Password=123;Integrated Security=true;Connect Timeout=30000;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        public string SafeGetString(SqlDataReader reader, int colIndex)
        {
            try
            {
                if (!reader.IsDBNull(colIndex))
                    return reader.GetString(colIndex);
            }
            catch (Exception e)
            {
                return "";
            }
            return "";
        }

        public List<DoTuoi> layTatCaDoTuoi()
        {
            var listBrands = new List<DoTuoi>();
            try
            {
                SqlCommand cmd = new SqlCommand("select * from DOTUOI", conn);
                cmd.CommandType = System.Data.CommandType.Text;

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    var brand = new DoTuoi()
                    {
                        MaDoTuoi = dr.GetInt32(0),
                        stDoTuoi = dr.GetString(1)
                    };

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

        public List<SUA> layTatCaDoChoiV3()
        {
            var listDoChoiKM = new List<SUA>();
            try
            {
                SqlCommand cmd = new SqlCommand("layTatCaDoChoiV2", conn);
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
                        TENHANGDOCHOI = dr.GetString(6),
                        MAHANGDOCHOI = dr.GetInt32(10),
                        MAXUATXU = dr.GetInt32(11),
                    };

                    DoTuoi doTuoi = new DoTuoi()
                    {
                        MaDoTuoi = dr.GetInt32(12),
                        stDoTuoi = dr.GetString(13)
                    };

                    Nutri nutris = new Nutri()
                    {
                        id = dr.GetInt32(9)
                    };

                    SUA doChoi = new SUA()
                    {
                        Nutris = nutris,
                        TenSua = dr.GetString(7),
                        MaSua = idDoChoi,
                        ThayDoiGia = gia,
                        //KHUYENMAI = km,
                        HANGDOCHOI = hang,
                        DoTuoi = doTuoi
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

        public List<Nutri> getAllNutritions()
        {
            var listBrands = new List<Nutri>();
            try
            {
                SqlCommand cmd = new SqlCommand("getAllNutris", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    var brand = new Nutri();
                    brand.id = dr.GetInt32(0);
                    brand.Protein = dr.GetDouble(1);
                    brand.TotalFat = dr.GetDouble(2);
                    brand.TotalCarbon = dr.GetDouble(3);
                    brand.Calcium = dr.GetDouble(4);
                    brand.Sodium = dr.GetDouble(5);
                    brand.Magnesium = dr.GetDouble(6);
                    brand.Iron = dr.GetDouble(7);
                    brand.Copper = dr.GetDouble(8);
                    brand.Potassium = dr.GetDouble(9);
                    brand.VitaminD3 = dr.GetDouble(10);
                    brand.VitaminB1 = dr.GetDouble(11);
                    brand.VitaminB2 = dr.GetDouble(12);
                    brand.Iodine = dr.GetDouble(13);
                    brand.Zinc = dr.GetDouble(14);

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

        public SUA laySuaTheoMa(int idDoChoi)
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

                    var doChoi = new SUA(nhaCC, hangPH);
                    doChoi.MaSua = dr.GetInt32(0);
                    doChoi.TenSua = dr.GetString(1);
                    doChoi.TrangThai = dr.GetBoolean(2);
                    doChoi.MoTa = dr.GetString(3);
                    doChoi.SLTon = dr.GetInt32(4);
                    conn.Close();
                    return doChoi;
                }
                else
                {
                    var doChoi = new SUA();
                    conn.Close();
                    return doChoi;
                }
            }
            catch (Exception e)
            {
                var a = e.Message;
                var doChoi = new SUA();
                conn.Close();
                return doChoi;

            }
        }

        public KHUYENMAI layKmTheoSua(int masua)
        {
            var km = new KHUYENMAI();
            try
            {
                SqlCommand cmd = new SqlCommand("layKmTheoDoChoi", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                cmd.Parameters.AddWithValue("@MaDoChoi", masua);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        var ctkm = new CTKM()
                        {
                            IdDoChoi = masua,
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
                        IdDoChoi = masua,
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

        public List<HINHANH> layTatCaAnhTheoSua(int? maDoChoi)
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

        public int themDoTuoi(string tenHang)
        {
            try
            {

                SqlCommand cmd = new SqlCommand("themDoTuoi", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                cmd.Parameters.AddWithValue("@DoTuoi", tenHang);

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

        public int xoaDoTuoi(int maHang)
        {
            try
            {

                SqlCommand cmd = new SqlCommand("xoaDoTuoi", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                cmd.Parameters.AddWithValue("@maDoTuoi", maHang);

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

        public int suaDoTuoi(string tenHang, int maHang)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("suaDoTuoi", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                cmd.Parameters.AddWithValue("@tenDoTuoi", tenHang);
                cmd.Parameters.AddWithValue("@idDoTuoi", maHang);

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

        public int taoPhieuNhap(int manv)
        {
            try
            {

                SqlCommand cmd = new SqlCommand("taophieunhap", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
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

        public int nhaphang(int masua, int mapn, int sl, DateTime ngaysx, DateTime ngayhethan, DateTime ngaysdtotnhat, string mota)
        {
            try
            {

                SqlCommand cmd = new SqlCommand("nhaphang", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                cmd.Parameters.AddWithValue("@mapn", mapn);
                cmd.Parameters.AddWithValue("@masua", masua);
                cmd.Parameters.AddWithValue("@sl", sl);
                cmd.Parameters.AddWithValue("@mota", mota);
                cmd.Parameters.AddWithValue("@ngaysx", ngaysx.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@ngagyhethan", ngayhethan.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@ngaysdtotnhat", ngaysdtotnhat.ToString("yyyy-MM-dd"));

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

        public LoHang layLoHangTheoSua(int idSua)
        {
            var gia = new LoHang();
            try
            {
                SqlCommand cmd = new SqlCommand("laylohang", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                cmd.Parameters.AddWithValue("@idsua", idSua);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {


                    gia = new LoHang();

                    gia.id = dr.GetInt32(0);
                    gia.sl = dr.GetInt32(1);
                    gia.mapn = dr.GetInt32(2);
                    gia.ngaysx = dr.GetDateTime(3);
                    gia.ngayhethan = dr.GetDateTime(4);
                    gia.ngaysdtotnhat = dr.GetDateTime(5);
                    gia.mota = SafeGetString(dr,6);
                    
                }
                conn.Close();
            }
            catch (Exception e)
            {
                throw new Exception();
            }
            return gia;
        }
    }
}

