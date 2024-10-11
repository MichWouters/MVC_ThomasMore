using AutoMapper;
using MVC_ThomasMore.Data.Entities;
using MVC_ThomasMore.Data.Repositories;
using MVC_ThomasMore.Model;

namespace MVC_ThomasMore.Services
{
    public class ProductService : IProductService
    {
        private IProductRepo _repo;
        private IMapper _mapper;

        public ProductService(IProductRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<Product> GetProductAsync(int id)
        {
            ProductEntity entity = await _repo.GetProductWithCategory(id);

            Product model = _mapper.Map<Product>(entity);

            // We voeren berekeningen ENKEL op het Model uit
            model.TotaalPrijs = model.Prijs + 15;

            return model;
        }
    }
}
