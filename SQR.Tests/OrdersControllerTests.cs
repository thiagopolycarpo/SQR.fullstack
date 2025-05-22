using Microsoft.AspNetCore.Mvc;
using Moq;
using SQR.Backend.Controllers;
using SQR.Backend.Interfaces;
using SQR.Backend.Models;
using System.Threading.Tasks;
using Xunit;

namespace SQR.Tests
{
    public class OrdersControllerTests
    {
        [Fact]
        public async Task SetProduction_ValidRequest_ReturnsOk()
        {
            // Arrange
            var mockService = new Mock<IProductionService>();
            var request = new SetProductionRequest
            {
                Email = "teste@sequor.com.br",
                Order = "111",
                ProductionDate = "2025-04-22",
                ProductionTime = "09:00:00",
                Quantity = 50,
                MaterialCode = "aaa",
                CycleTime = 30
            };
            var response = new SetProductionResponse { Type = "S", Status = 200, Description = "Apontamento realizado com sucesso!" };
            mockService.Setup(s => s.SetProductionAsync(request)).ReturnsAsync(response);
            var controller = new OrdersController(mockService.Object);

            // Act
            var result = await controller.SetProduction(request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<SetProductionResponse>(okResult.Value);
            Assert.Equal("S", returnValue.Type);
            Assert.Equal(200, returnValue.Status);
        }

        [Fact]
        public async Task SetProduction_InvalidRequest_ReturnsBadRequest()
        {
            // Arrange
            var mockService = new Mock<IProductionService>();
            var request = new SetProductionRequest { Email = "invalid@sequor.com.br" };
            var response = new SetProductionResponse { Type = "E", Status = 400, Description = "Usuário não está registrado!" };
            mockService.Setup(s => s.SetProductionAsync(request)).ReturnsAsync(response);
            var controller = new OrdersController(mockService.Object);

            // Act
            var result = await controller.SetProduction(request);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            var returnValue = Assert.IsType<SetProductionResponse>(badRequestResult.Value);
            Assert.Equal("E", returnValue.Type);
            Assert.Equal(400, returnValue.Status);
        }
    }
}