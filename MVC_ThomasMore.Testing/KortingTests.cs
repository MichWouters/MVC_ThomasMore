using MVC_ThomasMore.Services;

namespace MVC_ThomasMore.Testing
{
    /*Een unit test is een methodie controleert of
     * het resultaat van een methode(idealiter in een business layer)
     */

    internal class KortingTests
    {
        [Test]
        public void AlsTotaalAankoopGroterisDan1000_DanKrijgtKlant5PercentKorting()
        {
            // Arrange
            double prijs = 1200;
            double verwachtResultaat = 1140;
            double resultaat = 0;
            KortingHelper helper = new KortingHelper();

            // Act
            resultaat = helper.BerekenPrijsMetKorting(prijs);

            // Assert
            Assert.That(resultaat, Is.EqualTo(verwachtResultaat));
        }

        [Test]
        public void AlsTotaalAankoopGroterisDan2000_DanKrijgtKlant10PercentKorting()
        {
            // Arrange
            double prijs = 2500;
            double verwachtResultaat = 2250;
            double resultaat = 0;
            KortingHelper helper = new KortingHelper();

            // Act
            resultaat = helper.BerekenPrijsMetKorting(prijs);

            // Assert
            Assert.That(resultaat, Is.EqualTo(verwachtResultaat));
        }
    }
}