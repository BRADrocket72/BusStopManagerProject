using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using Domain;


namespace WebApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class LoopController : ControllerBase
    {
        private readonly LoopRepo _loopRepo;
        private readonly ILogger<LoopController> _logger;

        public LoopController(ILoopRepo loopRepo)
        {
            _loopRepo = loopRepo;
            _logger = logger;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAllLoops()
        {
            _logger.LogInformation("Getting all loops");
            var loops = _loopRepo.GetAllLoops();
            return Ok(loops);
        }

        [HttpGet("GetLoopById")]
        public IActionResult GetLoopById(int id)
        {
            _logger.LogInformation($"Getting loop with ID {id}");
            Loop loop = _loopRepo.GetLoopById(id);
            if (loop == null)
            {
                _logger.LogWarning($"Loop with ID {id} not found");
                return NotFound();
            }
            return Ok(loop);
        }

        [HttpPost("CreateLoop")]
        public IActionResult CreateLoop([FromBody] Loop Loop)
        {
            _logger.LogInformation("Creating new loop");
            Loop loopInfo;
            try
            {
                loopInfo = _loopRepo.AddLoop(Loop);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error while creating new loop");
                return new ObjectResult(e.Message) { StatusCode = 403 }; //Forbidden
            }
            return Ok(loopInfo);
        }

        [HttpPost("Update/UpdateLoopInfo")]
        public IActionResult UpdateLoopInformation([FromBody] Loop loop)
        {
            _logger.LogInformation($"Updating loop with ID {loop.Id}");
            Loop updatedLoopInfo;
            try
            {
                updatedLoopInfo = _loopRepo.UpdateLoop(loop);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Error while updating loop with ID {loop.Id}");
                return BadRequest(e.Message);
            }
            return Ok(updatedLoopInfo);
        }

        [HttpDelete("Delete/Loop")]
        public IActionResult DeleteLoop(int id)
        {
            _logger.LogInformation($"Deleting loop with ID {id}");
            try
            {
                _loopRepo.DeleteLoop(id);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Error while deleting loop with ID {id}");
                return BadRequest(e.Message);
            }
            return Ok("Loop Deleted.");
        }
    }
}