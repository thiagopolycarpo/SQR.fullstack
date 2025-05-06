using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQR.Backend.Data;
using SQR.Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQR.Backend.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ProductionContext _context;

        public OrdersController(ProductionContext context)
        {
            _context = context;
        }

        [HttpGet("GetOrders")]
        public async Task<ActionResult> GetOrders()
        {
            try
            {
                // Fetch orders with products
                var orderProducts = await _context.Orders
                    .Join(_context.Products,
                        o => o.ProductCode,
                        p => p.ProductCode,
                        (o, p) => new
                        {
                            OrderId = o.OrderId,
                            Quantity = o.Quantity,
                            ProductCode = o.ProductCode,
                            ProductDescription = p.ProductDescription,
                            Image = p.Image,
                            CycleTime = p.CycleTime
                        })
                    .ToListAsync();

                // Fetch all product materials with materials
                var productMaterials = await _context.ProductMaterials
                    .Join(_context.Materials,
                        pm => pm.MaterialCode,
                        m => m.MaterialCode,
                        (pm, m) => new
                        {
                            pm.ProductCode,
                            MaterialCode = m.MaterialCode,
                            MaterialDescription = m.MaterialDescription
                        })
                    .ToListAsync();

                // Combine data client-side
                var orders = orderProducts
                    .GroupJoin(productMaterials,
                        op => op.ProductCode,
                        pm => pm.ProductCode,
                        (op, materials) => new OrderResponse
                        {
                            Order = op.OrderId,
                            Quantity = op.Quantity,
                            ProductCode = op.ProductCode,
                            ProductDescription = op.ProductDescription,
                            Image = op.Image,
                            CycleTime = op.CycleTime,
                            Materials = materials
                                .Select(m => new MaterialResponse
                                {
                                    MaterialCode = m.MaterialCode,
                                    MaterialDescription = m.MaterialDescription
                                })
                                .ToList()
                        })
                    .ToList();

                return Ok(new { orders });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Internal server error", details = ex.Message });
            }
        }

        [HttpGet("GetProduction")]
        public async Task<ActionResult<IEnumerable<Production>>> GetProduction([FromQuery] string email)
        {
            if (string.IsNullOrEmpty(email))
                return BadRequest(new { productions = new List<Production>() });

            var productions = _context.Productions
                .Where(p => p.Email == email)
                .Select(p => new ProductionResponse
            {
                Email = p.Email,
                Order = p.OrderId,
                ProductionDate = p.Date.ToString("yyyy-MM-dd HH:mm:ss"),
                Quantity = p.Quantity,
                MaterialCode = p.MaterialCode,
                MaterialDescription = p.Material.MaterialDescription,
                CycleTime = p.CycleTime
            }).ToList();

            return Ok(new { productions });
        }


        [HttpPost("SetProduction")]
        public async Task<ActionResult<SetProductionResponse>> SetProduction([FromBody] SetProductionRequest request)
        {
            try
            {
                // Validate Email
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
                if (user == null)
                    return Ok(new SetProductionResponse { Status = 201, Type = "E", Description = "Falha no apontamento - Usuário não cadastrado!" });

                // Validate Order
                var order = await _context.Orders.FirstOrDefaultAsync(o => o.OrderId == request.Order);
                if (order == null)
                    return Ok(new SetProductionResponse { Status = 201, Type = "E", Description = "Falha no apontamento - Ordem não cadastrada!" });

                // Validate Date
                DateTime productionDateTime;
                try
                {
                    productionDateTime = DateTime.Parse($"{request.ProductionDate} {request.ProductionTime}");
                }
                catch
                {
                    return Ok(new SetProductionResponse { Status = 201, Type = "E", Description = "Falha no apontamento - Formato de data/hora inválido!" });
                }

                if (productionDateTime < user.InitialDate || productionDateTime > user.EndDate)
                    return Ok(new SetProductionResponse { Status = 201, Type = "E", Description = "Falha no apontamento - Data fora do período permitido!" });

                // Validate Quantity
                if (request.Quantity <= 0 || request.Quantity > order.Quantity)
                    return Ok(new SetProductionResponse { Status = 201, Type = "E", Description = "Falha no apontamento - Quantidade inválida!" });

                // Validate Material
                var materialExists = await _context.ProductMaterials
                    .AnyAsync(pm => pm.ProductCode == order.ProductCode && pm.MaterialCode == request.MaterialCode);
                if (!materialExists)
                    return Ok(new SetProductionResponse { Status = 201, Type = "E", Description = "Falha no apontamento - Material não associado à ordem!" });

                // Validate Cycle Time
                if (request.CycleTime <= 0)
                    return Ok(new SetProductionResponse { Status = 201, Type = "E", Description = "Falha no apontamento - Tempo de ciclo inválido!" });

                var product = await _context.Products.FirstOrDefaultAsync(p => p.ProductCode == order.ProductCode);
                string description = "Apontamento realizado com sucesso!";
                if (request.CycleTime < product.CycleTime)
                    description = $"Apontamento realizado, mas o tempo de ciclo ({request.CycleTime}) é menor que o cadastrado ({product.CycleTime})!";

                // Save Production
                var production = new Production
                {
                    Email = request.Email,
                    OrderId = request.Order,
                    Date = productionDateTime,
                    Quantity = request.Quantity,
                    MaterialCode = request.MaterialCode,
                    CycleTime = request.CycleTime
                };

                _context.Productions.Add(production);
                await _context.SaveChangesAsync();

                return Ok(new SetProductionResponse { Status = 200, Type = "S", Description = description });
            }
            catch (Exception ex)
            {
                return Ok(new SetProductionResponse { Status = 201, Type = "E", Description = $"Erro interno: {ex.Message}" });
            }
        }
    }
}