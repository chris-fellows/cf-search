using CFSearch.Interfaces;
using CFSearch.Models;

namespace CFSearch.Services
{
    public class SearchEvaluatorService : ISearchEvaluatorService
    {
        public bool IsMatches(SearchOptions searchOptions, string text)
        {
            return searchOptions.RootSearchItem.IsValueMatches(text, searchOptions.CaseSensitive);
        }   
    }
}
