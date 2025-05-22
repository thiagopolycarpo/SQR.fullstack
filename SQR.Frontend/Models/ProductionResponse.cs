using System.Collections.Generic;

namespace SQR.Frontend.Models
{
    public class ProductionResponse
    {
        public string Email { get; set; }
        public string Order { get; set; }
        public string ProductionDate { get; set; }
        public decimal Quantity { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialDescription { get; set; }
        public decimal CycleTime { get; set; }
    }

    public class ProductionsResponse
    {
        public List<ProductionResponse> Productions { get; set; }
    }
}