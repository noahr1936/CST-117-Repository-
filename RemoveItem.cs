using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManager
{
    public partial class RemoveItem : Form
    {
        public RemoveItem()
        {
            InitializeComponent();
        }

        private void btn_remove_Click(object sender, EventArgs e)
        {
            //when the button is clicked it removes the item from inventory
            try
            {
                MessageBox.Show(Main.removeItem(Convert.ToInt32(tb_itemNumber.Text)));
                this.Close();
            }
            catch (Exception) {
                l_itemInfo.Text = "Enter valid item number";
            }
        }

        private void tb_itemNumber_TextChanged(object sender, EventArgs e)
        {
            //if the text is changed it catches the exception but allows the items 
            //being displayed to be dynamically changed
            try
            {
                l_itemInfo.Text = Main.showItemInfo(Convert.ToInt32(tb_itemNumber.Text));
            }
            catch (Exception) {
                l_itemInfo.Text = "No Item found in inventory";
            }
        }
    }
}
