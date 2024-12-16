using contact_management_system.BusinessLogic.Implementation;
using contact_management_system.BusinessLogic.Interface;
using contact_management_system.GlobalException;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ragister service for dependencies. Added By : Megha Patel
builder.Services.AddSingleton<IContactManagementService, ContactManagementService>();
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
