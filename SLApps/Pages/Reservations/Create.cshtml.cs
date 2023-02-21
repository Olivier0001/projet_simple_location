using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using SLAppsDataAccess.Repository.IRepository;
using SLAppsModels;

namespace SLApps.Pages.Reservations
{
    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public Reservation Reservation { get; set; }
        public SelectList Clients { get; set; }
        public SelectList Voitures { get; set; }

        public CreateModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void OnGet()
        {
            this.Clients = new SelectList(clientList(), "id_client", "nom_client");
            this.Voitures = new SelectList(voitureList(), "id_voiture", "modele_voiture");
        }

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

        private static List<Voiture> voitureList()
        {
            string constr = @"Data Source=DELL-222;Initial Catalog=projetbdd;Integrated Security=True";
            List<Voiture> voitures = new List<Voiture>();
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "SELECT modele_voiture, id_voiture FROM voitures";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            voitures.Add(new Voiture
                            {
                                modele_voiture = sdr["modele_voiture"].ToString(),
                                id_voiture = Convert.ToInt32(sdr["id_voiture"])
                            });
                        }
                    }
                    con.Close();
                }
            }

            return voitures;


        }

        

        public async Task<IActionResult> OnPost(Reservation reservation)
        {


            if (ModelState.IsValid)
            {
                

                _unitOfWork.Reservation.Add(reservation);
                _unitOfWork.Save();
                TempData["success"] = "La reservation a été créé avec succès.";
                return RedirectToPage("Index");
            }



            return Page();

        }
    }
}
