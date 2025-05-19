using System;
using System.Collections.Generic;
using TaxManagementApp.Models;

namespace TaxManagementApp.Repositories
{
    public interface ITaxRepository
    {
        List<TaxRecord> GetAll();
        void Add(TaxRecord record);
    }
}