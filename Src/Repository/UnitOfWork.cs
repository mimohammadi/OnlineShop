using Common.Interface;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly DataBaseContext _dbContext;

        public UnitOfWork(DataBaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Begin()
        {
            await _dbContext.Database.BeginTransactionAsync();
        }
        public async Task Commit()
        {
            await _dbContext.Database.CommitTransactionAsync();
        }

        public async Task RollBack()
        {
            await _dbContext.Database.RollbackTransactionAsync();
        }
    }
}
