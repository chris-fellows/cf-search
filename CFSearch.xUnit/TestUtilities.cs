using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFSearch.xUnit
{
    internal static class TestUtilities
    {
        /// <summary>
        /// Text items to be searched
        /// </summary>
        public static List<string> SearchTextItems
        {
            get
            {
                var textItems = new List<string>()
                {
                    "This is sentence one that contains the word horse",
                    "This is sentence two that contains the word dog",
                    "This is sentence three that contains the word cat",
                    "This is sentence four that contains the word zebra",
                    "This is sentence five that contains the word donkey",
                    "This is sentence six that contains the word giraffe",
                    "This is sentence seven that contains the word rabbit",
                    "This is sentence eight that contains the word wolf",
                    "This is sentence nine that contains the owl",
                    "This is sentence ten that contains the goat",
                };
                return textItems;
            }
        }
    }
}
