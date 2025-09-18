using System.Collections.Generic;

namespace MaintenancePortal.API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; } // Changed from string to byte[]
        public byte[] PasswordSalt { get; set; } // Added this property
        public string Role { get; set; }

        public ICollection<Ticket> ReportedTickets { get; set; }
        public ICollection<Ticket> AssignedTickets { get; set; }
    }
}

