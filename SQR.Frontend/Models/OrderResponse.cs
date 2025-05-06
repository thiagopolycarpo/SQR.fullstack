using System.Collections.Generic;

namespace SQR.Frontend.Models
{
    public class OrderResponse
    {
        public string Order { get; set; }
        public decimal Quantity { get; set; }
        public string ProductCode { get; set; }
        public string ProductDescription { get; set; }
        public string Image { get; set; }
        public decimal CycleTime { get; set; }
        public List<MaterialResponse> Materials { get; set; }
    }

    public class MaterialResponse
    {
        public string MaterialCode { get; set; }
        public string MaterialDescription { get; set; }
    }
}