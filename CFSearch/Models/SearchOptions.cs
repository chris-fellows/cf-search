using CFSearch.Enums;

namespace CFSearch.Models
{
    /// <summary>
    /// Search options
    /// </summary>
    public class SearchOptions
    {
        /// <summary>
        /// Whether case sensitive
        /// </summary>
        public bool CaseSensitive { get; set; }

        /// <summary>
        /// Root search item
        /// </summary>
        public SearchItemBase RootSearchItem = new SearchItemGroup() { };
    }
}
