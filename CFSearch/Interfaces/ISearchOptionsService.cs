using CFSearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFSearch.Interfaces
{
    /// <summary>
    /// Service to decode user entered search text in to SearchOptions
    /// </summary>
    public interface ISearchOptionsService
    {
        /// <summary>
        /// Returns SearchOptions from user entered text
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        SearchOptions Get(string search);
    }
}
