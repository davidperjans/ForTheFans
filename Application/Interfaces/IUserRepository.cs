﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<List<User>> SearchUsersAsync(string query, Guid excludeUserId);
        Task<List<User>> GetFriendsOfUserAsync(Guid userId);
    }
}
