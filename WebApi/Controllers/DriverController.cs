using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using Domain;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers {

    [Authorize]
    [ApiController]
    [Route("[Controller]")]
    public class DriverController : ControllerBase
    {
        private readonly IDriverRepo _driverRepo;
        private readonly ILogger<DriverController> _logger;

        
        public DriverController(IDriverRepo driverRepo, ILogger<DriverController> logger)
        {
            _driverRepo = driverRepo;
            _logger = logger;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAllDrivers()
        {
            _logger.LogInformation("GetAllDrivers method called.");
            var drivers = _driverRepo.GetAllDrivers();
            return Ok(drivers);
        }

        [HttpGet("GetDriverById")]
        public IActionResult GetDriverById(int id)
        {
             _logger.LogInformation($"GetDriverById method called with id {id}.");
            var driver = _driverRepo.GetDriverById(id);
            if (driver == null){
                _logger.LogWarning($"Driver with id {id} not found.");
                return NotFound();
            }
            return Ok(driver);
        }

        [HttpPost("CreateDriver")]
        public IActionResult CreateDriver([FromBody] Driver driver)
        {
            _logger.LogInformation("CreateDriver method called.");
            Driver driverInfo;
            try
            {
                driverInfo = _driverRepo.AddDriver(driver);
                _logger.LogInformation($"Driver with id {driverInfo.Id} created successfully.");
            }
            catch (Exception e) 
            {
                _logger.LogError($"Error creating driver: {e.Message}");
                return new ObjectResult(e.Message) {  StatusCode = 403 }; //Forbidden
            }
            return Ok(driverInfo);
        }

        [HttpPost("Update/UpdateDriver")]
        public IActionResult UpdateDriver([FromBody] Driver driver) 
        {
            _logger.LogInformation($"UpdateDriver method called with driver id {driver.Id}.");
            Driver updatedDriverInfo;
            try
            {
                updatedDriverInfo = _driverRepo.UpdateDriver(driver);
                _logger.LogInformation($"Driver with id {driver.Id} updated successfully.");
            }
            catch (Exception e)
            {
                _logger.LogError($"Error updating driver with id {driver.Id}: {e.Message}");
                return BadRequest(e.Message);
            }
            return Ok(updatedDriverInfo);
        }

        [HttpDelete("Delete/Driver")]
        public IActionResult DeleteDriver(int driverId)
        {
            _logger.LogInformation($"DeleteDriver method called with driver id {driverId}.");
            try
            {
                _driverRepo.DeleteDriver(driverId);
                _logger.LogInformation($"Driver with id {driverId} deleted successfully.");
            }
            catch (Exception e) 
            {
                _logger.LogError($"Error deleting driver with id {driverId}: {e.Message}");
                return BadRequest(e.Message);
            }
            return Ok("Driver successfully deleted.");
        }
    }
}