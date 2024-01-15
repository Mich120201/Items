using ItemBlazor.Data;
using ItemBlazor.Models;
using Microsoft.AspNetCore.Mvc;

namespace ItemBlazor.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeSeriesController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public TimeSeriesController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddTimeSeries(TimeSeries timeSeries)
        {
            _appDbContext.TimeSeries.Add(timeSeries);
            await _appDbContext.SaveChangesAsync();

            return Ok(timeSeries);
        }

        [HttpGet]
        public IActionResult GetTimeSeries()
        {
            var timeSeries = _appDbContext.TimeSeries.ToList();
            return Ok(timeSeries);
        }

        [HttpGet("{id}")]
        public IActionResult GetTimeSeries(Guid id)
        {
            var timeSeries = _appDbContext.TimeSeries.Find(id);
            if (timeSeries == null)
            {
                return NotFound();
            }
            return Ok(timeSeries);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTimeSeries(Guid id, TimeSeries updatedItem)
        {
            var existingItem = _appDbContext.TimeSeries.Find(id);
            if (existingItem == null)
            {
                return NotFound();
            }

            existingItem.Value = updatedItem.Value;
            existingItem.Type = updatedItem.Type;

            _appDbContext.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTimeSeries(Guid id)
        {
            var timeSeries = _appDbContext.TimeSeries.Find(id);
            if (timeSeries == null)
            {
                return NotFound();
            }

            _appDbContext.TimeSeries.Remove(timeSeries);
            _appDbContext.SaveChanges();

            return NoContent();
        }
    }
}
