namespace MaintenancePortal.API.Dtos
{
    public class TicketForCreateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; }
        public int AssetId { get; set; }
        public int ReportedByUserId { get; set; }
    }
}

