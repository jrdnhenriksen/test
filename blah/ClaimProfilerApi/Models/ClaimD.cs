using System;

namespace ClaimProfilerApi.Models
{
    public class ClaimD
    {
        public int DaysSupply { get; set; }
        public string DrugCode { get; set; }
        public int FillNumber { get; set; }
        public string Id { get; set; }
        public DateTime ServicedDate { get; set; }
        public string Type { get; set; }
    }
}