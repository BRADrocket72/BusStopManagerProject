using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
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
        private readonly ILogger<BusController> _logger;
        private readonly BusRepo _busRepo;


        public BusController(IBusRepo busRepo)
        {
            _logger = logger;
            _busRepo = busRepo;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAllBusses()
        {
            _logger.LogInformation("Getting all busses...");
            var busses = _busRepo.GetAllBuses();
            _logger.LogInformation("Returning all busses.");
            return Ok(busses);
        }

        [HttpGet("GetBusById")]
        public IActionResult GetBusById(int id)
        {
            _logger.LogInformation($"Getting bus by ID: {id}...");
            var bus = _busRepo.GetBusById(id);
            if (bus == null){
                _logger.LogWarning($"Bus with ID {id} not found.");
                return NotFound();
            }
            _logger.LogInformation($"Returning bus with ID {id}.");
            return Ok(bus);
        }

        [HttpPost("CreateBus")]
        public IActionResult CreateBus(Bus bus)
        {
            _logger.LogInformation($"Creating new bus: {bus}...");
            Bus busInfo;
            try
            {
                busInfo = _busRepo.AddBus(bus);
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed to create bus: {e.Message}");
                return new ObjectResult(e.Message) { StatusCode = 403 }; //Forbidden
            }
            _logger.LogInformation($"New bus created with ID {busInfo.Id}.");
            return Ok(busInfo);
        }

        [HttpPost("Update/UpdateBusInfo")]
        public IActionResult UpdateBusInfo([FromBody]Bus bus) 
        {
            _logger.LogInformation($"Updating bus info: {bus}...");
            Bus updatedBusInfo;
            try
            {
                updatedBusInfo = _busRepo.UpdateBus(bus);
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed to update bus info: {e.Message}");
                return BadRequest(e.Message);
            }
            _logger.LogInformation($"Bus info updated for bus with ID {updatedBusInfo.Id}.");
            return Ok(updatedBusInfo);
        }

        [HttpPost("Delete/Bus")]
        public IActionResult DeleteBus(int  id)
        {
             _logger.LogInformation($"Deleting bus with ID: {id}...");
            try
            {
                _busRepo.DeleteBus(id);
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed to delete bus with ID {id}: {e.Message}");
                return BadRequest(e.Message);
            }
            _logger.LogInformation($"Bus with ID {id} deleted successfully.");
            return Ok("Bus successfully deleted.");
        }
    }
}