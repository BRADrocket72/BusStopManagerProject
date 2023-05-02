using Domain;
using Microsoft.AspNetCore.Mvc;
using System.Linq;


namespace WebApi.Controllers
{
    public class EntryController : ControllerBase
    {
        private readonly EntryRepo _entryRepo;

        public EntryController(EntryRepo entryRepo)
        {
            _entryRepo = entryRepo;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAllEntries(){
            var entries = _entryRepo.GetAllEntries();
            return Ok(entries);
        }

        [HttpGet("GetEntryById")]
        public IActionResult GetEntryById(int id){
            var entry = _entryRepo.GetEntryById(id);
            if (entry == null){
                return NotFound();
            }
            return Ok(entry);
        }

        [HttpPost("CreateEntry")]
        public IActionResult CreateEntry([FromBody] Entry entry)
        {
            string entryInfo;
            try
            {
                entryInfo = _entryRepo.AddEntry(entry);
            }
            catch (Exception e) {
                return new ObjectResult(e.Message) { StatusCode = 403 }; //Forbidden
            }
            return Ok(entryInfo);
        }

        [HttpPost("Update/UpdateEntryInfo")]
        public IActionResult UpdateEntryInformation([FromBody] Entry entry) 
        {
            string updatedEntryInfo;
            try
            {
                updatedEntryInfo = _entryRepo.UpdateEntry(entry);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok(updatedEntryInfo);
        }

        [HttpDelete("Delete/Entry")]
        public IActionResult DeleteEntry(int id) {
            try 
            {
                _entryRepo.DeleteEntry(id);
            }
            catch (Exception e){
                return BadRequest(e.Message);
            }
            return Ok("Entry Deleted.");
        }
    }
}