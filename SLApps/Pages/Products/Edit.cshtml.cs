using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using SLAppsDataAccess.Repository.IRepository;
using SLAppsModels;
using System.Net.Sockets;

namespace SLApps.Pages.Products
{
    public class EditModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public Product Product { get; set; }
        public SelectList Clients { get; set; }

        public EditModel(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }



        public void OnGet(int Id)
        {
            Product = _unitOfWork.Product.GetFirstOrDefault(u => u.Id == Id);
            this.Clients = new SelectList(clientList(), "id_client", "nom_client");

            
        }

        //public void OnPostSubmit(Client client)
        //{
        //    string message = "Nom Client: " + client.nom_client;
        //    message += "\\nId Client: " + client.id_client;
        //    ViewData["Message"] = message;
        //}

        private static List<Client> clientList()
        {
            string constr = @"Data Source=DELL-222;Initial Catalog=projetbdd;Integrated Security=True";
            List<Client> clients = new List<Client>();
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "SELECT nom_client, id_client FROM clients";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            clients.Add(new Client
                            {
                                nom_client = sdr["nom_client"].ToString(),
                                id_client = Convert.ToInt32(sdr["id_client"])
                            });
                        }
                    }
                    con.Close();
                }
            }

            return clients;


        }

        public async Task<IActionResult> OnPost(Product product, IFormFile file)
        {


            if (ModelState.IsValid)
            {

                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(wwwRootPath, @"images/products");
                    var extension = Path.GetExtension(file.FileName);

                    if (product.ImageUrl != null)
                    {
                        var oldImagePath = Path.Combine(wwwRootPath, product.ImageUrl.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        file.CopyTo(fileStreams);
                    }

                    product.ImageUrl = @"\images\products\" + fileName + extension;

                }

                if ((product.Id == 0)) 
                {
                    _unitOfWork.Product.Add(product);
                }

                else
                {
                    _unitOfWork.Product.Update(product);
                }

                _unitOfWork.Save();
                TempData["success"] = "Le product a été modifié avec succès.";
                return RedirectToPage("Index");
            }



            return Page();

        }
    }
}
