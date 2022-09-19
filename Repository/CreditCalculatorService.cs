
using Castle.Core.Resource;

namespace Zip.Credit.Services
{
    public class CreditCalculatorService : ICreditCalculatorService
    {
        /// <summary>
        ///  Calculates the available credit(in $) for a given customer
        /// </summary>
        /// <param name="customer">The customer for whom we are calculating the credit</param>
        /// <returns>Available credit based on total points</returns>
        /// <exception cref="Exception"></exception>
        public Task<decimal> GetCreditCalculatorAsync(Customer customer)
        {
            if (customer == null)
                throw new Exception("customer is empty");

            decimal availableCredit = 0;
            int totalPoints = customer.GetTotalCustPoints();

            switch (totalPoints)
            {
                case int points when (totalPoints <= 0):
                    availableCredit = 0;
                    break;
                case 1:
                    availableCredit = 100;
                    break;
                case 2:
                    availableCredit = 200;
                    break;
                case 3:
                    availableCredit = 300;
                    break;
                case 4:
                    availableCredit = 400;
                    break;
                case 5:
                    availableCredit = 500;
                    break;
                case int points when (totalPoints >= 6):
                    availableCredit = 600;
                    break;
            }

            return Task.FromResult(availableCredit);


        }

    }
}
