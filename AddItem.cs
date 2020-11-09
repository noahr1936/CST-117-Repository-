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
    public partial class AddItem : Form
    {
        public AddItem()
        {
            InitializeComponent();

        }

        private void b_addItem_Click(object sender, EventArgs e)
        {
            try
            {
                //takes the text from all the textboxes and assigns it to the correct variables 
                //will catch if the wrong format was entered 
                string itemDescription = tb_itemDescription.Text;
                int itemNumber = Convert.ToInt32(tb_itemNumber.Text);
                string modelNumber = tb_modelNumber.Text;
                int onHand = Convert.ToInt32(tb_onHand.Text);
                double price = Convert.ToDouble(tb_price.Text);
   
                //it then shows whether the item was succesfully added by calling the addItem method
                //and returning the string
                MessageBox.Show(Main.addItem(itemDescription, itemNumber, modelNumber, onHand, price, 0));
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Incorrect variables entered");
            }
        }
    }
}
