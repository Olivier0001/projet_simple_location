using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using SLAppsDataAccess.Repository.IRepository;
using SLAppsModels;

namespace SLApps.Pages.Voitures
{
    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public Voiture Voiture { get; set; }

        public CreateModel(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost(Voiture voiture, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(wwwRootPath, @"images/voitures");
                    var extension = Path.GetExtension(file.FileName);

                    using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        file.CopyTo(fileStreams);
                    }

                    voiture.image_voiture = @"\images\voitures\" + fileName + extension;
                }
                _unitOfWork.Voiture.Add(voiture);
                _unitOfWork.Save();
                TempData["success"] = "La voiture a été créé avec succès.";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
