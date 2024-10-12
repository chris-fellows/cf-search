using CFSearch.Enums;

namespace CFSearch.Models
{
    /// <summary>
    /// Search options
    /// </summary>
    public class SearchOptions
    {
        /// <summary>
        /// How to evaluate search items:
        /// And - All search items must be valid.
        /// Or - Any search item must be valid.
        /// </summary>
        public AndOr AndOrItems { get; set; } = AndOr.And;

        /// <summary>
        /// Search items
        /// </summary>
        public List<SearchItemBase> Items { get; set; } = new List<SearchItemBase>();
    }
}
