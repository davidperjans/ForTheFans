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
    public class FriendshipConfiguration : IEntityTypeConfiguration<Friendship>
    {
        public void Configure(EntityTypeBuilder<Friendship> builder)
        {
            builder.HasKey(f => f.Id);

            builder.Property(f => f.Since)
                .IsRequired();

            builder.HasOne(f => f.User1)
                .WithMany(u => u.FriendshipsInitiated)
                .HasForeignKey(f => f.User1Id)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(f => f.User2)
                .WithMany(u => u.FriendshipsReceived)
                .HasForeignKey(f => f.User2Id)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
