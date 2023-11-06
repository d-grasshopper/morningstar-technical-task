using Mapster;
using Microsoft.EntityFrameworkCore;
using MorningstarSearch.Data;
using MorningstarSearch.Models;
using MorningstarSearch.Models.DTOs;

namespace MorningstarSearch.Services;

public class SearchService : ISearchService
{
    private PeopleDbContext _context { get; }

    public SearchService(PeopleDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<PersonDto>> Search(string searchTerm)
    {
        if (searchTerm == "") return new List<PersonDto>();

        var results = _context.People.AsEnumerable().Where(person =>
                (person.FirstName + " " + person.LastName).Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                person.Email.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)
        ).ToList();

        return results.Adapt<List<PersonDto>>();
    }

    public async Task AddPeople(List<PersonDto> people)
    {
        await _context.AddRangeAsync(people.Adapt<List<Person>>());
        await _context.SaveChangesAsync();
    }
}
