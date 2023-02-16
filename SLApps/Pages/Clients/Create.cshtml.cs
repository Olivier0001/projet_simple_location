using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SLApps.DataAccess;
using SLAppsDataAccess.Repository.IRepository;
using SLAppsModels;

namespace SLApps.Pages.Clients
{
    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public Client Client { get; set; }
        public CreateModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost(Client client)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Client.Add(client);
                _unitOfWork.Save();
                TempData["success"] = "Le client a été créé avec succès.";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
