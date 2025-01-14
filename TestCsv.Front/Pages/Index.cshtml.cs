using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace TestCsv.Front.Pages
{
    public class IndexModel : PageModel
    {
        //private readonly ILogger<IndexModel> _logger;
        [BindProperty]
        public IFormFile Upload { get; set; }
        //public IndexModel(ILogger<IndexModel> logger)
        //{
        //    _logger = logger;
        //}

        //public void OnGet()
        //{

        //}

        public async Task OnPostAsync()
        {
            JsonContent content = JsonContent.Create(Upload);

            using (var httpClient = new HttpClient())



            using (HttpResponseMessage response = await httpClient.PostAsync("https://localhost:7287/api/UploadFile/", Upload, new JsonMediaTypeFormatter()))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                //var a = JsonConvert.DeserializeObject<List<IncidentModel>>(apiResponse);
            }
        }
    }
}

