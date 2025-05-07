using Domain.Entities;
using Infrastructure.Database.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<FriendRequest> FriendRequests { get; set; }
        public DbSet<Friendship> Friendships { get; set; }
        public DbSet<Stadium> Stadiums { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new FriendRequestConfiguration());
            modelBuilder.ApplyConfiguration(new FriendshipConfiguration());
            modelBuilder.ApplyConfiguration(new StadiumConfiguration());
            modelBuilder.ApplyConfiguration(new PostConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
        }
    }
}
