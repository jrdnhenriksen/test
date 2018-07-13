using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClaimProfilerApi.Models
{
    public class Patient
    {
        public string BeneficiaryId { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string GivenName { get; set; }
        public string Id { get; set; }
        public string LastName { get; set; }   
    }
}