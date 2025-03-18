using CFSearch.Enums;
using System.Text.RegularExpressions;

namespace CFSearch.Models
{
    /// <summary>
    /// Search item for RegEx
    /// </summary>
    public class SearchItemRegEx : SearchItemBase
    {
        /// <summary>
        /// Condition
        /// </summary>
        public Condition Condition { get; set; } = Condition.InValueList;

        /// <summary>
        /// RegEx expression
        /// </summary>
        public string Expression { get; set; } = String.Empty;

        public override bool IsValueMatches(string value, bool caseSensitive)
        {
            Regex regex = new Regex(Expression);

            return Condition switch
            {
                Condition.MatchesRegEx => regex.IsMatch(value),
                Condition.NotMatchesRegEx => !regex.IsMatch(value),
                _ => false
            };
        }
    }
}
