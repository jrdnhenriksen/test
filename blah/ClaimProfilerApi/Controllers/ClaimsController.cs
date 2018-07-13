using ClaimProfilerApi.Helper;
using ClaimProfilerApi.Models;
using ClaimProfilerApi.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ClaimProfilerApi.Controllers
{
    public class ClaimsController : ApiController
    {
        private readonly IClaimService _claimService;

        public ClaimsController(IClaimService claimService)
        {
            _claimService = claimService;
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            var authToken = Request.Headers.GetValues("AuthToken").FirstOrDefault();
            var eob = new ExplanationOfBenefit();

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", authToken);

                var uri = new Uri($"https://sandbox.bluebutton.cms.gov/v1/fhir/ExplanationOfBenefit?count=50");
                var response = await client.GetAsync(uri);

                var claimData = await response.ConvertToObject<Response>();

                var partBClaims = claimData.Entries
                    .Select(x => x.Resource)
                    .Where(x => x.Insurance.Coverage.Reference.Contains("part-b")).ToList();
                var partDClaims = claimData.Entries
                    .Select(x => x.Resource)
                    .Where(x => x.Insurance.Coverage.Reference.Contains("part-d")).ToList();

                eob.PartBClaims = _claimService.ParseBClaims(partBClaims);
                eob.PartDClaims = _claimService.ParseDClaims(partDClaims);

                return Ok(eob);
            }
        }
    }
}
