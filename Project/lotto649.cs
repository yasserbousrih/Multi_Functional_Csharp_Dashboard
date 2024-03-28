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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Project
{
    public partial class lotto649 : Form
    {

        private Random random = new Random();

        public lotto649()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Confirm Exit", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            // Generate 7 unique digits between 0 and 9.
            HashSet<int> generatedDigits = new HashSet<int>();
            while (generatedDigits.Count < 7)
            {
                int randomNumber = random.Next(0, 10);
                if (!generatedDigits.Contains(randomNumber))
                {
                    generatedDigits.Add(randomNumber);
                }
            }
            string digitsText = string.Join("", generatedDigits);
            label2.Text = digitsText;

            // Generate 7 unique numbers between 1 and 49 and a bonus number.
            const int NUM_NUMBERS = 6;
            const int MAX_NUMBER = 49;
            const int MAX_BONUS_NUMBER = 49;

            // List of all possible numbers.
            List<int> lottoNumbers = Enumerable.Range(1, MAX_NUMBER).ToList();

            // List to hold the generated numbers.
            List<int> generatedNumbers = new List<int>();

            // Generate unique random numbers.
            for (int i = 0; i < NUM_NUMBERS; i++)
            {
                int randomNumber = lottoNumbers[random.Next(lottoNumbers.Count)];
                generatedNumbers.Add(randomNumber);
                lottoNumbers.Remove(randomNumber);
            }

            // Sort ascending order.
            generatedNumbers.Sort();

            // Generate a random bonus number.
            int bonusNumber = random.Next(1, MAX_BONUS_NUMBER);

            // Display the generated numbers.
            string numbersText = string.Join(Environment.NewLine, generatedNumbers) + Environment.NewLine + bonusNumber;
            string fullText = $"649, {DateTime.Now}, {string.Join(",", generatedNumbers)}, Bonus {bonusNumber}";
            textBox2.Text = numbersText;

            // Save the generated numbers and bonus number to a text file.
            using (StreamWriter writer = new StreamWriter("LottoNbrs.txt", true))
            {
                writer.WriteLine(fullText);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string title = "Lotto 649 ";

            try
            {
                string fileContent = "";

                // Read the contents of the text file and display it in a message box.
                using (FileStream stream = new FileStream("LottoNbrs.txt", FileMode.Open, FileAccess.Read))
                {
                    // Open the file and read its contents.
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        fileContent = reader.ReadToEnd();// Read the entire contents of the file into a string.
                    }
                }

                MessageBox.Show(fileContent, title);
            }
            catch (IOException ex)
            {
                // If an exception occurs while reading the file, display an error message.
                MessageBox.Show($"Error reading file: {ex.Message}", title);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
