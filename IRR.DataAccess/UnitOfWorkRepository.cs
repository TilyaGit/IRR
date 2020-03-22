using System;
using System.Collections.Generic;
using System.Text;
using IRR.Core;
using JetBrains.Annotations;

namespace IRR.DataAccess
{
    public class UnitOfWorkRepository : IUnitOfWorkFactory
    {
        private readonly IRRDbContext _dbContext;

        public UnitOfWorkRepository([NotNull] IRRDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public IUnitOfWork Create()
        {
            return new UnitOfWork(_dbContext);
        }
    }
}
