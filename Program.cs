// Michael Backman Section 001
// Mission #3 Assignment
using Mission3;
using System;
using System.Collections.Generic;

namespace Mission3
{
    class Program
    {
        static List<FoodItem> inventory = new List<FoodItem>();

        static void Main(string[] args)
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("\nFood Bank Inventory System");
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. Add Food Item");
                Console.WriteLine("2. Delete Food Item");
                Console.WriteLine("3. Print List of Current Food Items");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice (1-4): ");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    AddFoodItem();
                    NewAction(ref isRunning);
                }
                else if (choice == "2")
                {
                    DeleteFoodItem();
                    NewAction(ref isRunning);
                }
                else if (choice == "3")
                {
                    PrintInventory();
                    NewAction(ref isRunning);
                }
                else if (choice == "4")
                {
                    Console.WriteLine("Exiting the program. Goodbye!");
                    isRunning = false;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }
            }
        }

        static void AddFoodItem()
        {
            try
            {
                Console.WriteLine("Enter the name of the new food item: ");
                string name = Console.ReadLine();

                Console.WriteLine("Enter the description of the new food item: ");
                string category = Console.ReadLine();

                Console.WriteLine("Enter the quantity: ");
                int quantity = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter the expiration date (YYYY-MM-DD): ");
                DateTime expirationDate = DateTime.Parse(Console.ReadLine());

                FoodItem newItem = new FoodItem(name, category, quantity, expirationDate);
                inventory.Add(newItem);
                Console.WriteLine("Food Item added.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }

        static void DeleteFoodItem()
        {
            try
            {
                Console.Write("Enter the name of the food item to delete: ");
                string name = Console.ReadLine();

                FoodItem deleteItem = inventory.Find(item => item.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

                if (deleteItem != null)
                {
                    inventory.Remove(deleteItem);
                    Console.WriteLine("Food Item deleted.");
                }
                else
                {
                    Console.WriteLine("Food Item does not exist.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }

        static void PrintInventory()
        {
            if (inventory.Count == 0)
            {
                Console.WriteLine("There are no items in inventory.");
            }
            else
            {
                Console.WriteLine("\nCurrent food items in inventory:");
                foreach (var item in inventory)
                {
                    Console.WriteLine(item);
                }
            }
        }

        static void NewAction(ref bool isRunning)
        {
            Console.Write("\nWould you like to do another action? (y/n): ");
            string response = Console.ReadLine();
            
            if (response.ToLower() == "n")
            {
                Console.WriteLine("Exiting the program. Goodbye!");
                isRunning = false;
            }
            else if (response.ToLower() != "y")
            {
                Console.WriteLine("Invalid input. Exiting the program.");
                isRunning = false;
            }
        }
    }
}
