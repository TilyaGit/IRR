using System.Threading.Tasks;
using JetBrains.Annotations;

namespace IRR.Core
{
    public interface ICategoryFieldRepository
    {
        Task AddCategoryField([NotNull] CategoryField categoryField);

    }
}
