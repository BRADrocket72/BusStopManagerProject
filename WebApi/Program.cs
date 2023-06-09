using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Domain;

var builder = WebApplication.CreateBuilder(args);
var folder = Environment.SpecialFolder.LocalApplicationData;
var path = Environment.GetFolderPath(folder);
var dbPath = Path.Join(path, "BusStopProject.db");

builder.Services.AddDbContext<BusContext>(options => options.UseInMemoryDatabase("ConnectionString"));

builder.Services.AddIdentityCore<Driver>();
// Add services to the container.
builder.Services.AddDefaultIdentity<Driver>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<BusContext>();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy =>
        policy.RequireClaim("IsAdmin", "true"));

});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IBusRepo, BusRepo>();
builder.Services.AddScoped<IEntryRepo, EntryRepo>();
builder.Services.AddScoped<IDriverRepo, DriverRepo>();
builder.Services.AddScoped<IStopRepo, StopRepo>();
builder.Services.AddScoped<IRouteRepo, RouteRepo>();
builder.Services.AddScoped<ILoopRepo, LoopRepo>();

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

public partial class Program { }
