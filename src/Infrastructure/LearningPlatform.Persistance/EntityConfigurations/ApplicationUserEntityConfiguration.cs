using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningPlatform.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearningPlatform.Persistance.EntityConfigurations;
internal class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.HasOne(x => x.Wallet)
            .WithOne(x => x.User)
            .HasForeignKey<Wallet>(x => x.UserId);
        builder.HasMany(x => x.Blogs)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.Writer_Id)
            .OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(x => x.Teacher)
            .WithOne(x => x.TeacherUser)
            .HasForeignKey<Teacher>(x=>x.TeacherUserId);
        builder.HasMany(x => x.Carts)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.User_Id);

        builder.HasMany(x => x.Podcasts)
            .WithOne(x => x.Author)
            .HasForeignKey(x => x.Author_Id);

        builder.HasMany(x => x.Tickets)
            .WithOne(x => x.Author)
            .HasForeignKey(x => x.Author_Id);
        
    }
}
