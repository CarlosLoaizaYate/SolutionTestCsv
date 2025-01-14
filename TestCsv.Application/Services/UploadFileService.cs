using Microsoft.AspNetCore.Http;
using TestCsv.Application.IServices;
using TestCsv.Core.Entities;
using TestCsv.Infraestructure.IRepositories;

namespace TestCsv.Application.Services
{
    public class UploadFileService : IUploadFileService
    {
        private readonly IUploadFileRepository _uploadFileRepository;
        private readonly IColumnNameFileRepository _columnNameFileRepository;
        private readonly IColumnValueFileRepository _columnValueFileRepository;

        public UploadFileService(IUploadFileRepository uploadFileRepository, IColumnNameFileRepository columnNameFileRepository, IColumnValueFileRepository columnValueFileRepository)
        {
            _uploadFileRepository = uploadFileRepository;
            _columnNameFileRepository = columnNameFileRepository;
            _columnValueFileRepository = columnValueFileRepository;
        }


        public void UploadFile(IFormFile fileModel)
        {
            var AutodetectSeparators = new char[] { ',', ';', '\t', '|', '#' };

            UploadFile uploadFile = new()
            {
                InsertDate = DateTime.Now,
                UploadFileName = fileModel.FileName
            };

            _uploadFileRepository.InsertUploadFile(uploadFile);

            List<ColumnNameFile> columnsNameFile = [];
            List<ColumnValueFile> ColumnsValueFile = [];
            using (var stream = fileModel.OpenReadStream())
            using (StreamReader sr = new StreamReader(stream))
            {
                string[] headers = sr.ReadLine().Split(AutodetectSeparators);
                foreach (string header in headers)
                {
                    ColumnNameFile columnNameFile = new()
                    {
                        ColumnName = header,
                        IdUploadFile = uploadFile.Id
                    };

                    columnsNameFile.Add(columnNameFile);
                }
                _columnNameFileRepository.InsertColumnNameFile(columnsNameFile);
                while (!sr.EndOfStream)
                {
                    string[] rows = sr.ReadLine().Split(AutodetectSeparators);
                    for (int i = 0; i < columnsNameFile.Count; i++)
                    {
                        ColumnValueFile columnValueFile = new()
                        {
                            ColumnValue = rows[i],
                            IdColumnNameFile = columnsNameFile[i].Id
                        };

                        ColumnsValueFile.Add(columnValueFile);
                    }
                }
                _columnValueFileRepository.InsertColumnValueFile(ColumnsValueFile);
            }
        }

        public IEnumerable<UploadFile> GetFiles()
        {
            return _uploadFileRepository.GetFiles();
        }

        public UploadFile GetFilesById(int Id)
        {
            return _uploadFileRepository.GetFilesById(Id);
        }
    }
}
