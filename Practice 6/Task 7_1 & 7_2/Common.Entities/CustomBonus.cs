using System;
using System.Collections.Generic;

namespace Common.Entities
{
    class CustomBonus
    {
        public Guid Id { get; }

        public string Title { get; set; }

        public List<User> OwnerList { get; }

        public CustomBonus(Guid id, string title)
        {
            Id = id;
            Title = title;
            OwnerList = new List<User>();
        }
    }
}
