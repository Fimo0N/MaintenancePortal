using System.ComponentModel.DataAnnotations;

namespace MaintenancePortal.API.Models
{
    public class Asset
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Location { get; set; }

        public string Status { get; set; } // e.g., "Operational", "Under Maintenance"
    }
}
