using System;
namespace TaxCalculator.Models
{
    public class CalculateTaxRequest
    {
        
        public string ToCountry { get; set; }
        public float ShippingCost { get; set; }
        public float Amount { get; set; }
        public string ZipCode { get; set; }
        public string State { get; set; }
    }



    public class CalculateTaxRequest_TaxJar
    {
        public string from_state;
        public string from_zip;
        public string from_country;
        public string to_country { get; set; }
        public float shipping { get; set; }
        public float amount { get; set; }
        public string to_zip { get; set; }
        public string to_state { get; set; }
    }
}
