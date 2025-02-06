using Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Domain;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController // inheriting functionality from the BaseApiController
    {
        private readonly DataContext _context; // Datacontext being injected into the controller

        public ActivitiesController(DataContext context)
        {
            _context = context;

            
        }

        [HttpGet] // Endpoint for the controller: specifies the method that will be used by the controller (how the controller will respond to a get request)
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            return await _context.Activities.ToListAsync();
        }

        [HttpGet("{id}")] // Endpoint for the controller: specifies the method that will be used by the controller (how the controller will respond to a get request for a specific id)

        public async Task<ActionResult<Activity>> GetActivity(Guid id)
        {
            return await _context.Activities.FindAsync(id);
        }
    }
}