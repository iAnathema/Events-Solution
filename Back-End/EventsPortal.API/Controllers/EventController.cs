using AutoMapper;
using EventsPortal.API.DTO;
using EventsPortal.BLL.UnitOfWork;
using EventsPortal.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EventsPortal.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly ILogger<IUnitOfWork> _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOFWork;



        public EventController(IUnitOfWork unitOfWork, ILogger<IUnitOfWork> logger, IMapper mapper)
        {
            _unitOFWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        // GET api/event
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<EventHeader>))]   // Found        
        [ProducesResponseType(401)]     // BadRequest
        [ProducesResponseType(404)]     // NotFound
        public IActionResult GetAll([FromQuery] int? pageNum = null, [FromQuery] int? pageSize = null)
        {
            try
            {

                var result = _mapper.Map<ICollection<EventHeader>>(_unitOFWork.Events.GetAll(pageNum, pageSize, null, x => x.OrderByDescending(o => o.Date))).ToList();
                if (result != null) return Ok(result);
                else return NotFound();

            }
            catch (Exception e)
            {
                _logger.LogError(e, "Internal Server Error");
                return StatusCode(500);
            }
        }

        // GET api/event/:id        
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(EventDetails))]   // Found        
        [ProducesResponseType(401)]     // BadRequest
        [ProducesResponseType(404)]     // NotFound       
        public IActionResult GetById(int id)
        {
            try
            {
                var result = _mapper.Map<EventDetails>(_unitOFWork.Events.GetByID(id));
                if (result != null) return Ok(result);
                else return NotFound();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Internal Server Error");
                return StatusCode(500);
            }
        }

        // POST api/event
        [HttpPost]
        [ProducesResponseType(typeof(NewRecordResponse), 201)]     // Inserted        
        [ProducesResponseType(401)]     // BadRequest
        [ProducesResponseType(404)]     // NotFound
        public IActionResult NewEvent([FromBody] EventDetails newEvent)
        {
            try
            {
                if (!_unitOFWork.EventTypes.ExistsID(newEvent.TypeId))
                    return StatusCode(400, new ProblemDetails { Title = "Format Error", Detail = "The defined EventTypeId doesn't exist" });

                var record = _mapper.Map<Event>(_mapper.Map<Event>(newEvent));
                _unitOFWork.Events.Insert(record);
                _unitOFWork.Commit();
                return StatusCode(201, new NewRecordResponse { id = record.Id });
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Internal Server Error");
                return StatusCode(500);
            }
        }

        // PUT api/event
        [HttpPut("{id}")]
        [ProducesResponseType(200)]     // Updated        
        [ProducesResponseType(401)]     // BadRequest
        [ProducesResponseType(404)]     // NotFound
        public IActionResult UpdateEvent(int id, [FromBody] EventDetails newEvent)
        {
            try
            {               
                if (!_unitOFWork.EventTypes.ExistsID(newEvent.TypeId))
                    return StatusCode(400, new ProblemDetails { Title = "Format Error", Detail = "The defined EventTypeId doesn't exist" });


                var newEv = _mapper.Map<Event>(newEvent);
                newEv.Id = id;
                _unitOFWork.Events.Update(id, newEv);
                _unitOFWork.Commit();
                return StatusCode(200);
            }
            catch (Exception e)
            {
                if(e.GetType() == typeof(System.ArgumentException))
                {
                    _logger.LogError(e, "Argument Error");
                    return StatusCode(400, new ProblemDetails { Title = "Argument Error", Detail = e.Message });
                }


                _logger.LogError(e, "Internal Server Error");
                return StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]     // Delete      
        [ProducesResponseType(401)]     // BadRequest
        [ProducesResponseType(404)]     // NotFound
        public IActionResult DeleteEvent(int id)
        {
            try
            {
                _unitOFWork.Events.Delete(id);
                _unitOFWork.Commit();
                return StatusCode(200);
            }
            catch (Exception e)
            {
                if (e.GetType() == typeof(System.ArgumentException))
                {
                    _logger.LogError(e, "Argument Error");
                    return StatusCode(400, new ProblemDetails { Title = "Argument Error", Detail = e.Message });
                }

                _logger.LogError(e, "Internal Server Error");
                return StatusCode(500);
            }
        }

    }
}
