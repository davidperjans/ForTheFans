using Application.DTOs;
using Application.Interfaces;
using Azure.Core;
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
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        private readonly AppDbContext _context;
        public PostRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<Post>> GetAllWithUsersAsync()
        {
            return await _context.Posts
                .Include(p => p.User)
                .ToListAsync();
        }

        public async Task<Post?> GetByIdWithUserAsync(Guid postId)
        {
            return await _context.Posts
                .Include(p => p.User)
                .FirstOrDefaultAsync(p => p.Id == postId);
        }

        public async Task<List<PostSummaryDto>> GetPostsByStadiumSlugAsync(string slug)
        {
            var stadium = await _context.Stadiums.FirstOrDefaultAsync(s => s.Slug == slug);
            if (stadium == null) return null;

            return await _context.Posts
                .Where(p => p.StadiumId == stadium.Id)
                .Include(p => p.User)
                .Select(p => new PostSummaryDto
                {
                    Id = p.Id,
                    Username = p.User.Username,
                    IsPrivate = p.User.IsPrivate ?? false,
                    Rating = p.Rating,
                    Comment = p.Comment,
                    CreatedAt = p.CreatedAt,
                    PhotoUrl = p.PhotoUrl
                })
                .ToListAsync();
        }

        public async Task<List<PostWithViewPermissionDto>> GetPostsByUserAsync(Guid targetUserId, Guid currentUserId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == targetUserId);
            if (user == null)
                return new List<PostWithViewPermissionDto>();

            var areFriends = await _context.Friendships.AnyAsync(f =>
                (f.User1Id == currentUserId && f.User2Id == targetUserId) ||
                (f.User1Id == targetUserId && f.User2Id == currentUserId)
            );

            bool canView = !user.IsPrivate ?? false || currentUserId == targetUserId || areFriends;

            var posts = await _context.Posts
                .Where(p => p.UserId == targetUserId)
                .OrderByDescending(p => p.CreatedAt)
                .Select(p => new PostWithViewPermissionDto
                {
                    Id = p.Id,
                    Username = user.Username,
                    Rating = p.Rating,
                    Comment = p.Comment,
                    CreatedAt = p.CreatedAt,
                    PhotoUrl = p.PhotoUrl,
                    CanView = canView
                })
                .ToListAsync();

            return posts;
        }
    }
}
