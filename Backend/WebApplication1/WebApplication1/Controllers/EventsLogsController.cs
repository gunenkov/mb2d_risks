using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsLogsController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public EventsLogsController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: api/EventsLogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventsLog>>> GetEventsLogs()
        {
            return await _context.EventsLogs.ToListAsync();
        }

        // GET: api/EventsLogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventsLog>> GetEventsLog(int id)
        {
            var eventsLog = await _context.EventsLogs.FindAsync(id);

            if (eventsLog == null)
            {
                return NotFound();
            }

            return eventsLog;
        }

        // PUT: api/EventsLogs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventsLog(int id, EventsLog eventsLog)
        {
            if (id != eventsLog.Id)
            {
                return BadRequest();
            }

            _context.Entry(eventsLog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventsLogExists(id))
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

        // POST: api/EventsLogs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EventsLog>> PostEventsLog(EventsLog eventsLog)
        {
            _context.EventsLogs.Add(eventsLog);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEventsLog", new { id = eventsLog.Id }, eventsLog);
        }

        // DELETE: api/EventsLogs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEventsLog(int id)
        {
            var eventsLog = await _context.EventsLogs.FindAsync(id);
            if (eventsLog == null)
            {
                return NotFound();
            }

            _context.EventsLogs.Remove(eventsLog);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EventsLogExists(int id)
        {
            return _context.EventsLogs.Any(e => e.Id == id);
        }
    }
}
