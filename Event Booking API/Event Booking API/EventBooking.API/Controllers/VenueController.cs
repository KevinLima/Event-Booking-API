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

        /// <summary>
        /// Injectable service for this controllers.
        /// </summary>
        /// <param name="venueService">The service that wil be injected.</param>
        public VenueController(VenueService venueService)
        {
            _venueService = venueService;
        }

        /// <summary>
        /// Gets a venue by its id
        /// </summary>
        /// <param name="venueId">The GUID id if the venue</param>
        /// <returns>A <see cref="ObjectResult"/>, and the venue if it was found.</returns>
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

        /// <summary>
        /// Gets all venues.
        /// </summary>
        /// <returns>A <see cref="ObjectResult"/> and a list of venues.</returns>
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

        /// <summary>
        /// Create a new venue
        /// </summary>
        /// <param name="venueDTO">The DTO of the new venue</param>
        /// <returns>A object result, and the venue if it was created.</returns>
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
