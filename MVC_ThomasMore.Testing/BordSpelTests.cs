using MVC_ThomasMore.Model;

namespace MVC_ThomasMore.Testing
{
    internal class BordSpelTests
    {
        // We maken een bordspel. Een gebruiker rolt een dobbelsteen
        // Als het aantal ogen even is verplaatsen we het aantal ogen
        // Als oneven, dan dubbel het aantal ogen
        [Test]
        public void SpelerRoltEvenAantalOgen_SpelerBeweegtHetAantalOgen()
        {
            // Arrange
            int aantalOgen = 4;
            Speler speler = new Speler();

            // Act
            speler.VerplaatsSpeler(aantalOgen);

            // Assert
            Assert.That(speler.Positie, Is.EqualTo(4));
        }

        [Test]
        public void SpelerRoltOnevenAantalOgen_SpelerBeweegtHetDubbelAantalOgen()
        {
            // Arrange
            int aantalOgen = 3;
            Speler speler = new Speler();

            // Act
            speler.VerplaatsSpeler(aantalOgen);

            // Assert
            Assert.That(speler.Positie, Is.EqualTo(6));
        }

        [Ignore("Not ready yet")]
        public void GanseApplicatieWerktGoed()
        {
            throw new NotImplementedException();
        }
    }
}
