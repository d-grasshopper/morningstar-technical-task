using MorningstarSearch.Models.DTOs;

namespace MorningstarSearch.Services;

public interface ISearchService
{
    IEnumerable<PersonDto> Search(string searchTerm);
}