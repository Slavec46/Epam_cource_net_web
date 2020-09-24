using System;
using System.Collections.Generic;

namespace Common.Entities
{
    public class User
    {
        public Guid Id { get; }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public List<Guid> BonusList { get; }

        public User(Guid id, string name, DateTime dateOfBirth)
        {
            Id = id;
            Name = name;
            DateOfBirth = dateOfBirth;
            BonusList = new List<Guid>();
        }
    }
}
