using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ValasztasWebapp.Models;

namespace ValasztasWebapp.Pages
{
    public class AdatokFeltolteseFajlbolModel : PageModel
    {
        private readonly IWebHostEnvironment _env;
        private readonly ValasztasDbContext _context;

        public AdatokFeltolteseFajlbolModel(IWebHostEnvironment env,
            ValasztasDbContext context)
        {
            _context = context;
            _env = env;
        }

        [BindProperty]
        public IFormFile UploadFile {  get; set; }


        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync() 
        {
            var UploadFilePath = 
                Path.Combine(_env.ContentRootPath, "uploads", UploadFile.FileName);

            using (var stream = new FileStream(UploadFilePath, FileMode.Create))
            {
                await UploadFile.CopyToAsync(stream);
            }

            StreamReader sr = new StreamReader(UploadFilePath)
                //feldolgozas

            sr.Close();
            return Page();
        }

    }
}
