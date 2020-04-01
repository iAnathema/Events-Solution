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
    public class EventTypeController : ControllerBase
    {
        private readonly ILogger<IUnitOfWork> _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOFWork;



        public EventTypeController(IUnitOfWork unitOfWork, ILogger<IUnitOfWork> logger, IMapper mapper)
        {
            _unitOFWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        // GET api/event
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<EventTypeHeader>))]   // Found        
        [ProducesResponseType(401)]     // BadRequest
        [ProducesResponseType(404)]     // NotFound
        public IActionResult GetAll([FromQuery] int? pageNum = null, [FromQuery] int? pageSize = null)
        {
            try
            {

                var result = _mapper.Map<ICollection<EventTypeHeader>>(_unitOFWork.EventTypes.GetAll(pageNum, pageSize, null, x => x.OrderBy(o => o.Title))).ToList();
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
        [ProducesResponseType(200, Type = typeof(EventTypeDetails))]   // Found        
        [ProducesResponseType(401)]     // BadRequest
        [ProducesResponseType(404)]     // NotFound       
        public IActionResult GetById(int id)
        {
            try
            {
                var result = _mapper.Map<EventTypeDetails>(_unitOFWork.EventTypes.GetByID(id));
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
        [ProducesResponseType(typeof(NewRecordResponse),201)]     // Inserted        
        [ProducesResponseType(401)]     // BadRequest
        [ProducesResponseType(404)]     // NotFound
        public IActionResult NewEventType([FromBody] EventTypeDetails newType)
        {
            try
            {
                var record = _mapper.Map<EventType>(newType);
                _unitOFWork.EventTypes.Insert(record);
                _unitOFWork.Commit();                
                return StatusCode(201, new NewRecordResponse { id =  record.TypeId });
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
        public IActionResult UpdateEventType(int id, [FromBody] EventTypeDetails eventType)
        {
            try
            {
                var evType = _mapper.Map<EventType>(eventType);
                evType.TypeId = id;
                _unitOFWork.EventTypes.Update(id, evType);
                _unitOFWork.Commit();
                return StatusCode(201);
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

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]     // Delete      
        [ProducesResponseType(401)]     // BadRequest
        [ProducesResponseType(404)]     // NotFound
        public IActionResult DeleteEventType(int id)
        {
            try
            {
                _unitOFWork.EventTypes.Delete(id);
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
