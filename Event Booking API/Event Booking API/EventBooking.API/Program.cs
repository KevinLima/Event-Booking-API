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
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<EventService>();

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
    var dummyEvent = new Event
    {
        Id = Guid.NewGuid(),
        Name = "Sample Event",
        Date = new EventDate(DateTime.Now.AddDays(10)),
        Venue = new Venue { Name = "Sample Venue", Location = "Sample Location" },
        Attendees = new List<Attendee>
        {
            new Attendee { Id = Guid.NewGuid(), Name = "John Doe", Ticket = new TicketType("VIP") },
            new Attendee { Id = Guid.NewGuid(), Name = "Jane Smith", Ticket = new TicketType("Regular") }
        }
    };
    eventService.CreateEvent(dummyEvent);
}

app.Run();