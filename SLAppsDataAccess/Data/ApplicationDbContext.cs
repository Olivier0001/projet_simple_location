using Microsoft.EntityFrameworkCore;
using SLAppsModels;
using System.Collections.Generic;

namespace SLApps.DataAccess;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Client> Clients { get; set; }
    
}
