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
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.PhotoUrl).HasMaxLength(200);
            builder.Property(p => p.Rating).IsRequired();
            builder.Property(p => p.Comment).HasMaxLength(1000);
            builder.Property(p => p.HomeTeam).HasMaxLength(50);
            builder.Property(p => p.AwayTeam).HasMaxLength(50);
            builder.Property(p => p.MatchResult).HasMaxLength(20);
            builder.Property(p => p.CreatedAt).IsRequired();

            builder.HasOne(p => p.User)
                .WithMany(u => u.Posts)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Stadium)
                .WithMany(s => s.Posts)
                .HasForeignKey(p => p.StadiumId);

            builder.HasMany(p => p.Comments)
                .WithOne(c => c.Post)
                .HasForeignKey(c => c.PostId);
        }
    }
}
