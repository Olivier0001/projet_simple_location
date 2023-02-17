using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLAppsModels
{
    public class Images_Voiture
    {
        public int id_image_voiture { get; set; }
        public string nom_image_voiture { get; set; }
        public DateTime date_creation_image_voiture { get; set; } = DateTime.Now;
    }
}
