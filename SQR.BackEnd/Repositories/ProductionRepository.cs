using Microsoft.EntityFrameworkCore;
using SQR.Backend.Data;
using SQR.Backend.Interfaces;
using SQR.Backend.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SQR.Backend.Repositories
{
    public class ProductionRepository : IProductionRepository
    {
        private readonly ProductionContext _context;

        public ProductionRepository(ProductionContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<Order> GetOrderByIdAsync(string orderId)
        {
            return await _context.Orders.FirstOrDefaultAsync(o => o.OrderId == orderId);
        }

        public async Task<Product> GetProductByOrderAsync(string orderId)
        {
            return await _context.Orders
                .Where(o => o.OrderId == orderId)
                .Join(_context.Products,
                    o => o.ProductId,
                    p => p.ProductId,
                    (o, p) => p)
                .FirstOrDefaultAsync();
        }

        public async Task<ProductMaterial[]> GetProductMaterialsAsync(string productId)
        {
            return await _context.ProductMaterials
                .Where(pm => pm.ProductId == productId)
                .ToArrayAsync();
        }

        public async Task<Production[]> GetProductionsByEmailAsync(string email)
        {
            return await _context.Productions
                .Where(p => p.Email == email)
                .Include(p => p.Material)
                .ToArrayAsync();
        }

        public async Task AddProductionAsync(Production production)
        {
            await _context.Productions.AddAsync(production);
            await _context.SaveChangesAsync();
        }
    }
}