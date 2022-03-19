using System;
namespace TaxCalculator.Models
{
    public class GetTaxRateRequest
    {
        public GetTaxRateRequest()
        {
        }

        public string ZipCode { get; set; }
    }
}
