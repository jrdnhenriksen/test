using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ClaimProfilerApi.Models
{
    public class Entry
    {
        [JsonProperty("resource")]
        public Resource Resource { get; set; }
    }
    public class Resource
    {
        [JsonProperty("billablePeriod")]
        public BillablePeriod BillablePeriod { get; set; }

        [JsonProperty("diagnosis")]
        public IList<Diagnosis> Diagnosises { get; set; }

        [JsonProperty("extension")]
        public IList<Extension> Extensions { get; set; }

        [JsonProperty("identifier")]
        public IList<Identifier> Identifiers { get; set; }

        [JsonProperty("insurance")]
        public Insurance Insurance { get; set; }

        [JsonProperty("item")]
        public IList<Item> Items { get; set; }
    }

    public class Response
    {
        [JsonProperty("entry")]
        public IList<Entry> Entries { get; set; }
    }

    public class Extension
    {
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("valueMoney")]
        public ExtensionValueMoney ValueMoney { get; set; }

    }

    public class ExtensionValueMoney
    {
        [JsonProperty("value")]
        public decimal Value { get; set; }
    }

    public class Identifier
    {
        [JsonProperty("system")]
        public string System { get; set; }
        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public class BillablePeriod
    {
        [JsonProperty("start")]
        public DateTime StartDate { get; set; }
        [JsonProperty("end")]
        public DateTime EndDate { get; set; }
    }

    public class Diagnosis
    {
        [JsonProperty("diagnosisCodeableConcept")]
        public DiagnosisConcept DiagnosisConcept { get; set; }
    }

    public class DiagnosisConcept
    {
        [JsonProperty("coding")]
        public IList<DiagnosisCode> Codings { get; set; }
    }

    public class DiagnosisCode
    {
        [JsonProperty("code")]
        public string Code { get; set; }
    }

    public class Insurance
    {
        [JsonProperty("coverage")]
        public InsuranceCoverage Coverage { get; set; }
    }

    public class InsuranceCoverage
    {
        [JsonProperty("reference")]
        public string Reference { get; set; }
    }

    public class Item
    {
        [JsonProperty("adjudication")]
        public IList<Adjudication> Adjudications { get; set; }
        [JsonProperty("category")]
        public ItemCategory Category { get; set; }
        [JsonProperty("locationCodeableConcept")]
        public LocationConcept LocationConcept { get; set; }
        [JsonProperty("servicedPeriod")]
        public ItemServicedPeriod ServicePeriod { get; set; }
        [JsonProperty("service")]
        public ItemService Service { get; set; }

        [JsonProperty("quantity")]
        public Quantity Quantity { get; set; }

        [JsonProperty("servicedDate")]
        public DateTime ServicedDate { get; set; }
    }

    public class Quantity
    {
        [JsonProperty("extension")]
        public IList<QuantityExtension> Extensions { get; set; }
    }

    public class QuantityExtension
    {
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("valueQuantity")]
        public ValueQuantity ValueQuantity { get; set; }
    }

    public class ValueQuantity
    {
        [JsonProperty("value")]
        public int Value { get; set; }
    }

    public class ItemCategory
    {
        [JsonProperty("coding")]
        public IList<ItemCategoryCoding> Codings { get; set; }
    }

    public class ItemCategoryCoding
    {
        [JsonProperty("display")]
        public string Display { get; set; }
    }

    public class ItemService
    {
        [JsonProperty("coding")]
        public IList<ItemServiceCoding> Codings { get; set; }
    }

    public class ItemServiceCoding
    {
        [JsonProperty("code")]
        public string Code { get; set; }
        [JsonProperty("system")]
        public string System { get; set; }
    }

    public class ItemServicedPeriod
    {
        [JsonProperty("start")]
        public DateTime StartDate { get; set; }
        [JsonProperty("end")]
        public DateTime EndDate { get; set; }
    }

    public class LocationConcept
    {
        [JsonProperty("coding")]
        public IList<LocationConceptCoding> Codings { get; set; }
    }

    public class LocationConceptCoding
    {
        [JsonProperty("display")]
        public string Display { get; set; }

    }

    public class Adjudication
    {
        [JsonProperty("category")]
        public AdjudicationCategory Category { get; set; }
        [JsonProperty("amount")]
        public AdjudicationAmount Amount { get; set; }
    }

    public class AdjudicationCategory
    {
        [JsonProperty("coding")]
        public IList<AdjudicationCategoryCoding> Codings { get; set; }
    }

    public class AdjudicationCategoryCoding
    {
        [JsonProperty("code")]
        public string Code { get; set; }
    }

    public class AdjudicationAmount
    {
        [JsonProperty("value")]
        public decimal Value { get; set; }
    }
}