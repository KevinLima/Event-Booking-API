using Lima.EventBooking.API.Services;
using Lima.EventBooking.API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Lima.EventBooking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VenueController : Controller
    {
        private readonly VenueService _venueService;

        public VenueController(VenueService venueService)
        {
            _venueService = venueService;
        }

        [HttpGet("{venueName}")]
        public IActionResult GetVenue(string venueName) 
        {
            var venue = _venueService.GetVenueByName(venueName);
            if (venue == null) 
            {
                return NotFound(new { message = "Venue not found"});
            }
            return Ok(venue);
        }

        [HttpGet]
        public IActionResult GetAllVenues()
        {
            var venues = _venueService.GetAllVenues();

            var venueDTOs = venues.Select(v => new VenueDTO
            {
                Name = v.Name,
                Location = v.Location,
            }).ToList();

            return Ok(venueDTOs);   
        }
    }
}
