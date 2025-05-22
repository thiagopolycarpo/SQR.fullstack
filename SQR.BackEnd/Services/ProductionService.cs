using SQR.Backend.Interfaces;
using SQR.Backend.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SQR.Backend.Services
{
    public class ProductionService : IProductionService
    {
        private readonly IProductionRepository _repository;

        public ProductionService(IProductionRepository repository)
        {
            _repository = repository;
        }

        public async Task<SetProductionResponse> SetProductionAsync(SetProductionRequest request)
        {
            if (request == null)
                return new SetProductionResponse { Type = "E", Status = 400, Description = "Request cannot be null" };

            var user = await _repository.GetUserByEmailAsync(request.Email);
            if (user == null)
                return new SetProductionResponse { Type = "E", Status = 400, Description = "Usuário não está registrado!" };

            var order = await _repository.GetOrderByIdAsync(request.Order);
            if (order == null)
                return new SetProductionResponse { Type = "E", Status = 400, Description = "Ordem não existe!" };

            if (!DateTime.TryParse(request.ProductionDate, out var productionDate) || productionDate > DateTime.Now)
                return new SetProductionResponse { Type = "E", Status = 400, Description = "Data de produção inválida!" };

            if (!TimeSpan.TryParse(request.ProductionTime, out var productionTime))
                return new SetProductionResponse { Type = "E", Status = 400, Description = "Hora de produção inválida!" };

            if (request.Quantity <= 0 || request.Quantity > order.Quantity)
                return new SetProductionResponse { Type = "E", Status = 400, Description = "Quantidade inválida!" };

            var product = await _repository.GetProductByOrderAsync(request.Order);
            if (product == null)
                return new SetProductionResponse { Type = "E", Status = 400, Description = "Produto não encontrado!" };

            var materials = await _repository.GetProductMaterialsAsync(product.ProductId);
            var material = materials.FirstOrDefault(m => m.MaterialCode == request.MaterialCode);
            if (material == null)
                return new SetProductionResponse { Type = "E", Status = 400, Description = "Material inválido!" };

            if (request.CycleTime < order.CycleTime)
                return new SetProductionResponse { Type = "E", Status = 400, Description = "Ciclo de produção inválido!" };

            var production = new Production
            {
                Email = request.Email,
                OrderId = request.Order,
                ProductionDate = productionDate,
                ProductionTime = productionTime,
                Quantity = request.Quantity,
                MaterialCode = request.MaterialCode,
                CycleTime = request.CycleTime
            };

            await _repository.AddProductionAsync(production);

            return new SetProductionResponse
            {
                Type = "S",
                Status = 200,
                Description = "Apontamento realizado com sucesso!"
            };
        }

        public async Task<ProductionResponse> GetProductionAsync(string email)
        {
            var productions = await _repository.GetProductionsByEmailAsync(email);
            return new ProductionResponse
            {
                Productions = productions.Select(p => new ProductionResponse.ProductionItem
                {
                    Email = p.Email,
                    Order = p.OrderId,
                    Date = p.ProductionDate.ToString("yyyy-MM-dd"),
                    Time = p.ProductionTime.ToString(@"hh\:mm\:ss"),
                    Quantity = p.Quantity,
                    MaterialDescription = p.Material?.MaterialDescription,
                    MaterialCode = p.MaterialCode
                }).ToArray()
            };
        }

        public async Task<Order[]> GetOrdersAsync()
        {
            var orders = await _repository.GetOrdersAsync();
            return orders;
        }
    }
}