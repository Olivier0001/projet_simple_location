using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SLApps.DataAccess;
using SLAppsDataAccess.Repository.IRepository;
using SLAppsModels;
using System.Net.Sockets;

namespace SLApps.Pages.Clients
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public Client Client { get; set; }
        public DeleteModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void OnGet(int id_client)
        {
            Client = _unitOfWork.Client.GetFirstOrDefault(u => u.id_client == id_client);
        }
        public async Task<IActionResult> OnPost(int? id_client)
        {
            var clientFromContext = _unitOfWork.Client.GetFirstOrDefault(u => u.id_client == id_client);
            if (clientFromContext != null)
            {
                _unitOfWork.Client.Remove(clientFromContext);
                _unitOfWork.Save();
                TempData["success"] = "Le client a été supprimé avec succès.";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
