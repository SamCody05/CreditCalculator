namespace Zip.Credit
{
    public class BureauScorePoints : ICreditPoints
    {
        /// <summary>
        ///  Get customer's credit score from a credit bureau
        /// </summary>
        /// <returns></returns>
        public int GetCreditPoints(int score)
        {
            int bureauScorePoints = 0;
            switch (score)
            {
                case int bureauScore when (bureauScore >= 0 && bureauScore <= 450):
                    bureauScorePoints = -1;
                    break;                                 
                case int bureauScore when (bureauScore > 450 && bureauScore <= 700):
                    bureauScorePoints = 1;
                    break;
                case int bureauScore when (bureauScore > 700 && bureauScore <= 850):
                    bureauScorePoints = 2;
                    break;
                case int bureauScore when (bureauScore > 850 && bureauScore <= 1000):
                    bureauScorePoints = 3;
                    break;
                default:
                    bureauScorePoints = 0;
                    break;
            }
            return bureauScorePoints;
        }
    }

    public class MissedPaymentPoints : ICreditPoints
    {
        /// <summary>
        /// Get the points based on number of payments missed by the customer
        /// </summary>
        /// <returns></returns>
        public int GetCreditPoints(int MissedPaymentCount)
        {
            int missedPaymentsPoints = 0;
            switch (MissedPaymentCount)
            {
                case 0:
                    missedPaymentsPoints = 0;
                    break;
                case 1:
                    missedPaymentsPoints = -1;
                    break;
                case 2:
                    missedPaymentsPoints = -3;
                    break;
                case int missedPaytimes when (missedPaytimes >= 3):
                    missedPaymentsPoints = -6;
                    break;
                default:
                    missedPaymentsPoints = 0;
                    break;
            }
            return missedPaymentsPoints;
        }
    }

    public class CompletedPaymentPoints : ICreditPoints
    {
        /// <summary>
        /// Get credit points based on customer's payment done on time
        /// </summary>
        /// <returns></returns>
        public int GetCreditPoints(int CompletedPaymentCount)
        {
            int completedPaymentsPoints = 0;
            switch (CompletedPaymentCount)
            {
                case 0:
                    completedPaymentsPoints = 0;
                    break;
                case 1:
                    completedPaymentsPoints = 2;
                    break;
                case 2:
                    completedPaymentsPoints = 3;
                    break;
                case int missedPaytimes when (missedPaytimes >= 3):
                    completedPaymentsPoints = 4;
                    break;
                default:
                    completedPaymentsPoints = 0;
                    break;
            }
            return completedPaymentsPoints;
        }
    }

    public class AgeBasedPoints : ICreditPoints
    {
        /// <summary>
        /// Get maximum points depending on age
        /// </summary>
        /// <returns></returns>
        public int GetCreditPoints(int AgeInYears)
        {
            int pointBasedOnAge = 0;
            switch (AgeInYears)
            {
                case int age when (age >= 18 && age <= 25):
                    pointBasedOnAge = 3;
                    break;
                case int age when (age >= 26 && age <= 35):
                    pointBasedOnAge = 4;
                    break;
                case int age when (age >= 36 && age <= 50):
                    pointBasedOnAge = 5;
                    break;
                case int age when (age >= 50):
                    pointBasedOnAge = 6;
                    break;
                default:
                    pointBasedOnAge = 0;
                    break;
            }
            return pointBasedOnAge;
        }
    }
}
