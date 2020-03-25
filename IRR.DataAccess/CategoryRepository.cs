using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IRR.Core;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

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
            var cat = _dbContext.Categories.Add(category);
                //.Include(d=>d.Parent)
                //.Where(s=>s.Parent.Id==category.Id)
                //.First();
                //.SingleOrDefault(c => c.Parent.Id == category.Parent.Id);

            //var child = category;

            //cat.Children.Add(child);
            _dbContext.SaveChanges();
        }

        public async Task<ICollection<Category>> GetRootCategories()
        {

            var categories = _dbContext.Categories
                .Include(e => e.Children)
                .AsEnumerable()
                .Where(e => e.ParentId == null)
                .ToList();
            return categories;

        }

        public ICollection<Category> GetCategories()
        {
            return _dbContext.Categories.ToList();
        }
    }
}
