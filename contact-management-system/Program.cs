using BAL.Implementation;
using BAL.Interface;
using contact_management_system.GlobalException;
using DAL.Implementation;
using DAL.Interface;
using DAL.models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ragister service for dependencies. Added By : Megha Patel
builder.Services.AddSingleton<IContactManagementService, ContactManagementService>();
builder.Services.AddSingleton<IRepository<Contact>, ContactRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
// Add CORS middleware to allow angular application to use APIs. Added By : Megha Patel
app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

app.UseAuthorization();
// Add Global Exception middleware for exception handling. Added By : Megha Patel
app.UseMiddleware<GlobalExceptionMiddleware>();
app.MapControllers();

app.Run();
