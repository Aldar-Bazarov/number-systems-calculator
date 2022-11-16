using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsCalc
{
    public partial class Form1 : Form
    {
        static Dictionary<char, int> symbolToDigit = new Dictionary<char, int>()
        {
            { '0', 0 },
            { '1', 1 },
            { '2', 2 },
            { '3', 3 },
            { '4', 4 },
            { '5', 5 },
            { '6', 6 },
            { '7', 7 },
            { '8', 8 },
            { '9', 9 },
            { 'A', 10 },
            { 'B', 11 },
            { 'C', 12 },
            { 'D', 13 },
            { 'E', 14 },
            { 'F', 15 },
        };

        static Dictionary<int, char> digitToSymbol = new Dictionary<int, char>()
        {
            { 0, '0' },
            { 1, '1' },
            { 2, '2' },
            { 3, '3' },
            { 4, '4' },
            { 5, '5' },
            { 6, '6' },
            { 7, '7' },
            { 8, '8' },
            { 9, '9' },
            { 10, 'A' },
            { 11, 'B' },
            { 12, 'C' },
            { 13, 'D' },
            { 14, 'E' },
            { 15, 'F' },
        };
        public Form1()
        {
            InitializeComponent();
        }

        public static int ConvertAnyToDecimal(string originNumber, int numberSystem)
        {
            double resultDecimalNumber = 0;

            int degree = originNumber.Length - 1;

            for (int i = 0; i < originNumber.Length; i++)
            {
                int tmp = symbolToDigit[originNumber[i]];
                resultDecimalNumber += tmp * Math.Pow(numberSystem, degree);
                degree--;
            }

            return (int)resultDecimalNumber;
        }

        public static string ConvertDecimalToAny(int originNumber, int numberSystem)
        {
            string resultNumber = "";

            while (originNumber > 0)
            {
                int tmp = originNumber % numberSystem;
                if (originNumber < numberSystem && originNumber != 0)
                    resultNumber += digitToSymbol[originNumber];
                else
                    resultNumber += digitToSymbol[tmp];
                originNumber = originNumber / numberSystem;
            }

            return new string(resultNumber.Reverse().ToArray());
        }

        public static int Add(int firstNumber, int secondNumber)
        {

            return firstNumber + secondNumber;
        }

        public static int Multiply(int firstNumber, int secondNumber)
        {
            return firstNumber * secondNumber;
        }

        private void additional_button_Click(object sender, EventArgs e)
        {
            string firstNumber = firstNumber_textBox.Text;
            string secondNumber = secondNumber_textBox.Text;

            int firstSystem = Convert.ToInt32(firstNumberSystem_textBox.Text);
            int secondSystem = Convert.ToInt32(secondNumberSystem_textBox.Text);

            int firstNumberInDecimal = ConvertAnyToDecimal(firstNumber, firstSystem);
            int secondNumberInDecimal = ConvertAnyToDecimal(secondNumber, secondSystem);

            int result = Add(firstNumberInDecimal, secondNumberInDecimal);
            int resultSystem = Convert.ToInt32(resultNumberSystem_textBox.Text);
            result_textBox.Text = ConvertDecimalToAny(result, resultSystem);
        }

        private void multiply_button_Click(object sender, EventArgs e)
        {
            string firstNumber = firstNumber_textBox.Text;
            string secondNumber = secondNumber_textBox.Text;

            int firstSystem = Convert.ToInt32(firstNumberSystem_textBox.Text);
            int secondSystem = Convert.ToInt32(secondNumberSystem_textBox.Text);

            int firstNumberInDecimal = ConvertAnyToDecimal(firstNumber, firstSystem);
            int secondNumberInDecimal = ConvertAnyToDecimal(secondNumber, secondSystem);

            int result = Multiply(firstNumberInDecimal, secondNumberInDecimal);
            int resultSystem = Convert.ToInt32(resultNumberSystem_textBox.Text);
            result_textBox.Text = ConvertDecimalToAny(result, resultSystem);
        }
    }
}
