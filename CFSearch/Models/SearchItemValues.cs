using CFSearch.Enums;

namespace CFSearch.Models
{
    /// <summary>
    /// Search item for list of values
    /// </summary>
    public class SearchItemValues : SearchItemBase
    {
        /// <summary>
        /// Condition
        /// </summary>
        public Condition Condition { get; set; } = Condition.InValueList;

        /// <summary>
        /// Values
        /// </summary>
        public List<string> Values { get; set; } = new List<string>();

        public override bool IsValueMatches(string value, bool caseSensitive)
        {
            if (caseSensitive)
            {
                return Condition switch
                {
                    Condition.InValueList => Values.Any(vc => value.Contains(vc)),
                    Condition.NotInValueList => !Values.Any(vc => value.Contains(vc)),
                    _ => false
                };
            }
            else
            {
                return Condition switch
                {
                    Condition.InValueList => Values.Any(vc => value.Contains(vc, StringComparison.InvariantCultureIgnoreCase)),
                    Condition.NotInValueList => !Values.Any(vc => value.Contains(vc, StringComparison.InvariantCultureIgnoreCase)),
                    _ => false
                };
            }
        }
    }
}
