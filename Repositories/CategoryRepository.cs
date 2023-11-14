using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly Store214358897Context _store214358897Context;

        public CategoryRepository(Store214358897Context store214358897Context)
        {
            _store214358897Context = store214358897Context;
        }

        public async Task<IEnumerable<CategoriesTbl>> GetCategoriesAsync()
        {
            return await _store214358897Context.CategoriesTbls.ToListAsync();
        }

    }
}
