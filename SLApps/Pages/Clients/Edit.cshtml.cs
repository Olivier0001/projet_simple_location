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
        private readonly IWebHostEnvironment _webHostEnvironment;
        public Client Client { get; set; }
        public EditModel(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public void OnGet(int id_client)
        {
            Client = _unitOfWork.Client.GetFirstOrDefault(u => u.id_client == id_client);
        }
        public async Task<IActionResult> OnPost(Client client, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(wwwRootPath, @"images/clients");
                    var extension = Path.GetExtension(file.FileName);
                    if (client.image_client != null)
                    {
                        var oldImagePath = Path.Combine(wwwRootPath, client.image_client.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }
                    using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        file.CopyTo(fileStreams);
                    }
                    client.image_client = @"\images\clients\" + fileName + extension;
                }
                if ((client.id_client == 0))
                {
                    _unitOfWork.Client.Add(client);
                }
                else
                {
                    _unitOfWork.Client.Update(client);
                }
                _unitOfWork.Save();
                TempData["success"] = "Le client a été modifié avec succès.";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
