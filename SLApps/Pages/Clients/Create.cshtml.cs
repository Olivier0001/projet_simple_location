using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SLApps.DataAccess;
using SLAppsModels;

namespace SLApps.Pages.Clients
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public Client Client { get; set; }
        public CreateModel(ApplicationDbContext context)
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
                await _context.Clients.AddAsync(client);
                await _context.SaveChangesAsync();
                TempData["success"] = "Le client a été créé avec succès.";
                return RedirectToPage("Index");
            }
            return Page();

        }
    }
}
