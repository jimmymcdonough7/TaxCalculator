using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using TaxCalculator.Models;
using TaxCalculator.Services;
using Xamarin.Forms;

namespace TaxCalculator.Services
{
    public class TaxJarCalculator : ITaxCalculator
    {
        private HttpClient _client;

        public TaxJarCalculator(IHttpClientFactory httpClient)
        {
            _client = httpClient.CreateClient("TaxJar");
        }

        public async Task<CalculateTaxResponse> CalculateTaxAsync(CalculateTaxRequest request)
        {
            var requestToSend = new CalculateTaxRequest_TaxJar
            {
                from_country = "US",
                from_zip = "07001",
                from_state = "NJ",
                amount = request.Amount,
                shipping = request.ShippingCost,
                to_country = request.ToCountry,
                to_zip = request.ZipCode,
                to_state = request.State,
                //hard code where we are sending it from just for now for sake of time
                
               
            };

            try
            {
                //TODO: ideally this would all be in an api project. then pull urls from appsettings json file not static class.
                var uri = new Uri(string.Format(Constants.CalculateTaxUrl));
                var json = JsonConvert.SerializeObject(requestToSend);
                var content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");

                var response = await _client.PostAsync(uri, content);
                var responsecontent = await response.Content.ReadAsStringAsync();
                var tax = await Task.Run(() => JsonConvert.DeserializeObject<CalculateTaxResponse_TaxJar>(responsecontent));

                return new CalculateTaxResponse
                {
                    Rate = tax.tax.rate,
                    TaxableAmount = tax.tax.taxable_amount,
                    TaxAmount = tax.tax.amount_to_collect
                };
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR" + e);
            }
            return null;
        }


        public async Task<GetTaxRateResponse> GetTaxRate(GetTaxRateRequest request)
        {
            try
            {
                var uri = new Uri(string.Format(Constants.TaxLookupUrl + request.ZipCode)); 
                var response = await _client.GetAsync(uri);
                var content = await response.Content.ReadAsStringAsync();
                var result = await Task.Run(() => JsonConvert.DeserializeObject<GetTaxRateResponse_TaxJar>(content));

                return new GetTaxRateResponse
                {
                    CityRate = result.Rate.city_rate,
                    CountyRate = result.Rate.county_rate,
                    StateRate = result.Rate.state_rate
                };
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR" + e);
            }
            return null;
        }
    }
}
