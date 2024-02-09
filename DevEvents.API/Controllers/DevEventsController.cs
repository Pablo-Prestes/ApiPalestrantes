using DevEvents.API.Data;
using DevEvents.API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        //api/dev-events GET
        [HttpGet]
        public IActionResult GetAll()
        {
            var devEvent = _context.DevEvents.Where(x => !x.Deletado).ToList();
            return Ok(devEvent);
        }

        //api/dev-events/123412 GET
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var devEvent = _context.DevEvents.SingleOrDefault(x => x.Id == id);
            if (devEvent == null) 
            {
                return NotFound();
            }
            return Ok(devEvent);
        }

        //api/dev-events/ POST  
        [HttpPost]
        public IActionResult PostDevEvent(DevEvent devEvent)
        {
            _context.DevEvents.Add(devEvent);
            return CreatedAtAction(nameof(GetById), new { id = devEvent.Id }, devEvent);
        }
        //api/dev-events/2722b2a6-27d7-43c9-8ecc-3d9509e4656e PUT
        [HttpPut("{id}")]
        public IActionResult UpdateDevEvent(Guid id, DevEvent input)
        {
            var devEvent = _context.DevEvents.SingleOrDefault(x => x.Id == id);
            if (devEvent == null)
            {
                return NotFound();
            }
            devEvent.Update(input.Titulo, input.Descricao, input.DataInicio, input.DataFim);
            return NoContent();
        }
        //api/dev-events/2722b2a6-27d7-43c9-8ecc-3d9509e4656e DELETE
        [HttpDelete("{id}")]
        public IActionResult DeleteDevEvent(Guid id)
        {
            var devEvent = _context.DevEvents.SingleOrDefault(x => x.Id == id);
            if (devEvent == null)
            {
                return NotFound();
            }
            devEvent.Delete();
            return NoContent();
        }

        [HttpPost("{id}/palestrantes")]
        public IActionResult PostPalestrante(Guid id, DevEventsPalestrantes palestrante) 
        {
            var devEvent = _context.DevEvents.SingleOrDefault(x => x.Id == id);
            if (devEvent == null)
            {
                return NotFound();
            }

            devEvent.Palestrantes.Add(palestrante);
            return NoContent();
        }

    }
}
