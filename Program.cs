using Mission3_Assignment;

// Introduction line.
Console.WriteLine("Welcome to the Food Inventory Program!");
bool isRunning = true; // Bool variable to keep showing the menu after each action.
List<FoodItem> foodInventory = new List<FoodItem>(); // List to store the food items.

// Loop to show the menu and select actions.
while (isRunning)
{
    // Menu options.
    Console.WriteLine("Please select an option:");
    Console.WriteLine("1. Add food");
    Console.WriteLine("2. Delete food");
    Console.WriteLine("3. Display food inventory");
    Console.WriteLine("4. Exit program");

    // Lets user select a menu option.
    string userInput = Console.ReadLine();
    Console.WriteLine();

    // Checks if the input is a valid integer between 1 and 4.
    if (int.TryParse(userInput, out int number) && number >= 1 && number <= 4)
    {
        int menuSelect = number;
        if (menuSelect == 1)
        {
            // Gets the name and category of the food and stores them.
            Console.Write("Enter the name of the food: ");
            string name = Console.ReadLine();
            Console.Write("Enter the category of the food: ");
            string category = Console.ReadLine();
            int quantity;
            // Loop to get the food quantity and make sure it's a valid, positive integer.
            while (true)
            {
                Console.Write("Enter the quantity of the food: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out quantity) && quantity > 0)
                {
                    break; 
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid positive integer.");
                }
            }
            // Gets the expiration date of the food and stores it.
            Console.Write("Enter the expiration date of the food (YYYY-MM-DD): ");
            string inputDate = Console.ReadLine();
            bool validDate = false;
            // Loop to check if the date is in the correct format and ask for a new input if not.
            while (!validDate)
            {
                if (DateTime.TryParse(inputDate, out DateTime checkDate))
                {
                    validDate = true;
                }
                else
                {
                    Console.WriteLine("Invalid date format.\nPlease enter the expiration date of the food (YYYY-MM-DD): ");
                    inputDate = Console.ReadLine();
                }
            }
            // Stores the expiration date in a DateTime variable.
            DateTime expirationDate = DateTime.Parse(inputDate);

            // Creates a new FoodItem object with the input values and adds it to the food inventory list.
            FoodItem foodItem = new FoodItem(name, category, quantity, expirationDate);
            foodInventory.Add(foodItem);
            Console.WriteLine($"\nSuccessfully added '{name}' to the inventory.");
            Console.WriteLine();
        }

        if (menuSelect == 2)
        {
            // Gets the name of the food to be deleted.
            Console.Write("Enter the name of the food to delete: ");
            string deleteFood = Console.ReadLine();
            // Removes all the food items with the same name as the input.
            int itemsRemoved = foodInventory.RemoveAll(food => food.Name.Equals(deleteFood, StringComparison.OrdinalIgnoreCase));
            //Shows a message about whether the food was deleted.
            if (itemsRemoved > 0)
            {
                Console.WriteLine($"\nSuccessfully deleted '{deleteFood}' from the inventory.");
            }
            else
            {
                Console.WriteLine($"\nNo food found with the name '{deleteFood}' in the inventory.");
            }
            Console.WriteLine();
        }

        if (menuSelect == 3)
        {
            // Displays the info about each food item in the inventory.
            Console.WriteLine("Food Inventory:");
            foreach (FoodItem foodItem in foodInventory)
            {
                Console.WriteLine($"Name: {foodItem.Name}, Category: {foodItem.Category}, Quantity: {foodItem.Quantity}, Expiration Date: {foodItem.ExpirationDate:yyyy-MM-dd}");
            }
            Console.WriteLine();
        }

        if (menuSelect == 4)
        {
            // Exits the program.
            Console.WriteLine("Thank you for using the Food Inventory Program!");
            Environment.Exit(0);
        }
    }
}