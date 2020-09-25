using System;
using System.Collections.Generic;
using System.Data.SqlClient;

using Common.Entities;
using DAL.Interfaces;

namespace Epam.Task_7.DAL.DataBase
{
    public class UsersDao : IUsersDao
    {
        private readonly IDao _objectDao;

        private string _connectionString;

        public UsersDao(string connectionString, IDao dao)
        {
            _connectionString = connectionString;
            _objectDao = dao;
        }

        public Guid AddUser(User user)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("dbo.Account_AddUser", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@Id", user.Id);
                command.Parameters.AddWithValue("@Login", user.Login);
                command.Parameters.AddWithValue("@Password", user.Password);
                command.Parameters.AddWithValue("@Role", user.Role);
                command.Parameters.AddWithValue("@Name", user.Name);
                command.Parameters.AddWithValue("@DateOfBirth", user.DateOfBirth);

                connection.Open();

                command.ExecuteNonQuery();

                return user.Id;
            }
        }

        public bool ChangeUser(User newUser)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("dbo.Account_ChangeUser", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@Id", newUser.Id);
                command.Parameters.AddWithValue("@Login", newUser.Login);
                command.Parameters.AddWithValue("@Password", newUser.Password);
                command.Parameters.AddWithValue("@Role", newUser.Role);
                command.Parameters.AddWithValue("@Name", newUser.Name);
                command.Parameters.AddWithValue("@DateOfBirth", newUser.DateOfBirth);

                connection.Open();

                command.ExecuteNonQuery();

                return true;
            }
        }

        public IEnumerable<User> GetAllUsers()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("dbo.Account_GetAllUsers", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                connection.Open();

                var reader = command.ExecuteReader();

                User user;

                while (reader.Read())
                {
                    user = new User(
                        (Guid)reader["Id"],
                        (string)reader["Name"],
                        (DateTime)reader["DateOfBirth"],
                        (string)reader["Login"],
                        (string)reader["Password"],
                        (string)reader["Role"]
                    );

                    foreach (var item in _objectDao.GetAllCustomBonusGuids(user.Id))
                    {
                        user.BonusList.Add(item);
                    }

                    yield return user;
                }
            }
        }

        public User GetUser(Guid id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("dbo.Account_GetUser", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@Id", id);

                connection.Open();

                var reader = command.ExecuteReader();

                reader.Read();

                User user = new User(
                        (Guid)reader["Id"],
                        (string)reader["Name"],
                        (DateTime)reader["DateOfBirth"],
                        (string)reader["Login"],
                        (string)reader["Password"],
                        (string)reader["Role"]
                    );

                foreach (var item in _objectDao.GetAllCustomBonusGuids(user.Id))
                {
                    user.BonusList.Add(item);
                }

                return user;
            }
        }

        public bool IsUser(Guid id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("dbo.Account_IsUser", connection)
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

        public bool DeleteUser(Guid id) 
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("dbo.Account_RemoveUser", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@Id", id);

                connection.Open();

                command.ExecuteNonQuery();

                return true;
            }
        }
    }
}