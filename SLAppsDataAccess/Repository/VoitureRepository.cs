using SLApps.DataAccess;
using SLAppsDataAccess.Repository.IRepository;
using SLAppsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLAppsDataAccess.Repository
{
    public class VoitureRepository : Repository<Voiture>, IVoitureRepository
    {
        private ApplicationDbContext _context;
        public VoitureRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        public void Update(Voiture obj)
        {
            var objFromDb = _context.Voitures.FirstOrDefault(u => u.id_voiture == obj.id_voiture);
            if (objFromDb != null)
            {
                objFromDb.marque_voiture = obj.marque_voiture;
                objFromDb.modele_voiture = obj.modele_voiture;
                objFromDb.couleur_voiture = obj.couleur_voiture;
                objFromDb.immatriculation_voiture = obj.immatriculation_voiture;
                objFromDb.annee_voiture = obj.annee_voiture;
                if (objFromDb.image_voiture != null)
                {
                    objFromDb.image_voiture = obj.image_voiture;
                }
            }
        }
    }
}
