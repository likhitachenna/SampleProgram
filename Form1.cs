using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Calculator
{
    public partial class Form1 : Form
    {
        Double result = 0;
        String operationPerformed = "";
        bool IsOperatorClicked = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void number_click(object sender, EventArgs e)
        {
            if(text_Result.Text == "0")
                text_Result.Clear();
            if(IsOperatorClicked)
                text_Result.Clear();
            IsOperatorClicked = false;
            Button button = (Button)sender;
            text_Result.Text = text_Result.Text + button.Text;
        }

        private void Operator_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if(result != 0)
            {
                btnEquals.PerformClick();
            }
            operationPerformed = button.Text;
            result = Double.Parse(text_Result.Text);
            if (label.Text != "")
                label.Text = "";
            if (operationPerformed == "+" || operationPerformed == "-" || operationPerformed == "*" || operationPerformed == "/")
                label.Text = result + " " + operationPerformed;
            else
                label.Text = operationPerformed + " (" + result + ")";
            IsOperatorClicked = true;
        }


        private void clear_click(object sender, EventArgs e)
        {
            text_Result.Text = "0";
            result = 0;
            label.Text = "";
        }


        private void Result_click(object sender, EventArgs e)
        {
            switch (operationPerformed)
            {   
                case "+":
                    label.Text = label.Text + " " + text_Result.Text;
                    text_Result.Text = (result + Double.Parse(text_Result.Text)).ToString();
                    break;
                case "-":
                    label.Text = label.Text + " " + text_Result.Text;
                    text_Result.Text = (result - Double.Parse(text_Result.Text)).ToString();
                    break;
                case "*":
                    label.Text = label.Text + " " + text_Result.Text;
                    text_Result.Text = (result * Double.Parse(text_Result.Text)).ToString();
                    break;
                case "/":
                    label.Text = label.Text + " " + text_Result.Text;
                    text_Result.Text = (result / Double.Parse(text_Result.Text)).ToString();
                    break;
                case "log":
                    text_Result.Text = (Math.Log10(result)).ToString();
                    break;
                case "ln":
                    text_Result.Text = (Math.Log(result)).ToString();
                    break;
                case "sin":
                    text_Result.Text = (Math.Sin(result)).ToString();
                    break;
                case "cos":
                    text_Result.Text = (Math.Cos(result)).ToString();
                    break;
                case "tan":
                    text_Result.Text = (Math.Tan(result)).ToString();
                    break;
                case "exp":
                    text_Result.Text = (Math.Exp(result)).ToString();
                    break;
                case "sqr":
                    text_Result.Text = (Math.Pow(result,2)).ToString();
                    break;
                default:
                    break;
            }
            label.Text = label.Text + " =";
            result = Double.Parse(text_Result.Text);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
