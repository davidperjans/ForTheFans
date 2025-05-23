﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Stadium
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int Capacity { get; set; }
        public string Surface { get; set; }
        public string ImageUrl { get; set; }


        // Navigering
        public ICollection<Post> Posts { get; set; } = new List<Post>();
    }
}
