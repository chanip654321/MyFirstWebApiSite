using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly Store214358897Context _store214358897Context;

        public ProductRepository(Store214358897Context store214358897Context)
        {
            _store214358897Context = store214358897Context;
        }

        public async Task<IEnumerable<ProductsTbl>> GetProductsAsync()
        {
            return await _store214358897Context.ProductsTbls.ToListAsync();
        }

        public async Task<IEnumerable<ProductsTbl>> GetProductsByCategoryAsync(int categoryId)
        {
            return await _store214358897Context.ProductsTbls.Where(c=>c.CategoryId == categoryId).ToListAsync();
        }

    }

}
