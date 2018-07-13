using ClaimProfilerApi.Models;

namespace ClaimProfilerApi.Services
{
    public interface IPatientService
    {
        Patient GetPatient(PatientResponse data);
    }
}