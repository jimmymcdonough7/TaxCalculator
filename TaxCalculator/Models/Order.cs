using System;

namespace TaxCalculator.Models
{
    public class Order : Tax
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
    }
}
