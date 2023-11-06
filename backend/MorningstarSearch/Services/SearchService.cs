using MorningstarSearch.Models.DTOs;

namespace MorningstarSearch.Services;

public class SearchService: ISearchService
{
    public IEnumerable<PersonDto> Search(string searchTerm)
    {
        return new List<PersonDto>();
    }
}