using System;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Project
{
    public partial class Calculator : Form
    {

        private calc calculator;

        public Calculator()
        {
            InitializeComponent();
            calculator = new calc();
        }

      
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text += "1";
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text += "2";
           
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            calculator.AdditiveOperation(Convert.ToDecimal(textBox1.Text));
            textBox1.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text += "3";
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            textBox1.Text += "4";
        }

        private void button5_Click(object sender, EventArgs e)
        {
          
            textBox1.Text += "5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
           
            textBox1.Text += "6";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
            textBox1.Text += "7";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
            textBox1.Text += "8";
        }

        private void button9_Click(object sender, EventArgs e)
        {
          
            textBox1.Text += "9";
        }

        private void button0_Click(object sender, EventArgs e)
        {
            textBox1.Text += "0";
            textBox1.Text = calculator.CurrentValue.ToString();
        }

        private void buttonEqauls_Click(object sender, EventArgs e)
        {
            calculator.Equals(Convert.ToDecimal(textBox1.Text));
            textBox1.Text = calculator.CurrentValue.ToString();

        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            calculator.Clear();
            textBox1.Text = "";
        }

        private void buttonSub_Click(object sender, EventArgs e)
        {
            calculator.Subtract(Convert.ToDecimal(textBox1.Text));
            textBox1.Text = "";
        }

        private void buttonDiv_Click(object sender, EventArgs e)
        {
            calculator.Divide(Convert.ToDecimal(textBox1.Text));
            textBox1.Text = "";
        }

        private void buttonMult_Click(object sender, EventArgs e)
        {
            calculator.Multiply(Convert.ToDecimal(textBox1.Text));
            textBox1.Text = "";
        }

        private void buttondot_Click(object sender, EventArgs e)
        {
            //calculator.Add(".");
            //textBox1.Text = calculator.CurrentValue.ToString();
            if (!textBox1.Text.Contains("."))
            {
                textBox1.Text += ".";
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to exit?", "Confirm Exit", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
