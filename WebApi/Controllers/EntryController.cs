using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using Domain;


namespace WebApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class EntryController : ControllerBase
    {
        private readonly EntryRepo _entryRepo;
        private readonly ILogger<DriverController> _logger;


        public EntryController(IEntryRepo entryRepo)
        {
            _entryRepo = entryRepo;
            _logger = logger;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAllEntries()
        {
            _logger.LogInformation("Getting all entries");
            var entries = _entryRepo.GetAllEntries();
            _logger.LogInformation($"Found {entries.Count()} entries");
            return Ok(entries);
        }

        [HttpGet("GetEntryById")]
        public IActionResult GetEntryById(int id)
        {
            _logger.LogInformation($"Getting entry by id: {id}");
            var entry = _entryRepo.GetEntryById(id);
            if (entry == null){
                _logger.LogWarning($"Entry with id {id} not found");
                return NotFound();
            }
            _logger.LogInformation($"Found entry with id {id}");
            return Ok(entry);
        }

        [HttpPost("CreateEntry")]
        public IActionResult CreateEntry([FromBody] Entry entry)
        {
            _logger.LogInformation("Creating new entry");
            Entry entryInfo;
            try
            {
                entryInfo = _entryRepo.AddEntry(entry);
                _logger.LogInformation($"Entry created with id {entryInfo.Id}");
            }
            catch (Exception e) {
                _logger.LogError(e, "Error creating new entry");
                return new ObjectResult(e.Message) { StatusCode = 403 }; //Forbidden
            }
            return Ok(entryInfo);
        }

        [HttpPost("Update/UpdateEntryInfo")]
        public IActionResult UpdateEntryInformation([FromBody] Entry entry) 
        {
            _logger.LogInformation($"Updating entry with id {entry.Id}");
            Entry updatedEntryInfo;
            try
            {
                updatedEntryInfo = _entryRepo.UpdateEntry(entry);
                _logger.LogInformation($"Entry with id {entry.Id} updated");
            }
            catch(Exception e)
            {
                _logger.LogError(e, $"Error updating entry with id {entry.Id}");
                return BadRequest(e.Message);
            }
            return Ok(updatedEntryInfo);
        }

        [HttpDelete("Delete/Entry")]
        public IActionResult DeleteEntry(int id) 
        {
            _logger.LogInformation($"Deleting entry with id {id}");
            try 
            {
                _entryRepo.DeleteEntry(id);
                _logger.LogInformation($"Entry with id {id} deleted");
            }
            catch (Exception e){
                _logger.LogError(e, $"Error deleting entry with id {id}");
                return BadRequest(e.Message);
            }
            return Ok("Entry Deleted.");
        }
    }
}