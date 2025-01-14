using TestCsv.Core.Entities;

namespace TestCsv.Infraestructure.IRepositories
{
    public interface IColumnNameFileRepository
    {
        void InsertColumnNameFile(List<ColumnNameFile> columnNameFile);
    }
}
