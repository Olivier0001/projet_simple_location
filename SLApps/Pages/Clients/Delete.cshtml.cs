using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SLApps.DataAccess;
using SLAppsModels;

namespace SLApps.Pages.Clients
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public Client Client { get; set; }

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet(int id_client)
        {
            Client = _context.Clients.Find(id_client);
            //Client = _context.Clients.FirstOrDefault(u=>u.id_client==id_client);
        }

        public async Task<IActionResult> OnPost()
        {
            var clientFromContext = _context.Clients.Find(Client.id_client);
            if (clientFromContext != null)
            {
                _context.Clients.Remove(clientFromContext);
                await _context.SaveChangesAsync();
                TempData["success"] = "Le client a été supprimé avec succès.";
                return RedirectToPage("Index");
            }

            return Page();

        }
    }
}
