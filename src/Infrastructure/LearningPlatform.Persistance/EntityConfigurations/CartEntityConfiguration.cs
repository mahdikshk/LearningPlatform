using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using LearningPlatform.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearningPlatform.Persistance.EntityConfigurations;
internal class CartEntityConfiguration : IEntityTypeConfiguration<Cart>
{
    public void Configure(EntityTypeBuilder<Cart> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.IsPaymentWasSuccessfull)
            .HasDefaultValue(false)
            .IsRequired();
        builder.HasMany(x => x.CartItems)
            .WithOne(x=>x.Cart)
            .HasForeignKey(x=>x.CartId);
    }
}
