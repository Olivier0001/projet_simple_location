using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace SLAppsModels
{
    public class Reservation
    {
        [Key]
        public int id_reservation { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Le champ Client est obligatoire")]
        public int id_client { get; set; }
        [ForeignKey("id_client")]

        [BindProperty]
        [ValidateNever]
        public Client Client { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Le champ Voiture est obligatoire")]
        public int id_voiture { get; set; }
        [ForeignKey("id_voiture")]

        [BindProperty]
        [ValidateNever]
        public Voiture Voiture { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Le champ Date de Début est obligatoire")] 
        public DateTime? date_de_debut { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Le champ Date de Fin est obligatoire")]
        public DateTime? date_de_fin { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime date_creation_reservation { get; set; } = DateTime.Now;
    }
}
