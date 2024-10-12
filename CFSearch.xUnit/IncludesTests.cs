using CFSearch.Interfaces;
using CFSearch.Models;
using CFSearch.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CFSearch.Services;

namespace CFSearch.xUnit
{
    /// <summary>
    /// Tests for search by including words
    /// </summary>
    public class IncludesTests
    {
        [Fact]
        public void Search_One_Word_Finds_All_Items()
        {
            var searchConfig = new SearchConfig();
            ISearchOptionsService searchOptionsService = new SearchOptionsService(searchConfig);
            ISearchEvaluatorService searchEvaluatorService = new SearchEvaluatorService();

            var searchTexts = TestUtilities.SearchTextItems;
            var words = new string[] { "owl" };
            var searchText = words[0];
      
            var searchOptions = searchOptionsService.Get(searchText);
            var searchTextsMatches = searchTexts.Where(text => searchEvaluatorService.IsMatches(searchOptions, text)).ToList();
            var searchTextsExpected = searchTexts.Where(text => text.Contains(words[0])).ToList();

            Assert.True(searchTextsMatches.SequenceEqual(searchTextsExpected));            
        }

        [Fact]
        public void Search_Two_Words_Finds_All_Items_With_All_Words()
        {
            var searchConfig = new SearchConfig();
            ISearchOptionsService searchOptionsService = new SearchOptionsService(searchConfig);
            ISearchEvaluatorService searchEvaluatorService = new SearchEvaluatorService();

            var searchTexts = TestUtilities.SearchTextItems;
            var words = new string[] { "owl", "nine" };
            var searchText = words[0];

            var searchOptions = searchOptionsService.Get(searchText);
            var searchTextsMatches = searchTexts.Where(text => searchEvaluatorService.IsMatches(searchOptions, text)).ToList();
            var searchTextsExpected = searchTexts.Where(text => text.Contains(words[0]) && text.Contains(words[1])).ToList();   // Text contains all words

            Assert.True(searchTextsMatches.SequenceEqual(searchTextsExpected));
        }

        [Fact]
        public void Search_Word_List_Finds_Items_With_Any_Word()
        {
            var searchConfig = new SearchConfig();
            ISearchOptionsService searchOptionsService = new SearchOptionsService(searchConfig);
            ISearchEvaluatorService searchEvaluatorService = new SearchEvaluatorService();
            
            var searchTexts = TestUtilities.SearchTextItems;
            var words = new string[] { "owl", "cat", "zebra" };
            var searchText = $"({words[0]},{words[1]},{words[2]})";

            var searchOptions = searchOptionsService.Get(searchText);
            var searchTextsMatches = searchTexts.Where(text => searchEvaluatorService.IsMatches(searchOptions, text)).ToList();
            var searchTextsExpected = searchTexts.Where(text => text.Contains(words[0]) ||
                                    text.Contains(words[1]) ||
                                    text.Contains(words[2])).ToList();

            Assert.True(searchTextsMatches.SequenceEqual(searchTextsExpected));                                   
        }

        [Fact]
        public void Search_Quoted_Phrase_Words_Finds_Items_With_Exact_Phrase()
        {
            var searchConfig = new SearchConfig();
            ISearchOptionsService searchOptionsService = new SearchOptionsService(searchConfig);
            ISearchEvaluatorService searchEvaluatorService = new SearchEvaluatorService();

            var searchTexts = TestUtilities.SearchTextItems;
            var words = new string[] { "sentence", "seven" };
            var searchText = $"\"{words[0]} {words[1]}\"";

            var searchOptions = searchOptionsService.Get(searchText);
            var searchTextsMatches = searchTexts.Where(text => searchEvaluatorService.IsMatches(searchOptions, text)).ToList();
            var searchTextsExpected = searchTexts.Where(text => text.Contains($"{words[0]} {words[1]}")).ToList();            

            Assert.True(searchTextsMatches.SequenceEqual(searchTextsExpected));
        }
    }
}
