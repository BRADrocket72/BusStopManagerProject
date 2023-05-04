using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using Domain;
using Route = Domain.Route;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class RouteController : ControllerBase
    {
        private readonly IRouteRepo _routeRepo;
        private readonly ILogger<RouteController> _logger;

        public RouteController(IRouteRepo routeRepo, ILogger<RouteController> logger)
        {
            _routeRepo = routeRepo;
            _logger = logger;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAllRoutes()
        {
            _logger.LogInformation("Getting all routes.");
            var routes = _routeRepo.GetAllRoutes();
            return Ok(routes);
        }

        [HttpGet("GetRouteById")]
        public IActionResult GetRouteById(int id)
        {
            _logger.LogInformation("Getting route by ID: {id}", id);
            var route = _routeRepo.GetRouteById(id);
            if (route == null)
            {
                _logger.LogWarning("Route not found for ID: {id}", id);
                return NotFound();
            }
            return Ok(route);
        }

        [HttpPost("CreateRoute")]
        public IActionResult CreateRoute([FromBody] Route Route)
        {
            _logger.LogInformation("Creating new route.");
            Route routeInfo;
            try
            {
                routeInfo = _routeRepo.AddRoute(Route);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error creating route: {error}", e.Message);
                return new ObjectResult(e.Message) { StatusCode = 403 }; //Forbidden
            }
            return Ok(routeInfo);
        }

        [HttpPost("Update/UpdateRouteInfo")]
        public IActionResult UpdateRouteInformation([FromBody] Route Route)
        {
            _logger.LogInformation("Updating route with ID: {id}", Route.Id);
            Route updatedRouteInfo;
            try
            {
                updatedRouteInfo = _routeRepo.UpdateRoute(Route);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error updating route with ID: {id}. Error message: {error}", Route.Id, e.Message);
                return BadRequest(e.Message);
            }
            return Ok(updatedRouteInfo);
        }

        [HttpDelete("Delete/Route")]
        public IActionResult DeleteRoute(int id)
        {
            _logger.LogInformation("Deleting route with ID: {id}", id);
            try
            {
                _routeRepo.DeleteRoute(id);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error deleting route with ID: {id}. Error message: {error}", id, e.Message);
                return BadRequest(e.Message);
            }
            return Ok("Route Deleted.");
        }
    }
}