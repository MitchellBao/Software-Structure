using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Assignment01_02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)   
        {
            textBox3.Clear();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox3.Clear();
        }

        private void equal_Click(object sender, EventArgs e)
        {

        }

        private void Clear(object sender, EventArgs e)   // clear texts in all textboxes and comboboxes
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            operatorBox.SelectedIndex = -1;
        }


        private void calculateButton_Click(object sender, EventArgs e)   // when touching the calculate button
        {
            string s = "";
            double result = 0;
            s = textBox1.Text;
            double x = double.Parse(s);
            s = textBox2.Text;
            double y = double.Parse(s);
            s = operatorBox.SelectedItem.ToString();
            switch (s)
            {
                case "+": result = x + y; break;
                case "-": result = x - y; break;
                case "*": result = x * y; break;
                case "÷": 
                    if (y == 0)
                    {
                        MessageBox.Show("THE DIVISOR CANNOT BE ZERO!!");
                        Clear(sender, e);
                        return;
                    }
                    result = x / y; break;
            }
            textBox3.Text = result.ToString();
        }

        private void operatorBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox3.Clear();
        }
    }
}

