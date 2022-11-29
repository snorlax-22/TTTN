using System.Data.SqlClient;

namespace TTTN.Helpers
{
    public class SQLHelper
    {
        static string dataSource = "188263-NMCUONG";
        static string dataBase = "TTTN";
        static string username = "sa";
        static string passWord = "123";
        static string timeOut = "30000";

        SqlConnection conn = new SqlConnection($"Data Source={dataSource}" +
            $";Initial Catalog={dataBase};" +
            $"User ID={username};" +
            $"Password={passWord};" +
            $"Integrated Security=true;" +
            $"Connect Timeout={timeOut};" +
            $"Encrypt=False;" +
            $"TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    }
}
