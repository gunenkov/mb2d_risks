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
    public class IncidentsController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public IncidentsController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: api/Incidents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Incident>>> GetIncidents()
        {
            return await _context.Incidents.ToListAsync();
        }

        // GET: api/Incidents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Incident>> GetIncident(int id)
        {
            var incident = await _context.Incidents.FindAsync(id);

            if (incident == null)
            {
                return NotFound();
            }

            return incident;
        }

        // PUT: api/Incidents/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIncident(int id, Incident incident)
        {
            if (id != incident.Id)
            {
                return BadRequest();
            }

            _context.Entry(incident).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IncidentExists(id))
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

        public class IncidentDto
        {
            public string IncidentName {  get; set; }
            public string RiskName {  get; set; }
        }


        // POST: api/Incidents
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Incident>> PostIncident(IncidentDto incidentDto)
        {
            var risk = _context.Risks.FirstOrDefault(r=>r.Name == incidentDto.RiskName);

            if (risk == null)
            {
                return NotFound("Риск не найден!");
            }

            var incident = new Incident
            {
                Name = incidentDto.IncidentName,
                RiskId = risk.Id,
                DateTime = DateTime.Now.ToLocalTime(),
                Result = IncidentResult.Undefined
            };

            _context.Incidents.Add(incident);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIncident", new { id = incident.Id }, incident);
        }

        // DELETE: api/Incidents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIncident(int id)
        {
            var incident = await _context.Incidents.FindAsync(id);
            if (incident == null)
            {
                return NotFound();
            }

            _context.Incidents.Remove(incident);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IncidentExists(int id)
        {
            return _context.Incidents.Any(e => e.Id == id);
        }

        [HttpGet("info")]
        public async Task<IActionResult> Info()
        {
            var incidents  = _context.Incidents.ToList();
            foreach (var incident in incidents)
            {
                var risk = _context.Risks.Include(r=>r.Events).FirstOrDefault(r => r.Id == incident.RiskId);
                var events = _context.Events.ToList();
                incident.Events = risk.Events;

                foreach (var @event in events)
                {
                    var log = new EventsLog
                    {
                        EventId = @event.Id,
                        Start = DateTime.Now.ToLocalTime(),
                        Finish = DateTime.Now.ToLocalTime().AddSeconds(@event.DurationInSeconds),
                        RiskId = risk.Id,
                        Status = EventLogStatus.Active
                    };
                    _context.EventsLogs.Add(log);
                    await _context.SaveChangesAsync();
                    @event.EventsLog = log;
                }

                if (incident.Result != IncidentResult.Undefined)
                {
                    continue;
                }
                
                var prod = risk.Prob * risk.Damage;

                // нет мероприятий
                if (risk.Events.Count == 0)
                {
                    incident.Result = IncidentResult.Accepted;
                }

                else
                {
                    // сумма значимостей всех инцидентов
                    var valuesSum = incident.Events.Sum(i=>i.Value);

                    if (valuesSum > prod)
                    {
                        incident.Result = IncidentResult.Escaped;
                    }

                    else
                    {
                        incident.Result = IncidentResult.Minimized;
                    }
                }
               
            }

            return Ok(incidents);
        }
    }
}
