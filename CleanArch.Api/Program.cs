using CleanArch.Application;
using CleanArch.Infrastructure;
using CleanArch.Presentation;
using ZymLabs.NSwag.FluentValidation;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddApplication()
                .AddInfrastructure()
                .AddPresentation()
                .AddPersistence(builder.Configuration);
// builder.Services.AddHealthChecks()
//             .AddDbContextCheck<CleanArchDbContext>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.Run();
