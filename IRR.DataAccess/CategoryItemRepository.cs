using System;
using System.Threading.Tasks;
using IRR.Core;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace IRR.DataAccess
{
    public class CategoryItemRepository : ICategoryItemRepository
    {
        private readonly IRRDbContext _dbContext;

        public CategoryItemRepository([NotNull] IRRDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task AddCategoryItem(CategoryItem categoryItem)
        {
            await _dbContext.CategoryItems.AddAsync(categoryItem);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<CategoryItem> Get(int id)
        {
            return await _dbContext.CategoryItems.
                FirstOrDefaultAsync(s => s.Id == id);
        }
    }
}
