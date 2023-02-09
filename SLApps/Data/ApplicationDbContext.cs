using Microsoft.EntityFrameworkCore;
using SLApps.Model;
using System.Collections.Generic;

namespace SLApps.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
    }
}
