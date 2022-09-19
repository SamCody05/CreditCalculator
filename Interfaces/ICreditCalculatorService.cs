using System.Collections.Generic;
using System.Threading.Tasks;
using Zip.Credit.Models;

namespace Zip.Credit.Services
{
    public interface ICreditCalculatorService
    {
        /// <summary>
        /// Calculates the available credit (in $) for a given customer
        /// </summary>
        /// <param name="customer">The customer for whom we are calculating credit</param>
        /// <returns>Available credit amount in $</returns>
        Task<decimal> GetCreditCalculatorAsync(Customer customer);
    }
}
