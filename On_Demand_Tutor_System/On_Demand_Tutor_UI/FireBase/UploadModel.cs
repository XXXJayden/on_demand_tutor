using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace On_Demand_Tutor_UI.FireBase
{
    public class UploadModel : PageModel
    {
        private readonly FireBaseStorage _firebaseStorage;

        public UploadModel(FireBaseStorage fireBaseStorge)
        {
            _firebaseStorage = fireBaseStorge;
        }

        [BindProperty]
        public IFormFile File { get; set; }
        public string UploadedFileUrl { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (File != null)
            {
                var fileName = Path.GetFileName(File.FileName);
                using (var stream = File.OpenReadStream())
                {
                    UploadedFileUrl = await _firebaseStorage.UploadFileAsync(stream, fileName);
                }
            }
            return Page();
        }
    }
}
