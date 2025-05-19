using System;
namespace TaxManagementApp.Models
{
    public class TaxRecord
    {
        public string Municipality { get; set; }  // Name of the municipality the tax applies to
        public DateTime StartDate { get; set; }  // Start date of the tax's validity period
        public DateTime EndDate { get; set; }   // end date of the tax's validity period
        public double Rate { get; set; } // Tax rate (e.g., 0.2 for 20%)
    }
}