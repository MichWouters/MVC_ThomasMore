namespace MVC_ThomasMore.Services
{
    public class KortingHelper
    {
        public double BerekenPrijsMetKorting(double totaalPrijs)
        {
            if (totaalPrijs > 2000)
            {
                return totaalPrijs * .9;
            }
            else if (totaalPrijs > 1000)
            {
                return totaalPrijs * .95;
            }
            else
            {
                return totaalPrijs;
            }
        }
    }
}
