using Đồ_án;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class UserDAL
    {
        public string AuthenticateUser(UserDTO user)
        {
            using (SqlConnection connection = ConnectionManager.GetConnection())
            {
                string query = "SELECT chucvu FROM nguoidung WHERE userid = @Username AND matkhau = @Password";

                try
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        Console.WriteLine(user.Username, user.Password);
                        // Thêm tham số để tránh SQL Injection
                        command.Parameters.AddWithValue("@Username", user.Username);
                        command.Parameters.AddWithValue("@Password", user.Password);

                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null )
                        {
                            return result.ToString();
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi kết nối cơ sở dữ liệu
                    throw new Exception("Lỗi kết nối cơ sở dữ liệu: " + ex.Message);
                }
            }
        }


    }
}
