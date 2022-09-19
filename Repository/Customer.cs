namespace Zip.Credit
{
    public class Customer
    {
        public int BureauScore { get; }

        public int MissedPaymentCount { get; }

        public int CompletedPaymentCount { get; }

        public int AgeInYears { get; }

        public Customer(int bureauScore, int missedPaymentCount,
            int completedPaymentCount, int ageInYears)
        {
            BureauScore = bureauScore;
            MissedPaymentCount = missedPaymentCount;
            CompletedPaymentCount = completedPaymentCount;
            AgeInYears = ageInYears;
        }

        /// <summary>
        /// Gets total customer points and cap the spending based on their age.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public int GetTotalCustPoints()
        {
            int bureauPoints = 0;
            int missedPayPoints = 0;
            int completedPayPoints = 0;
            int agePoints = 0;
            int totalPoints;

            ICreditPoints bureauScorePoints = new BureauScorePoints();
            bureauPoints = bureauScorePoints.GetCreditPoints(BureauScore);

            if (bureauPoints == -1)
                throw new Exception("Not allowed to use Zip");

            ICreditPoints missedPaymentPoints = new MissedPaymentPoints();
            missedPayPoints = missedPaymentPoints.GetCreditPoints(MissedPaymentCount);

            ICreditPoints completedPaymentPoints = new CompletedPaymentPoints();
            completedPayPoints = completedPaymentPoints.GetCreditPoints(CompletedPaymentCount);

            ICreditPoints ageBasedPoints = new AgeBasedPoints();
            agePoints = ageBasedPoints.GetCreditPoints(AgeInYears);

            totalPoints = bureauPoints + missedPayPoints + completedPayPoints ;

            if (totalPoints > agePoints && agePoints > 0)
            {
                totalPoints = agePoints;
            }

            return totalPoints;

        }
    }
}
