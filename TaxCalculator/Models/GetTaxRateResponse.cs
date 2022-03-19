using System;
namespace TaxCalculator.Models
{

    public class GetTaxRateResponse
    {
        public float StateRate { get; set; }
        public float CityRate { get; set; }
        public float CountyRate { get; set; }
    }

    


    //*** TAXJAR RESPONSE OBJECTS ***//
    public class GetTaxRateResponse_TaxJar
    {
        public Rate Rate { get; set; }

    }

    public class Rate
    {
        public float state_rate { get; set; }
        public float county_rate { get; set; }
        public float city_rate { get; set; }
    }
}
