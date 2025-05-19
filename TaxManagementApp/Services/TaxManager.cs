using System;
using System.Linq;
using TaxManagementApp.Models;
using TaxManagementApp.Repositories;

namespace TaxManagementApp.Services
{
    public class TaxManager // Service class responsible for tax operations
    {
        private readonly ITaxRepository _repo;

        public TaxManager(ITaxRepository repo) // Constructor that takes a repository implementing ITaxRepository
        {
            _repo = repo;
        }

        /// Returns the applicable tax rate for a given municipality and date.
       
        public double GetTaxRate(string municipality, DateTime date)
        {
            return _repo.GetAll()
                .Where(tr => tr.Municipality.Equals(municipality, StringComparison.OrdinalIgnoreCase)
                          && tr.StartDate <= date && tr.EndDate >= date) // Select records where the date is in range
                .OrderBy(tr => (tr.EndDate - tr.StartDate).Days) 
                .FirstOrDefault()?.Rate ?? 0.0; // Return rate or 0.0 if no match found
        }
        /// Checks if a given municipality exists in the tax records.
        public bool MunicipalityExists(string municipality)
        {
            return _repo.GetAll().Any(tr => tr.Municipality.Equals(municipality, StringComparison.OrdinalIgnoreCase));
        }
        /// Adds a new tax record to the repository.
        public void AddTaxRecord(string municipality, DateTime startDate, DateTime endDate, double rate)
        {
            _repo.Add(new TaxRecord
            {
                Municipality = municipality,
                StartDate = startDate,
                EndDate = endDate,
                Rate = rate
            });
        }
    }
}