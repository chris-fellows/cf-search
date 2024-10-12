using CFSearch.Enums;
using CFSearch.Interfaces;
using CFSearch.Models;
using System.Text.RegularExpressions;

namespace CFSearch.Services
{
    public class SearchEvaluatorService : ISearchEvaluatorService
    {
        public bool IsMatches(SearchOptions searchOptions, string text)
        {            
            int countMatches = 0;
            int countNotMatches = 0;
            foreach(var searchItem in searchOptions.Items)
            {
                // Evaluate search item
                var isMatched = searchItem switch
                {
                    SearchItemRegEx => IsMatchesItem((SearchItemRegEx)searchItem, text),
                    SearchItemValues => IsMatchesItem((SearchItemValues)searchItem, text),
                    _ => false
                };

                if (isMatched)
                {
                    countMatches++;                   
                }
                else
                {
                    countNotMatches++;
                }
            }

            return searchOptions.AndOrItems == AndOr.And ?
                 (countMatches > 0 && countNotMatches == 0) :
                 (countMatches > 0);            
        }

        /// <summary>
        /// Whether search item of regex matches text
        /// </summary>
        /// <param name="searchItem"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        private bool IsMatchesItem(SearchItemRegEx searchItem, string text)
        {
            Regex regex = new Regex(searchItem.Expression);

            switch(searchItem.Condition)
            {
                case Condition.MatchesRegEx:
                    return regex.IsMatch(text);
                case Condition.NotMatchesRegEx:
                    return !regex.IsMatch(text);
            }

            return false;
        }

        /// <summary>
        /// Whether search item of values matches text
        /// </summary>
        /// <param name="searchItem"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        private bool IsMatchesItem(SearchItemValues searchItem, string text)
        {
            bool isMatches = false;
     
            switch(searchItem.Condition)
            {
                case Condition.InValueList:
                    {
                        int countValuesMatched = 0;
                        int countValuesNotMatched = 0;

                        foreach (var value in searchItem.Values)
                        {
                            if (searchItem.CaseSensitive)
                            {
                                if (text.Contains(value))
                                {
                                    countValuesMatched++;
                                }
                                else
                                {
                                    countValuesNotMatched++;
                                }
                            }
                            else
                            {
                                if (text.Contains(value, StringComparison.InvariantCultureIgnoreCase))
                                {
                                    countValuesMatched++;
                                }
                                else
                                {
                                    countValuesNotMatched++;
                                }
                            }
                        }

                        switch (searchItem.AndOrValues)
                        {
                            case AndOr.And:
                                return countValuesMatched > 0 && countValuesNotMatched == 0;
                            case AndOr.Or:
                                return countValuesMatched > 0;
                        }
                    }
                    break;
                case Condition.NotInValueList:
                    {
                        int countValuesMatched = 0;
                        int countValuesNotMatched = 0;
                      
                        // Values=[Word1,Word2] Text="This is Word4 and something else"
                        foreach (var value in searchItem.Values)
                        {
                            if (searchItem.CaseSensitive)
                            {
                                if (text.Contains(value))
                                {
                                    countValuesMatched++;
                                }
                                else
                                {
                                    countValuesNotMatched++;
                                }
                            }
                            else
                            {
                                if (text.Contains(value, StringComparison.InvariantCultureIgnoreCase))
                                {
                                    countValuesMatched++;
                                }
                                else
                                {
                                    countValuesNotMatched++;
                                }
                            }
                        }

                        // Don't need to check And/Or
                        return countValuesMatched == 0;                    
                    }
                    break;
            }

            return isMatches;
        }
    }
}
