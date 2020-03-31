using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IRR.Core;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace IRR.DataAccess
{
    public class CategoryFieldRepository : ICategoryFieldRepository
    {
        private readonly IRRDbContext _dbContext;

        public CategoryFieldRepository([NotNull] IRRDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public CategoryField GetFields(int id)
        {
            return _dbContext.CategoryModelFields.Find(id);
        }

        public async Task<ICollection<CategoryField>> GetCategoryFiealds()
        {

            var catField = (_dbContext.CategoryModelFields
                                  .Include(e => e.Type)
                                  .AsEnumerable() ?? throw new InvalidOperationException())
                                  .ToList();
            return catField;
        }
    }
}
