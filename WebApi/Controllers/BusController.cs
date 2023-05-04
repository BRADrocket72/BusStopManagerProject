using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Domain;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controller
{
    [Authorize(Policy = "AdminOnly")]
    [ApiController]
    [Route("[Controller]")]
    public class BusController : ControllerBase
    {
        private readonly IBusRepo _busRepo;

        public BusController(IBusRepo busRepo)
        {
            _busRepo = busRepo;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAllBusses()
        {
            var busses = _busRepo.GetAllBuses();
            return Ok(busses);
        }

        [HttpGet("GetBusById")]
        public IActionResult GetBusById(int id)
        {
            var bus = _busRepo.GetBusById(id);
            if (bus == null){
                return NotFound();
            }
            return Ok(bus);
        }

        [HttpPost("CreateBus")]
        public IActionResult CreateBus(Bus bus)
        {
            Bus busInfo;
            try
            {
                busInfo = _busRepo.AddBus(bus);
            }
            catch (Exception e)
            {
                return new ObjectResult(e.Message) { StatusCode = 403 }; //Forbidden
            }
            return Ok(busInfo);
        }

        [HttpPost("Update/UpdateBusInfo")]
        public IActionResult UpdateBusInfo([FromBody]Bus bus) 
        {
            Bus updatedBusInfo;
            try
            {
                updatedBusInfo = _busRepo.UpdateBus(bus);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok(updatedBusInfo);
        }

        [HttpPost("Delete/Bus")]
        public IActionResult DeleteBus(int  id)
        {
            try
            {
                _busRepo.DeleteBus(id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok("Bus successfully deleted.");
        }
    }
}