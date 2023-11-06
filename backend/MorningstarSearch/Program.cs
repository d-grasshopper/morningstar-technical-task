using Microsoft.EntityFrameworkCore;
using MorningstarSearch.Data;
using MorningstarSearch.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PeopleDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<ISearchService, SearchService>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();