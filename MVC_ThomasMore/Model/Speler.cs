

namespace MVC_ThomasMore.Model
{
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
