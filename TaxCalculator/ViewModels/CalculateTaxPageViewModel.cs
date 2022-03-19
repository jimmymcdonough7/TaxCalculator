using System;
using System.Globalization;
using Microsoft.Extensions.Configuration;
using TaxCalculator.Models;
using TaxCalculator.Services;
using TaxCalculator.ViewModels;
using Xamarin.Forms;

namespace TaxCalculator.Views
{
    public class CalculateTaxPageViewModel : BaseViewModel
    {
        public CalculateTaxPageViewModel(ITaxService service)
        {
            DataStore = service;
            CalculateCommand = new Command(Calculate, ValidateFields);
        }

        

        private bool ValidateFields()
        {
            return !String.IsNullOrWhiteSpace(CountryCode); //todo check other fields
        }

        private string _amount;
        public string Amount
        {
            get => _amount;
            set => SetProperty(ref _amount, value);
        }

        private string _shippingCost;
        public string ShippingCost
        {
            get => _shippingCost;
            set => SetProperty(ref _shippingCost, value);
        }

        private string _countryCode;
        public string CountryCode
        {
            get => _countryCode;
            set => SetProperty(ref _countryCode, value);
        }

        private string _zipCode;
        public string ZipCode
        {
            get => _zipCode;
            set => SetProperty(ref _zipCode, value);
        }

        private string _state;
        public string State
        {
            get => _state;
            set => SetProperty(ref _state, value);
        }

        private CalculateTaxResponse _tax;
        public CalculateTaxResponse Tax
        {
            get => _tax;
            set => SetProperty(ref _tax, value);
        }

        public Command CalculateCommand { get; }

        private IConfiguration _config;

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void Calculate()
        {
            CalculateTaxRequest request = new CalculateTaxRequest()
            {
                Amount = float.Parse(Amount, CultureInfo.InvariantCulture.NumberFormat),
                ShippingCost = float.Parse(ShippingCost, CultureInfo.InvariantCulture.NumberFormat),
                ToCountry = CountryCode,
                ZipCode = ZipCode,
                State = State,
            };

            var taxResponse = await DataStore.CalculateTaxAsync(request);
            Tax = taxResponse;

        }
    }
}