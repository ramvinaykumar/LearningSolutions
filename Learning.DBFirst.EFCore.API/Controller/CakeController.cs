using Learning.DBFirst.EFCore.API.Data;
using Learning.DBFirst.EFCore.API.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Learning.DBFirst.EFCore.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CakeController : ControllerBase
    {
        private readonly MyDbContext _context;

        public CakeController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var cakes = await _context.Cake.ToListAsync();
            return Ok(cakes);
        }

        [HttpGet]
        [Route("get-cake-by-id")]
        public async Task<IActionResult> GetCakeByIdAsync(int id)
        {
            var cake = await _context.Cake.FindAsync(id);
            return Ok(cake);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Cake cake)
        {
            _context.Cake.Add(cake);
            await _context.SaveChangesAsync();
            return Created($"get-cake-by-id?id={cake.Id}", cake);
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(Cake cakeToUpdate)
        {
            _context.Cake.Update(cakeToUpdate);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var cakeToDelete = await _context.Cake.FindAsync(id);
            if (cakeToDelete == null)
            {
                return NotFound();
            }
            _context.Cake.Remove(cakeToDelete);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
