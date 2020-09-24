using System;
using System.Collections.Generic;
using Common.Entities;

namespace BLL.Interfaces
{
    public interface IUsersBll
    {
        Guid AddUser(User user);

        int ChangeUser(User user);

        int ChangeUser(User user, IBll objectBll);

        int DeleteUser(Guid id);

        int DeleteUser(Guid id, IBll objectBll);

        bool IsUser(Guid id);

        User GetUser(Guid id);

        IEnumerable<User> GetAllUsers();
    }
}
