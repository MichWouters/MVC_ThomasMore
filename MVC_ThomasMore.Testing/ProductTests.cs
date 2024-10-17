using AutoMapper;
using Moq;
using MVC_ThomasMore.Configuration;
using MVC_ThomasMore.Controllers;
using MVC_ThomasMore.Data.Entities;
using MVC_ThomasMore.Data.Repositories;
using MVC_ThomasMore.DTO.Product;
using MVC_ThomasMore.Model;
using MVC_ThomasMore.Services;

namespace MVC_ThomasMore.Testing
{
    public class ProductTests
    {
        [Test]
        public async Task AlsProductOpgehaaldWordt_WordenPrijzenCorrectBerekend()
        {
            // Arrange
            ProductEntity mockProduct = new ProductEntity
            {
                Id = 1,
                CategorieId = 1,
                Prijs = 100,
                Naam = "TestProduct"
            };

            // Mock Dependency
            Mock<IProductRepo> mockRepo = new Mock<IProductRepo>();
            mockRepo.Setup(x => x.GetProductWithCategory(It.IsAny<int>())).ReturnsAsync(mockProduct);

            // Set Automapper
            var config = new MapperConfiguration(cfg => { cfg.AddProfile(new MapperProfile()); });
            IMapper mapper = new Mapper(config);

            var service = new ProductService(mockRepo.Object, mapper);

            // Act
            var product = await service.GetProductAsync(1);

            // Assert
            Assert.That(product.TotaalPrijs, Is.EqualTo(115));
            Assert.That(product.PrijsInDollar, Is.EqualTo(90));
            Assert.That(product.PrijsInPond, Is.EqualTo(110));

        }

        [Test]
        public async Task AlsProductDuurderisDan100Euro_WordenErGeenVerzendKostenToegevoegdAsync()
        {
            // Arrange
            // We maken geen echte dependency aan, maar een fake dependency
            // E.G. Vogelverschrikker vs een echte persoon
            Mock<IProductRepo> mockRepo = new Mock<IProductRepo>();

            // Automapper kan niet gemockt worden. 
            // Als een klasse onder test Automapper als dependency heeft kan deze als volgt aangemaakt worden
            var config = new MapperConfiguration(cfg => { cfg.AddProfile(new MapperProfile()); });
            IMapper mapper = new Mapper(config);

            // Via Setup kan een gemockte methode op een dependency hard coded data terug geven
            ProductEntity productEntity = new ProductEntity()
            {
                Prijs = 150
            };

            mockRepo.Setup(x => x.GetProductWithCategory(It.IsAny<int>())).ReturnsAsync(productEntity);

            ProductService classUnderTest = new ProductService(mockRepo.Object, mapper);

            // Act
            Product model = await classUnderTest.GetProductAsync(1);

            // Assert
            Assert.That(model.TotaalPrijs, Is.EqualTo(150));
        }
    }
}