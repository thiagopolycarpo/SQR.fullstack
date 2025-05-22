using SQR.Backend.Models;
using System.Threading.Tasks;

namespace SQR.Backend.Interfaces
{
    public interface IProductionRepository
    {
        Task<User> GetUserByEmailAsync(string email);
        Task<Order> GetOrderByIdAsync(string orderId);
        Task<Product> GetProductByOrderAsync(string orderId);
        Task<ProductMaterial[]> GetProductMaterialsAsync(string productId);
        Task<Production[]> GetProductionsByEmailAsync(string email);
        Task AddProductionAsync(Production production);
    }
}