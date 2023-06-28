using System;
namespace FoodOrderingSystem
{
     class Program
    {

        static List<string> orderHistory = new List<string>();

        private static void Main(string[] args)
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("====== Food Ordering System =====");
                Console.WriteLine("1. Order Food");
                Console.WriteLine("2. Order History");
                Console.WriteLine("3. Exit");
                Console.WriteLine("================================");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        OrderFood();
                        break;
                    case "2":
                        ShowOrderHistory();
                        break;
                    case "3":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine();
            }

        }

        static void OrderFood()
        {
            List<string> menu = new List<string>
    {
        "Burger",
        "Pizza",
        "Fries",
        "Salad",
        "Sandwich",
        "Sushi",
        "Pasta",
        "Chicken Wings",
        "Steak",
        "Ice Cream"
    };

            Dictionary<string, decimal> itemPrices = new Dictionary<string, decimal>
    {
        { "Burger", 5.99m },
        { "Pizza", 8.99m },
        { "Fries", 2.99m },
        { "Salad", 4.99m },
        { "Sandwich", 6.99m },
        { "Sushi", 10.99m },
        { "Pasta", 7.99m },
        { "Chicken Wings", 9.99m },
        { "Steak", 15.99m },
        { "Ice Cream", 3.99m }
    };

            Dictionary<string, int> orderDetails = new Dictionary<string, int>();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("===== Menu =====");
                for (int i = 0; i < menu.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {menu[i]} - ${itemPrices[menu[i]]}");
                }
                Console.WriteLine("0. Done Ordering");
                Console.WriteLine("================");

                Console.Write("Enter the item number to order (0 to finish): ");
                string input = Console.ReadLine();
                if (input == "0")
                {
                    break;
                }

                if (int.TryParse(input, out int itemNumber) && itemNumber >= 1 && itemNumber <= menu.Count)
                {
                    string selectedItem = menu[itemNumber - 1];

                    Console.Write($"Enter the quantity for {selectedItem}: ");
                    if (int.TryParse(Console.ReadLine(), out int quantity) && quantity >= 1)
                    {
                        if (orderDetails.ContainsKey(selectedItem))
                        {
                            orderDetails[selectedItem] += quantity;
                        }
                        else
                        {
                            orderDetails[selectedItem] = quantity;
                        }

                        Console.WriteLine($"{quantity} {selectedItem}(s) added to the order.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid quantity. Please try again.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid item number. Please try again.");
                }

                Console.WriteLine();
            }

            if (orderDetails.Count > 0)
            {
                Console.Clear();
                Console.WriteLine("===== Order Summary =====");
                Console.WriteLine("Item\t\tQuantity\tPrice\t\tTotal");
                Console.WriteLine("-----------------------------------------------");
                decimal total = 0;
                foreach (var item in orderDetails)
                {
                    string itemName = item.Key;
                    int quantity = item.Value;
                    decimal price = itemPrices[itemName];
                    decimal itemTotal = price * quantity;
                    total += itemTotal;

                    Console.WriteLine($"{itemName}\t\t{quantity}\t\t${price}\t\t${itemTotal}");
                }
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine($"Total:\t\t\t\t\t\t${total}");

                Console.WriteLine();

                Console.Write("Proceed with the order? (Y/N): ");
                string proceedChoice = Console.ReadLine();
                if (proceedChoice.ToUpper() == "Y")
                {
                    Console.Write("Enter the payment amount: $");
                    if (decimal.TryParse(Console.ReadLine(), out decimal paymentAmount))
                    {
                        if (paymentAmount >= total)
                        {
                            decimal change = paymentAmount - total;
                            Console.WriteLine($"Change: ${change}");

                            string orderDetailsString = GenerateOrderDetailsString(orderDetails, itemPrices, total, paymentAmount, change);
                            orderHistory.Add(orderDetailsString);

                            Console.WriteLine("Order placed successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Insufficient payment. Order canceled.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid payment amount. Order canceled.");
                    }
                }
                else
                {
                    Console.WriteLine("Order canceled. Thank you for visiting our store.");
                }
            }
            else
            {
                Console.WriteLine("No items ordered.");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        static void ShowOrderHistory()
        {
            if (orderHistory.Count > 0)
            {
                Console.Clear();
                Console.WriteLine("===== Order History =====");
                foreach (string order in orderHistory)
                {
                    Console.WriteLine(order);
                    Console.WriteLine("==================================");
                }
            }
            else
            {
                Console.WriteLine("No order history available.");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        static string GenerateOrderDetailsString(Dictionary<string, int> orderDetails, Dictionary<string, decimal> itemPrices, decimal total, decimal paymentAmount, decimal change)
        {
            string orderDetailsString = "===== Order Details =====\n";
            orderDetailsString += "Item\t\tQuantity\tPrice\t\tTotal\n";
            orderDetailsString += "----------------------------------------------------\n";

            foreach (var item in orderDetails)
            {
                string itemName = item.Key;
                int quantity = item.Value;
                decimal price = itemPrices[itemName];
                decimal itemTotal = price * quantity;

                orderDetailsString += $"{itemName}\t\t{quantity}\t\t${price}\t\t${itemTotal}\n";
            }

            orderDetailsString += "----------------------------------------------------\n";
            orderDetailsString += $"Total:\t\t\t\t\t\t${total}\n";
            orderDetailsString += $"Payment:\t\t\t\t\t${paymentAmount}\n";
            orderDetailsString += $"Change:\t\t\t\t\t\t${change}\n";

            return orderDetailsString;
        }


    }
}
