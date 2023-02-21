using SLAppsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLAppsDataAccess.Repository.IRepository
{
    public interface IReservationRepository : IRepository<Reservation>
    {
        void Update(Reservation obj);
    }
}
