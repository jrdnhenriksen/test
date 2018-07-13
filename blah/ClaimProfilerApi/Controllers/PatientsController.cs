using ClaimProfilerApi.Helper;
using ClaimProfilerApi.Models;
using ClaimProfilerApi.Services;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ClaimProfilerApi.Controllers
{
    public class PatientsController : ApiController
    {
        private readonly IPatientService _patientService;

        public PatientsController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            var authToken = Request.Headers.GetValues("AuthToken").FirstOrDefault();

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", authToken);

                var uri = new Uri($"https://sandbox.bluebutton.cms.gov/v1/fhir/Patient");
                var response = await client.GetAsync(uri);
                var patientData = await response.ConvertToObject<PatientResponse>();
                var result = _patientService.GetPatient(patientData);

                return Ok(result);
            }
        }
    }
}
