using Microsoft.AspNetCore.Mvc;
using Domain;


namespace WebApi.Controllers {

    [ApiController]
    [Route("[Controller]")]
    public class DriverController : ControllerBase
    {
        private readonly DriverRepo _driverRepo;
        
        public DriverController(DriverRepo driverRepo)
        {
            _driverRepo = driverRepo;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAllDrivers()
        {
            var drivers = _driverRepo.GetAllDrivers();
            return Ok(drivers);
        }

        [HttpGet("GetDriverById")]
        public IActionResult GetDriverById(int id)
        {
            var driver = _driverRepo.GetDriverById(id);
            if (driver == null){
                return NotFound();
            }
            return Ok(driver);
        }

        [HttpPost("CreateDriver")]
        public IActionResult CreateDriver([FromBody] Driver driver)
        {
            Driver driverInfo;
            try
            {
                driverInfo = _driverRepo.AddDriver(driver);
            }
            catch (Exception e) 
            {
                return new ObjectResult(e.Message) {  StatusCode = 403 }; //Forbidden
            }
            return Ok(driverInfo);
        }

        [HttpPost("Update/UpdateDriver")]
        public IActionResult UpdateDriver([FromBody] Driver driver) 
        {
            Driver updatedDriverInfo;
            try
            {
                updatedDriverInfo = _driverRepo.UpdateDriver(driver);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok(updatedDriverInfo);
        }

        [HttpDelete("Delete/Driver")]
        public IActionResult DeleteDriver(int driverId)
        {
            try
            {
                _driverRepo.DeleteDriver(driverId);
            }
            catch (Exception e) 
            {
                return BadRequest(e.Message);
            }
            return Ok("Driver successfully deleted.");
        }
    }
}