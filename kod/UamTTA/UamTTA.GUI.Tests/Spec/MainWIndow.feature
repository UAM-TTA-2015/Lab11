Feature: MainWindow

Scenario: Application starts with no data loaded
	Given I have started the application
		And I can see application window
	Then Budget list is empty

Scenario: Application starts data is loaded after button click
	Given I have started the application
		And I can see application window
	When I click Get Budgets button
		And Wait for 5 second
	Then Budget list is not empty
