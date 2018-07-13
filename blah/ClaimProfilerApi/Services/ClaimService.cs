using System.Collections.Generic;
using ClaimProfilerApi.Models;
using System.Linq;

namespace ClaimProfilerApi.Services
{
    public class ClaimService : IClaimService
    {
        public IList<ClaimB> ParseBClaims(IEnumerable<Resource> data)
        {
            var claims = new List<ClaimB>();

            foreach (var entry in data)
            {
                var claim = new ClaimB
                {
                    AmountApproved = entry.Extensions
                    .FirstOrDefault(x => x.Url.Contains("nch_carr_clm_alowd_amt")).ValueMoney.Value,
                    AmountPaid = entry.Extensions
                    .FirstOrDefault(x => x.Url.Contains("nch_clm_prvdr_pmt_amt")).ValueMoney.Value,
                    AmountSubmitted = entry.Extensions
                    .FirstOrDefault(x => x.Url.Contains("nch_carr_clm_sbmtd_chrg_amt")).ValueMoney.Value,
                    DiagnosesCodes = entry.Diagnosises
                    .SelectMany(x => x.DiagnosisConcept.Codings).Select(y => y.Code).ToList(),
                    Id = entry.Identifiers
                    .FirstOrDefault(x => x.System.Contains("clm_id"))
                    .Value,
                    Items = new List<ClaimBItem>(),
                    ServiceStartDate = entry.BillablePeriod.StartDate,
                    ServiceEndDate = entry.BillablePeriod.EndDate,
                    Type = "Part B"
                };

                foreach (var i in entry.Items)
                {
                    var claimItem = new ClaimBItem
                    {
                        AmountAllowed = i.Adjudications
                            .FirstOrDefault(x => x.Category.Codings
                                .Any(y => y.Code.Contains("line_alowd_chrg_amt")))
                                .Amount.Value,
                        AmountSubmitted = i.Adjudications
                            .FirstOrDefault(x => x.Category.Codings
                                .Any(y => y.Code.Contains("line_sbmtd_chrg_amt")))
                                .Amount.Value,
                        ProcedureCode = i.Service.Codings
                            .Select(x => x.Code).FirstOrDefault(),
                        ServiceEndDate = i.ServicePeriod.EndDate,
                        ServiceLocation = i.LocationConcept.Codings
                            .Select(x => x.Display).FirstOrDefault(),
                        ServiceStartDate = i.ServicePeriod.StartDate,
                        ServiceType = i.Category.Codings
                            .Select(x => x.Display).FirstOrDefault()
                    };

                    claim.Items.Add(claimItem);
                }

                claims.Add(claim);
            }

            return claims;
        }

        public IList<ClaimD> ParseDClaims(IEnumerable<Resource> data)
        {
            var claims = new List<ClaimD>();

            foreach (var entry in data)
            {
                var claim = new ClaimD
                {
                    DaysSupply = entry.Items
                        .SelectMany(x => x.Quantity.Extensions)
                        .FirstOrDefault(x => x.Url.Contains("days_suply_num"))
                        .ValueQuantity
                        .Value,
                    DrugCode = entry.Items
                        .SelectMany(x => x.Service.Codings)
                        .FirstOrDefault(x => x.System.Contains("ndc"))
                        .Code,
                    FillNumber = entry.Items
                        .SelectMany(x => x.Quantity.Extensions)
                        .FirstOrDefault(x => x.Url.Contains("fill_num"))
                        .ValueQuantity
                        .Value,
                    Id = entry.Identifiers
                        .FirstOrDefault(x => x.System.Contains("pde_id"))
                        .Value,
                    ServicedDate = entry.Items
                        .Select(x => x.ServicedDate).FirstOrDefault(),
                    Type = "Part D"
                };

                claims.Add(claim);
            }

            return claims;
        }
    }
}