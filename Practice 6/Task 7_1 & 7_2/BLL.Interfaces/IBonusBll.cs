using System;
using System.Collections.Generic;
using Common.Entities;

namespace BLL.Interfaces
{
    public interface IBonusBll
    {
        Guid AddBonus(Bonus bonus);

        int ChangeBonus(Bonus bonus);

        int ChangeBonus(Bonus bonus, IBll objectBll);

        int DeleteBonus(Guid id);

        int DeleteBonus(Guid id, IBll objectBll);

        bool IsBonus(Guid id);

        Bonus GetBonus(Guid id);

        IEnumerable<Bonus> GetAllBonuses();
    }
}
