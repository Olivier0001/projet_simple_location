using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SLAppsDataAccess.Repository.IRepository;
using SLAppsModels;

namespace SLApps.Pages.Voitures
{
    public class DetailsModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public IEnumerable<Voiture> Voitures { get; set; }
        public Voiture Voiture  { get; set; }
        public DetailsModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void OnGet(int id_voiture)
        {
            Voiture = _unitOfWork.Voiture.GetFirstOrDefault(u => u.id_voiture == id_voiture);

        }
    }
}
