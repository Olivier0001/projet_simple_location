using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLAppsModels
{
    public class Voiture
    {
        [Key]
        public int id_voiture { get; set; }

        [Required(ErrorMessage = "Le champ Marque Voiture est obligatoire")]
        public string marque_voiture { get; set; }

        [Required(ErrorMessage = "Le champ Modele Voiture est obligatoire")]
        public string modele_voiture { get; set; }

        [Required(ErrorMessage = "Le champ Couleur Voiture est obligatoire")]
        public string couleur_voiture { get; set; }

        [Required(ErrorMessage = "Le champ Immatriculation Voiture est obligatoire")]
        public string immatriculation_voiture { get; set; }

        [Required(ErrorMessage = "Le champ Annee Voiture est obligatoire")]
        public int annee_voiture { get; set; }

        [ValidateNever]
        [Required(ErrorMessage = "Le champ Image Voiture est obligatoire")]
        public string? image_voiture { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime date_creation_voiture { get; set; } = DateTime.Now;
    }
}
