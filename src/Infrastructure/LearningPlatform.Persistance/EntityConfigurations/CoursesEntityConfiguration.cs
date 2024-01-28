using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningPlatform.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearningPlatform.Persistance.EntityConfigurations;
internal class CoursesEntityConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.IsFree).HasDefaultValue(true).IsRequired();
        builder.Property(x => x.DiscountPercentage).HasDefaultValue(0);
        builder.Property(x=>x.HasDiscount).HasDefaultValue(false).IsRequired();
        builder
            .HasOne(x => x.Teacher)
            .WithMany(x => x.Courses)
            .HasForeignKey(x => x.Teacher_Id)
            .IsRequired();
        builder
            .Property(x=>x.OriginalPrice)
            .HasDefaultValue(0);
        builder.Property(x => x.Name)
            .HasMaxLength(1000);
        builder.Property(x => x.Description)
            .HasMaxLength(100_000);
        builder
            .HasMany(x => x.Comments)
            .WithOne(x => x.Course)
            .HasForeignKey(x => x.CourseId);
    }
}
