using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SLAppsDataAccess.Repository.IRepository;
using SLAppsModels;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

namespace SLApps.Pages.Reservations
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public IEnumerable<Reservation> Reservations { get; set; }
        public IEnumerable<Client> Clients { get; set; }
        public IEnumerable<Voiture> Voitures { get; set; }

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void OnGet()
        {
            Clients = _unitOfWork.Client.GetAll();
            Voitures = _unitOfWork.Voiture.GetAll();
            Reservations = _unitOfWork.Reservation.GetAll();
        }



    }   
}
