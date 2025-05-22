using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SQR.Frontend.Models;
using System.Configuration;
using System.Globalization;

namespace SQR.Frontend.ViewModels
{
    public class ProductionViewModel
    {
        private readonly HttpClient _httpClient;
        public List<OrderResponse> Orders { get; private set; } = new();
        public bool IsFormFilled { get; set; }
        public int FillTimeSeconds { get; set; }
        public DateTime OrderSelectionTime { get; set; }
        public DateTime FillStartTime { get; set; }
        public decimal RequiredCycleTime { get; set; }
        public bool BypassCycleTime { get; set; }

        public ProductionViewModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(ConfigurationManager.AppSettings["ApiBaseUrl"]);
        }

        public async Task LoadOrdersAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/orders/GetOrders");
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<OrdersResponse>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                Orders = result.Orders;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao carregar ordens: {ex.Message}");
            }
        }

        public bool CheckFormFilled(string email, int orderIndex, int materialIndex, string quantity)
        {
            bool isFilled = !string.IsNullOrEmpty(email) &&
                           orderIndex >= 0 &&
                           materialIndex >= 0 &&
                           !string.IsNullOrEmpty(quantity) &&
                           decimal.TryParse(quantity, NumberStyles.Any, CultureInfo.InvariantCulture, out _);

            if (isFilled && !IsFormFilled)
            {
                IsFormFilled = true;
                FillTimeSeconds = (int)(DateTime.Now - FillStartTime).TotalSeconds;
            }
            else if (!isFilled)
            {
                IsFormFilled = false;
            }
            return isFilled;
        }

        public async Task<SetProductionResponse> SubmitProductionAsync(string email, string orderId, DateTime productionDateTime, decimal quantity, string materialCode, decimal cycleTime)
        {
            try
            {
                var request = new SetProductionRequest
                {
                    Email = email,
                    Order = orderId,
                    ProductionDate = productionDateTime.ToString("yyyy-MM-dd"),
                    ProductionTime = productionDateTime.ToString("HH:mm:ss"),
                    Quantity = quantity,
                    MaterialCode = materialCode,
                    CycleTime = cycleTime
                };

                var json = JsonSerializer.Serialize(request);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("api/orders/SetProduction", content);

                if (!response.IsSuccessStatusCode)
                {
                    var errorJson = await response.Content.ReadAsStringAsync();
                    var errorResult = JsonSerializer.Deserialize<SetProductionResponse>(errorJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return errorResult ?? new SetProductionResponse { Type = "E", Description = $"Erro na resposta da API: {response.ReasonPhrase}" };
                }

                var responseJson = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<SetProductionResponse>(responseJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            catch (Exception ex) 
            {
                return new SetProductionResponse { Type = "E", Description = $"Erro ao enviar apontamento: {ex.Message}" };
            }
        } 
    }
}