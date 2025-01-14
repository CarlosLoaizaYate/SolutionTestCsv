using TestCsv.Core.Entities;

namespace TestCsv.Infraestructure.IRepositories
{
    public interface IUploadFileRepository
    {
        void InsertUploadFile(UploadFile uploadFile);
        IEnumerable<UploadFile> GetFiles();
        UploadFile GetFilesById(int Id);
    }
}
