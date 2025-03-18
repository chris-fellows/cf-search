using CFSearch.Enums;
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
    /// Tests getting SearchOptions from user entered texy
    /// </summary>
    public class SearchOptionsTests
    {
        //[Fact]
        //public void Single_Word_Search_Returns_Correct_Search_Options()
        //{
        //    var searchConfig = new SearchConfig();
        //    ISearchOptionsService searchOptionsService = new SearchOptionsService(searchConfig);

        //    var words = new string[] { "owl" };
        //    var searchText = $"{words[0]}";
        //    var searchOptions = searchOptionsService.Get(searchText);

        //    Assert.True(searchOptions.Items.Count == 1);
        //    Assert.True(searchOptions.Items[0] is SearchItemValues);
        //    var searchItems = (SearchItemValues)searchOptions.Items[0];
        //    Assert.True(searchItems.AndOrValues == AndOr.And);  // Must contain all values
        //    Assert.True(searchItems.Condition == Condition.InValueList);            
        //    Assert.True(searchItems.Values.Count == 1 && 
        //            searchItems.Values.Contains(words[0]));                        
        //}

        //[Fact]
        //public void Two_Word_Search_Returns_Correct_Search_Options()
        //{
        //    var searchConfig = new SearchConfig();
        //    ISearchOptionsService searchOptionsService = new SearchOptionsService(searchConfig);

        //    var words = new string[] { "owl", "dog" };
        //    var searchText = $"{words[0]} {words[1]}";
        //    var searchOptions = searchOptionsService.Get(searchText);

        //    Assert.True(searchOptions.Items.Count == 1);
        //    Assert.True(searchOptions.Items[0] is SearchItemValues);
        //    var searchItems = (SearchItemValues)searchOptions.Items[0];
        //    Assert.True(searchItems.AndOrValues == AndOr.And);  // Must contain all values
        //    Assert.True(searchItems.Condition == Condition.InValueList);            
        //    Assert.True(searchItems.Values.Count == 2 &&
        //                searchItems.Values.Contains(words[0]) &&
        //                searchItems.Values.Contains(words[1]));

        //    int xxx = 1000;
        //}

        //[Fact]
        //public void Two_Word_List_Returns_Correct_Search_Options()
        //{
        //    var searchConfig = new SearchConfig();
        //    ISearchOptionsService searchOptionsService = new SearchOptionsService(searchConfig);

        //    var words = new string[] { "owl", "dog" };
        //    var searchText = $"({words[0]},{words[1]})";
        //    var searchOptions = searchOptionsService.Get(searchText);

        //    Assert.True(searchOptions.Items.Count == 1);
        //    Assert.True(searchOptions.Items[0] is SearchItemValues);
        //    var searchItems = (SearchItemValues)searchOptions.Items[0];
        //    Assert.True(searchItems.AndOrValues == AndOr.Or);  // Must contain any word
        //    Assert.True(searchItems.Condition == Condition.InValueList);
        //    Assert.True(searchItems.Values.Count == 2 &&
        //                searchItems.Values.Contains(words[0]) &&
        //                searchItems.Values.Contains(words[1]));

        //    int xxx = 1000;
        //}

        //[Fact]
        //public void Two_Word_Exclude_List_Returns_Correct_Search_Options()
        //{
        //    var searchConfig = new SearchConfig();
        //    ISearchOptionsService searchOptionsService = new SearchOptionsService(searchConfig);

        //    var words = new string[] { "owl", "dog" };
        //    var searchText = $"-({words[0]},{words[1]})";
        //    var searchOptions = searchOptionsService.Get(searchText);

        //    Assert.True(searchOptions.Items.Count == 1);
        //    Assert.True(searchOptions.Items[0] is SearchItemValues);
        //    var searchItems = (SearchItemValues)searchOptions.Items[0];
        //    Assert.True(searchItems.AndOrValues == AndOr.Or);  // Must contain any word
        //    Assert.True(searchItems.Condition == Condition.NotInValueList);
        //    Assert.True(searchItems.Values.Count == 2 &&
        //                searchItems.Values.Contains(words[0]) &&
        //                searchItems.Values.Contains(words[1]));

        //    int xxx = 1000;
        //}
    }
}
