using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Project
{
    public partial class dashBoard : Form
    {
        public dashBoard()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
            
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Confirm Exit", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            lottoMax form2 = new lottoMax();
            form2.Show();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            moneyEx form4 = new moneyEx();
            form4.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            temConvertion form5 = new temConvertion();
            form5.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Calculator formcalc = new Calculator();
            formcalc.Show();


        }

        private void button6_Click(object sender, EventArgs e)
        {
            ipValidator form7 = new ipValidator();
            form7.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lotto649 form3 = new lotto649();
            form3.Show();
        }
    }
}
