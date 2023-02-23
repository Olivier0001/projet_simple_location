
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
    public DbSet<Role> Roles { get; set; }
    public DbSet<Voiture> Voitures { get; set; }
    public DbSet<Reservation> Reservations { get; set; }

}
