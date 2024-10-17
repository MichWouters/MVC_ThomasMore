namespace MVC_ThomasMore.Services
{
    public class PrijsService
    {
        public double BerekenTotaalPrijs(double basisPrijs, double btwPercentage)
        {
            ValidateBerekenTotaalPrijsInput(basisPrijs, btwPercentage);

            double resultaat = basisPrijs + (basisPrijs * btwPercentage);

            if (basisPrijs >= 1000)
            {
                resultaat = BerekenKorting(resultaat);
            }

            return Math.Round(resultaat, 2);
        }

        private void ValidateBerekenTotaalPrijsInput(double basisPrijs, double btwPercentage)
        {
            // Defensive programming
            if (basisPrijs <= 0)
            {
                throw new ArgumentException("Basisprijs moet groter zijn dan 0");
            }

            if (btwPercentage <= 0)
            {
                throw new ArgumentException("Btw Percentage moet groter zijn dan 0");
            }
        }

        private double BerekenKorting(double resultaat)
        {
            resultaat *= .9;
            return resultaat;
        }
    }
}
