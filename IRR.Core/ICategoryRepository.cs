using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace IRR.Core
{
    public interface ICategoryRepository
    {
        Task Add([NotNull] Category category);

        [ItemNotNull]
        Task<IQueryable<Category>> GetRootCategories();
    }
}
