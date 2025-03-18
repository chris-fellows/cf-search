using CFSearch.Enums;

namespace CFSearch.Models
{
    /// <summary>
    /// Group of child search items
    /// </summary>
    public class SearchItemGroup : SearchItemBase
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
        
        public override bool IsValueMatches(string value, bool caseSensitive)
        {
            // Check child items
            int countMatched = 0;            
            foreach(var searchItem in Items)
            {
                var isValid = searchItem.IsValueMatches(value, caseSensitive);
                if (isValid) countMatched++;                
            }

            return AndOrItems switch {
                AndOr.And => countMatched == Items.Count,       // All match
                AndOr.Or => countMatched > 0,                   // Any matches
                _ => false
            };                
        }
    }
}
