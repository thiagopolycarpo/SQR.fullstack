using SQR.Backend.Models;
using System.Threading.Tasks;

namespace SQR.Backend.Interfaces
{
    public interface IProductionService
    {
        Task<SetProductionResponse> SetProductionAsync(SetProductionRequest request);
        Task<ProductionResponse> GetProductionAsync(string email);
        Task<Order[]> GetOrdersAsync();
    }
}