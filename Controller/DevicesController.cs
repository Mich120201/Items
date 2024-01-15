using ItemBlazor.Data;
using ItemBlazor.Models;
using Microsoft.AspNetCore.Mvc;

namespace ItemBlazor.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevicesController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public DevicesController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddDevice(Devices device)
        {
            _appDbContext.Devices.Add(device);
            await _appDbContext.SaveChangesAsync();

            return Ok(device);
        }

        [HttpGet]
        public IActionResult GetDevices()
        {
            var device = _appDbContext.Devices.ToList();
            return Ok(device);
        }

        [HttpGet("{id}")]
        public IActionResult GetDevices(Guid id)
        {
            var device = _appDbContext.Devices.Find(id);
            if (device == null)
            {
                return NotFound();
            }
            return Ok(device);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDevices(Guid id, Devices updatedItem)
        {
            var existingItem = _appDbContext.Devices.Find(id);
            if (existingItem == null)
            {
                return NotFound();
            }

            existingItem.Name = updatedItem.Name;
            existingItem.Type = updatedItem.Type;

            _appDbContext.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDevices(Guid id)
        {
            var device = _appDbContext.Devices.Find(id);
            if (device == null)
            {
                return NotFound();
            }

            _appDbContext.Devices.Remove(device);
            _appDbContext.SaveChanges();

            return NoContent();
        }
    }
}
