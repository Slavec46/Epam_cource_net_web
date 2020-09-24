using System;
using System.Collections.Generic;
using Common.Entities;

namespace DAL.Interfaces
{
   public interface IUsersDao
   {
        Guid AddUser(User user);

        bool ChangeUser(User newUser);

        bool DeleteUser(Guid id);

        bool IsUser(Guid id);

        User GetUser(Guid id);

        IEnumerable<User> GetAllUsers();
    }
}
