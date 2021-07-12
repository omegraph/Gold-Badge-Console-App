using MenuItem.POCOs;
using MenuItemRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeCafe
{
    public class Program_UI
    {
        private readonly MenuItemsRepository _menuItemsRepository = new MenuItemsRepository();
        private bool isRuning;
        
        public void Run()
        {
            RunApplication();
        }

        private void RunApplication()
        {
            bool isRuning = true;
            while (isRuning)
            {
                Console.WriteLine("Welcome to Komodo Cafe Menu App\n" +
                              "1. Add Item\n" +
                              "2. Delete Item\n" +
                              "3. See All Items\n" +
                              "4. Close Application\n");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        AddItem();
                        break;
                    case "2":
                        DeleteItem();
                        break;
                    case "3":
                        ViewAllItems();
                        break;
                    case "4":
                        isRuning = false;
                        Console.WriteLine("Pressany key to continue");
                        Console.ReadKey();
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid Entry");
                        Console.ReadKey();
                        break;

                }
                Console.Clear();
            }

        }

        private void ViewAllItems()
        {
            Console.Clear();
            List<MenuItems> menuItemsInDatabase = _menuItemsRepository.GetMenuItems().ToList();

            foreach (var menuItems in menuItemsInDatabase)
            {
                DisplayMenuItemsData(menuItems);
            }

            Console.ReadKey();
        }

        private void DisplayMenuItemsData(MenuItems menuItems)
        {
            Console.WriteLine(
                              $"Meal Number: {menuItems.MealNumber}\n" +
                              $"Meal Name: {menuItems.MealName}\n" +
                              $"Description: {menuItems.Description}\n" +
                              $"Ingridients: {menuItems.Ingredients}\n" +
                              $"Price: {menuItems.Price}\n");
            Console.WriteLine("------------------------------------------------");

        }

        private void DeleteItem()
        {
            Console.Clear();
            Console.WriteLine("Please enter the meal number:");
            var userInputMealNumber = int.Parse(Console.ReadLine());

            bool success = _menuItemsRepository.DeleteItem(userInputMealNumber);
            if (success)
            {
                Console.WriteLine("Item deleted successfully");
            }
            else
            {
                Console.WriteLine("Item does not exist!");
            }
            Console.ReadKey();
        }

        private void AddItem()
        {
            Console.Clear();
            Console.WriteLine("Please enter the Meal Name:");
            var userInputMealName = Console.ReadLine();

            Console.WriteLine("Please enter the Description:");
            var userInputDescription = Console.ReadLine();

            Console.WriteLine("Please enter the Ingridients:");
            var userInputIngredients = Console.ReadLine();

            Console.WriteLine("Please the Price:");
            var userInputPrice = Console.ReadLine();

            var menuItems = new MenuItems(userInputMealName, userInputDescription, userInputIngredients, userInputPrice);

            bool success = _menuItemsRepository.AddItem(menuItems);
            if (success)
            {
                Console.WriteLine("SUCCESS");
            }
            else
                Console.WriteLine("FAILED");
            Console.ReadKey();
        }
    }
}
