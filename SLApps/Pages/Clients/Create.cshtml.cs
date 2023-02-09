using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SLApps.DataAccess;
using SLAppsDataAccess.Repository.IRepository;
using SLAppsModels;

namespace SLApps.Pages.Clients
{
    public class CreateModel : PageModel
    {
        private readonly IClientRepository _context;

        public Client Client { get; set; }
        public CreateModel(IClientRepository context)
        {
            _context = context;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(Client client)
        {
            //if (Client.nom_client == Client.prenom_client)
            //{
            //    ModelState.AddModelError(string.Empty, "Le prénom ne peut pas correspondre exactement au nom");
            //}

            if (ModelState.IsValid)
            {
                _context.Add(client);
                _context.Save();
                TempData["success"] = "Le client a été créé avec succès.";
                return RedirectToPage("Index");
            }
            return Page();

        }
    }
}
