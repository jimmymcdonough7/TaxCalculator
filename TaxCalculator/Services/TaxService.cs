using System;
using System.Threading.Tasks;
using TaxCalculator.Models;

namespace TaxCalculator.Services
{
    public class TaxService : ITaxService
    {
        private ITaxCalculator _taxCalculator;

        public TaxService(ITaxCalculator taxCalculator)
        {
            _taxCalculator = taxCalculator;
        }

        public Task<CalculateTaxResponse> CalculateTaxAsync(CalculateTaxRequest request)
        {
            if (string.IsNullOrEmpty(request.ToCountry)) { throw new Exception(); } //todo check all required fields needed
            return _taxCalculator.CalculateTaxAsync(request);
        }

        public Task<GetTaxRateResponse> GetTaxRate(GetTaxRateRequest request)
        {
            if (string.IsNullOrEmpty(request.ZipCode)) { throw new Exception(); }
            return _taxCalculator.GetTaxRate(request);
        }

       
    }
}
