﻿using System;
using System.Collections.Generic;

namespace Common.Entities
{
    public class Bonus
    {
        public Guid Id { get; }

        public string Title { get; set; }

        public List<Guid> OwnerList { get; }

        public Bonus(Guid id, string title)
        {
            Id = id;
            Title = title;
            OwnerList = new List<Guid>();
        }
    }
}
