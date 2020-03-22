using System;
using System.Collections.Generic;
using System.Text;
using IRR.Core;
using JetBrains.Annotations;

namespace IRR.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IRRDbContext _dbContext;
        public UnitOfWork([NotNull] IRRDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _dbContext.Database.BeginTransaction();
        }

        public void Dispose()
        {
            _dbContext.Database.CurrentTransaction?.Rollback();
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
            _dbContext.Database.CurrentTransaction.Commit();
        }
    }
}
