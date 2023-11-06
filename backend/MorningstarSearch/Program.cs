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

builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MigrateDatabaseChanges<PeopleDbContext>();

app.MapGet("/search/{searchTerm}",
    ([FromRoute] string searchTerm, ISearchService searchService) => searchTerm == null ? Results.BadRequest() : Results.Ok(searchService.Search(searchTerm)));

app.MapPost("/people",
    ([FromBody] List<PersonDto> people, ISearchService searchService) => searchService.AddPeople(people));

app.UseSwagger();
app.UseSwaggerUI();

app.Run();