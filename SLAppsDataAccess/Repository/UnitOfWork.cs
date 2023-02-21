using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
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
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context) 
        {
            _context = context;
            Client = new ClientRepository(_context);
            Product = new ProductRepository(_context);
            Role = new RoleRepository(_context);
            Voiture = new VoitureRepository(_context);
            Reservation = new ReservationRepository(_context);
        }
        public IClientRepository Client { get; private set; }
        public IProductRepository Product { get; private set; }
        public IRoleRepository Role { get; private set; }
        public IVoitureRepository Voiture { get; private set; }
        public IReservationRepository Reservation { get; private set; }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
