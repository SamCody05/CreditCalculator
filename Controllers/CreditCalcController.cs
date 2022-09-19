using Microsoft.AspNetCore.Mvc;
using Zip.Credit.Models;
using System.IO.Pipes;
using CreditCalculator.Models;
using Zip.Credit.Services;

namespace Zip.Credit.Controllers
{
    public class CreditCalcController : Controller
    {
        private readonly ILogger _logger;     
        private readonly ICreditCalculatorService _creditCalculatorService;
        public CreditCalcController(ILogger<CreditCalcController> logger, ICreditCalculatorService calculatorService)
        {
            _logger = logger;
            _creditCalculatorService = calculatorService;
        }

        public IActionResult Index()
        {
            return View();
        }
       
        public  IActionResult CreditCalculate()
        {
            return View();
        }

        /// <summary>
        /// Gets the available credit bases on bureau score, missed payment,
        /// completed payment and age
        /// </summary>
        /// <param name="creditCalc">contains bureau score, missed payment,completed payment and age</param>
        /// <returns>Credit</returns>
        [HttpPost]
        public async Task<IActionResult> CreditCalculate(IFormCollection creditCalc)
        {
            decimal availableCredit = 0;
            try
            {

                Customer customer = new Customer(Convert.ToInt32(creditCalc["BureauScore"]), Convert.ToInt32(creditCalc["MissedPaymentCount"]), Convert.ToInt32(creditCalc["CompletedPaymentCount"]), Convert.ToInt32(creditCalc["AgeInYears"]));
                _logger.LogInformation("bureauScore: {0},missedPaymentCount: {1}, completedPaymentCount: {2},ageInYears: {3}", Convert.ToInt32(creditCalc["BureauScore"]), Convert.ToInt32(creditCalc["MissedPaymentCount"]), Convert.ToInt32(creditCalc["CompletedPaymentCount"]), Convert.ToInt32(creditCalc["AgeInYears"]));

                availableCredit = await _creditCalculatorService.GetCreditCalculatorAsync(customer);
               
                _logger.LogInformation("totalCredit= {0}", availableCredit);

            }
            catch (Exception ex)
            {
                _logger.LogInformation(Convert.ToString(ex.InnerException));
            }

            return View(new CreditCalculateModel()
            {
                BureauScore = Convert.ToInt32(creditCalc["BureauScore"]),
                MissedPaymentCount = Convert.ToInt32(creditCalc["MissedPaymentCount"]),
                CompletedPaymentCount = Convert.ToInt32(creditCalc["CompletedPaymentCount"]),
                AgeInYears = Convert.ToInt32(creditCalc["AgeInYears"]),
                AvailableCredit = availableCredit
            }
            );

        }

    }
}
