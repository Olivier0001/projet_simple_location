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
        private readonly IClientRepository _context;

        public Client Client { get; set; }

        public DeleteModel(IClientRepository context)
        {
            _context = context;
        }

        public void OnGet(int id_client)
        {
            //Client = _context.Clients.Find(id_client);
            Client = _context.GetFirstOrDefault(u => u.id_client == id_client);
        }

        public async Task<IActionResult> OnPost(int? id_client)
        {
            var clientFromContext = _context.GetFirstOrDefault(u => u.id_client == id_client);
            if (clientFromContext != null)
            {
                _context.Remove(clientFromContext);
                _context.Save();
                TempData["success"] = "Le client a été supprimé avec succès.";
                return RedirectToPage("Index");
            }

            return Page();

        }
    }
}
