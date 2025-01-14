using TestCsv.Core.Entities;
using TestCsv.Infraestructure.Context;
using TestCsv.Infraestructure.IRepositories;

namespace TestCsv.Infraestructure.Repositories
{
    public class ColumnNameFileRepository : IColumnNameFileRepository
    {

        private readonly TestCsvDbContext _dbContext;

        public ColumnNameFileRepository(TestCsvDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void InsertColumnNameFile(List<ColumnNameFile> columnNameFile)
        {
            _dbContext.ColumnNameFile.AddRange(columnNameFile);
            _dbContext.SaveChanges();
        }

    }
}
