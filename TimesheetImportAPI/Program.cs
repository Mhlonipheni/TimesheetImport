using Microsoft.Extensions.Configuration;
using System.Text;
using TimesheetImport.Infrastructure;
using TimesheetImport.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

// Add services to the container.

builder.Services.Configure<InfrastructureOptions>(builder.Configuration);
builder.Services.AddTransient<ITimesheetSiteRepository, TimesheetSiteRepository>();
builder.Services.AddTransient<ITimesheetSiteService, TimesheetSiteService>();
builder.Services.AddControllers();

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
