using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using Domain;


namespace WebApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class StopController : ControllerBase
    {
        private readonly StopRepo _stopRepo;
        private readonly ILogger<StopController> _logger;

        public StopController(StopRepo stopRepo)
        {
            _stopRepo = stopRepo;
            _logger = logger;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAllStops()
        {
            _logger.LogInformation("Getting all stops.");
            var stops = _stopRepo.GetAllStops();
            return Ok(stops);
        }

        [HttpGet("GetStopById")]
        public IActionResult GetStopById(int id)
        {
            _logger.LogInformation($"Getting stop with id {id}.");
            var stop = _stopRepo.GetStopById(id);
            if (stop == null)
            {
                _logger.LogInformation($"Stop with id {id} not found.");
                return NotFound();
            }
            return Ok(stop);
        }

        [HttpPost("CreateStop")]
        public IActionResult CreateStop([FromBody] Stop stop)
        {
            _logger.LogInformation("Creating a new stop.");
            Stop stopInfo;
            try
            {
                stopInfo = _stopRepo.AddStop(stop);
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed to create stop: {e.Message}");
                return new ObjectResult(e.Message) { StatusCode = 403 }; //Forbidden
            }
            return Ok(stopInfo);
        }

        [HttpPost("Update/UpdateStopInfo")]
        public IActionResult UpdateStopInformation([FromBody] Stop stop)
        {
            _logger.LogInformation($"Updating stop with id {stop.Id}.");
            Stop updatedStopInfo;
            try
            {
                updatedStopInfo = _stopRepo.UpdateStop(stop);
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed to update stop with id {stop.Id}: {e.Message}");
                return BadRequest(e.Message);
            }
            return Ok(updatedStopInfo);
        }

        [HttpDelete("Delete/Stop")]
        public IActionResult DeleteStop(int id)
        {
            _logger.LogInformation($"Deleting stop with id {id}.");
            try
            {
                _stopRepo.DeleteStop(id);
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed to delete stop with id {id}: {e.Message}");
                return BadRequest(e.Message);
            }
            return Ok("Stop Deleted.");
        }
    }
}