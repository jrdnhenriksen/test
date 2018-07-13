using System;
using System.Collections.Generic;

namespace ClaimProfilerApi.Models
{
    public class ExplanationOfBenefit
    {
        public IList<ClaimB> PartBClaims { get; set; }
        public IList<ClaimD> PartDClaims { get; set; }
    }
}