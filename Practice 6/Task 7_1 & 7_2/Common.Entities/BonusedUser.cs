using System;
using System.Collections.Generic;

namespace Common.Entities
{
    class BonusedUser
    {
        public Guid Id { get; }

        public string Name { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }

        public DateTime DateOfBirth { get; set; }

        public List<Bonus> BonusList { get; }

        public BonusedUser(Guid id, string name, DateTime dateOfBirth, string login, string password, string role)
        {
            Id = id;
            Name = name;
            DateOfBirth = dateOfBirth;
            BonusList = new List<Bonus>();
            Login = login;
            Password = password;
            Role = role;
        }
    }
}
