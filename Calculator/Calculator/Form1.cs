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
        double tempResult = 0;
        bool isNewNum = true;
        bool secondOper = false;
        bool operContinue = false;
        string oper = "+";
        string preButtonOper = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void button0_Click(object sender, EventArgs e)
        {
            Button buttonNum = (Button)sender;
            preButtonOper = "";
            operContinue = false;
            if (isNewNum)
            {
                if (label1.Text == "0")
                {
                    if(buttonNum.Text == ".")
                    {
                        label1.Text = label1.Text + buttonNum.Text;
                        if (countDot(label1.Text) > 0)
                        {
                            buttonDot.Enabled = false;
                        }
                    }
                    else
                    {
                        label1.Text = buttonNum.Text;
                    }
                }
                else
                {   
                    label1.Text = label1.Text + buttonNum.Text;
                    if (countDot(label1.Text) > 0)
                    {
                        buttonDot.Enabled = false;
                    }
                }
            }
            else
            {   
                label1.Text = buttonNum.Text;
                if(buttonNum.Text == ".")
                {
                    label1.Text = "0" + buttonNum.Text;
                }
                isNewNum = true;
            }
            label2.Text = label1.Text;
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            Button buttonOper = (Button)sender;
            buttonDot.Enabled = true;
            if (!operContinue)
            {
                if (buttonOper.Text.Equals(preButtonOper))
                {
                    return;
                }

                if (!secondOper)
                {
                    tempResult = Double.Parse(label1.Text);
                    oper = decisionOper(buttonOper.Text);
                    secondOper = true;
                }
                else
                {
                    if (oper == "+")
                    {
                        tempResult = tempResult + Double.Parse(label1.Text);
                        oper = buttonOper.Text;
                    }
                    else if (oper == "-")
                    {
                        tempResult = tempResult - Double.Parse(label1.Text);
                        oper = buttonOper.Text;
                    }
                    else if (oper == "*")
                    {
                        tempResult = tempResult * Double.Parse(label1.Text);
                        oper = buttonOper.Text;
                    }
                    else if (oper == "/")
                    {
                        tempResult = tempResult / Double.Parse(label1.Text);
                        oper = buttonOper.Text;
                    }
                }
                label3.Text = tempResult.ToString();
                tempLabel.Text = tempLabel.Text + label1.Text + buttonOper.Text;
                isNewNum = false;
                preButtonOper = buttonOper.Text;
                operContinue = true;
            }

            if (operContinue)
            {
                oper = decisionOper(buttonOper.Text);
                int startIndex = tempLabel.Text.Length - 1;
                string a = tempLabel.Text.Substring(startIndex, 1); //마지막 문자 즉, 연산자

                tempLabel.Text = tempLabel.Text.Replace(a, buttonOper.Text);
            }
            
        }

        private void buttonEqual_Click(object sender, EventArgs e)
        {
            buttonDot.Enabled = true;
            double secondValue = Double.Parse(label2.Text);

            if (oper == "+")
            {
                tempResult = tempResult + secondValue;
            }else if(oper == "-")
            {
                tempResult = tempResult - secondValue;
            }else if(oper == "*")
            {
                tempResult = tempResult * secondValue;
            }else if(oper == "/")
            {
                tempResult = tempResult / secondValue;
            }

            label1.Text = tempResult.ToString();
            tempLabel.Text = "";
            isNewNum = false;
            secondOper = false;
        }

        private void buttonC_Click(object sender, EventArgs e)
        {
            tempResult = 0;
            isNewNum = true;
            oper = "+";
            label1.Text = "0";
            label2.Text = "0";
            tempLabel.Text = "";
            secondOper = false;
            buttonDot.Enabled = true;
            label3.Text = "0";
            preButtonOper = "";
            operContinue = false;
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            label1.Text = label1.Text.Remove(label1.Text.Length - 1, 1);
            if(label1.Text.Length == 0)
            {
                label1.Text = "0";
            }
            if(countDot(label1.Text) == 0)
            {
                buttonDot.Enabled = true;
            }
        }

        public int countDot(string input)
        {
            int count = (input.Length - input.Replace(".", "").Length) / ".".Length;
            return count;
        }

        public string decisionOper(string buttonText)
        {
            string oper = "";
            if(buttonText == "+")
            {
                oper = "+";
            }else if(buttonText == "-")
            {
                oper = "-";
            }else if(buttonText == "*")
            {
                oper = "*";
            }else if(buttonText == "/")
            {
                oper = "/";
            }
            return oper;
        }
    }
    //계산기 완성
    //변경내용 적용 성공
}
