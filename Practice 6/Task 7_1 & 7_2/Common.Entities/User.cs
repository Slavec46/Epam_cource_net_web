﻿using System;
using System.Collections.Generic;

namespace Common.Entities
{
    public class User
    {
        public Guid Id { get; }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public List<Guid> BonusList { get; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }

        public User(Guid id, string name, DateTime dateOfBirth, string login, string password, string role)
        {
            Id = id;
            Name = name;
            DateOfBirth = dateOfBirth;
            BonusList = new List<Guid>();
            Login = login;
            Password = password;
            Role = role;
        }
    }
}
