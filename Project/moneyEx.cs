using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class moneyEx : Form
    {
        // Add exchange rates for each currency to CAD
        private const double CADtoCAD = 1.0;
        private const double USDtoCAD = 1.25;
        private const double EURtoCAD = 1.45;
        private const double GBPtoCAD = 1.70;
        private const double TNDtoCAD = 0.35;

        //

        private DateTime formLoadTime;

        public moneyEx()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }


        private void btnExit_Click(object sender, EventArgs e)
        {     // Get the time when the form is closed
            DateTime formCloseTime = DateTime.Now;

            // Calculate the time spent using the form
            TimeSpan timeSpent = formCloseTime - formLoadTime;
            double totalSeconds = timeSpent.TotalSeconds;
            double totalMinutes = timeSpent.TotalMinutes;

            // Ask for confirmation before closing the form
            string message = $"You have used this form for {totalSeconds} seconds ({totalMinutes} minutes). Are you sure you want to exit?";
            if (MessageBox.Show(message, "Confirm Exit", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
                formLoadTime = DateTime.Now;
        }
        private void SaveConversionToFile(string filePath, string content)
        {
            try
            {
                // Append the given content to the specified file, followed by a new line
                File.AppendAllText(filePath, content + Environment.NewLine);
            }
            catch (Exception ex)
            {
                // Show an error message if there was an issue saving the conversion to the file
                MessageBox.Show($"Error saving conversion: {ex.Message}");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Parse the input amount
            double inputAmount;

            // Check if the input is valid
            if (double.TryParse(textBox1.Text, out inputAmount))
            {
                double fromRate = 0;
                double toRate = 0;

                // Determine the 'from' currency rate
                if (radioButton1.Checked) fromRate = CADtoCAD;
                else if (radioButton2.Checked) fromRate = USDtoCAD;
                else if (radioButton3.Checked) fromRate = EURtoCAD;
                else if (radioButton4.Checked) fromRate = GBPtoCAD;
                else if (radioButton5.Checked) fromRate = TNDtoCAD;

                // Determine the 'to' currency rate
                if (radioButton10.Checked) toRate = CADtoCAD;
                else if (radioButton9.Checked) toRate = USDtoCAD;
                else if (radioButton8.Checked) toRate = EURtoCAD;
                else if (radioButton7.Checked) toRate = GBPtoCAD;
                else if (radioButton6.Checked) toRate = TNDtoCAD;

                // Calculate the conversion result
                double result = (inputAmount * fromRate) / toRate;

                // Display the result
                textBox2.Text = result.ToString("0.00");

                // Determine the 'from' and 'to' currencies
                string fromCurrency = "";
                string toCurrency = "";
                // From currency
                if (radioButton1.Checked) fromCurrency = "CAD";
                else if (radioButton2.Checked) fromCurrency = "USD";
                else if (radioButton3.Checked) fromCurrency = "EUR";
                else if (radioButton4.Checked) fromCurrency = "GBP";
                else if (radioButton5.Checked) fromCurrency = "TND";
                // TO currency
                if (radioButton10.Checked) toCurrency = "CAD";
                else if (radioButton9.Checked) toCurrency = "USD";
                else if (radioButton8.Checked) toCurrency = "EUR";
                else if (radioButton7.Checked) toCurrency = "GBP";
                else if (radioButton6.Checked) toCurrency = "TND";

                // Prepare the file path and conversion string
                string filePath = "MoneyConv.txt";
                string conversion = $"{inputAmount} {fromCurrency} = {result:0.00} {toCurrency}, {DateTime.Now:yyyy/MM/dd h:mm:ss tt}";

                // Save the conversion to the file
                SaveConversionToFile(filePath, conversion);
            }
            else
            {
                // Show an error message if the input is invalid
                MessageBox.Show("Invalid input. Please enter a valid number.");
            }
        }


        private void button5_Click(object sender, EventArgs e)
        {
            // Set the file path 
            string filePath = "MoneyConv.txt";

            try
            {
                // Read the content of the text file
                string fileContent = File.ReadAllText(filePath);

                // Set the name of the user who is accessing the file
                string myName = "Yasser";

                // Create the message to be displayed in the message box, including the file content and pertinent information
                string message = $"File content:\n\n{fileContent}\n\n---\n\nPertinent information: This file has been read by {myName}.";

                // Set the title for the message box
                string title = $"File Information - {myName}";

                // Show the message box with the file content, pertinent information, and title
                MessageBox.Show(message, title);
            }
            catch (Exception ex)
            {
                // If there is an error while reading the file, display the error message in a message box
                MessageBox.Show($"Error reading file: {ex.Message}");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

            

            