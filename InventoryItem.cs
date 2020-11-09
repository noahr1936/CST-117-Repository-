using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager
{
    class InventoryItem
    {
        public String ItemDescription { get; set; }
        public int ItemNumber { get; set; }
        public String ModelNumber { get; set; }
        public int OnHand { get; set; }
        public double Price { get; set; }
        public int OrderedYTD { get; set; }

        //constructor created inventory item with all variables being required to create an inventory item
        public InventoryItem(String itemDescription, int itemNumber, String modelNumber, int onHand, double price, int orderedYTD)
        {
            ItemDescription = itemDescription;
            ItemNumber = itemNumber;
            ModelNumber = modelNumber;
            OnHand = onHand;
            Price = price;
            OrderedYTD = orderedYTD;
        }
        override
        public String ToString()
        {
            return ItemDescription + " || " + ItemNumber + " || " + ModelNumber + " || " +
                 OnHand + " || " + Price + " || " + OrderedYTD;
        }
    }
}
