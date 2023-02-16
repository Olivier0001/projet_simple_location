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
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        private ApplicationDbContext _context;
        public RoleRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        public void Update(Role obj)
        {
            var objFromDb = _context.Roles.FirstOrDefault(u => u.id_role == obj.id_role);
            if (objFromDb != null)
            {
                objFromDb.nom_role = obj.nom_role;
            }
        }
    }
}
