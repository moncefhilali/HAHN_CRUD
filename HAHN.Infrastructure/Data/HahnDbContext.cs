using HAHN.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HAHN.Infrastructure.Data
{
    public class HahnDbContext : DbContext
    {
        public HahnDbContext(DbContextOptions<HahnDbContext> options) : base(options) { }

        public DbSet<Ticket> Tickets { get; set; }
    }
}
