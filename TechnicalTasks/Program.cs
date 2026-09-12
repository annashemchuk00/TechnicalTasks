using Microsoft.EntityFrameworkCore;
using TechnicalTask.Infrastructure.DbContexts;
using TechnicalTasks.Application.Managers;
using TechnicalTasks.Application.MappingProfiles;
using TechnicalTasks.Domain.Interfaces;
using TechnicalTasks.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);
//дозвіл на автоматичну обробку локального часу
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<DataContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(cfg =>

{
    cfg.AddMaps(typeof(ConferenceRoomMappingProfile).Assembly);
});

builder.Services.AddScoped<IConferenceRoomRepository, ConferenceRoomRepository>();
builder.Services.AddScoped<IConferenceRoomManager, ConferenceRoomManager>();

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
