namespace MVC_ThomasMore.Testing
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TwoPlusTwoEqualsFour()
        {
            // Arrange -> Verzamel alle nodige gegevens
            int numberOne = 2; 
            int numberTwo = 2;

            // Act -> Voer actie uit die getest moet worden
            int result = numberOne + numberTwo;

            // Assert
            Assert.AreEqual(4, result);
        }
    }
}