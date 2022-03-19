using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TaxCalculator.Views
{
    public partial class CalculateTaxPage : ContentPage
    {
        private CalculateTaxPageViewModel _viewModel;

        public CalculateTaxPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = (CalculateTaxPageViewModel)Startup.ServiceProvider.GetService(typeof(CalculateTaxPageViewModel));
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            _viewModel.CalculateCommand.Execute(null);
        }
    }
}
