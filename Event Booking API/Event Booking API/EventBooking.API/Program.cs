using Lima.EventBooking.Domain.Services;
using Lima.EventBooking.Infrastructure.Repositories;
using Lima.EventBooking.Domain.Entities;
using Lima.EventBooking.Domain.ValueObjects;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register your repositories and services
builder.Services.AddSingleton<IEventRepository, EventRepository>();
builder.Services.AddSingleton<IVenueRepository, VenueRepository>();
builder.Services.AddScoped<EventService>();
builder.Services.AddScoped<VenueService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Initialize scope
using (var scope = app.Services.CreateScope())
{
    var eventService = scope.ServiceProvider.GetRequiredService<EventService>();
    var venueService = scope.ServiceProvider.GetRequiredService<VenueService>();

    var dummyVenue = new Venue
    {
        Name = "Grote zaal",
        Location = "Capgemini HQ"
    };

    var dummyEvent = new Event
    {
        Id = Guid.NewGuid(),
        Name = "Young Professional Networking",
        Date = new EventDate(DateTime.Now.AddDays(10)),
        Venue = dummyVenue,
        Attendees = new List<Attendee>
        {
            new Attendee { Id = Guid.NewGuid(), Name = "John Doe", 
                Ticket = new TicketType("VIP") },
            new Attendee { Id = Guid.NewGuid(), Name = "Jane Smith", 
                Ticket = new TicketType("Regular") }
        }
    };

    venueService.CreateVenue(dummyVenue);
    eventService.CreateEvent(dummyEvent);
    Console.WriteLine("Dummy event created: " + dummyEvent.Id);
}

app.Run();