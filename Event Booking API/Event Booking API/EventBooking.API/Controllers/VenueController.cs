using Lima.EventBooking.API.Services;
using Lima.EventBooking.API.DTOs;
using Microsoft.AspNetCore.Mvc;
using Lima.EventBooking.Domain.Entities;

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

        [HttpGet("{venueId}")]
        public IActionResult GetVenue(Guid venueId) 
        {
            var venue = _venueService.GetVenueById(venueId);
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
                Id = v.Id,
                Name = v.Name,
                Location = v.Location,
            }).ToList();

            return Ok(venueDTOs);   
        }

        [HttpPost]
        public IActionResult CreateVenue([FromBody] VenueDTO venueDTO)
        {
            try
            {
                var venue = new Venue
                {
                    Id = Guid.NewGuid(),
                    Name = venueDTO.Name,
                    Location = venueDTO.Location
                };

                _venueService.CreateVenue(venue);
                return Ok(new { 
                    message = "Venue created", 
                    venueId = venue.Id });
            }
            catch(Exception ex)
            {
                return BadRequest(new { message = ex });
            }
        }
    }
}
