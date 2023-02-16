using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using SLAppsDataAccess.Repository.IRepository;
using SLAppsModels;

namespace SLApps.Pages.Roles
{
    public class EditModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public Role Role { get; set; }
        public EditModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void OnGet(int id_role)
        {
            Role = _unitOfWork.Role.GetFirstOrDefault(u => u.id_role == id_role);
        }
        public async Task<IActionResult> OnPost(Role role)
        {
            if (ModelState.IsValid)
            {               
                _unitOfWork.Role.Update(role);
                _unitOfWork.Save();
                TempData["success"] = "Le role a été modifié avec succès.";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
