# cf-search

Mechanism for converting a free format search string entered by a user into a structure that the 
system can understand and then evaluating this structure against a list of items.

Example						Description
-------						-----------
Word1						Text contains the word
-Word1						Text does not contain word
Word1 Word2 Word3			Text contains all of the words
-(Word1,Word2,Word3)		Text does not contain any of the words
#REGEXMATCHES# MyPattern	Text matches regex pattern MyPattern
#REGEXNOTMATCHES# MyPattern Text does not match regex pattern MyPattern

Sample App
----------
The sample app demonstrates use of the functionality.

Interfaces
----------
ISearchOptionsService  : Converts free format search string in to SearchOptions instances.
ISearchEvaluatorService: Evaluates if a text string matches a SearchOptions instance.

