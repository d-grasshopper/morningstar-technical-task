using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MorningstarSearch.Data;
using MorningstarSearch.Extensions;
using MorningstarSearch.Models.DTOs;
using MorningstarSearch.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PeopleDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<ISearchService, SearchService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

var app = builder.Build();

app.MigrateDatabaseChanges<PeopleDbContext>();

app.UseCors(corsBuilder =>
{
    corsBuilder.AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin();
});

app.MapGet("/search/{searchTerm}",
    async ([FromRoute] string searchTerm, ISearchService searchService) => searchTerm == null ? Results.BadRequest() : Results.Ok(await searchService.Search(searchTerm)));

app.MapPost("/people",
    async ([FromBody] List<PersonDto> people, ISearchService searchService) => await searchService.AddPeople(people));

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
