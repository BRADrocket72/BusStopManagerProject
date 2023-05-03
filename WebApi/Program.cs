using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IBusRepo, BusRepo>();
builder.Services.AddScoped<IEntryRepo, EntryRepo>();
builder.Services.AddScoped<IBusRepo, BusRepo>();
builder.Services.AddScoped<IBusRepo, BusRepo>();
builder.Services.AddScoped<IBusRepo, BusRepo>();
builder.Services.AddScoped<IBusRepo, BusRepo>();
builder.Services.AddDbContext<BusContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});
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
