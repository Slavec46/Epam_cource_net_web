using System;
using System.Collections.Generic;
using System.IO;

using DAL.Interfaces;
using Common.Entities;

namespace DAL.Json
{
    class ObjectDao : IDao
    {
        public IUsersDao Users { get; }
        public IBonusDAO Bonus { get; }

        private readonly string _storagePath;

        public ObjectDao(string storagePath, string storageName = "StorageJson")
        {
            _storagePath = Path.Combine(storagePath, storageName);
            CreateDirectory(_storagePath);

            Users = new UsersDao(_storagePath);
            Bonus = new BonusDao(_storagePath);
        }

        public void AddDependUserBonuses(Guid userId, Guid bonusId)
        {
            User user = Users.GetUser(userId);
            Bonus bonus = Bonus.GetBonus(bonusId);

            user.BonusList.Add(bonusId);
            bonus.OwnerList.Add(userId);

            Users.ChangeUser(user);
            Bonus.ChangeBonus(bonus);
        }

        public IEnumerable<Guid> GetAllBonusedUserGuids(Guid bonusId)
        {
            Bonus bonus = Bonus.GetBonus(bonusId);

            foreach (var item in bonus.OwnerList)
            {
                yield return item;
            }
        }




        private void CreateDirectory(string path)
        {
            Directory.CreateDirectory(path);
        }
    }
}
