using System;
using System.Collections.Generic;
using Common.Entities;

namespace BLL.Interfaces
{
    public interface IBonusBll
    {
        Guid AddBonus(Bonus bonus);

        int RemoveBonus(Guid id);

        bool IsBonus(Guid id);

        Bonus GetBonus(Guid id);

        IEnumerable<Bonus> GetAllBonus();
    }
}
