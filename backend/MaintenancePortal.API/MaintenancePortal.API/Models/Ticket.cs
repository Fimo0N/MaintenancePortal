using System.ComponentModel.DataAnnotations;

namespace MaintenancePortal.API.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public string Priority { get; set; } // "Low", "Medium", "High", "Critical"

        public string Status { get; set; } // "Open", "Assigned", "In Progress", "Resolved"

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Foreign Keys - These create the relationships between tables
        public int AssetId { get; set; }
        public Asset Asset { get; set; }

        public int ReportedByUserId { get; set; }
        public User ReportedByUser { get; set; }

        public int? AssignedToUserId { get; set; } // Nullable: a ticket might not be assigned yet
        public User AssignedToUser { get; set; }
    }
}
