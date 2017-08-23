Feature: GooleSearch
	


Scenario: SearchGoogleName
	Given I have google website open
	And I have entered "text" to search
	When I press search
	Then the result page sould be on the screen



Scenario: SearchGoogleCity
	Given I have google website open
	And I have entered "text" to search
	When I press search
	Then the result page sould be on the screen
