﻿using System;
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

        public async Task AddCategory(Category category)
        {
            await _dbContext.Categories.AddAsync(category);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Category> Get(int id)
        {
            return await _dbContext.Categories.
                Include(s => s.CategoryItem).
                FirstOrDefaultAsync(s => s.Id == id);
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