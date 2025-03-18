using CFSearch.Models;

namespace CFSearch.Interfaces
{
    /// <summary>
    /// Service to evaluate SearchOptions with text to match
    /// </summary>
    public interface ISearchEvaluatorService
    {
        /// <summary>
        /// Whether search options match text
        /// </summary>
        /// <param name="searchOptions"></param>
        /// <param name="text"></param>
        /// <param name="caseSensitive"></param>
        /// <returns></returns>
        bool IsMatches(SearchOptions searchOptions, string text);
    }
}
