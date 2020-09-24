using System;
using System.Collections.Generic;

using BLL.Interfaces;
using DAL.Interfaces;
using Common.Entities;

namespace BLL
{
    public class BonusBll : IBonusBll
    {
        private readonly IBonusDAO _bonusDao;

        public BonusBll(IBonusDAO bonusDAO)
        {
            _bonusDao = bonusDAO;
        }

        public Guid AddBonus(Bonus bonus)
        {
            if (bonus.Id == Guid.Empty || string.IsNullOrWhiteSpace(bonus.Title))
            {
                return Guid.Empty;
            }

            return _bonusDao.AddBonus(bonus);
        }

        public IEnumerable<Bonus> GetAllBonuses()
        {
            foreach (var item in _bonusDao.GetAllBonus())
            {
                yield return item;
            }
        }

        /// <exception cref="ArgumentException"><</exception>
         
        public Bonus GetBonus(Guid id)
        {
            if (Guid.Empty == id)
            {
                throw new ArgumentException("Argument id is empty.");
            }

            try
            {
                return _bonusDao.GetBonus(id);
            }
            catch (ArgumentException)
            {
                throw new ArgumentException("Incorrect id");
            }
        }

        public bool IsBonus(Guid id)
        {
            if (Guid.Empty == id)
            {
                return false;
            }

            return _bonusDao.IsBonus(id);
        }

        public int RemoveBonus(Guid id)
        {
            if (Guid.Empty == id)
            {
                return -1;
            }

            if (_bonusDao.DeleteBonus(id))
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
