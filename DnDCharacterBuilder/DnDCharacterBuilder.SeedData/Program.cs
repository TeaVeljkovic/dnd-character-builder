using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using DnDCharacterBuilder.Data.Interfaces;
using DnDCharacterBuilder.Data.Repositories;
using DnDCharacterBuilder.Domain.Entities;
using DnDCharacterBuilder.Application.Services;
using DnDCharacterBuilder.Application.Interfaces;
using DnDCharacterBuilder.Application.Mappers;
using DnDCharacterBuilder.Data.Context;

var serviceProvider = new ServiceCollection()
    .AddDbContext<DataContext>()
    .AddScoped<IRepository<Skill>, Repository<Skill>>()
    .AddScoped<ISkillService, SkillService>()
    .AddScoped<IRepository<Class>, Repository<Class>>()
    .AddScoped<IClassService, ClassService>()
    .AddScoped<IRepository<Race>, Repository<Race>>()
    .AddScoped<IRaceService, RaceService>()
    .AddAutoMapper(typeof(SkillMappings))
    .AddAutoMapper(typeof(ClassMappings))
    .BuildServiceProvider();

var skillService = serviceProvider.GetService<ISkillService>();
await skillService.SeedSkills();

var classService = serviceProvider.GetService<IClassService>();
await classService.SeedClasses();

var raceService = serviceProvider.GetService<IRaceService>();
await raceService.SeedRaces();
