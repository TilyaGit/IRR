using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace IRR.Core
{
    public interface ICategoryRepository
    {
        Task AddCategory([NotNull] Category category);

        [ItemNotNull]
        Task<ICollection<Category>> GetRootCategories();

        Category GetCategory(int? id);
    }
}
