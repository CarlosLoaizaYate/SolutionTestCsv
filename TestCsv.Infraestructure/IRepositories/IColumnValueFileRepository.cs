using TestCsv.Core.Entities;

namespace TestCsv.Infraestructure.IRepositories
{
    public interface IColumnValueFileRepository
    {
        void InsertColumnValueFile(List<ColumnValueFile> columnValueFile);
    }
}
