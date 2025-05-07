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
    public class FriendRequestConfiguration : IEntityTypeConfiguration<FriendRequest>
    {
        public void Configure(EntityTypeBuilder<FriendRequest> builder)
        {
            builder.HasKey(fr => fr.Id);

            builder.Property(fr => fr.Status)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(fr => fr.SentAt)
                .IsRequired();

            builder.HasOne(fr => fr.FromUser)
                .WithMany(u => u.SentFriendRequests)
                .HasForeignKey(fr => fr.FromUserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(fr => fr.ToUser)
                .WithMany(u => u.ReceivedFriendRequests)
                .HasForeignKey(fr => fr.ToUserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
