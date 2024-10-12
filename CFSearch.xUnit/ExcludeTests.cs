using CFSearch.Interfaces;
using CFSearch.Models;
using CFSearch.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFSearch.xUnit
{ 
    /// <summary>
    /// Tests for search by excluding words
    /// </summary>
    public class ExcludeTests
    {
        private static StringComparison GetStringComparison(bool caseSensitive)
        {
            return caseSensitive ? StringComparison.InvariantCulture : StringComparison.InvariantCultureIgnoreCase;
        }

        private static void SetUpperCase(ref string[] words)
        {
            for (int index = 0; index < words.Length; index++)
            {
                words[index] = words[index].ToUpper();
            }
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void Search_One_Word_Finds_Items_Without_Word(bool caseSensitive)
        {
            var searchConfig = new SearchConfig();
            ISearchOptionsService searchOptionsService = new SearchOptionsService(searchConfig);
            ISearchEvaluatorService searchEvaluatorService = new SearchEvaluatorService();

            var searchTexts = TestUtilities.SearchTextItems;
            var words = new string[] { "owl" };
            if (!caseSensitive) SetUpperCase(ref words);
            var searchText = $"-{words[0]}";

            var searchOptions = searchOptionsService.Get(searchText);
            var searchTextsMatches = searchTexts.Where(text => searchEvaluatorService.IsMatches(searchOptions, text, caseSensitive)).ToList();
            var searchTextsExpected = searchTexts.Where(text => !text.Contains(words[0], GetStringComparison(caseSensitive))).ToList();

            Assert.True(searchTextsMatches.SequenceEqual(searchTextsExpected));
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void Search_Two_Words_Finds_Items_Without_Any_Word(bool caseSensitive)
        {
            var searchConfig = new SearchConfig();
            ISearchOptionsService searchOptionsService = new SearchOptionsService(searchConfig);
            ISearchEvaluatorService searchEvaluatorService = new SearchEvaluatorService();

            var searchTexts = TestUtilities.SearchTextItems;
            var words = new string[] { "owl", "nine" };
            if (!caseSensitive) SetUpperCase(ref words);
            var searchText = $"-{words[0]} -{words[1]}";

            var searchOptions = searchOptionsService.Get(searchText);
            var searchTextsMatches = searchTexts.Where(text => searchEvaluatorService.IsMatches(searchOptions, text, false)).ToList();
            var searchTextsExpected = searchTexts.Where(text => !text.Contains(words[0], GetStringComparison(caseSensitive)) && 
                            !text.Contains(words[1], GetStringComparison(caseSensitive))).ToList();   // Text contains all words

            Assert.True(searchTextsMatches.SequenceEqual(searchTextsExpected));
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void Search_Word_List_Finds_Items_Without_Any_Word(bool caseSensitive)
        {
            var searchConfig = new SearchConfig();
            ISearchOptionsService searchOptionsService = new SearchOptionsService(searchConfig);
            ISearchEvaluatorService searchEvaluatorService = new SearchEvaluatorService();

            var searchTexts = TestUtilities.SearchTextItems;
            var words = new string[] { "owl", "cat", "zebra" };
            if (!caseSensitive) SetUpperCase(ref words);
            var searchText = $"-({words[0]},{words[1]},{words[2]})";

            var searchOptions = searchOptionsService.Get(searchText);
            var searchTextsMatches = searchTexts.Where(text => searchEvaluatorService.IsMatches(searchOptions, text, false)).ToList();
            var searchTextsExpected = searchTexts.Where(text => !text.Contains(words[0], GetStringComparison(caseSensitive)) &&
                                    !text.Contains(words[1], GetStringComparison(caseSensitive)) &&
                                    !text.Contains(words[2], GetStringComparison(caseSensitive))).ToList();

            Assert.True(searchTextsMatches.SequenceEqual(searchTextsExpected));
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void Search_One_Quoted_Phrase_Finds_Items_Without_Exact_Phrase(bool caseSensitive)
        {
            var searchConfig = new SearchConfig();
            ISearchOptionsService searchOptionsService = new SearchOptionsService(searchConfig);
            ISearchEvaluatorService searchEvaluatorService = new SearchEvaluatorService();

            var searchTexts = TestUtilities.SearchTextItems;
            var words = new string[] { "sentence", "seven" };
            if (!caseSensitive) SetUpperCase(ref words);
            var searchText = $"-\"{words[0]} {words[1]}\"";

            var searchOptions = searchOptionsService.Get(searchText);
            var searchTextsMatches = searchTexts.Where(text => searchEvaluatorService.IsMatches(searchOptions, text, false)).ToList();
            var searchTextsExpected = searchTexts.Where(text => !text.Contains($"{words[0]} {words[1]}", GetStringComparison(caseSensitive))).ToList();

            Assert.True(searchTextsMatches.SequenceEqual(searchTextsExpected));
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void Search_Quoted_Phrases_List_Finds_Items_Without_Exact_Phrase(bool caseSensitive)
        {
            var searchConfig = new SearchConfig();
            ISearchOptionsService searchOptionsService = new SearchOptionsService(searchConfig);
            ISearchEvaluatorService searchEvaluatorService = new SearchEvaluatorService();

            var searchTexts = TestUtilities.SearchTextItems;
            var words1 = new string[] { "sentence", "seven" };
            if (!caseSensitive) SetUpperCase(ref words1);
            var words2 = new string[] { "sentence", "nine" };
            if (!caseSensitive) SetUpperCase(ref words2);
            var searchText = $"-(\"{words1[0]} {words1[1]}\" \"{words2[0]} {words2[1]}\")";

            var searchOptions = searchOptionsService.Get(searchText);
            var searchTextsMatches = searchTexts.Where(text => searchEvaluatorService.IsMatches(searchOptions, text, false)).ToList();
            var searchTextsExpected = searchTexts.Where(text => !text.Contains($"{words1[0]} {words1[1]}", GetStringComparison(caseSensitive)) &&
                                !text.Contains($"{words2[0]} {words2[1]}", GetStringComparison(caseSensitive))).ToList();

            Assert.True(searchTextsMatches.SequenceEqual(searchTextsExpected));
        }
    }
}
