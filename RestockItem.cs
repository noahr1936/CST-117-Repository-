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
    public partial class RestockItem : Form
    {
        int itemNumber;
        public RestockItem()
        {
            InitializeComponent();
        }

        private void RestockItem_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                
                
                
            }
            catch (Exception) { }
        }

        private void btn_restock_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(Main.restockItem(Convert.ToInt32(tb_itemNumber.Text), Convert.ToInt32(tb_units.Text)));
                this.Close();
            }
            catch (Exception)
            {
                l_newInfo.Text = "Enter valid item number";
            }
           
        }

        private void tb_itemNumber_TextChanged(object sender, EventArgs e)
        {
            try
            {
                l_newInfo.Text = Main.showRestockInfo(Convert.ToInt32(tb_itemNumber.Text));
            }
            catch (Exception) { }
            tb_units.Text = "__________";
        }
    }
}
