using System;
using System.Collections.Generic;
using TaxCalculator.ViewModels;
using Xamarin.Forms;

namespace TaxCalculator.Views
{
    public partial class TaxLookupPage : ContentPage
    {
        private TaxLookupPageViewModel _viewModel;

        public TaxLookupPage()
        {
            
            InitializeComponent();
            BindingContext = _viewModel = (TaxLookupPageViewModel)Startup.ServiceProvider.GetService(typeof(TaxLookupPageViewModel));
        }


        

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            _viewModel.LookupCommand.Execute(null);
        }
    }
}
