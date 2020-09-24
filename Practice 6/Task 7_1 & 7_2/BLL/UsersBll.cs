using System;
using System.Collections.Generic;

using BLL.Interfaces;
using DAL.Interfaces;
using Common.Entities;

namespace BLL
{
    public class UsersBll : IUsersBll
    {
        private readonly IUsersDao _usersDao;

        public UsersBll(IUsersDao usersDao)
        {
            _usersDao = usersDao;
        }

        public Guid AddUser(User user)
        {
            if (user.Id == Guid.Empty)
            {
                return _usersDao.AddUser(user); 
            }

            return _usersDao.AddUser(user);
        }

        public IEnumerable<User> GetAllUsers()
        {
            foreach (var item in _usersDao.GetAllUsers())
            {
                yield return item;
            }
        }

        /// <exception cref="ArgumentException"></exception>
        
        public User GetUser(Guid id)
        {
            if (Guid.Empty == id)
            {
                throw new ArgumentException("Argument id is empty.");
            }

            try
            {
                return _usersDao.GetUser(id);
            }
            catch (ArgumentException)
            {
                throw new ArgumentException("Incorrect id.");
            }
        }

        public bool IsUser(Guid id)
        {
            if (Guid.Empty == id)
            {
                return false;
            }

            return _usersDao.IsUser(id);
        }

        public int DeleteUser(Guid id)
        {
            if (Guid.Empty == id)
            {
                return -1;
            }

            if (_usersDao.DeleteUser(id))
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
    }
}
