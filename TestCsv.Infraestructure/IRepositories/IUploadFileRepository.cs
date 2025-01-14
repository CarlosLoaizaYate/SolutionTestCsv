using TestCsv.Core.Entities;

namespace TestCsv.Infraestructure.IRepositories
{
    public interface IUploadFileRepository
    {
        void InsertUploadFile(UploadFile uploadFile);
        List<UploadFile> GetFiles();
        UploadFile GetFilesById(int Id);
    }
}
