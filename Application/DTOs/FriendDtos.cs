﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class FriendDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string ProfilePicture { get; set; }
    }
}
