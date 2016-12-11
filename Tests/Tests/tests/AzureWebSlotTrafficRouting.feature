Feature: AzureWebSlotTrafficRouting
	In order to A/B test using the Staging and Production slots 
	As a route me administrator
	I want to have an automated approach to test the alpha environment to allow automated scaling up or down of the percentage of users hitting the alpha environment

@basic
Scenario: GetRoutingDirection - Routing to alpha increasing
Given I have a build with no problem
	And I have a default of 10% with a 5% increment
When I deploy a new staging build
Then I expect to see the percentage of traffic go up to 15%

@validation
Scenario Outline: GetRoutingDirection - Routing to alpha decreasing
Given I have a build with <Problem>
	And I have a default of 10% with a 5% increment
When I deploy a new staging build
Then I expect to see the the percentage of traffic go down to <Staging Routing Percentage>

Examples: Technical issues
	 | Problem            | Azure API | Azure API Metric                           | Description                         | Staging Routing Percentage |
	 | Router issues      | metrics   | availabilityResults/availabilityPercentage | As determined load testing on Azure | 5%                         |
	 | Javascript errors  | metrics   | exceptions/browser                         | Application insights                | 0%                         |
	 | Server side errors | metrics   | exceptions/server                          | Application insights                | 0%                         |
	 | Latency regression | metrics   | browserTimings/receiveDuration             | Must be less than 20% regression    | 5%                         |

Examples: Business issues
	 | Problem                             | Azure API | Azure API Metric   | Description                                   | Staging Routing Percentage |
	 | Customer conversion regression      | events    | customEvents       | Are users getting through the sales funnel.   | 5%                         |
	 | Customer bounce rate                | metrics   | pageViews/count    | How far do users get through our sales funnel | 5%                         |
	 | Customer average time spent on page | metrics   | pageViews/duration | Are users engaged enough with content?        | 5%                         |
																															                             
 Examples: Many issues
	 | Problem                                                    | Azure API | Azure API Metric | Description                 | Staging Routing Percentage |
	 | Server side errors & Latency regression                    | N/A       | N/A              | Many technical              | 0%                         |
	 | Customer bounce rate & Customer average time spent on page | N/A       | N/A              | Many business               | 5%                         |
	 | All issue types                                            | N/A       | N/A              | Many technical and business | 0%                         |
																																			                               
																																			                               