using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AgendaWebAPI.Context;
using AgendaWebAPI.Model;

namespace AgendaWebAPI.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class AgendaController : ControllerBase
    {
        private readonly Database _context;

        public AgendaController(Database context)
        {
            _context = context;
        }
        
        [HttpGet(Name = "GetAgenda")]
        public async Task<ActionResult<Agenda>> GetAgenda([FromQuery] int id)
        {
            var agenda = await _context.Agendas.FindAsync(id);

            if (agenda == null)
            {
                return NotFound();
            }

            return agenda;
        }
        
        [HttpPost]
        public async Task<ActionResult<Agenda>> CreateAgenda([FromBody] Agenda agenda)
        {
            _context.Agendas.Add(agenda);
            await _context.SaveChangesAsync();

            return CreatedAtRoute("GetAgenda", new { id = agenda.IdAgenda }, agenda);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAgenda([FromQuery] int id, [FromBody] Agenda agenda)
        {
            if (id != agenda.IdAgenda)
            {
                return BadRequest();
            }

            _context.Entry(agenda).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgendaExists(id))
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

     
        [HttpDelete]
        public async Task<IActionResult> DeleteAgenda([FromQuery] int id)
        {
            var agenda = await _context.Agendas.FindAsync(id);

            if (agenda == null)
            {
                return NotFound();
            }

            _context.Agendas.Remove(agenda);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AgendaExists(int id)
        {
            return _context.Agendas.Any(e => e.IdAgenda == id);
        }
    }
}