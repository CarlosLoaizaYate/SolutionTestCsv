using Microsoft.EntityFrameworkCore;
using TestCsv.Core.Entities;
using TestCsv.Infraestructure.Context;
using TestCsv.Infraestructure.IRepositories;

namespace TestCsv.Infraestructure.Repositories
{
    public class UploadFileRepository : IUploadFileRepository
    {
        private readonly TestCsvDbContext _dbContext;
        private bool disposed = false;

        public UploadFileRepository(TestCsvDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void InsertUploadFile(UploadFile uploadFile)
        {
            _dbContext.UploadFile.Add(uploadFile);
            _dbContext.SaveChanges();
        }

        public List<UploadFile> GetFiles()
        {
            return _dbContext.UploadFile.ToList();
        }

        public UploadFile GetFilesById(int Id)
        {
            UploadFile uploadFile = new();

            try
            {
                //var listFiles = 
                //if (listFiles.Count > 0)
                //{
                //    eventEm = listEvents[0];
                //}

                uploadFile = _dbContext.UploadFile.Where(x => x.Id == Id).Include(x => x.ColumnsNameFile).ThenInclude(x => x.ColumnsValueFile).FirstOrDefault();
                return uploadFile;
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
