using HAHN.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HAHN.Infrastructure.Data
{
    public class HahnDbContext : DbContext
    {
        public HahnDbContext(DbContextOptions<HahnDbContext> options) : base(options) { }

        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Ticket>(entity =>
            {
                // Start Id from 1000
                entity
                    .Property(t => t.TicketId)
                    .UseIdentityColumn(1000, 1);

                // Initial seed
                entity.HasData(
                    new() { TicketId = 1002, Description = "Promotion code issued", Status = TicketStatus.Open, Date = new DateTime(2022, 5, 29) },
                    new() { TicketId = 1003, Description = "Additional user account", Status = TicketStatus.Open, Date = new DateTime(2022, 5, 27) },
                    new() { TicketId = 1004, Description = "Change payment method", Status = TicketStatus.Open, Date = new DateTime(2022, 5, 28) },
                    new() { TicketId = 1005, Description = "Activate account", Status = TicketStatus.Closed, Date = new DateTime(2022, 5, 28) },
                    new() { TicketId = 1007, Description = "Great job", Status = TicketStatus.Closed, Date = new DateTime(2022, 5, 29) },
                    new() { TicketId = 1008, Description = "Another Great Job", Status = TicketStatus.Closed, Date = new DateTime(2022, 5, 29) },
                    new() { TicketId = 1000, Description = "Help with Login", Status = TicketStatus.Closed, Date = new DateTime(2022, 5, 28) },
                    new() { TicketId = 1024, Description = "Happy Customer", Status = TicketStatus.Open, Date = new DateTime(2022, 5, 29) }
                );
            });
        }
    }
}
