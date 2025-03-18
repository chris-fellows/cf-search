using CFSearch.Interfaces;
using CFSearch.Models;
using CFSearch.Services;
using System.ComponentModel.DataAnnotations;

namespace CFSearch.xUnit
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var searchText = "-(owl,horse)";
            var searchConfig = new SearchConfig();

            ISearchOptionsService searchOptionsService = new SearchOptionsService1(searchConfig);
            ISearchEvaluatorService searchEvaluatorService = new SearchEvaluatorService();

            var searchOptions = searchOptionsService.Get(searchText, true);

            int xxx = 1000;

            var results = searchEvaluatorService.IsMatches(searchOptions, "This is an oywl or a donkey");

            int xxxxx = 1000;
            
        }
    }
}