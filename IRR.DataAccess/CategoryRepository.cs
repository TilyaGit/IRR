using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IRR.Core;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace IRR.DataAccess
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IRRDbContext _dbContext;

        public CategoryRepository([NotNull] IRRDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task Add(Category category)
        {
            _dbContext.Categories.Add(category);
        }

        public async Task<ICollection<Category>> GetRootCategories()
        {
            return _dbContext.Categories.Where(r => r.ParentId == null).Include(s => s.Children).ToList();
        }
    }
}
