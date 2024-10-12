namespace CFSearch.Models
{
    /// <summary>
    /// Search item for RegEx
    /// </summary>
    public class SearchItemRegEx : SearchItemBase
    {
        /// <summary>
        /// RegEx expression
        /// </summary>
        public string Expression { get; set; } = String.Empty;
    }
}
