using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SLApps.DataAccess;
using SLAppsDataAccess.Repository.IRepository;
using SLAppsModels;
using System.Text.Json.Nodes;

namespace SLApps.Pages.Products
{
    public class IndexModel : PageModel
    {
        

        private readonly IUnitOfWork _unitOfWork;

        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Client> Clients { get; set; }

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void OnGet()
        {
            Products = _unitOfWork.Product.GetAll();
            Clients = _unitOfWork.Client.GetAll();
        }

        


    }

}
