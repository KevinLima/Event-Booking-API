using Lima.EventBooking.Infrastructure.Repositories;
using Lima.EventBooking.Domain.Entities;
using Lima.EventBooking.Domain.ValueObjects;
using Lima.EventBooking.API.Services;
using Event_Booking_API.EventBooking.Infrastructure.Repositories;
using Event_Booking_API.EventBooking.API.Services;
using Lima.EventBooking.Infrastructure.Repositories.Interfaces;
using Lima.EventBooking.API.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register your repositories and services
builder.Services.AddSingleton<IEventRepository, EventRepository>();
builder.Services.AddSingleton<IVenueRepository, VenueRepository>();
builder.Services.AddSingleton<IAttendeeRepository, AttendeeRepository>();

builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IVenueService, VenueService>();
builder.Services.AddScoped<IAttendeeService, AttendeeService>();

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
    var eventService = scope.ServiceProvider.GetRequiredService<IEventService>();
    var venueService = scope.ServiceProvider.GetRequiredService<IVenueService>();
    var attendeeService = scope.ServiceProvider.GetRequiredService<IAttendeeService>();

    var dummyVenue = new Venue
    {
        Name = "Grote zaal",
        Location = "Capgemini HQ"
    };

    var dummyAttendee = new Attendee
    {
        Id = Guid.NewGuid(),
        Name = "John Doe",
        Ticket = new TicketType("VIP")
    };

    var dummyAttendee2 = new Attendee
    {
        Id = Guid.NewGuid(),
        Name = "Jane Smith",
        Ticket = new TicketType("Regular")
    };

    var dummyEvent = new Event
    {
        Id = Guid.NewGuid(),
        Name = "Young Professional Networking",
        Date = new EventDate(DateTime.Now.AddDays(10)),
        Venue = dummyVenue,
        Attendees = new List<Attendee>
        {
            dummyAttendee,
            dummyAttendee2
        }
    };

    venueService.CreateVenue(dummyVenue);
    eventService.CreateEvent(dummyEvent);
    attendeeService.CreateAttendee(dummyAttendee);
    attendeeService.CreateAttendee(dummyAttendee2); 
}

app.Run();