using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClaimProfilerApi.Models;

namespace ClaimProfilerApi.Services
{
    public class PatientService : IPatientService
    {
        public Patient GetPatient(PatientResponse data)
        {
            var entry = data.Entries[0].Resource;

            return new Patient
            {
                BeneficiaryId = entry.Identifiers.FirstOrDefault(x => x.System.Contains("bene_id")).Value,
                BirthDate = entry.BirthDate,
                Gender = entry.Gender,
                GivenName = entry.Name.Select(x => string.Join(", ", x.GivenName).ToString()).FirstOrDefault(),
                LastName = entry.Name.FirstOrDefault(x => !string.IsNullOrWhiteSpace(x.LastName)).LastName,
                Id = entry.Id,
            };
        }
    }
}