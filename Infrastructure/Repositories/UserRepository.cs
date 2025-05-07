using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public async Task<List<User>> SearchUsersAsync(string query, Guid excludeUserId)
        {
            return await _context.Users
                .Where(u => (u.Username.Contains(query) || u.Email.Contains(query)) && u.Id != excludeUserId)
                .ToListAsync();
        }
    }
}
