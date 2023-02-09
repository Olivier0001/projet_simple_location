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
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        private ApplicationDbContext _context;

        public ClientRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Client obj)
        {
            _context.Clients.Update(obj);
        }
    }
}
