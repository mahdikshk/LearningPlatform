using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningPlatform.Domain;

namespace LearningPlatform.Application.Contracts.Persistance;
public interface ICartRepository : IGenericRepository<Cart>
{
    ValueTask AddCartItemToCart(CartItem item, CancellationToken cancellationToken);
    Task DeleteCartItemFromCart(CartItem item, CancellationToken cancellationToken);
    Task<IEnumerable<CartItem>> GetAllCartItemsByIdAsync(Guid id, CancellationToken cancellationToken);
}
