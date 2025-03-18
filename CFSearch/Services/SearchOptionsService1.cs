using CFSearch.Enums;
using CFSearch.Interfaces;
using CFSearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFSearch.Services
{
    /// <summary>
    /// Search options format 1:
    /// 
    /// Formats:
    /// "word1" = Contains word.
    /// "-word1" = Does not contain word.
    /// "(word1,word2)" = Contains any word word.
    /// "-(word1,word2)" = Does not contain any word
    /// 
    /// </summary>
    public class SearchOptionsService1 : ISearchOptionsService
    {
        private readonly SearchConfig _searchConfig;
        private const string _regExMatchesPrefix = "#REGEXMATCHES#";
        private const string _regExNotMatchesPrefix = "#REGEXNOTMATCHES#";

        public SearchOptionsService1(SearchConfig searchConfig)
        {
            _searchConfig = searchConfig;
        }

        /// <summary>
        /// Gets search options for values
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        private SearchOptions GetValues(string search, bool caseSensitive)
        {          
            StringBuilder value = new StringBuilder("");
            bool isQuotesActive = false;
            bool isListActive = false;

            // Search single group
            var searchItemGroup = new SearchItemGroup()
            {
                Items = new(),
                AndOrItems = AndOr.Or
            };

            // Set current values to accumulate
            var values = new List<string>();
            var valuesCondition = Condition.InValueList;

            // Process characters
            for (int charIndex = 0; charIndex < search.Length; charIndex++)
            {
                // Get current & next char
                Char character = search[charIndex];
                Char? nextCharacter = charIndex < search.Length - 1 ? search[charIndex + 1] : null;
    
                // Whether to add character to value. If it's one of the special characters then we change to false.
                bool isAddCharacterToValue = true;  // Default;

                if (isQuotesActive)   // Quotes active
                {
                    // If quotes active then we just need to add the character to the current value unless it's end quotes
                    if (character == _searchConfig.QuotesChar)   // End quote for value
                    {
                        // Add value to list
                        if (value.Length > 0)
                        {                            
                            values.Add(value.ToString());
                            value.Length = 0;
                        }
                        isQuotesActive = false;
                        isAddCharacterToValue = false;
                    }
                }
                else     // Quotes not active
                {
                    // Check character
                    if (character == _searchConfig.ExcludeChar)
                    {                        
                        valuesCondition = Condition.NotInValueList;
                        isAddCharacterToValue = false;
                    }

                    if (character == _searchConfig.ListStartChar)
                    {
                        isListActive = true;    
                        values = new();
                        isAddCharacterToValue = false;
                    }

                    if (character == _searchConfig.ListEndChar)
                    {
                        isListActive = false;

                        // Add value to list
                        if (value.Length > 0)
                        {                            
                            values.Add(value.ToString());
                            value.Length = 0;
                        }                        
                        if (values.Any())
                        {
                            // Create search item of values
                            var searchItemValues = new SearchItemValues()
                            {
                                Condition = valuesCondition,
                                Values = values
                            };

                            // Add to group
                            searchItemGroup.Items.Add(searchItemValues);
                        }

                        // Reset values                        
                        values = new();
                        valuesCondition = Condition.InValueList;

                        isAddCharacterToValue = false;
                    }

                    if (character == _searchConfig.ListItemSepChar)
                    {
                        // Add value to list
                        if (value.Length > 0)
                        {                            
                            values.Add(value.ToString());
                            value.Length = 0;
                        }
                        isAddCharacterToValue = false;
                    }

                    if (character == _searchConfig.SpaceChar)
                    {
                        // Add value to list
                        if (value.Length > 0)
                        {
                            //searchItem.Values.Add(value.ToString());
                            values.Add(value.ToString());
                            value.Length = 0;
                        }
                        isAddCharacterToValue = false;
                    }

                    if (character == _searchConfig.QuotesChar)
                    {
                        if (isQuotesActive) // Quotes to end value
                        {
                            if (value.Length > 0)
                            {
                                //searchItem.Values.Add(value.ToString());
                                values.Add(value.ToString());
                                value.Length = 0;
                            }

                            isQuotesActive = false;
                        }
                        else   // Quotes to start value
                        {
                            isQuotesActive = true;
                            value.Length = 0;
                        }

                        isAddCharacterToValue = false;
                    }
                }

                // Add character to value
                if (isAddCharacterToValue)
                {
                    value.Append(character);
                }
            }

            // If we have an active search item then add to list. If we processed "Word1 Word2" then this will add 
            if (value.Length > 0)
            {
                values.Add(value.ToString());
                value.Length = 0;
            }

            // Add any final search item
            if (values.Any())
            {
                var searchItemValues = new SearchItemValues()
                {
                    Condition = valuesCondition,
                    Values = values,                    
                };

                searchItemGroup.Items.Add(searchItemValues);
            }

            // If the group only has one child item then we could make that the root item
            return new SearchOptions()
            {
                CaseSensitive = caseSensitive,
                RootSearchItem = searchItemGroup                
            };
        }

        ///// <summary>
        ///// Gets SearchOptions for regex
        ///// </summary>
        ///// <param name="search"></param>
        ///// <returns></returns>
        //private SearchOptions GetRegEx(string search)
        //{
        //    var searchOptions = new SearchOptions() { Items = new List<SearchItemBase>(), AndOrItems = AndOr.And };

        //    // Add search item
        //    var searchItem = new SearchItemRegEx()
        //    {
        //        AndOrValues = AndOr.And
        //    };
        //    searchOptions.Items.Add(searchItem);
            
        //    if (search.StartsWith(_regExMatchesPrefix))
        //    {
        //        searchItem.Condition = Condition.MatchesRegEx;
        //        searchItem.Expression = search.Substring(_regExMatchesPrefix.Length + 1);
        //    }
        //    else if (search.StartsWith(_regExNotMatchesPrefix))
        //    {
        //        searchItem.Condition = Condition.NotMatchesRegEx;
        //        searchItem.Expression = search.Substring(_regExNotMatchesPrefix.Length + 1);
        //    }
     
        //    return searchOptions;
        //}

        public SearchOptions Get(string search, bool caseSensitive)
        {
            //if (search.StartsWith(_regExMatchesPrefix) || search.StartsWith(_regExNotMatchesPrefix))
            //{
            //    return GetRegEx(search);
            //}
            return GetValues(search, caseSensitive);
        }
    }
}
