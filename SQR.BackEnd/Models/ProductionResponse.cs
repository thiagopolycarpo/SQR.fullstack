namespace SQR.Backend.Models{
    public class ProductionResponse {
            public string Email { get; set; }
            public string Order { get; set; }
            public string ProductionDate { get; set; }
            public decimal Quantity { get; set; }
            public string MaterialCode { get; set; }
            public string MaterialDescription { get; set; }
            public decimal CycleTime { get; set; }
    }
}

