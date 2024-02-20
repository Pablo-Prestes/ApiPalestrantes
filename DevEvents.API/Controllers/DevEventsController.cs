using DevEvents.API.Data;
using DevEvents.API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevEvents.API.Controllers
{
    [Route("api/dev-events")]
    [ApiController]
    public class DevEventsController : ControllerBase
    {
        private readonly DevEventsDbContext _context;

        public DevEventsController(DevEventsDbContext context) 
        {
            _context = context;
        }

        //GET: api/dev-events 
        [HttpGet]
        public IActionResult GetAll()
        {
            var devEvent = _context.DevEvents.Where(x => !x.Deletado).ToList();
            return Ok(devEvent);
        }

        //GET Id: api/dev-events/123412 
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var devEvent = _context.DevEvents
                .Include(de => de.Palestrantes)
                .SingleOrDefault(x => x.Id == id);
            if (devEvent == null) 
            {
                return NotFound();
            }
            return Ok(devEvent);
        }

        //POST: api/dev-events/ 
        [HttpPost]
        public IActionResult PostDevEvent(DevEvent devEvent)
        {
            _context.DevEvents.Add(devEvent);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = devEvent.Id }, devEvent);
        }
        //PUT: api/dev-events/Id
        [HttpPut("{id}")]
        public IActionResult UpdateDevEvent(Guid id, DevEvent input)
        {
            var devEvent = _context.DevEvents.SingleOrDefault(x => x.Id == id);
            if (devEvent == null)
            {
                return NotFound();
            }
            devEvent.Update(input.Titulo, input.Descricao, input.DataInicio, input.DataFim);

            _context.DevEvents.Update(devEvent);
            _context.SaveChanges();
            return NoContent();
        }
        //DELETE: api/dev-events/Id 
        [HttpDelete("{id}")]
        public IActionResult DeleteDevEvent(Guid id)
        {
            var devEvent = _context.DevEvents.SingleOrDefault(x => x.Id == id);
            if (devEvent == null)
            {
                return NotFound();
            }
             devEvent.Delete();
            _context.SaveChanges();
            return NoContent();
        }
        
        //POST: Palestrante api/DevEventsPalestrantes/
        [HttpPost("{id}/palestrantes")]
        public IActionResult PostPalestrante(Guid id, DevEventsPalestrantes palestrante) 
        {

            palestrante.DevEventsId = id;

            var devEvent = _context.DevEvents.Any(x => x.Id == id);

            if (!devEvent)
            {
                return NotFound();
            }

            _context.DevEventsPalestrantes.Add(palestrante);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
