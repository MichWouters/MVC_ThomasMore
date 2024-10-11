using AutoMapper;
using Moq;
using MVC_ThomasMore.Configuration;
using MVC_ThomasMore.Controllers;
using MVC_ThomasMore.Data.Entities;
using MVC_ThomasMore.Data.Repositories;
using MVC_ThomasMore.DTO.Product;
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
    }
}