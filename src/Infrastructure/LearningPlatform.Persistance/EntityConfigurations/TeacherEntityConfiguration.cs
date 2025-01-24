using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningPlatform.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearningPlatform.Persistance.EntityConfigurations;
internal class TeacherEntityConfiguration : IEntityTypeConfiguration<Teacher>
{
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Description)
            .HasMaxLength(10_000)
            .IsRequired();
        builder.Property(x => x.TeacherWebsite)
            .HasMaxLength(200);
        builder.Property(x => x.TeacherEmail)
            .HasMaxLength(400);
        builder.Property(x => x.TeacherPhone)
            .HasMaxLength(50);
        builder.HasMany(x => x.Courses)
            .WithOne(x => x.Teacher)
            .HasForeignKey(x => x.Teacher_Id);

        builder.HasOne(x => x.TeacherUser)
            .WithOne(x => x.Teacher)
            .HasForeignKey<ApplicationUser>(x => x.TeacherId);
    }
}
