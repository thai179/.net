using Đồ_án;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class UserBLL
    {
        private readonly UserDAL _userDAL;

        public UserBLL()
        {
            _userDAL = new UserDAL();
        }

        public string AuthenticateUser(string username, string password)
        {
            UserDTO user = new UserDTO
            {
                Username = username,
                Password = password
            };

            return _userDAL.AuthenticateUser(user);
        }
    }
}
