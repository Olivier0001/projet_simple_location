using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SLAppsDataAccess.Repository.IRepository;
using SLAppsModels;

namespace SLApps.Pages.Voitures
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public IEnumerable<Voiture> Voitures { get; set; }
        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void OnGet()
        {
            Voitures = _unitOfWork.Voiture.GetAll();
        }
    }
}
