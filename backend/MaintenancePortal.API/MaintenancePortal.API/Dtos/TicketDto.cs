using System;

namespace MaintenancePortal.API.Dtos
{
    public class TicketDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public string Priority { get; set; }
        public DateTime CreatedAt { get; set; }
        public AssetDto Asset { get; set; }
        public UserDto ReportedByUser { get; set; }
    }

    public class AssetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
    }
}
