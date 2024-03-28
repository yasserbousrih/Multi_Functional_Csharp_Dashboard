using System;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

public class calc
{
    private decimal currentValue;
    public decimal operand1;
    private decimal operand2;
    private string op;
    private bool decimalPointAdded;
    private StreamWriter writer;
    public calc()
    {
        currentValue = 0;
        operand2 = 0;
        op = null;
        decimalPointAdded = false;
        writer = new StreamWriter("Calculator.txt");
    }

    public decimal CurrentValue
    {
        get { return currentValue; }
    }

    public void AdditiveOperation(decimal par)
    {
        operand1 = par;
        op = "+";
        decimalPointAdded = false;
    }


    public void Subtract(decimal par)
    {
        operand1 = par;
        op = "-";
        decimalPointAdded = false;
    }
    public void Multiply(decimal par)
    {
        operand1 = par;
        op = "*";
        decimalPointAdded = false;
    }

    public void Divide(decimal par)
    {
        operand1 = par;
        op = "/";
        decimalPointAdded = false;
    }

    public void Equals(decimal par)
    {
        operand2 = par;
        switch (op)
        {
            case "+":
                currentValue = operand1 + operand2;
                writer.WriteLine(operand1.ToString() + " + " + operand2.ToString() + " = " + currentValue.ToString());
                writer.Flush();
                break;
            case "-":
                currentValue = operand1 - operand2;
                writer.WriteLine(operand1.ToString() + " - " + operand2.ToString() + " = " + currentValue.ToString());
                writer.Flush();
                break;
            case "*":
                currentValue = operand1 * operand2;
                writer.WriteLine(operand1.ToString() + " * " + operand2.ToString() + " = " + currentValue.ToString());
                writer.Flush();
                break;
            case "/":
                if (operand2 != 0)
                {
                    currentValue = operand1 / operand2;
                    writer.WriteLine(operand1.ToString() + " / " + operand2.ToString() + " = " + currentValue.ToString());
                    writer.Flush();
                }
                else
                {
                    MessageBox.Show("Cannot divide by zero!");
                }
                break;
            default:
                break;
        }

        decimalPointAdded = false;
    }

    public void Clear()
    {
        currentValue = 0;
        operand1 = 0;
        operand2 = 0;
        op = null;
        decimalPointAdded = false;
    }

    public void CloseFile()
    {
        writer.Close();
    }
}
