using ItemBlazor.Data;
using ItemBlazor.Models;
using Microsoft.AspNetCore.Mvc;

namespace ItemBlazor.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        public ItemsController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddItems(Items item)
        {
            ModelState.Clear();
            _appDbContext.Item.Add(item);
            await _appDbContext.SaveChangesAsync();

            return Ok(item);
        }

        [HttpGet]
        public IActionResult GetItems()
        {
            var items = _appDbContext.Item.ToList();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public IActionResult GetItem(Guid id)
        {
            var item = _appDbContext.Item.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateItem(Guid id, Items updatedItem)
        {
            var existingItem = _appDbContext.Item.Find(id);
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
        public IActionResult DeleteItem(Guid id)
        {
            var item = _appDbContext.Item.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            _appDbContext.Item.Remove(item);
            _appDbContext.SaveChanges();

            return NoContent();
        }
    }
}
