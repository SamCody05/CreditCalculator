namespace Zip.Credit
{
    public interface ICreditPoints
    {
        /// <summary>
        /// Gets the credit points based on Bureau Score, missed payments, completed paymemts
        /// and maximum points depending upon age
        /// </summary>
        int GetCreditPoints(int score); 

    }
}
