using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningPlatform.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearningPlatform.Persistance.EntityConfigurations;
internal class CommentEntityConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(x => x.Text).HasMaxLength(5_000);
        builder.HasOne(x=>x.Course)
            .WithMany(x=>x.Comments)
            .HasForeignKey(x=>x.CourseId);
        builder.HasOne(x=>x.User)
            .WithMany(x=>x.Comments)
            .HasForeignKey(x=>x.UserId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
