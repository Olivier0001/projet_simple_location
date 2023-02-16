
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SLAppsModels
{
    public class Client
    {
        [BindProperty]
        [Key]
        public int id_client { get; set; }
        public int id_role { get; set; } = 1;

        [BindProperty]
        [Required(ErrorMessage = "Le champ Nom Client est obligatoire")]
        public string? nom_client { get; set; }

        [Required(ErrorMessage = "Le champ Prenom Client est obligatoire")]
        public string prenom_client { get; set; }

        [Required(ErrorMessage = "Le champ Age Client est obligatoire")]
        public string age_client { get; set; }

        [Required(ErrorMessage = "Le champ Numero Telephone Client est obligatoire")]
        public string numero_telephone_client { get; set; }

        [Required(ErrorMessage = "Le champ Email Client est obligatoire")]
        public string email_client { get; set; }

        [Required(ErrorMessage = "Le champ Adresse Client est obligatoire")]
        public string adresse_client { get; set; }

        [Required(ErrorMessage = "Le champ Code Postal Client est obligatoire")]
        public string code_postal_client { get; set; }

        [Required(ErrorMessage = "Le champ Ville Client est obligatoire")]
        public string ville_client { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime date_creation_client { get; set; } = DateTime.Now;
    }
}