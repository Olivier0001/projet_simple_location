using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SLApps.DataAccess;
using SLAppsDataAccess.Repository.IRepository;
using SLAppsModels;

namespace SLApps.Pages.Clients
{
    public class EditModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public Client Client { get; set; }
        public EditModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void OnGet(int id_client)
        {
            Client = _unitOfWork.Client.GetFirstOrDefault(u => u.id_client == id_client);
        }
        public async Task<IActionResult> OnPost(Client client)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Client.Update(client);
                _unitOfWork.Save();
                TempData["success"] = "Le client a été modifié avec succès.";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
