using System;
using System.Collections.Generic;
using Mission__3;

namespace FoodBankInventorySystem
{
    class Program
    {
        static List<FoodItem> inventory = new List<FoodItem>();

        static void Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Food Bank Inventory System");
                Console.WriteLine("1. Add Food Item");
                Console.WriteLine("2. Delete Food Item");
                Console.WriteLine("3. Print List of Current Food Items");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddFoodItem();
                        break;
                    case "2":
                        DeleteFoodItem();
                        break;
                    case "3":
                        PrintFoodItems();
                        break;
                    case "4":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void AddFoodItem()
        {
            Console.Clear();
            Console.WriteLine("Add a Food Item");
            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Category: ");
            string category = Console.ReadLine();

            Console.Write("Quantity: ");
            int quantity;
            while (!int.TryParse(Console.ReadLine(), out quantity) || quantity < 0)
            {
                Console.WriteLine("Invalid quantity. Please enter a non-negative number.");
            }

            Console.Write("Expiration Date (YYYY-MM-DD): ");
            DateTime expirationDate;
            while (!DateTime.TryParse(Console.ReadLine(), out expirationDate))
            {
                Console.WriteLine("Invalid date. Please enter a valid date (YYYY-MM-DD).");
            }

            inventory.Add(new FoodItem(name, category, quantity, expirationDate));
            Console.WriteLine("Food item added successfully!");
            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
        }

        static void DeleteFoodItem()
        {
            Console.Clear();
            Console.WriteLine("Delete a Food Item");
            PrintFoodItems();

            if (inventory.Count == 0)
            {
                Console.WriteLine("No items to delete. Press any key to return to the menu...");
                Console.ReadKey();
                return;
            }

            Console.Write("Enter the number of the item to delete: ");
            int index;
            while (!int.TryParse(Console.ReadLine(), out index) || index <= 0 || index > inventory.Count)
            {
                Console.WriteLine("Invalid input. Please enter a valid item number.");
            }

            inventory.RemoveAt(index - 1);
            Console.WriteLine("Food item deleted successfully!");
            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
        }

        static void PrintFoodItems()
        {
            Console.Clear();
            Console.WriteLine("Current Food Items:");

            if (inventory.Count == 0)
            {
                Console.WriteLine("No items in inventory.");
            }
            else
            {
                for (int i = 0; i < inventory.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {inventory[i]}");
                }
            }

            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
        }
    }
}
