using System;
using System.Threading.Tasks;
using IRR.Core;
using JetBrains.Annotations;

namespace IRR.DataAccess
{
    public class CategoryFieldRepository : ICategoryFieldRepository
    {
        private readonly IRRDbContext _dbContext;

        public CategoryFieldRepository([NotNull] IRRDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task AddCategoryField([NotNull] CategoryField categoryField)
        {
            await _dbContext.CategoryFields.AddAsync(categoryField);
            await _dbContext.SaveChangesAsync();
        }
    }
}
