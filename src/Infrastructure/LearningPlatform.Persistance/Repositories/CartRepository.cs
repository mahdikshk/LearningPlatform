using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningPlatform.Application.Contracts.Persistance;
using LearningPlatform.Domain;

namespace LearningPlatform.Persistance.Repositories;
internal class CartRepository(ApplicationDbContext context) : GenericRepository<Cart>(context), ICartRepository
{
    public async ValueTask AddCartItemToCart(CartItem item, CancellationToken cancellationToken)
    {
        await context.AddAsync(item, cancellationToken);
    }

    public Task DeleteCartItemFromCart(CartItem item, CancellationToken cancellationToken)
    {
        context.Remove(item);
        return Task.CompletedTask;
    }
}
