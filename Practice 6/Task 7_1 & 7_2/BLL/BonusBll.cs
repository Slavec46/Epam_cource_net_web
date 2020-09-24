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

        public int ChangeBonus(Bonus bonus)
        {
            if (_bonusDao.ChangeBonus(bonus))
            {
                return 0;
            }
            return 1;
        }

        public int ChangeBonus(Bonus bonus, IBll objectBll)
        {
            var oldBonus = objectBll.Bonus.GetBonus(bonus.Id);

            foreach (var item in oldBonus.OwnerList)
            {
                objectBll.DeleteDependUserAndBonuses(item, bonus.Id);
            }

            ChangeBonus(bonus);

            foreach (var item in bonus.OwnerList)
            {
                var user = objectBll.Users.GetUser(item);
                user.BonusList.Add(bonus.Id);
                objectBll.Users.ChangeUser(user);
                objectBll.AddDependUserAndBonuses(item, bonus.Id);
            }

            return 1;
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

        public int DeleteBonus(Guid id)
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

        public int DeleteBonus(Guid id, IBll objectBll)
        {
            if (Guid.Empty == id || objectBll == null)
            {
                return -1;
            }

            foreach (var userId in _bonusDao.GetBonus(id).OwnerList)
            {
                objectBll.DeleteDependUserAndBonuses(userId, id);
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
