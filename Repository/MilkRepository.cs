using System.Collections.Generic;
using System;
using System.Data.SqlClient;
using TTTN.Models;

namespace TTTN.Repository
{
    public class MilkRepository
    {
        SqlConnection conn = new SqlConnection("Data Source=188263-NMCUONG;Initial Catalog=TTTN;User ID=sa;Password=123;Integrated Security=true;Connect Timeout=30000;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        public List<DOCHOI> layTatCaDoChoiV3()
        {
            var listDoChoiKM = new List<DOCHOI>();
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
    }
}

