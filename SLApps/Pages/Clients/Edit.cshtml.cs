using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SLApps.DataAccess;
using SLAppsModels;

namespace SLApps.Pages.Clients
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public Client Client { get; set; }

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet(int id_client)
        {
            Client = _context.Clients.Find(id_client);
            //Client = _context.Clients.FirstOrDefault(u=>u.id_client==id_client);
        }

        public async Task<IActionResult> OnPost(Client client)
        {
            //if (Client.nom_client == Client.prenom_client)
            //{
            //    ModelState.AddModelError(string.Empty, "Le prénom ne peut pas correspondre exactement au nom");
            //}

            if (ModelState.IsValid)
            {
                _context.Clients.Update(client);
                await _context.SaveChangesAsync();
                TempData["success"] = "Le client a été modifié avec succès.";
                return RedirectToPage("Index");
            }
            return Page();

        }
    }
}
