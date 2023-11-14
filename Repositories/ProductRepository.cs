using Entities;
//using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<ProductsTbl>> GetProductsAsync(string? name, int? minPrice, int? maxPrice, int?[] CategoryIds)
        {
            var query = _store214358897Context.ProductsTbls.Where(product =>
            (name == null ? true : product.Description.Contains(name))
            && ((minPrice == null) ? true : (product.Price >= minPrice))
            && ((maxPrice == null) ? true : (product.Price <= maxPrice))
            && ((CategoryIds.Length == 0) ? true : CategoryIds.Contains(product.CategoryId)))
            .OrderBy(product => product.Price);

            List<ProductsTbl> products = await query.ToListAsinc();
            return products;
        }

        public async Task<IEnumerable<ProductsTbl>> GetProductsByCategoryAsync(int categoryId)
        {
            return await _store214358897Context.ProductsTbls.Where(c=>c.CategoryId == categoryId).ToListAsync();
        }

    }

}
