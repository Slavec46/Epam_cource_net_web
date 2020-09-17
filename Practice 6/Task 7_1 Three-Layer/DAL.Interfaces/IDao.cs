using System;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    interface IDao
    {
        IUsersDao Users { get; }

        IBonusDAO Bonus { get; }

        IEnumerable<Guid> GetAllCustomBonusGuids(Guid userId);

        IEnumerable<Guid> GetAllBonusedUsersGuids(Guid BonusId);

        void AddDependUserAndBonuses(Guid userId, Guid bonusId);

        void RemoveDependUserAndBonuses(Guid userId, Guid bonusId);
    }
}
