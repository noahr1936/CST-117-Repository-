using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;

namespace InventoryManager
    //This is me Noah Roerig's work
    //11/1/20
{
    public class Driver
    {
        //driver program calls the main program to get it started
        public static void Main (String [] args)
        {
            //object of InventoryManager is created to access the ConsoleMain()
            InventoryManager im = new InventoryManager();
            im.ConsoleMain();
        }
    }
    
    public class InventoryManager
    {
        //list of type InventoryItem is created to store the items
        List<InventoryItem> theList = new List<InventoryItem>();
        String lineSpace = "---------------------------";
        public int userChoice { get; set; }

        //main menu of app 
        public void ConsoleMain()
        {
            Console.WriteLine(lineSpace);
            Console.WriteLine("What would you like the power to do?" +
                "\nAdd Item         -->   1" +
                "\nRemove Item      -->   2" +
                "\nRe-stock Item    -->   3" + 
                "\nShow Inventory   -->   4" + 
                "\nSearch Item      -->   5");

            //userchoice from list is captured and used in switch list to make decision 
            try
            {
                userChoice = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Choose a valid option");
                ConsoleMain();
            }
        
            switch (userChoice)
            {
                case 1:
                    //assigns userinput to variables and captures incorrect entries
                    try {
                        Console.WriteLine(lineSpace);
                        Console.WriteLine("Adding Item");
                        Console.WriteLine("Item Description: ");
                        String itemD = Console.ReadLine();
                        Console.WriteLine("Item Number: ");
                        int itemN = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Model Number: ");
                        String modelN = Console.ReadLine();
                        Console.WriteLine("On Hand: ");
                        int onH = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Price: ");
                        decimal price = Convert.ToDecimal(Console.ReadLine());
                    
                        addItem(itemD, itemN, modelN, onH, price, 0);
                    }
                    catch(Exception)
                    {
                        Console.WriteLine("Incorrect variables entered" +
                            "\nRe-enter item");
                        ConsoleMain();
                    }
                    break;
                case 2:
                    //uses inventory number entered by user to delete item
                    Console.WriteLine("Enter item number to delete from inventory");
                    int item = Convert.ToInt32(Console.ReadLine());

                    //calls delete method by passing in the entered number
                    removeItem(item);
                    break;
                case 3:
                    //uses inventory number entered by user to restock item
                    Console.WriteLine("Enter item number to be re-stocked: ");
                    int newOnHandItemNumber = Convert.ToInt32(Console.ReadLine());

                    //calls the restock method by passing in the entered number
                    restockItem(newOnHandItemNumber);
                    break;
                case 4:
                    //issue with this where after the showInventory() method is called and causes the catch statement in 
                    //case 1 to occur
                    showInventory();
                   
                    break;
                case 5:
                    //sets default values to 0 or nothing for next part
                    String stringValue = "";
                    int intValue = 0;
                    decimal decimalValue = 0m;

                    //could not get the program to read the price variable. it kept seeing it as a string
                    Console.WriteLine("Search for items with any variable except price: ");
                   
                    //user input is assigned to a var so that any input can be entered in without causing a format issue
                    var first = Console.ReadLine();
                    
                    //the getType method checks what type the var is
                    //it is then compared to type int, string, or decimal 
                    //if it is of one of the listed types it is converted to that type 
                    if (first.GetType() == typeof(int))
                    {
                        intValue = Convert.ToInt32(first);
                    }
                    else if (first.GetType() == typeof(decimal))
                    {
                        decimalValue = Convert.ToDecimal(first);
                    }
                    else if (first.GetType() == typeof(String))
                    {
                        stringValue = Convert.ToString(first);
                    }

                    //method takes all types since a var can not be passed as a paramter
                    searchItem(stringValue, intValue, decimalValue);
                    break;
                default:
                    ConsoleMain();
                    break;
            }
        }

        public void addItem(String itemDescription, int itemNumber, String modelNumber, int onHand, decimal price, int orderedYTD)
        {
            //uses a separate method to add items so each item added doesn't have to be added with a name
            //try statement will catch any error and route back to the main menu
            try
            {
                theList.Add(new InventoryItem(itemDescription, itemNumber, modelNumber, onHand, price, orderedYTD));
                Console.WriteLine("Item successfully added to inventory");
                ConsoleMain();
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Error");
                ConsoleMain();
            }
        }

        public void restockItem(int newOnHandItemNumber)
        {
            Console.WriteLine(lineSpace);
            //takes in the passed in item number and uses that to find the specific item and assign it to var
            var item = theList.FirstOrDefault(x => x.ItemNumber == newOnHandItemNumber);

            //this allows the item to be referenced so that the description and amount can be displayed 
            Console.WriteLine(item.ItemDescription + " current amount: " + item.OnHand);
            Console.WriteLine("Enter the amount to be ordered: ");
            int newValue = Convert.ToInt32(Console.ReadLine());
            
            if (item != null)
            {
                //if the item is found it raises the value of the ordered number 
                //and adds the newly ordered amount to the previous amount to create a new total
                item.OrderedYTD = newValue;
                item.OnHand = newValue + item.OnHand;
                Console.WriteLine("Ordered " + newValue + " units");
            }
            else
                Console.WriteLine("Item not in inventory");
            ConsoleMain();
        }

        public void searchItem(String stringValue, int intValue , decimal decimalValue)
        {
            //search item takes in all three types
            Console.WriteLine(lineSpace);
            int index = 0;
            
            /*uses if statement to search for the entered input
            if a int was entered but no string then the stringValue will = "" because that was the default value that 
            it was given in the previous step. The string if statement will be skipped and the program will move to the 
            int statement to check if its a item number or onHand count
            */
            if(stringValue != null)
            {
                index = theList.FindIndex(c => c.ItemDescription == stringValue || c.ModelNumber == stringValue);
            }
            else if (intValue != 0)
            {
                index = theList.FindIndex(c => c.ItemNumber == intValue || c.OnHand == intValue || c.OrderedYTD == intValue);
            }
            else if (decimalValue < 0)
            {
                index = theList.FindIndex(c => c.Price == decimalValue);
            }
            else
                Console.WriteLine("No items found with search query");     
            
            //these if statements return the index number where that item was found in the list 
            //the console write then displays the item in the list
            Console.WriteLine(theList[index]);
            ConsoleMain();
        }

        
        public void removeItem(int itemNumber)
        {
            Console.WriteLine(lineSpace);
            try
            {
                //passed in itemNumber is checked against item numbers in the list 
                //if one is a match it returns the index number where it was found in the list
                int index = theList.FindIndex(c => c.ItemNumber == itemNumber);
                if (index < 0)
                {
                    //if statement catches if item is ever found 
                    Console.WriteLine("Item not in inventory ");
                    ConsoleMain();
                }
                else
                {
                    //if index is greater than 0 the item is removed from the inventory 
                    theList.RemoveAt(index);
                    Console.WriteLine("Item successfully removed");
                    ConsoleMain();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error");
                ConsoleMain();
            }
        }

        public void showInventory()
        {
            //uses for loop to loop through list until the end of its capacity
            Console.WriteLine(lineSpace);
            
                for (int x = 0; x < theList.Capacity; x++)
                {
                    Console.WriteLine(theList[x]);
                }
            
           
            Console.WriteLine("Inventory is empty");
            ConsoleMain();
        }
    }

    public class InventoryItem
    {
        //getters and setters for each variable 
        public String ItemDescription { get; set; }
        public int ItemNumber { get; set; }
        public String ModelNumber { get; set; }
        public int OnHand { get; set; }
        public decimal Price { get; set; }
        public int OrderedYTD { get; set; }

        //constructor created inventory item with all variables being required to create an inventory item
        public InventoryItem(String itemDescription, int itemNumber, String modelNumber, int onHand, decimal price, int orderedYTD)
        {
            ItemDescription = itemDescription;
            ItemNumber = itemNumber;
            ModelNumber = modelNumber;
            OnHand = onHand;
            Price = price;
            OrderedYTD = orderedYTD;
        }

        //to string creates a readable item rather than a memory location
        override
        public String ToString()
        {
            return "Item Desription: " + ItemDescription + 
                "\nItem Number: " + ItemNumber + 
                "\nModel Number: " + ModelNumber + 
                "\nOn Hand: " + OnHand +
                "\nPrice: " + Price + 
                "\nOrdered: " + OrderedYTD +
                "\n------------------------------------------";
        }
    }
}
