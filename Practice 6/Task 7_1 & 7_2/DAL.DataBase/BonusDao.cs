using System;
using System.Collections.Generic;
using System.Data.SqlClient;

using DAL.Interfaces;
using Common.Entities;

namespace DAL.DataBase
{
    public class BonusDao : IBonusDAO
    {

        private readonly IDao _objectDao;

        private string _connectionString;

        public BonusDao(string connectionString, IDao dao)
        {
            _connectionString = connectionString;
            _objectDao = dao;
        }

        public Guid AddBonus(Bonus bonus)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("dbo.Bonus_AddBonus", connection)
                {

                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@Id", bonus.Id);
                command.Parameters.AddWithValue("@Title", bonus.Title);

                connection.Open();
                command.ExecuteNonQuery();

                return bonus.Id;
            }
        }

        public bool ChangeBonus(Bonus newBonus)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("dbo.Bonus_ChangeBonus", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@Id", newBonus.Id);
                command.Parameters.AddWithValue("@Title", newBonus.Title);

                connection.Open();

                command.ExecuteNonQuery();

                return true;
            }
        }

        public bool DeleteBonus(Guid id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("dbo.Bonus_DeleteBonus", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@Id", id);

                connection.Open();

                command.ExecuteNonQuery();

                return true;
            }
        }

        public IEnumerable<Bonus> GetAllBonus()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("Bonus_GetAllBonus", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                connection.Open();

                var reader = command.ExecuteReader();

                Bonus bonus;

                while (reader.Read())
                {
                    bonus = new Bonus((Guid)reader["Id"], reader["Title"] as string);

                    foreach (var item in _objectDao.GetAllBonusedUserGuids(bonus.Id))
                    {
                        bonus.OwnerList.Add(item);
                    }

                    yield return bonus;
                }
            }
        }

        public Bonus GetBonus(Guid id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("Bonus_GetBonus", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@Id", id);

                connection.Open();

                var reader = command.ExecuteReader();

                reader.Read();

                return new Bonus((Guid)reader["Id"], reader["Title"] as string);
            }
        }

        public bool IsBonus(Guid id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("Bonus_GetBonus", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@Id", id);

                connection.Open();

                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return true;
                }

                return false;
            }
        }
    }
}
