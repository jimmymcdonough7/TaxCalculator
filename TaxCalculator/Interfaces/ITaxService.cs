using System;
using System.Threading.Tasks;
using TaxCalculator.Models;

namespace TaxCalculator.Services
{
    public interface ITaxService
    {
        Task<CalculateTaxResponse> CalculateTaxAsync(CalculateTaxRequest request);
        Task<GetTaxRateResponse> GetTaxRate(GetTaxRateRequest request);
        
    }
}
