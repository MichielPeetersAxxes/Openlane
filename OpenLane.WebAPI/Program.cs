using Openlane.DAL;
using Openlane.Services;
using Openlane.Shared.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<Openlanecontext>();

builder.Services.AddScoped<IBikeContainerService, BikeContainerService>();
builder.Services.AddScoped<IBikeService, BikeService>();
builder.Services.AddScoped<IBidService, BidService>();

builder.Services.AddHttpClient();

builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();