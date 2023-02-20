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
        private readonly IWebHostEnvironment _webHostEnvironment;
        public Client Client { get; set; }
        public DeleteModel(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public void OnGet(int id_client)
        {
            Client = _unitOfWork.Client.GetFirstOrDefault(u => u.id_client == id_client);
        }
        public async Task<IActionResult> OnPost(int? id_client, Client client, IFormFile file)
        {
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            string Path = wwwRootPath + client.image_client;
            var clientFromContext = _unitOfWork.Client.GetFirstOrDefault(u => u.id_client == id_client);
            if (clientFromContext != null)
            {
                FileInfo fileInfo = new FileInfo(Path);
                if (fileInfo.Exists)
                {
                    fileInfo.Delete();
                }
                _unitOfWork.Client.Remove(clientFromContext);
                _unitOfWork.Save();
                TempData["success"] = "Le client a été supprimé avec succès.";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
