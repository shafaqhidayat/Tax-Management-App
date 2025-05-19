using System;
using TaxManagementApp.Services;
using TaxManagementApp.Repositories;
using Xunit;

namespace TaxManagementApp.Tests
{
    public class TaxManagerTests
    {
        [Fact]
        public void GetTaxRate_ReturnsCorrectRate_ForMay2025()
        {
            var repo = new InMemoryTaxRepository();
            var taxManager = new TaxManager(repo);

            double rate = taxManager.GetTaxRate("Copenhagen", new DateTime(2025, 5, 15));

            Assert.Equal(0.4, rate);
        }

        [Fact]
        public void MunicipalityExists_ReturnsFalse_ForUnknown()
        {
            var repo = new InMemoryTaxRepository();
            var taxManager = new TaxManager(repo);

            bool exists = taxManager.MunicipalityExists("NowhereLand");

            Assert.False(exists);
        }
    }
}