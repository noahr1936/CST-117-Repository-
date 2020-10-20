using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Milestone_2
{
    public partial class Form1 : Form
    {
        //This is me Noah Roerig's work
        //10/18/20
        public string itemDescription, modelNumber;
        public int onHand, dueFile, damaged, soldYTD, onOrder;
        List<Form1> _list = new List<Form1>();

        public int itemNumber { get; private set; }

        public int index { get; set; }

        private void button2_Click(object sender, EventArgs e)
        {
            //shows inventory by looping over each item in the list and assigning it to var
            //this is then printed to the console where it the ToString makes it readable
            foreach (var items in _list)
            {
                Console.WriteLine(items);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addItem(); 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            searchItem();
        }

        //constructor that creates each item 
        public Form1(string ItemDescription, int ItemNumber, string ModelNumber, int Onhand)
        {
            itemDescription = ItemDescription;
            itemNumber = ItemNumber;
            modelNumber = ModelNumber;
            onHand = Onhand;
            //dueFile = DueFile;
            //damaged = Damaged;
            //soldYTD = SoldYTD;
            //onOrder = OnOrder;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            findItemToUpdate();
            clearBoxes();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            edit(index);
        }

        //clears all textboxes 
        public void clearBoxes()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        //method takes in an int 
        public void removeItem(int a)
        {
            //the int is used to compare with items from the list and assigns the object chosen to a variable 
            var itemToRemove = _list.Single(r => r.itemNumber == a);

            //the object is then removed from the list
            _list.Remove(itemToRemove);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            removeItem(int.Parse(textBox2.Text));
            Console.WriteLine("Remove Item");
        }

        //finds an item index for the next method to use based of the item number entered
        public void findItemToUpdate()
        {
            //try statement catches any issues
            try
            {
                //compares itemNumbers from the list with the passed in int from the textbox and assigns the variable to b
                int b = _list.FindIndex(a => a.itemNumber == int.Parse(textBox2.Text));
                
                //assigns the b to the global variable index
                Console.WriteLine("Enter in new values for the item being updated");
                index = b;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Enter correct values in fields " + "\n",ex);
            }
        }

        //edits an item an inventory by passing in the index from findItemToUpdate
        public void edit(int a)
        {          
            //if statement checks if variable is greater than 0 so that a object from the array is being passed through
            if(a >= 0)
            {
                try
                {
                    //the inventory item is replaced at the index with a new item entered
                    _list[a] = new Form1(textBox1.Text, int.Parse(textBox2.Text), textBox3.Text, int.Parse(textBox4.Text));
                    Console.WriteLine("Item updated");
                }
                catch (Exception ex) 
                {
                    Console.WriteLine("Enter correct values into fields" + ex);
                }
            }
            
        }

        //searches for items in list based off of item number, item description, and model number
        public void searchItem()
        {
            try
            {
                //searches for an int that eqauls the one that is typed into the text box. This item it finds is assigned to var
                var findItemNumber = _list.FirstOrDefault(x => x.itemNumber == int.Parse(textBox2.Text));

                //the var is displayed through the console and the ToString gives it the correct format
                Console.WriteLine("" + findItemNumber);
            }
            catch (System.FormatException ex)
            {
                //searches for the item description or model number based off of the string typed into the textboxes
                var findItemDescription = _list.FirstOrDefault(x => x.itemDescription == textBox1.Text);
                var findModelNumber = _list.FirstOrDefault(x => x.modelNumber == textBox3.Text);
                Console.WriteLine("" + findItemDescription + findModelNumber);
            }
            catch (Exception fx) {
                Console.WriteLine("Enter correct values when searching" + fx);
            }
        }

        //adds items to the inventory list
        public void addItem()
        {
            try
            {
                //creates a new item based off the info typed into the textboxes
                Form1 item = new Form1(textBox1.Text, int.Parse(textBox2.Text), textBox3.Text, int.Parse(textBox4.Text));

                //adds newly created item to list
                _list.Add(item);
                Console.WriteLine("Item added to inventory");
                clearBoxes();
            }
            //catches if wrong values are entered into item
            catch(Exception ex)
            {
                Console.WriteLine("Enter correct values into fields" + ex);
            }   
        }

        //ToString created readable output for the user to understand rather than memory locations 
        public override string ToString()
        {
            return "--" + itemDescription + "--" + "\nItem #: " + itemNumber + "\nModel #: " + modelNumber + "\nOn Hand: " + onHand;
        }
    }
}
