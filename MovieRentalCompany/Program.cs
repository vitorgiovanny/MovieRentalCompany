using Microsoft.EntityFrameworkCore;
using MovieRentalCompany.Domain.Entities;
using MovieRentalCompany.Domain.Interfaces.Repositories;
using MovieRentalCompany.Domain.Interfaces.Services;
using MovieRentalCompany.Domain.Services;
using MovieRentalCompany.Infrastructure.Database.Context;
using MovieRentalCompany.Infrastructure.Repositories;
using MovieRentalCompany.Services.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

/* DI repositories */
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

/* DI services */

builder.Services.AddScoped<IServices<Customer>, CustomerServices>();
builder.Services.AddScoped<IServices<Movie>, MovieServices >();
builder.Services.AddScoped<IServices<MovieRentalCompany>, MovieRentalServices>();

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
