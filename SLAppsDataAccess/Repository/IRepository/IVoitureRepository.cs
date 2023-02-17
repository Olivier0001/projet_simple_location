using SLAppsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLAppsDataAccess.Repository.IRepository
{
    public interface IVoitureRepository : IRepository<Voiture>
    {
        void Update(Voiture obj);
    }
}
