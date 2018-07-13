using ClaimProfilerApi.Models;
using System.Collections.Generic;

namespace ClaimProfilerApi.Services
{
    public interface IClaimService
    {
        IList<ClaimB> ParseBClaims(IEnumerable<Resource> data);
        IList<ClaimD> ParseDClaims(IEnumerable<Resource> data);
    }
}