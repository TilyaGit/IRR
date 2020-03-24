using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace IRR.Core
{
    public interface ICategoryRepository
    {
        Task AddCategory([NotNull] Category category);

        [ItemNotNull]
        Task<ICollection<Category>> GetRootCategories();

    }
}
