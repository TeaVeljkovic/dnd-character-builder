using DnDCharacterBuilder.Application.Interfaces;
using DnDCharacterBuilder.Application.Mappers;
using DnDCharacterBuilder.Application.Models;
using DnDCharacterBuilder.Application.Services;
using DnDCharacterBuilder.Data.Context;
using DnDCharacterBuilder.Data.Interfaces;
using DnDCharacterBuilder.Data.Repositories;
using DnDCharacterBuilder.Domain.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddDbContext<DataContext>()
    .AddScoped<IRepository<Skill>, Repository<Skill>>()
    .AddScoped<ISkillService, SkillService>()
    .AddScoped<IRepository<Class>, Repository<Class>>()
    .AddScoped<IClassService, ClassService>()
    .AddScoped<IRepository<Race>, Repository<Race>>()
    .AddScoped<IRaceService, RaceService>()
    .AddScoped<IRepository<Character>, Repository<Character>>()
    .AddScoped<ICharacterService, CharacterService>()
    .AddAutoMapper(typeof(CreateCharacterModel))
    .AddAutoMapper(typeof(SkillMappings))
    .AddAutoMapper(typeof(ClassMappings));
builder.Services.AddAutoMapper(typeof(Program));

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
