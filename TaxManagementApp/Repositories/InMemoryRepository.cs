using System;
using System.Collections.Generic;
using TaxManagementApp.Models;

namespace TaxManagementApp.Repositories
{
    public class InMemoryTaxRepository : ITaxRepository // In memory implementation of ITaxRepository for storing tax records
    {
        private List<TaxRecord> _taxRecords = new List<TaxRecord>  // Initial list of hard coded tax records for the municipality "Copenhagen"
        {
            new TaxRecord { Municipality = "Copenhagen", StartDate = new DateTime(2025, 1, 1), EndDate = new DateTime(2025, 1, 1), Rate = 0.1 },   // Daily tax rate for January 1, 2025
            new TaxRecord { Municipality = "Copenhagen", StartDate = new DateTime(2025, 12, 25), EndDate = new DateTime(2025, 12, 25), Rate = 0.1 },  // Daily tax rate for December 25, 2025
            new TaxRecord { Municipality = "Copenhagen", StartDate = new DateTime(2025, 5, 1), EndDate = new DateTime(2025, 5, 31), Rate = 0.4 }, // Monthly tax rate for May 2025
            new TaxRecord { Municipality = "Copenhagen", StartDate = new DateTime(2025, 1, 1), EndDate = new DateTime(2025, 12, 31), Rate = 0.2 }       // Yearly tax rate for all of 2025
        };

        public List<TaxRecord> GetAll() => _taxRecords;   // Returns all tax records

        public void Add(TaxRecord record) => _taxRecords.Add(record);  // Adds a new tax record to the in memory list
    }
}