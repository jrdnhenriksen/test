using System;
using System.Collections.Generic;

namespace ClaimProfilerApi.Models
{
    public class ClaimB
    {
        public decimal AmountApproved { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal AmountSubmitted { get; set; }
        public IList<string> DiagnosesCodes { get; set; }
        public string Id { get; set; }
        public IList<ClaimBItem> Items { get; set; }
        public DateTime ServiceEndDate { get; set; }
        public DateTime ServiceStartDate { get; set; }
        public string Type { get; set; }
    }
}