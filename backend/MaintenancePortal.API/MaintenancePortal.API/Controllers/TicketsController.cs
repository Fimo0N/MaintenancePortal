using MaintenancePortal.API.Data;
using MaintenancePortal.API.Dtos;
using MaintenancePortal.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace MaintenancePortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly DataContext _context;

        public TicketsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetTickets()
        {
            var tickets = await _context.Tickets
                .Include(t => t.Asset)
                .Include(t => t.ReportedByUser)
                .Select(t => new TicketDto // This is the mapping part
                {
                    Id = t.Id,
                    Title = t.Title,
                    Status = t.Status,
                    Priority = t.Priority,
                    CreatedAt = t.CreatedAt,
                    Asset = new AssetDto { Id = t.Asset.Id, Name = t.Asset.Name },
                    ReportedByUser = new UserDto { Id = t.ReportedByUser.Id, Username = t.ReportedByUser.Username }
                })
                .ToListAsync();

            return Ok(tickets);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTicket(TicketForCreateDto ticketForCreateDto)
        {
            var ticket = new Ticket
            {
                Title = ticketForCreateDto.Title,
                Description = ticketForCreateDto.Description,
                Priority = ticketForCreateDto.Priority,
                AssetId = ticketForCreateDto.AssetId,
                ReportedByUserId = ticketForCreateDto.ReportedByUserId,
                Status = "Open",
                CreatedAt = System.DateTime.Now
            };

            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();

            return StatusCode(201);
        }
    }
}

