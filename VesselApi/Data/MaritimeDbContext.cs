using Microsoft.EntityFrameworkCore;
using VesselApi.Models;

namespace VesselApi.Data;

public class MaritimeDbContext : DbContext
{
    public MaritimeDbContext(DbContextOptions<MaritimeDbContext> options) : base(options)
    {
        
    }

    public DbSet<Vessel> Vessels { get; set; }
}