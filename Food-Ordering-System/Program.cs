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

            List<string> orderedItems = new List<string>();
            decimal total = 0;

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
                    orderedItems.Add(selectedItem);
                    total += itemPrices[selectedItem];
                    Console.WriteLine($"{selectedItem} added to the order.");
                }
                else
                {
                    Console.WriteLine("Invalid item number. Please try again.");
                }

                Console.WriteLine();
            }

            if (orderedItems.Count > 0)
            {
                Console.Clear();
                Console.WriteLine("===== Order Summary =====");
                Console.WriteLine("Items Ordered:");
                foreach (string item in orderedItems)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("=========================");
                Console.WriteLine($"Total: ${total}");

                Console.Write("Enter the payment amount: $");
                if (decimal.TryParse(Console.ReadLine(), out decimal paymentAmount))
                {
                    if (paymentAmount >= total)
                    {
                        decimal change = paymentAmount - total;
                        Console.WriteLine($"Change: ${change}");

                        string orderDetails = $"Items Ordered: {string.Join(", ", orderedItems)}\nTotal: ${total}\nPayment: ${paymentAmount}\nChange: ${change}";
                        orderHistory.Add(orderDetails);

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

    }
}