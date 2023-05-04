using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;


namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[Controller]")]
    public class LoopController : ControllerBase
    {
        private readonly ILoopRepo _loopRepo;

        public LoopController(ILoopRepo loopRepo)
        {
            _loopRepo = loopRepo;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAllLoops()
        {
            var loops = _loopRepo.GetAllLoops();
            return Ok(loops);
        }

        [HttpGet("GetLoopById")]
        public IActionResult GetLoopById(int id)
        {
            Loop loop = _loopRepo.GetLoopById(id);
            if (loop == null)
            {
                return NotFound();
            }
            return Ok(loop);
        }

        [HttpPost("CreateLoop")]
        public IActionResult CreateLoop([FromBody] Loop Loop)
        {
            Loop loopInfo;
            try
            {
                loopInfo = _loopRepo.AddLoop(Loop);
            }
            catch (Exception e)
            {
                return new ObjectResult(e.Message) { StatusCode = 403 }; //Forbidden
            }
            return Ok(loopInfo);
        }

        [HttpPost("Update/UpdateLoopInfo")]
        public IActionResult UpdateLoopInformation([FromBody] Loop loop)
        {
            Loop updatedLoopInfo;
            try
            {
                updatedLoopInfo = _loopRepo.UpdateLoop(loop);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok(updatedLoopInfo);
        }

        [HttpDelete("Delete/Loop")]
        public IActionResult DeleteLoop(int id)
        {
            try
            {
                _loopRepo.DeleteLoop(id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok("Loop Deleted.");
        }
    }
}