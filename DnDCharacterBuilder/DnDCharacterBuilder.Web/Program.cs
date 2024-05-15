using Auth0.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;
using DnDCharacterBuilder.Application.Interfaces;
using DnDCharacterBuilder.Application.Mappers;
using DnDCharacterBuilder.Application.Services;
using DnDCharacterBuilder.Data.Context;
using DnDCharacterBuilder.Data.Interfaces;
using DnDCharacterBuilder.Data.Repositories;
using DnDCharacterBuilder.Domain.Entities;
using DnDCharacterBuilder.Application.Models;
using DnDCharacterBuilder.Web.Models;
using DnDCharacterBuilder.Web.CustomMiddleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
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
    .AddAutoMapper(typeof(ClassMappings))
    .AddAutoMapper(typeof(ClassViewModel))
    .AddAutoMapper(typeof(RaceViewModel));
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddAuth0WebAppAuthentication(options =>
{
    options.Domain = builder.Configuration["Auth0:Domain"];
    options.ClientId = builder.Configuration["Auth0:ClientId"];
});

var app = builder.Build();

app.UseMiddleware<ContentSecurityPolicyMiddleware>();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseCookiePolicy(new CookiePolicyOptions
{
    MinimumSameSitePolicy = SameSiteMode.None,
    Secure = CookieSecurePolicy.Always
});

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
