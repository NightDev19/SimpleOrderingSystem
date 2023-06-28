# SimpleOrderingSystem
The Food Ordering System is a console application developed in C# that allows users to place food orders, view order history, and generate receipts. The system provides a menu with food options, calculates the total price of the order, and accepts payment. The order details are then stored in the order history.

## Prerequisites

To run the Food Ordering System, ensure that you have the following:

- [.NET Core SDK](https://dotnet.microsoft.com/download) installed on your machine.

## Running the Application

1. Clone or download the code from the [Food Ordering System](https://github.com/NightDev19/SimpleOrderingSystem.git) repository.

2. Open a terminal or command prompt and navigate to the project directory.

3. Run the following command to build the application:
4. Once the build is successful, run the following command to start the application:

5. The Food Ordering System console application will start running. Follow the on-screen instructions to navigate through the system.

## Usage

The Food Ordering System provides the following options:

1. **Order Food**: Allows users to place food orders.

2. **Order History**: Displays the order history, including previous orders and their details.

3. **Exit**: Exits the application.

### Order Food

1. Select the "Order Food" option from the main menu.

2. The menu will be displayed, showing the available food items and their prices.

3. Enter the item number for each food item you wish to order. Enter "0" when you are finished ordering.

4. Once you have finished ordering, the order summary will be displayed, listing the items ordered and the total price.

5. Enter the payment amount when prompted.

6. If the payment amount is equal to or greater than the total, the change will be displayed, and the order will be placed.

7. If the payment amount is insufficient, the order will be canceled.

### Order History

1. Select the "Order History" option from the main menu.

2. The order history will be displayed, showing previous orders and their details.

## Customization

To customize the Food Ordering System, you can modify the following aspects:

- **Menu**: The list of food items and their corresponding prices can be updated in the `menu` list and `itemPrices` dictionary within the `OrderFood` method.

- **Output Messages**: You can modify the output messages, prompts, and error messages within the code to suit your requirements.

## Conclusion

The Food Ordering System is a simple console application that allows users to place food orders, view order history, and generate receipts. By following the provided documentation, you can run and customize the system according to your needs.

Enjoy using the Food Ordering System!
