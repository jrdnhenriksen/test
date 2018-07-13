using System;

namespace ClaimProfilerApi.Models
{
    public class ClaimBItem
    {
        public decimal AmountAllowed { get; set; }
        public decimal AmountNotCovered
        {
            get { return AmountSubmitted - AmountAllowed; }
        }
        public decimal AmountSubmitted { get; set; }
        public string ProcedureCode { get; set; }
        public DateTime ServiceEndDate { get; set; }
        public string ServiceLocation { get; set; }
        public DateTime ServiceStartDate { get; set; }
        public string ServiceType { get; set; }
    }
}