using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using SLAppsDataAccess.Repository.IRepository;
using SLAppsModels;

namespace SLApps.Pages.Roles
{
    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public Role Role { get; set; }
        public CreateModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost(Role role)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Role.Add(role);
                _unitOfWork.Save();
                TempData["success"] = "Le role a été créé avec succès.";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
