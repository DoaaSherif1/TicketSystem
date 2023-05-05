using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketSystem.BL.DTOs.Tickets;
using TicketSystem.BL.Managers.Tickets;

namespace Lab2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketsManager _ticketsManager;

        public TicketsController(ITicketsManager ticketsManager)
        {
            _ticketsManager = ticketsManager;
        }

        [HttpGet]
        public ActionResult<List<TicketReadDto>> GetAll()
        {
            return _ticketsManager.GetAll();  //Ok 200 //  
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<TicketReadDto> GetById(int id)
        {
            TicketReadDto? ticket = _ticketsManager.GetById(id);

            if (ticket == null)
            {
                return NotFound();
            }
            return ticket;

        }

        [HttpPost]
        public ActionResult Add(TicketAddDto ticketDto)
        {
            var newId = _ticketsManager.Add(ticketDto);
            return CreatedAtAction("GetById", new {id = newId}, new {m = "Added Successfuly"});
            //return NoContent();
        }

        [HttpPut]
        public ActionResult Update(TicketUpdateDto ticketDto)
        {
            var isFound = _ticketsManager.Update(ticketDto);
            if (!isFound)
            {
                return NotFound();
            }

            return NoContent(); //204 Success with not content
        }

        
       

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            _ticketsManager.Delete(id);
            return NoContent();
        }


    }
}
