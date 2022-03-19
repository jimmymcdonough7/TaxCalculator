using System;
using System.Collections.Generic;
using TaxCalculator.ViewModels;
using TaxCalculator.Views;
using Xamarin.Forms;

namespace TaxCalculator
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(TaxLookupPage), typeof(TaxLookupPage));
            Routing.RegisterRoute(nameof(CalculateTaxPage), typeof(CalculateTaxPage));
        }

    }
}
