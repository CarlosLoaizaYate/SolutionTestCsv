using Microsoft.AspNetCore.Mvc;
using TestCsv.Application.IServices;
using TestCsv.Core.Entities;
using TestCsv.Common.Classes;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestCsv.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadFileController : ControllerBase
    {
        private readonly IUploadFileService _uploadFileService;

        public UploadFileController(IUploadFileService uploadFileService)
        {
            _uploadFileService = uploadFileService;
        }

        //GET: api/<ValuesController>
        [HttpGet]
        public ResponseContract<List<UploadFile>> Get()
        {
            ResponseContract<List<UploadFile>> response = new ResponseContract<List<UploadFile>>();
            response.Data = _uploadFileService.GetFiles();
            return response;
        }

        //GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public ResponseContract<UploadFile> Get(int id)
        {
            ResponseContract<UploadFile> response = new ResponseContract<UploadFile>();
            response.Data = _uploadFileService.GetFilesById(id);
            return response;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post(IFormFile file)
        {
            _uploadFileService.UploadFile(file);
        }
    }
}
