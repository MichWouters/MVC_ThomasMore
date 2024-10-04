namespace MVC_ThomasMore.Model
{
    // Deze klasse wordt enkel gebruikt om een unit test te simuleren.
    public class Speler
    {
        public int Positie { get; set; }

        public int VerplaatsSpeler(int aantalOgen)
        {
            if (aantalOgen % 2 == 0)
            {
                Positie = Positie + aantalOgen;
            }
            else
            {
                Positie = Positie + (aantalOgen * 2);
            }

            return Positie;
        }
    }
}