using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TaxCalculator.Models;
using TaxCalculator.Services;
using Xamarin.Forms;

namespace TaxCalculator.ViewModels
{
    public class TaxLookupPageViewModel : BaseViewModel
    {
        private string _zipCode;
        private GetTaxRateResponse _taxRate;

        public TaxLookupPageViewModel(ITaxService service)
        {
            DataStore = service;
            LookupCommand = new Command(Lookup, ValidateFields);            
        }

        private bool ValidateFields()
        {
            return !String.IsNullOrWhiteSpace(ZipCode);
        }

        public string ZipCode
        {
            get => _zipCode;
            set => SetProperty(ref _zipCode, value);
        }

        public GetTaxRateResponse TaxRate
        {
            get => _taxRate;
            set => SetProperty(ref _taxRate, value);
        }

        public Command LookupCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void Lookup()
        {
            GetTaxRateRequest request = new GetTaxRateRequest()
            {
                ZipCode = ZipCode
            };

            var rate = await DataStore.GetTaxRate(request);
            TaxRate = rate;
            
        }
    }
}
