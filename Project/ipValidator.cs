using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class ipValidator : Form
    {
        private DateTime formLoadTime;

        public ipValidator()
        {
            InitializeComponent();
            // Store the current time as the form load time
            label1.Text = DateTime.Now.ToLongDateString();
            formLoadTime = DateTime.Now;

        }
        
        private bool IsValidIPAddress(string ipAddress)
        {
            // Checks if the given string is a valid IP address format
            string ipPattern = @"^\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b$";
            Regex regex = new Regex(ipPattern);

            return regex.IsMatch(ipAddress);
        }

        private void label1_Click(object sender, EventArgs e)
        {
        
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Clears the text box
            textBox1.Text = "";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            // Calculate the time used since the form was loaded
            TimeSpan timeUsed = DateTime.Now - formLoadTime;
            int totalSeconds = (int)timeUsed.TotalSeconds;
            int totalMinutes = (int)timeUsed.TotalMinutes;

            MessageBox.Show($"You used the form for {totalSeconds} seconds ({totalMinutes} minutes).");
            if (MessageBox.Show("Are you sure you want to exit?", "Confirm Exit", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Validates the IP address entered and writes it to a binary file if it is valid

            string ipAddress = textBox1.Text.Trim(); //trim is to remove any spaces 

            if (IsValidIPAddress(ipAddress))
            {
                // Show a message box with the valid IP address 
                MessageBox.Show($"{ipAddress}\n" +
                                $"Valid IP address format!");

                try
                {
                    // Open a binary file stream in append mode
                    using (FileStream fileStream = new FileStream("ip_addresses.bin", FileMode.Append))
                    {
                        // Create a binary writer to write to the file stream
                        using (BinaryWriter writer = new BinaryWriter(fileStream))
                        {
                            // Write the IP address and current time to the file
                            writer.Write(ipAddress);
                            writer.Write(DateTime.Now.ToBinary());
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Show an error message for an exception 
                    MessageBox.Show("Error occurred while writing to file: " + ex.Message);
                }
            }
            else
            {
                // Show a message box with the invalid IP address format
                MessageBox.Show($"{ipAddress}\n" +
                                $"Invalid IP address format!\n" +
                                $"The IP address must have 4 bytes (integer numbers between 0 and 255), separated by a dot (e.g. 192.168.1.1)");
            }
        }
        }
    }
