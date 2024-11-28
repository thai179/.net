using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Đồ_án
{
    internal class ConnectionManager
    {
        private static string connectionString = "Data Source=LAPTOP-VSAJD1CH\\THAI; Database=QLKTX_V1;User ID=sa; Password=tahabie@1204;TrustServerCertificate=True";

        // Phương thức trả về đối tượng SqlConnection
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
