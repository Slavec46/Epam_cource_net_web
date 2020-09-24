using System;
using System.Collections.Generic;
using System.Text;

using BLL.Interfaces;

namespace BLL
{
    class Authentication
    {
        private readonly IUsersBll _users;

        public Authentication(IUsersBll users)
        {
            _users = users;
        }

        public bool CheckAuthentification(string login, string password)
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
