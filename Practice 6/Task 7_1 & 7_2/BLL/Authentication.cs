using DAL.DataBase;
using DAL.Interfaces;
using BLL;
using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Authentication : IAuthenfication
    {
        private readonly IUsersBll _users;

        public Authentication(IUsersBll users)
        {
            _users = users;
        }

        public bool CheckAuthentication(string login, string password)
        {
            foreach (var user in _users.GetAllUsers())
            {
                if (user.Login == login && user.Password == password)
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsLogin(string login)
        {
            foreach (var user in _users.GetAllUsers())
            {
                if (user.Login == login)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
