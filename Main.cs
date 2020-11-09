using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManager
{
    static class Main
    {
        static List<InventoryItem> theList = new List<InventoryItem>();
        static int listLength = 0;

        //method addItem takes in 6 parameters
        static public string addItem(String itemDescription, int itemNumber, String modelNumber, int onHand, double price, int orderedYTD)
        {
            //adds to the list by creating a new inventory item
            theList.Add(new InventoryItem(itemDescription, itemNumber, modelNumber, onHand, price, orderedYTD));

            //listLength and theList.count stay the same
            //if listLength is less after the addition then list length is iterated 
            if (listLength < theList.Count)
            {
                listLength++;
                return "Item succesfully added";
            }
            else
            {
                return "Error";
            }
            
        }

        static public string showInventory()
        {
            //if count is empty, lets user know
            if(theList.Count == 0)
            {
                return "Inventory is empty";
            }
            //returns a string with all the inventory items
            return String.Join(Environment.NewLine, theList);
            
        }

        
        static public string removeItem(int itemNumber)
        {
            try
            {
                //takes in an itemNumber to search for the index where that was located 
                int index = theList.FindIndex(c => c.ItemNumber == itemNumber);
                if (index < 0)
                    return "Item not found in inventory";

                else
                {
                    //if the theList isnt empty it removes the item at the index and decreases the list
                    theList.RemoveAt(index);
                    listLength--;
                    return (itemNumber + " removed from Inventory");
                }
            }
            catch (Exception) { }

            return "Error";
        }

        //takes a stringV and a intV as parameters 
        //both values are default in the InventoryManager form
        static public string searchItem(int intV, String stringV)
        {
            int index = 0;
            try
            {
                //only one parameter will have a value
                //checks to see what to correctly look for
                if (intV != 0)
                {
                    index = theList.FindIndex(c => c.ItemNumber == intV || c.OnHand == intV);

                    //returns a tostring of the item so its in string form
                    return theList[index].ToString();
                }
                else if (stringV != null)
                {
                    index = theList.FindIndex(c => c.ItemDescription == stringV || c.ModelNumber == stringV);
                    return theList[index].ToString();
                }
                else
                    return "No item in inventory";
            }
            catch (Exception) { }
            return "No item found in inventory";
        }        

        static public string showItemInfo(int itemNumber)
        {
            var item = theList.FirstOrDefault(c => c.ItemNumber == itemNumber);
            if (item != null)
            {
                //making a var hold the items allows for quick access to the description, onHand count, and orderedYTD count
                return ("Item Description: " + item.ItemDescription +
                "\nModel Number: " + item.ModelNumber +
                "\nOn Hand: " + item.OnHand);
            }
            else
                return "Item not in Inventory";
        }
        static public string showRestockInfo(int itemNumber)
        {
            //takes in an itemNumber to search for the item to assign to item
            var item = theList.FirstOrDefault(c => c.ItemNumber == itemNumber);
            if (item != null)
            {
                //making a var hold the items allows for quick access to the description, onHand count, and orderedYTD count
                return ("Item Description: " + item.ItemDescription +
                "\nOn Hand: " + item.OnHand +
                "\nOrdered YTD: " + item.OrderedYTD +
                "\nEnter amount to be ordered: ");
            }
            else
                return "Item not in Inventory";

        }
        static public string restockItem(int itemNumber, int toBeOrdered)
        {
            var item = theList.FirstOrDefault(c => c.ItemNumber == itemNumber);

            //if amount is greater than 500 it wont allow it to be ordered
            if (toBeOrdered > 5000)
                return "Amount too be great to ordered";
            
            //if item isnt null then that counts will be updated 
            else if (item != null)
            {
                item.OrderedYTD = toBeOrdered;
                item.OnHand += toBeOrdered;
                return ("Ordered " + toBeOrdered + " units");
            }
            else
                return "Item not in inventory";
        }
    }
}
