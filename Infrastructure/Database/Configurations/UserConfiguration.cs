using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Username).IsRequired().HasMaxLength(50);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(100);
            builder.Property(u => u.PasswordHash).IsRequired();
            builder.Property(u => u.FavoriteTeam).HasMaxLength(50);
            builder.Property(u => u.Bio).HasMaxLength(500);
            builder.Property(u => u.ProfilePictureUrl).HasMaxLength(500);

            builder.HasMany(u => u.Posts)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId);

            builder.HasMany(u => u.SentFriendRequests)
                .WithOne(fr => fr.FromUser)
                .HasForeignKey(fr => fr.FromUserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(u => u.ReceivedFriendRequests)
                .WithOne(fr => fr.ToUser)
                .HasForeignKey(fr => fr.ToUserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(u => u.FriendshipsInitiated)
                .WithOne(f => f.User1)
                .HasForeignKey(f => f.User1Id)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(u => u.FriendshipsReceived)
                .WithOne(f => f.User2)
                .HasForeignKey(f => f.User2Id)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(u => u.Comments)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId);
        }
    }
}
