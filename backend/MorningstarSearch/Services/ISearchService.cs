using MorningstarSearch.Models.DTOs;

namespace MorningstarSearch.Services;

public interface ISearchService
{
    Task<IEnumerable<PersonDto>> Search(string searchTerm);

    Task AddPeople(List<PersonDto> people);
}