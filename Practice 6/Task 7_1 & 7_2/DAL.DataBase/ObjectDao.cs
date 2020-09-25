using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

using Common.Entities;
using DAL.Interfaces;
using DAL.DataBase;

namespace Epam.Task_7.DAL.DataBase
{
    public class ObjectDao : IDao
    {
        public IUsersDao Users { get; }

        public IBonusDAO Bonus { get; }

        private string _connectionString;

        public ObjectDao(string connectionString = @"////////////")
        {
            _connectionString = connectionString;

            Users = new UsersDao(_connectionString, this);
            Bonus = new BonusDao(_connectionString, this);
        }

        public void AddDependUserAndBonuses(Guid userId, Guid bonusId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("dbo.AccountAndBonus_AddDependUserAndBonus", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@UserId", userId);
                command.Parameters.AddWithValue("@BonusId", bonusId);

                connection.Open();

                command.ExecuteNonQuery();
            }
        } 

        public IEnumerable<Guid> GetAllBonusedUserGuids(Guid bonusId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("dbo.AccountAndBonus_GetAllBonusedUserGuids", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@Id", bonusId);

                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return (Guid)reader["AccountID"];
                }
            }
        }

        public IEnumerable<Guid> GetAllCustomBonusGuids(Guid userId) 
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("dbo.AccountAndBonus_GetAllСustomBonusGuids", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@Id", userId);

                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return (Guid)reader["BonusID"];
                }
            }
        }
         
        public void DeleteDependUserAndBonuses(Guid userId, Guid bonusId) 
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("dbo.AccountAndBonus_RemoveDependUserAndBonus", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@UserId", userId);
                command.Parameters.AddWithValue("@BonusId", bonusId);

                connection.Open();

                command.ExecuteNonQuery();
            }
        }
    }
}