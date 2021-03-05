# Kaplan .NET Developer Interview Challenge

## Recommended Tools

* Visual Studio 2019 - The Community Edition is available for you to use for individual use.

## System Notes
* The project contains an in memory database. Modification of the classes in WebApiTest.Data is not required.
* Orders have both an ordering customer and can contain multiple students tied to each item ordered.

## Code Tasks
1. Find and fix the following bugs in the REST API:
  - The web service call to GET /OrderSummary/101 fails
  - The Post to /Orders/101 with the following payload fails

		{
			"lineNumber": 0,
			"productID": 2,
			"studentPersonID": 3,
			"price": 150
		}

2. Create a new resource to delete an Item from the order.

3. Change the OrderItems GET resource to return a 404 when the OrderID does not exist in the database and add a unit test for it.