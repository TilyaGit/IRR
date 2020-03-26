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

        public async Task AddCategory([NotNull]Category category)
        {
            _dbContext.Categories.Add(category); 
            _dbContext.SaveChanges();
        }

        public Category GetCategory(int? id)
        {
            return _dbContext.Categories.Find(id);            
        }

        public async Task<ICollection<Category>> GetRootCategories()
        {

            var categories = (_dbContext.Categories
                                  .Include(e => e.Children)
                                  .AsEnumerable() ?? throw new InvalidOperationException())
                                  .Where(e => e.ParentId == null)
                                  .ToList();
            return categories;

        }

    }
}
