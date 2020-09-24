using System;
using System.Collections.Generic;
using Common.Entities;

namespace BLL.Interfaces
{
    public interface IUsersBll
    {
        Guid AddUser(User user);

        int DeleteUser(Guid id);

        bool IsUser(Guid id);

        User GetUser(Guid id);

        IEnumerable<User> GetAllUsers();
    }
}
