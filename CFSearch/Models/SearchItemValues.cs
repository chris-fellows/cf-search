using CFSearch.Enums;

namespace CFSearch.Models
{
    /// <summary>
    /// Search item for list of values
    /// </summary>
    public class SearchItemValues : SearchItemBase
    {
        ///// <summary>
        ///// How to match values:
        ///// And - All values need to match. Typically for "Word1 Word2 Word3"
        ///// Or - Any value needs to match. Typically for "(Word1,Word2,Word3)"                
        ///// </summary>
        //public AndOr AndOrValues { get; set; } = AndOr.Or;

        ///// <summary>
        ///// Case sensitivity settings
        ///// </summary>
        //public bool CaseSensitive { get; set; } = false;

        /// <summary>
        /// Values
        /// </summary>
        public List<string> Values { get; set; } = new List<string>();
    }
}
