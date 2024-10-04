using MVC_ThomasMore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            int positie = speler.VerplaatsSpeler(aantalOgen);

            // Assert
            Assert.AreEqual(4, speler.Positie);
        }

        [Test]
        public void SpelerRoltOnevenAantalOgen_SpelerBeweegtHetDubbelAantalOgen()
        {
            // Arrange
            int aantalOgen = 3;
            Speler speler = new Speler();

            // Act
            int positie = speler.VerplaatsSpeler(aantalOgen);

            // Assert
            Assert.AreEqual(6, speler.Positie);
        }

        [Ignore("Not ready yet")]
        public void GanseApplicatieWerktGoed()
        {
            throw new NotImplementedException();
        }
    }
}
