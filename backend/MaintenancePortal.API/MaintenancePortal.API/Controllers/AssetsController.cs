using MaintenancePortal.API.Data;
using MaintenancePortal.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MaintenancePortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetsController : ControllerBase
    {
        private readonly DataContext _context;

        public AssetsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Asset>>> GetAssets()
        {
            var assets = await _context.Assets.ToListAsync();
            return Ok(assets);
        }

        [HttpPost]
        public async Task<ActionResult<Asset>> CreateAsset(Asset asset)
        {
            _context.Assets.Add(asset);
            await _context.SaveChangesAsync();

            return Ok(asset);
        }
    }
}
