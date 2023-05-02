using Domain;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Route = Domain.Route;

namespace WebApi.Controllers
{
    public class RouteController : ControllerBase
    {
        private readonly RouteRepo _routeRepo;

        public RouteController(RouteRepo routeRepo)
        {
            _routeRepo = routeRepo;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAllRoutes(){
            var routes = _routeRepo.GetAllRoutes();
            return Ok(routes);
        }

        [HttpGet("GetRouteById")]
        public IActionResult GetRouteById(int id){
            var route = _routeRepo.GetRouteById(id);
            if (route == null){
                return NotFound();
            }
            return Ok(route);
        }

        [HttpPost("CreateRoute")]
        public IActionResult CreateRoute([FromBody] Route Route)
        {
            string routeInfo;
            try
            {
                routeInfo = _routeRepo.AddRoute(Route);
            }
            catch (Exception e) {
                return new ObjectResult(e.Message) { StatusCode = 403 }; //Forbidden
            }
            return Ok(routeInfo);
        }

        [HttpPost("Update/UpdateRouteInfo")]
        public IActionResult UpdateRouteInformation([FromBody] Route Route) 
        {
            string updatedRouteInfo;
            try
            {
                updatedRouteInfo = _routeRepo.UpdateRoute(Route);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok(updatedRouteInfo);
        }

        [HttpDelete("Delete/Route")]
        public IActionResult DeleteRoute(int id) {
            try 
            {
                _routeRepo.DeleteRoute(id);
            }
            catch (Exception e){
                return BadRequest(e.Message);
            }
            return Ok("Route Deleted.");
        }
    }
}