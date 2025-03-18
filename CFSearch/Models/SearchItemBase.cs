using CFSearch.Enums;

namespace CFSearch.Models
{
    /// <summary>
    /// Base for search item
    /// </summary>
    public abstract class SearchItemBase
    {          
        /// <summary>
        /// Whether value matches search item
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual bool IsValueMatches(string value, bool caseSensitive)
        {
            return false;
        }
    }
}
