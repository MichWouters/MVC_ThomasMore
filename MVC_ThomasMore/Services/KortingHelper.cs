namespace MVC_ThomasMore.Services
{
    /* Enkel Services kunnen Unit testing gebruiken
    Er kunnen geen instanties van controllers gemaakt worden
    Data klassen testen we niet -> Data verandert vaak
    En we willen geen test data in een echte DB pompen
    */

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