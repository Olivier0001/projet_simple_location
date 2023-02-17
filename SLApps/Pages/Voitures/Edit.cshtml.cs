using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SLAppsDataAccess.Repository.IRepository;
using SLAppsModels;

namespace SLApps.Pages.Voitures
{
    public class EditModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public Voiture Voiture { get; set; }
        public EditModel(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public void OnGet(int id_voiture, IFormFile file)
        {
            Voiture = _unitOfWork.Voiture.GetFirstOrDefault(u => u.id_voiture == id_voiture);
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
                    if (voiture.image_voiture != null)
                    {
                        var oldImagePath = Path.Combine(wwwRootPath, voiture.image_voiture.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }
                    using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        file.CopyTo(fileStreams);
                    }
                    voiture.image_voiture = @"\images\voitures\" + fileName + extension;
                }
                if ((voiture.id_voiture == 0))
                {
                    _unitOfWork.Voiture.Add(voiture);
                }
                else
                {
                    _unitOfWork.Voiture.Update(voiture);
                }
                _unitOfWork.Save();
                TempData["success"] = "La voiture a été modifié avec succès.";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
