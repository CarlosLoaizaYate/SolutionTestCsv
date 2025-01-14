using TestCsv.Core.Entities;
using TestCsv.Infraestructure.Context;
using TestCsv.Infraestructure.IRepositories;

namespace TestCsv.Infraestructure.Repositories
{
    public class ColumnValueFileRepository : IColumnValueFileRepository
    {

        private readonly TestCsvDbContext _dbContext;

        public ColumnValueFileRepository(TestCsvDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void InsertColumnValueFile(List<ColumnValueFile> columnValueFile)
        {
            _dbContext.ColumnValueFile.AddRange(columnValueFile);
            _dbContext.SaveChanges();
        }

        //public void InsertColumnValueFile(List<ColumnValueFile> columnValueFile)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
