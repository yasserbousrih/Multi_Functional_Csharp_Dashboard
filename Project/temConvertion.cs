using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Project
{
    public partial class temConvertion : Form
    {
        public temConvertion()
        {
            InitializeComponent();
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ctof_CheckedChanged(object sender, EventArgs e)
        {
            // displaying the C and the F
            if (ctof.Checked)
            {
                label2.Text = "C";
                label3.Text = "F";
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void ftoc_CheckedChanged(object sender, EventArgs e)
        {
            if (ftoc.Checked)
            {
                // displaying the C and the F

                label2.Text = "F";
                label3.Text = "C";



            }
        }
        private string GetMessage(double tempf)
        {
            // used the f because its more accurate 
            double tempc = (tempf - 32) * 5 / 9;
            string message;
            if (tempc >= 100)
            {
                message = "Water boils";
                label5.ForeColor = Color.Red;
            }
            else if (tempc >= 40)
            {
                message = "Hot Bath";
                label5.ForeColor = Color.Red;
            }
            else if (tempc >= 37)
            {
                message = "Body temperature";
                label5.ForeColor = Color.Green;
            }
            else if (tempc >= 30)
            {
                message = "Beach weather";
                label5.ForeColor = Color.Green;
            }
            else if (tempc >= 21)
            {
                message = "Room temperature";
                label5.ForeColor = Color.Green;
            }
            else if (tempc >= 10)
            {
                message = "Cool Day";
                label5.ForeColor = Color.Blue;
            }
            else if (tempc >= 0)
            {
                message = "Freezing point of water";
                label5.ForeColor = Color.Blue;
            }
            else if (tempc >= -18)
            {
                message = "Very Cold Day";
                label5.ForeColor = Color.Blue;
            }
            else
            {
                message = "Extremely Cold Day";
                label5.ForeColor = Color.Blue;
            }
            return message;
        }


        private void button4_Click(object sender, EventArgs e)
        {
            // Get the input temperature value
            if (!double.TryParse(textBox1.Text, out double temperature))
            {
                MessageBox.Show("Please enter a valid temperature value.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check which radio button is selected and convert the temperature accordingly
            double convertedTemperature;
            string fromUnit, toUnit;
            string message;
            if (ctof.Checked)
            {
                convertedTemperature = temperature * 9 / 5 + 32;
                fromUnit = "C";
                toUnit = "F";
                message = GetMessage(convertedTemperature);
            }
            else
            {
                convertedTemperature = (temperature - 32) * 5 / 9;
                fromUnit = "F";
                toUnit = "C";
                message = GetMessage(temperature);
            }

            // Update the converted temperature text box
            textBox2.Text = convertedTemperature.ToString("0.00");

            // Update the message text box
            label5.Text = message;
            

            // Save the conversion to a file
            try
            {
                using (StreamWriter writer = new StreamWriter("TempConv.txt", true))
                {
                    string line = $"{temperature} {fromUnit} = {convertedTemperature} {toUnit}, {DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss tt")} {message}";
                    writer.WriteLine(line);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving the conversion: {ex.Message}", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            double tempf = temperature * 9 / 5 + 32;
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

            try
            {
                // Read all lines from the file and concatenate them into a string
                string[] lines = File.ReadAllLines("TempConv.txt");
                StringBuilder sb = new StringBuilder();
                foreach (string line in lines)
                {
                    sb.AppendLine(line);
                }

                // Show the string in a message box
                MessageBox.Show(sb.ToString(), "Temperature Conversions", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading the file: {ex.Message}", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Confirm Exit", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}

        
    

