using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLAppsModels
{
    public class Role
    {
        [BindProperty]
        [Key]
        public int id_role { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Le champ Nom Role est obligatoire")]
        public string nom_role { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime date_creation_role{ get; set; } = DateTime.Now;
    }
}
