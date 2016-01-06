Feature: MainWindow

Scenario: Application starts with no data loaded
	Given I have started web browser
		And I navigated to application URL
	Then Budget list is empty

Scenario: Application starts data is loaded after button click
	Given I have started web browser
		And I navigated to application URL
	When I click Get Budgets button
		And Wait for 5 seconds
	Then Budget list is not empty
