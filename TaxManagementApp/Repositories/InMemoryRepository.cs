using System;
using System.Collections.Generic;
using TaxManagementApp.Models;

namespace TaxManagementApp.Repositories
{
    public class InMemoryTaxRepository : ITaxRepository
    {
        private List<TaxRecord> _taxRecords = new List<TaxRecord>
        {
            new TaxRecord { Municipality = "Copenhagen", StartDate = new DateTime(2025, 1, 1), EndDate = new DateTime(2025, 1, 1), Rate = 0.1 },
            new TaxRecord { Municipality = "Copenhagen", StartDate = new DateTime(2025, 12, 25), EndDate = new DateTime(2025, 12, 25), Rate = 0.1 },
            new TaxRecord { Municipality = "Copenhagen", StartDate = new DateTime(2025, 5, 1), EndDate = new DateTime(2025, 5, 31), Rate = 0.4 },
            new TaxRecord { Municipality = "Copenhagen", StartDate = new DateTime(2025, 1, 1), EndDate = new DateTime(2025, 12, 31), Rate = 0.2 }
        };

        public List<TaxRecord> GetAll() => _taxRecords;

        public void Add(TaxRecord record) => _taxRecords.Add(record);
    }
}