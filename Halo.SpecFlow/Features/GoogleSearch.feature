Feature: GoogleSearch
	I want to search cricket on google search

@GoogleSearch
Scenario: Can find search results
	Given I am on the google page
	When I enter search term as "Cricket"
	And I click search
	Then I should see title "Cricket - Google Search"

