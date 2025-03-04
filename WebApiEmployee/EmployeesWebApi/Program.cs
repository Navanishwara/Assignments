using System.Text;
using EmployeesWebApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers().AddXmlSerializerFormatters();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//configure dependency  inject 
builder.Services.AddDbContext<EmployeeDbContext>(options =>
{ 
options.UseNpgsql(builder.Configuration.GetConnectionString("conStr"));
});
//configure dependency injuction for data accesslayer
builder.Services.AddScoped<IEmployeeDataAccess, EmployeeDataAccess>();


var secretKey = builder.Configuration["jwt:secretKey"];
var byteKey = Encoding.UTF8.GetBytes(secretKey);
builder.Services.AddAuthentication(options => 
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(
   options =>
   options.TokenValidationParameters = new TokenValidationParameters
   {
       ValidateIssuer = true,
       ValidateAudience = true,
       ValidateLifetime = true,
       ValidateIssuerSigningKey = true,

       ValidIssuer = builder.Configuration["jwt:issuer"],
       ValidAudience = builder.Configuration["jwt: audience"],
       IssuerSigningKey = new SymmetricSecurityKey(byteKey),

   });
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy =>
    {
        policy.RequireRole("Admin");
    });
});
//add cors policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("clients-allowed", policy =>
    {
        policy.WithOrigins("http://localhost:5130")
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});
//builder.Services.AddSingleton<GlobalErrorHandlercs>(new GlobalErrorHandlercs());
//add the global error handle middleware
builder.Services.AddScoped<GlobalErrorHandlercs>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();
app.UseCors("clients-allowed");
//use the global error handler middleware
app.UseMiddleware<GlobalErrorHandlercs>();

app.Run();
