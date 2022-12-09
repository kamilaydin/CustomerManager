using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CustomerAPI;
using CustomerAPI.Contexts;
using CustomerAPI.Entity;

namespace CustomerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdressesController : ControllerBase
    {
        private readonly CustomerManageDbContext _context;

        public AdressesController(CustomerManageDbContext context)
        {
            _context = context;
        }

        // GET: api/Adresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Address>>> GetAdresses()
        {
            return await _context.Addresses.ToListAsync();
        }

        // GET: api/Adresses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Address>> GetAdress(int id)
        {
            var adress = await _context.Addresses.FindAsync(id);

            if (adress == null)
            {
                return NotFound();
            }

            return adress;
        }

        // PUT: api/Adresses/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdress(int id, Address adress)
        {
            if (id != adress.Id)
            {
                return BadRequest();
            }

            _context.Entry(adress).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdressExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Adresses
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Address>> PostAdress(Address adress)
        {
            _context.Addresses.Add(adress);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AdressExists(adress.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAdress", new { id = adress.Id }, adress);
        }

        // DELETE: api/Adresses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Address>> DeleteAdress(int id)
        {
            var adress = await _context.Addresses.FindAsync(id);
            if (adress == null)
            {
                return NotFound();
            }

            _context.Addresses.Remove(adress);
            await _context.SaveChangesAsync();

            return adress;
        }

        private bool AdressExists(int id)
        {
            return _context.Addresses.Any(e => e.Id == id);
        }
    }
}
