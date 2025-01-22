using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningPlatform.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearningPlatform.Persistance.EntityConfigurations;
internal class BlogCommentEntityTypeConfiguration : IEntityTypeConfiguration<BlogComment>
{
    public void Configure(EntityTypeBuilder<BlogComment> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Text)
            .IsRequired();
        builder.HasOne(x => x.User)
            .WithMany(x => x.BlogsComment)
            .HasForeignKey(x => x.UserId);
        builder.HasOne(x=>x.Blog)
            .WithMany(x=>x.Comments)
            .HasForeignKey(x=>x.Blog_Id);
    }
}
