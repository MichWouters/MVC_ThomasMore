using MVC_ThomasMore.Services;

namespace MVC_ThomasMore.Testing
{
    internal class TotaalPrijsTests
    {
        private PrijsService serviceUnderTest;

        [SetUp]
        public void Setup()
        {
            serviceUnderTest = new PrijsService();
            // Setup wordt uitgevoerd voor iedere testmethode gerund wordt
        }

        [TestCase(100, .21, 121)]
        [TestCase(100, .06, 106)]
        [TestCase(875, .21, 1058.75)]
        [TestCase(875, .06, 927.5)]
        [TestCase(359.24574, .21, 434.69)]
        public void BerekenTotaalPrijs_Onder1000Euro_KrijgtGeenKorting_ZelfsMetBTW
            (double basisPrijs, double btwPercentage, double verwachteTotaal)
        {
            // Arrange
            //double basisPrijs = 100;
            //double btwPercentage = .21;
            //double verwachteTotaal = 121;

            // Act
            double resultaat = serviceUnderTest.BerekenTotaalPrijs(basisPrijs, btwPercentage);

            // Assert
            Assert.That(resultaat, Is.EqualTo(verwachteTotaal));
        }

        [Test]
        public void BerekenTotaalPrijs_BedragMetBtw_Boven1000Euro_KrijgtTienPercentKorting()
        {
            // Arrange
            double basisPrijs = 1100;
            double btwPercentage = .21;
            double verwachteTotaal = 1197.9;

            // Act
            double resultaat = serviceUnderTest.BerekenTotaalPrijs(basisPrijs, btwPercentage);

            // Assert
            Assert.That(resultaat, Is.EqualTo(verwachteTotaal));
        }

        [Test]
        public void BerekenTotaalPrijs_TotaalBedragGroterDan1000_MaarBasisPrijsOnder1000_KrijgtGeenKorting()
        {
            // Arrange
            double basisPrijs = 900;
            double btwPercentage = .21;
            double verwachteTotaal = 1089;

            // Act
            double resultaat = serviceUnderTest.BerekenTotaalPrijs(basisPrijs, btwPercentage);

            // Assert
            Assert.That(resultaat, Is.EqualTo(verwachteTotaal));
        }

        // Test ook de Unhappy path -> Wat verwachten we niet?
        [Test]
        public void BerekenTotaalPrijs_AlsGebruikerNegatiefGetalInvoert_WordtEenExceptionGegooid()
        {
            // Arrange
            double basisPrijs = -1100;
            double btwPercentage = .21;

            // Act & Assert
            Assert.Throws<ArgumentException>(()
                => serviceUnderTest.BerekenTotaalPrijs(basisPrijs, btwPercentage));
        }
    }
}