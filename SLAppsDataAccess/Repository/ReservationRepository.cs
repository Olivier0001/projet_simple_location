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
    
    
        public class ReservationRepository : Repository<Reservation>, IReservationRepository
        {
            private ApplicationDbContext _context;
            public ReservationRepository(ApplicationDbContext context) : base(context)
            {
                _context = context;
            }
            public void Save()
            {
                _context.SaveChanges();
            }
            public void Update(Reservation obj)
            {
                var objFromDb = _context.Reservations.FirstOrDefault(u => u.id_reservation == obj.id_reservation);
                if (objFromDb != null)
                {
                    objFromDb.id_client = obj.id_client;
                    objFromDb.id_voiture = obj.id_voiture;
                    objFromDb.date_de_debut = obj.date_de_debut;
                    objFromDb.date_de_fin = obj.date_de_fin;
                }
            }
        }
    
}
