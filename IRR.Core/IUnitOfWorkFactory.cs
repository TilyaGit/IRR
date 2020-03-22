using JetBrains.Annotations;

namespace IRR.Core
{
    public interface IUnitOfWorkFactory
    {
        [NotNull]
        IUnitOfWork Create();
    }
}
