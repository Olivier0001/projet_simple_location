using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SLApps.DataAccess;
using SLAppsDataAccess.Repository.IRepository;
using SLAppsModels;

namespace SLApps.Pages.Clients
{
    public class EditModel : PageModel
    {
        private readonly IClientRepository _context;

        public Client Client { get; set; }

        public EditModel(IClientRepository context)
        {
            _context = context;
        }

        public void OnGet(int id_client)
        {
            //Client = _context.Clients.Find(id_client);
            Client = _context.GetFirstOrDefault(u => u.id_client == id_client);
        }

        public async Task<IActionResult> OnPost(Client client)
        {
            //if (Client.nom_client == Client.prenom_client)
            //{
            //    ModelState.AddModelError(string.Empty, "Le prénom ne peut pas correspondre exactement au nom");
            //}

            if (ModelState.IsValid)
            {
                _context.Update(client);
                _context.Save();
                TempData["success"] = "Le client a été modifié avec succès.";
                return RedirectToPage("Index");
            }
            return Page();

        }
    }
}
