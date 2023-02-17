
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using SLAppsDataAccess.Repository.IRepository;
using SLAppsModels;
using System.Drawing;

namespace SLApps.Pages.Voitures
{
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public Voiture Voiture { get; set; }
        public DeleteModel(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public void OnGet(int id_voiture)
        {
            Voiture = _unitOfWork.Voiture.GetFirstOrDefault(u => u.id_voiture == id_voiture);
        }
        public async Task<IActionResult> OnPost(int? id_voiture, Voiture voiture, IFormFile file)
        {
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            string Path = wwwRootPath + voiture.image_voiture;
            var voitureFromContext = _unitOfWork.Voiture.GetFirstOrDefault(u => u.id_voiture == id_voiture);
            if (voitureFromContext != null)
            {
                FileInfo fileInfo = new FileInfo(Path);
                if(fileInfo.Exists)
                {
                    fileInfo.Delete();
                }
                _unitOfWork.Voiture.Remove(voitureFromContext);
                _unitOfWork.Save();
                TempData["success"] = "La Voiture a été supprimé avec succès.";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
