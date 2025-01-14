using Microsoft.AspNetCore.Http;
using TestCsv.Core.Entities;

namespace TestCsv.Application.IServices
{
    public interface IUploadFileService
    {
        void UploadFile(IFormFile fileModel);
        List<UploadFile> GetFiles();
        UploadFile GetFilesById(int Id);
    }
}
