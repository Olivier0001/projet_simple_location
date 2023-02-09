using Microsoft.EntityFrameworkCore;
using SLApps.Model;

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
