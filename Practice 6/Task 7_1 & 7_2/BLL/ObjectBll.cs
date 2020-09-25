using System;
using System.Collections.Generic;

using BLL.Interfaces;
using DAL.Interfaces;

namespace BLL
{
    public class ObjectBll : IBll
    {
        public IUsersBll Users { get; }
        public IBonusBll Bonus { get; }
        private readonly IDao _objectDao;

        public ObjectBll(IDao objectDao)
        {
            _objectDao = objectDao;

            Users = new UsersBll(_objectDao.Users);

            Bonus = new BonusBll(_objectDao.Bonus);
        }

        public IEnumerable<Guid> GetAllCustomBonusGuids(Guid userId)
        {
            if (!_objectDao.Users.IsUser(userId))
            {
                throw new ArgumentException("Incorrect argument userId");
            }

            foreach (var item in _objectDao.GetAllCustomBonusGuids(userId))
            {
                yield return item;
            }
        }

        public IEnumerable<Guid> GetAllBonusUserGuids(Guid bonusId)
        {
            if (!_objectDao.Bonus.IsBonus(bonusId))
            {
                throw new ArgumentException("Incorrect argument bonusId.");
            }

            foreach (var item in _objectDao.GetAllBonusedUserGuids(bonusId))
            {
                yield return item;
            }
        }

        public void AddDependUserAndBonuses(Guid userId, Guid bonusId)
        {
            if (!Users.IsUser(userId))
            {
                throw new ArgumentException("Incorrect argument userId.");
            }
            else if (!Bonus.IsBonus(bonusId))
            {
                throw new ArgumentException("Incorrect argument bonusId.");
            }
            else
            {
                _objectDao.AddDependUserAndBonuses(userId, bonusId);
            }
        }

        public void DeleteDependUserAndBonuses(Guid userId, Guid bonusId)
        {
            if (!Users.IsUser(userId))
            {
                throw new ArgumentException("Incorrect argument userId.");
            }
            else if (!Bonus.IsBonus(bonusId))
            {
                throw new ArgumentException("Incorrect argument bonusId.");
            }
            else
            {
                _objectDao.DeleteDependUserAndBonuses(userId, bonusId);
            }
        }
    }
}
