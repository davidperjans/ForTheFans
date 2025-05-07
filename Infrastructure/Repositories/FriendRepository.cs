using Application.Interfaces;
using Domain.Entities;
using Domain.Enums;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class FriendRepository : IFriendRepository
    {
        private readonly AppDbContext _context;
        public FriendRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> FriendRequestExistsAsync(Guid fromUserId, Guid toUserId)
        {
            return await _context.FriendRequests.AnyAsync(fr =>
            fr.FromUserId == fromUserId && fr.ToUserId == toUserId && fr.Status == RequestStatus.Pending);
        }
        public async Task AddFriendRequestAsync(FriendRequest friendRequest)
        {
            await _context.FriendRequests.AddAsync(friendRequest);
            await _context.SaveChangesAsync();
        }

        public async Task<FriendRequest?> GetFriendRequestByIdAsync(Guid requestId)
        {
            return await _context.FriendRequests.FirstOrDefaultAsync(fr => fr.Id == requestId);
        }

        public async Task AddFriendshipAsync(Friendship friendship)
        {
            await _context.Friendships.AddAsync(friendship);
            await _context.SaveChangesAsync();
        }

        public async Task<List<User>> GetFriendsOfUserAsync(Guid userId)
        {
            var friendships = await _context.Friendships
                .Where(f => f.User1Id == userId || f.User2Id == userId)
                .Include(f => f.User1)
                .Include(f => f.User2)
                .ToListAsync();

            var friends = friendships.Select(f =>
                f.User1Id == userId ? f.User2 : f.User1).ToList();

            return friends;
        }

        public async Task<Friendship?> GetFriendshipAsync(Guid userId, Guid friendId)
        {
            return await _context.Friendships
                .FirstOrDefaultAsync(f => 
                    (f.User1Id == userId && f.User2Id == friendId) ||
                    (f.User1Id == friendId && f.User2Id == userId));
        }

        public async Task RemoveFriendshipAsync(Friendship friendship)
        {
            _context.Friendships.Remove(friendship);
            await _context.SaveChangesAsync();
        }

        public async Task<List<FriendRequest>> GetPendingFriendRequestsAsync(Guid userId)
        {
            return await _context.FriendRequests
            .Where(fr => fr.ToUserId == userId && fr.Status == RequestStatus.Pending)
            .Include(fr => fr.FromUser)
            .ToListAsync();
        }
    }
}
