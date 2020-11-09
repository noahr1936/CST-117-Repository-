using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManager
{

    public partial class InventoryManager : Form
    {     
        public InventoryManager()
        {
            InitializeComponent();
            tb_searchQuery.Text = "Search for many different parameters";
            tb_inventoryList.Visible = false;
            
        }

        private void InventoryManager_Load(object sender, EventArgs e)
        {
           
        }

        private void b_addItem_Click(object sender, EventArgs e)
        {
            //calls the addItem form
            AddItem ai = new AddItem();
            ai.Show();
        }

        private void btn_showInventory_Click(object sender, EventArgs e)
        {
            //makes the inventory box in the middle of the screen visible then shows the inventory
            tb_inventoryList.Visible = true;
            tb_inventoryList.Text = Main.showInventory();
        }

        private void btn_removeItem_Click(object sender, EventArgs e)
        {
            //calls the removeItem form
            RemoveItem ri = new RemoveItem();
            ri.Show();
        }

        private void btn_restockItem_Click(object sender, EventArgs e)
        {
            //cals the restockItem form
            RestockItem ri = new RestockItem();
            ri.Show();
        }

        private void tb_searchQuery_TextChanged(object sender, EventArgs e)
        {
            //assigns the value in the searchQuery to second 
            tb_inventoryList.Visible = true;
            String stringValue = "";
            int intValue = 0;
            var second = tb_searchQuery.Text;

            //it is first attempted to be changed to integer
            try
            {
                intValue = Convert.ToInt32(second);
            }
            catch (Exception) { }

            //if its not then it will fall under a string
            if (second.GetType() == typeof(String))
                stringValue = second;

            //calls the search method and returns a string showing the item
            tb_inventoryList.Text = Main.searchItem(intValue, stringValue);

        }
    }
}
