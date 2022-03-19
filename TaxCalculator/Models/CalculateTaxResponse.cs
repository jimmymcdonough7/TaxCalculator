using System;
namespace TaxCalculator.Models
{
    public class CalculateTaxResponse
    {
        public float TaxAmount { get; set; }
        public float Rate { get; set; }
        public float TaxableAmount { get; set; }
    }




    //***TAXJAR RESPONSE OBJECTS***//
    public class CalculateTaxResponse_TaxJar
    {
        public Tax tax { get; set; }
    }

    public class Tax
    {
        public float shipping { get; set; }
        public string tax_source { get; set; }
        public float amount_to_collect { get; set; }
        public float rate { get; set; }
        public float taxable_amount { get; set; }
        public float order_total_amount { get; set; }
    }
}
