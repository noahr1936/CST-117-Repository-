using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Milestone2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Boolean globalSelection = true;
        public void setGlobalSelection(Boolean value)
        {
            this.globalSelection = value;
        } 

        public Boolean getGlobalSelection()
        {
            return globalSelection;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (globalSelection == true)
            {
                if (listBox1.SelectedItem.ToString() == "Blue")
                {
                    pictureBox1.BackColor = Color.Blue;
                }
                if (listBox1.SelectedItem.ToString() == "Red")
                {
                    pictureBox1.BackColor = Color.Red;
                }
                if (listBox1.SelectedItem.ToString() == "Green")
                {
                    pictureBox1.BackColor = Color.Green;
                }
                if (listBox1.SelectedItem.ToString() == "Yellow")
                {
                    pictureBox1.BackColor = Color.Yellow;
                }
                if (listBox1.SelectedItem.ToString() == "Orange")
                {
                    pictureBox1.BackColor = Color.Orange;
                }
            }
            else if(globalSelection == false)
            {
                if (listBox1.SelectedItem.ToString() == "Red")
                {
                    pictureBox1.BackColor = Color.Blue;
                }
                if (listBox1.SelectedItem.ToString() == "Yellow")
                {
                    pictureBox1.BackColor = Color.Red;
                }
                if (listBox1.SelectedItem.ToString() == "Orange")
                {
                    pictureBox1.BackColor = Color.Green;
                }
                if (listBox1.SelectedItem.ToString() == "Blue")
                {
                    pictureBox1.BackColor = Color.Yellow;
                }
                if (listBox1.SelectedItem.ToString() == "Green")
                {
                    pictureBox1.BackColor = Color.Orange;
                }

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            setGlobalSelection(true);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            setGlobalSelection(false);
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
            {
                textBox1.Text = ("CST-117");
            }
            else if(checkBox1.Checked == false)
            {
           
                textBox1.Text = ("");
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox2.Text = ("Aiman Darwiche");
            }
            else if (checkBox1.Checked == false)
            {
                textBox2.Text = ("");
            }

        }

        

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                textBox3.Text = ("Noah Roerig");
            }
            else if (checkBox3.Checked == false)
            {
                textBox3.Text = ("");
            }
        }
    }
    }

