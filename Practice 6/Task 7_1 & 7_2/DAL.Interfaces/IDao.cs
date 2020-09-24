using System;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IDao
    {
        IUsersDao Users { get; }

        IBonusDAO Bonus { get; }

        IEnumerable<Guid> GetAllCustomBonusGuids(Guid userId);

        IEnumerable<Guid> GetAllBonusedUsersGuids(Guid bonusId);

        void AddDependUserAndBonuses(Guid userId, Guid bonusId);

        void DeleteDependUserAndBonuses(Guid userId, Guid bonusId);
    }
}
