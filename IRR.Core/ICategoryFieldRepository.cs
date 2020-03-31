using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace IRR.Core
{
    public interface ICategoryFieldRepository
    {
        [ItemNotNull]
        Task<ICollection<CategoryField>> GetCategoryFiealds();

        CategoryField GetFields(int id);
    }
}
