using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TaxCalculator.Services;
using TaxCalculator.Views;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using TaxCalculator.Models;

namespace TaxCalculator
{
    public partial class App : Application
    {
        
        public App()
        {
            InitializeComponent();

            //DependencyService.Register<TaxJarCalculator>();

            Startup.Init();

            MainPage = new AppShell();
        }

        

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
