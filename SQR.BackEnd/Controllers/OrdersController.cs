using Microsoft.AspNetCore.Mvc;
using SQR.Backend.Interfaces;
using SQR.Backend.Models;
using System.Threading.Tasks;

namespace SQR.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IProductionService _productionService;

        public OrdersController(IProductionService productionService)
        {
            _productionService = productionService;
        }

        [HttpGet("GetOrders")]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _productionService.GetOrdersAsync();
            return Ok(new { Orders = orders });
        }

        [HttpPost("SetProduction")]
        public async Task<IActionResult> SetProduction([FromBody] SetProductionRequest request)
        {
            var result = await _productionService.SetProductionAsync(request);
            return result.Type == "S" ? Ok(result) : BadRequest(result);
        }

        [HttpGet("GetProduction")]
        public async Task<IActionResult> GetProduction([FromQuery] string email)
        {
            var result = await _productionService.GetProductionAsync(email);
            return Ok(result);
        }
    }
}