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

                    Nutri nutris = new Nutri()
                    {
                        id = dr.GetInt32(9)
                    };

                    DOCHOI doChoi = new DOCHOI(idDoChoi)
                    {
                        Nutris = nutris,
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
    }
}

