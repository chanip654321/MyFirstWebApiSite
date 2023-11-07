using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductServies : IProductServies
    {
        IProductRepository _productRepository;

        public ProductServies(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductsTbl>> GetProductsAsync()
        {
            return await _productRepository.GetProductsAsync();
        }

        public async Task<IEnumerable<ProductsTbl>> GetProductsByCategoryAsync(int categoryId)
        {
            return await _productRepository.GetProductsByCategoryAsync(categoryId);
        }
    }

}
