using System;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IBll
    {
        IUsersBll Users { get; }

        IBonusBll Bonus { get; }

        IEnumerable<Guid> GetAllCustomBonusGuids(Guid userId);

        IEnumerable<Guid> GetAllBonusUserGuids(Guid bonusId);

        void AddDependUserAndBonuses(Guid userId, Guid bonusId);

        void DeleteDependUserAndBonuses(Guid userId, Guid bonusId);
    }
}
