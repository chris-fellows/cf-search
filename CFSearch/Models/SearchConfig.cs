using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFSearch.Models
{
    /// <summary>
    /// Search config
    /// </summary>
    public class SearchConfig
    {
        /// <summary>
        /// Character to exclude item
        /// </summary>
        public Char ExcludeChar = '-';

        /// <summary>
        /// Character to start list. E.g. ( from (Value1,Value2,Value3)
        /// </summary>
        public Char ListStartChar = '(';

        /// <summary>
        /// Character to end list. E.g. ) from (Value1,Value2,Value3)
        /// </summary>
        public Char ListEndChar = ')';

        /// <summary>
        /// Character to separate items in list. E.g. , from (Value1,Value2,Value3)
        /// </summary>
        public Char ListItemSepChar = ',';

        /// <summary>
        /// Space character
        /// </summary>
        public Char SpaceChar = ' ';

        /// <summary>
        /// Quotes character
        /// </summary>
        public Char QuotesChar = '"';
    }
}
