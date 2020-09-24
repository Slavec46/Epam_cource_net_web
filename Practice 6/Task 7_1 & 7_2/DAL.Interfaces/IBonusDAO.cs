using Common.Entities;
using System;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IBonusDAO
    {
        Guid AddBonus(Bonus bonus);

        bool ChangeBonus(Bonus newBonus);

        bool DeleteBonus(Guid id);

        bool IsBonus(Guid id);

        Bonus GetBonus(Guid id);

        IEnumerable<Bonus> GetAllBonus();
    }
}
