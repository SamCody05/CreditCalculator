using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
using Zip.Credit;
using Zip.Credit.Controllers;
using Zip.Credit.Models;
using Zip.Credit.Services;

namespace Zip.Credit.Test
{
    public class CreditCalculateTest
    {
        private CreditCalculatorService _creditCalculatorService;

        public CreditCalculateTest()
        {
            if (_creditCalculatorService == null)
            {
                _creditCalculatorService = new CreditCalculatorService();
            }
        }

        /// <summary>
        /// Test method to calculate available credit
        /// </summary>
        [Fact]
        public void CalculateAvailableCredit()
        {
            int bureauScore = 750;
            int missedPaymentCount = 1;
            int completedPaymentCount = 4;
            int ageInYears = 29 ;
            

            var customer = new Customer(bureauScore, missedPaymentCount, completedPaymentCount, ageInYears);
            Task<decimal> availableCredit = _creditCalculatorService.GetCreditCalculatorAsync(customer);
            Assert.Equal(400 , availableCredit.Result);

        }

    }
}
