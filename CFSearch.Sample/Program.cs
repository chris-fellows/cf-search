using CFSearch.Interfaces;
using CFSearch.Models;
using CFSearch.Services;

Char quotes = (Char)'"';

var searchConfig = new SearchConfig();
ISearchOptionsService searchOptionsService = new SearchOptionsService1(searchConfig);
ISearchEvaluatorService searchEvaluatorService = new SearchEvaluatorService();

//var result = searchOptionsService.Get("##REGEX## abcdeghij");
//var options = searchOptionsService.Get("(one,two,five) (donkey,owl)");

// Prompt user to search
do
{    
    // Search text items to search
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
    Console.WriteLine("Items to search:");
    textItems.ForEach(textItem => Console.WriteLine(textItem));
    Console.WriteLine("");

    Console.WriteLine("Enter search or EXIT to exit:");
    var search = Console.ReadLine();
    if (search == "EXIT")
    {
        break;
    }
    else if (!String.IsNullOrEmpty(search))
    {
        var searchOptions = searchOptionsService.Get(search);
        var textItemsMatches = textItems.Select(text => searchEvaluatorService.IsMatches(searchOptions, text, false)).ToList();

        // Write matched
        Console.WriteLine($"Search found {textItemsMatches.Count(i => i == true)} items:");
        for (int index = 0; index < textItemsMatches.Count; index++)
        {
            if (textItemsMatches[index])
            {
                Console.WriteLine($"{textItems[index]}");
            }
        }        
        Console.WriteLine("--------------------------------------------------------------");
        Console.WriteLine("");
    }
} while (true);

// Get search options for user entered search
//var searchOptions1 = searchOptionsService.Get("Word1 Word2");     // Contains all words
//var searchOptions2 = searchOptionsService.Get("-Word1 -Word2");          // Does not contain word
//var searchOptions3 = searchOptionsService.Get("(Word1,Word2,Word3)");      // Contains any word
//var isMatched3 = searchEvaluatorService.IsMatches(searchOptions3, "This sentence contains Word3 x");
var searchOptions4 = searchOptionsService.Get("-(Word1,Word2,Word3)");     // Does not contain any word
//var isMatched4 = searchEvaluatorService.IsMatches(searchOptions4, "This sentence contains Word5 x");

//var searchOptions5 = searchOptionsService.Get($"{quotes}Test with quotes{quotes}");       // Contains phrase
//var searchOptions6 = searchOptionsService.Get($"-{quotes}Test with quotes{quotes}");      // Does not contain phrase
//var searchOptions7 = searchOptionsService.Get($"({quotes}Value one{quotes},{quotes}Value two{quotes},{quotes}Value three{quotes})");
//var searchOptions8 = searchOptionsService.Get($"-({quotes}Value one{quotes},{quotes}Value two{quotes},{quotes}Value three{quotes})");

int xxx = 1000;

