using MaintenancePortal.API.Models;
using Microsoft.EntityFrameworkCore;

namespace MaintenancePortal.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Asset> Assets { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        // THIS IS THE NEW METHOD WITH THE INSTRUCTIONS
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Instruction 1: The 'Reported By' relationship
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.ReportedByUser)
                .WithMany(u => u.ReportedTickets)
                .HasForeignKey(t => t.ReportedByUserId)
                .OnDelete(DeleteBehavior.Restrict); // Prevents deleting a user if they have tickets

            // Instruction 2: The 'Assigned To' relationship
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.AssignedToUser)
                .WithMany(u => u.AssignedTickets)
                .HasForeignKey(t => t.AssignedToUserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

