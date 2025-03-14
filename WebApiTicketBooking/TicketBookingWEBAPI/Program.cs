using Microsoft.EntityFrameworkCore;
using TicketBookingWEBAPI.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//
builder.Services.AddDbContext<BookingDBContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("conStr"));
});
//configure dependency injuction for data accesslayer
builder.Services.AddScoped<ITicketBookingAccess, TicketDataAccessLayer>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
