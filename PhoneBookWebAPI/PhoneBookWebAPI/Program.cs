using Microsoft.EntityFrameworkCore;
using PhoneBookWebAPI.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers().AddXmlSerializerFormatters();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ContactDBContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("conStr"));
   
});
builder.Services.AddScoped<IContact, ContactDataAccessLayer>();
//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultAuthenticateScheme = Jwt
//});

builder.Services.AddCors(options =>
{
    options.AddPolicy("clients-allowed", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseCors("clients-allowed");
app.MapControllers();

app.Run();
