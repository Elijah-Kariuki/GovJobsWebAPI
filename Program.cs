using GovJobsWebAPI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using GovJobsWebAPI.Data;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using GovJobsWebAPI.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<JobDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("GovJobsDatabase"),
    new MySqlServerVersion(new Version(8, 0, 33))));

// Add services to the container.
builder.Services.AddControllers();

// Correct the section name to "USAJOBS"
builder.Services.Configure<UsaJobsApiConfig>(builder.Configuration.GetSection("USAJOBS"));

builder.Services.AddHttpClient<JobSearch>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<JobSearch>(); // You had this twice, removed the duplicate
builder.Services.AddLogging();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();