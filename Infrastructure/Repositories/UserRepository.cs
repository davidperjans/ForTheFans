using Application.Interfaces;
using Azure.Core;
using Domain.Entities;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<User>> GetFriendsOfUserAsync(Guid userId)
        {
            var friendships = await _context.Friendships
                .Include(f => f.User1)
                .Include(f => f.User2)
                .Where(f => f.User1Id == userId || f.User2Id == userId)
                .ToListAsync();

            var friends = friendships.Select(f =>
                f.User1Id == userId ? f.User2 : f.User1
            ).Distinct().ToList();

            return friends;
        }

        public async Task<List<User>> SearchUsersAsync(string query, Guid excludeUserId)
        {
            return await _context.Users
                .Where(u => (u.Username.Contains(query) || u.Email.Contains(query)) && u.Id != excludeUserId)
                .ToListAsync();
        }
    }
}
