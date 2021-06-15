Set yourself a time limit and stick to it. We do not expect everyone to complete all tasks so prioritize your time well!

Please make sure the project builds and runs before you start. If you have any issues please post in the teams chat.

List of tasks to complete:
1.Restructure the code into more logical parts (think models, controllers, services, etc)

2.Add functionality for a user to create a new trade. This should include a new angular component and a new API endpoint

3.Add functionality for a user to edit an existing trade. This should include a new angular component and a new API endpoint (or you can add edit functionality to the create component)

4.Add functionality for a user to delete a trade. This should include a new angular component and a new API endpoint

5.Change the trades property in the fetch-trades.component from an array of BinaryTrade into an observable.

6.Create a header component that shows on every page which shows the total amount of all trades (sum up all the amount properties of all the trades).

7.The reports component contains 2 reports that are currently empty. Create the following reports display the data: 
  the most popular assets in descending order and another report showing each asset and the total number of long/short positions (trade direction either 1 or 0).
  For example "AUD/USD", long - 3, short - 2 (this would mean 5 trades total for the "AUD/USD" asset with 3 trades with a direction of 1 and 2 trades with a direction of 0)

8.Add unit tests using your framework of choice to test the CRUD operations in both the frontend and backend. 

9.Add one more piece of core functionality to the app that you feel is missing.
