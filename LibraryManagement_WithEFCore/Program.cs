using AutoMapper;
using BusinessLayer.AutoMapper;
using BusinessLayer.Services;
using BusinessLayer.Services.Interfaces;
using DataAccessLayer.Context;
using DataAccessLayer.Repositories;
using DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDBContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("conn")));
// Add services to the container.


builder.Services.AddScoped<IUserProvider, UserProvider>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IBookProvider, BookProvider>();
builder.Services.AddScoped<IRequestService, RequestService>();
builder.Services.AddScoped<IRequestProvider, RequestProvider>();
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
IMapper mapper = new MapperConfiguration(mc =>
{
    mc.AddProfile(new Mappings());
}).CreateMapper();
builder.Services.AddSingleton(mapper);

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
