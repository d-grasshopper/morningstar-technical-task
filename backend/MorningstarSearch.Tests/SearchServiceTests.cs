using Mapster;
using Microsoft.EntityFrameworkCore;
using MorningstarSearch.Data;
using MorningstarSearch.Models;
using MorningstarSearch.Services;
using NSubstitute;

namespace MorningstarSearch.Tests;

public class SearchServiceTests
{
    private PeopleDbContext _context;
    private ISearchService _sut;
    
    [SetUp]
    public async Task Setup()
    {
        var dbContextOptions = new DbContextOptionsBuilder<PeopleDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .EnableSensitiveDataLogging()
            .Options;

        _context = Substitute.ForPartsOf<PeopleDbContext>(dbContextOptions);
        
        _context.People.AddRange(TestData.TestPeople.Adapt<List<Person>>());
        
        await _context.SaveChangesAsync();
        
        _sut = new SearchService(_context);
    }

    [TestCase("James", 2)]
    [TestCase("jam", 3)]
    [TestCase("Katey Soltan", 1)]
    [TestCase("Jasmine Duncan", 0)]
    [TestCase("", 0)]
    public async Task SearchService_ShouldReturnResults(string searchTerm, int expectedResults)
    {
        var result = await _sut.Search(searchTerm);
        
        Assert.AreEqual(expectedResults, result.Count());
    }
}