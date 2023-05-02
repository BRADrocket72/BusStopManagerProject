using Domain;
using Microsoft.AspNetCore.Mvc;
using System.Linq;


namespace WebApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class StopController : ControllerBase
    {
        private readonly StopRepo _stopRepo;

        public StopController(StopRepo stopRepo)
        {
            _stopRepo = stopRepo;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAllStops()
        {
            var stops = _stopRepo.GetAllStops();
            return Ok(stops);
        }

        [HttpGet("GetStopById")]
        public IActionResult GetStopById(int id)
        {
            var stop = _stopRepo.GetStopById(id);
            if (stop == null)
            {
                return NotFound();
            }
            return Ok(stop);
        }

        [HttpPost("CreateStop")]
        public IActionResult CreateStop([FromBody] Stop stop)
        {
            Stop stopInfo;
            try
            {
                stopInfo = _stopRepo.AddStop(stop);
            }
            catch (Exception e)
            {
                return new ObjectResult(e.Message) { StatusCode = 403 }; //Forbidden
            }
            return Ok(stopInfo);
        }

        [HttpPost("Update/UpdateStopInfo")]
        public IActionResult UpdateStopInformation([FromBody] Stop stop)
        {
            Stop updatedStopInfo;
            try
            {
                updatedStopInfo = _stopRepo.UpdateStop(stop);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok(updatedStopInfo);
        }

        [HttpDelete("Delete/Stop")]
        public IActionResult DeleteStop(int id)
        {
            try
            {
                _stopRepo.DeleteStop(id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok("Stop Deleted.");
        }
    }
}