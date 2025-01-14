using Microsoft.AspNetCore.Mvc;
using TestCsv.Application.IServices;
using TestCsv.Core.Entities;

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
        public IEnumerable<UploadFile> Get()
        {
            return _uploadFileService.GetFiles();
        }

        //GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public UploadFile Get(int id)
        {
            return _uploadFileService.GetFilesById(id);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post(IFormFile file)
        {
            _uploadFileService.UploadFile(file);
        }
    }
}
