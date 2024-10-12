using CFSearch.Enums;

namespace CFSearch.Models
{
    public abstract class SearchItemBase
    {   
        /// <summary>
        /// Condition
        /// </summary>
        public Condition Condition { get; set; } = Condition.InValueList;

        /// <summary>
        /// How to match values:
        /// And - All values need to match. Typically for "Word1 Word2 Word3"
        /// Or - Any value needs to match. Typically for "(Word1,Word2,Word3)"                
        /// </summary>
        public AndOr AndOrValues { get; set; } = AndOr.Or;
    }
}
