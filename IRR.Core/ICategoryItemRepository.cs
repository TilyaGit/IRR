using System.Threading.Tasks;
using JetBrains.Annotations;

namespace IRR.Core
{
    public interface ICategoryItemRepository
    {
        Task AddCategoryItem([NotNull] CategoryItem categoryItem);

        [ItemCanBeNull]
        Task<CategoryItem> Get(int id);

    }
}
