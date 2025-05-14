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
    public class StadiumConfiguration : IEntityTypeConfiguration<Stadium>
    {
        public void Configure(EntityTypeBuilder<Stadium> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(s => s.Slug)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(s => s.Address)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(s => s.City)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(s => s.Country)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(s => s.Capacity)
                .IsRequired();

            builder.Property(s => s.Surface)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(s => s.ImageUrl)
                .HasMaxLength(300);

            builder.HasMany(s => s.Posts)
                .WithOne(p => p.Stadium)
                .HasForeignKey(p => p.StadiumId);
        }
    }
}
