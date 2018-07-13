using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ClaimProfilerApi.Models
{
    public class PatientEntry
    {
        [JsonProperty("resource")]
        public PatientResource Resource { get; set; }
    }

    public class PatientIdentifier
    {
        [JsonProperty("system")]
        public string System { get; set; }
        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public class PatientName
    {
        [JsonProperty("family")]
        public string LastName { get; set; }
        [JsonProperty("given")]
        public IList<string> GivenName { get; set; }
    }

    public class PatientResource
    {
        [JsonProperty("birthDate")]
        public DateTime BirthDate { get; set; }
        [JsonProperty("gender")]
        public string Gender { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("identifier")]
        public IList<PatientIdentifier> Identifiers { get; set; }
        [JsonProperty("name")]
        public IList<PatientName> Name { get; set; }
    }

    public class PatientResponse
    {
        [JsonProperty("entry")]
        public IList<PatientEntry> Entries { get; set; }
    }
}