using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningPlatform.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearningPlatform.Persistance.EntityConfigurations;
internal class BlogEntityConfiguration : IEntityTypeConfiguration<Blog>
{
    public void Configure(EntityTypeBuilder<Blog> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(x => x.Title)
            .IsRequired();
        builder.Property(x=>x.Text)
            .IsRequired();
        builder.HasOne(x => x.User)
            .WithMany(x => x.Blogs)
            .HasForeignKey(x => x.Writer_Id);
        builder.HasMany(x => x.Comments)
            .WithOne(x => x.Blog)
            .HasForeignKey(x => x.Blog_Id);
    }
}
