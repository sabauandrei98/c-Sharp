using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Conversii
{
    public partial class Arithmetic : Form
    {
        public Arithmetic()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ARITHMETIC OPERATIONS
        /// 
        /// This file contains:
        /// OTHER FUNCTIONS - functions of Visual Studio controls
        /// UI
        /// FUNCTIONALITIES
        /// VALIDATION
        /// UTILS
        /// 
        /// Program made by Sabau Andrei-Mircea. Group 916
        /// </summary>


        ////////////////////////////////////////////////////
        /// OTHER FUNCTIONS
        ////////////////////////////////////////////////////

        private void compute_Click(object sender, EventArgs e)
        {
            ///checks if:
            ///-an operation is selected
            ///-a base is selected
            ///-input is given

            if (emptyFields(operationCombo.SelectedIndex, baseCombo.SelectedIndex, numar.Text, cifra.Text))
            {
                showWarning(1);
                return;
            }

            ///checks if input is in the correct format for the coresponding base
            if (!inputValidation(numar.Text, cifra.Text, baseCombo.Text))
            {
                showWarning(2);
                return;
            }

            ///update the result textBox
            string result = computeOperation(numar.Text, cifra.Text, int.Parse(baseCombo.Text));
            printResult(result);
        }


        private void clearButton_Click(object sender, EventArgs e)
        {
            ///clear the input fields when pressing the clear button
            cifra.Text = "";
            numar.Text = "";
        }

        private void baseCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ///make app user friendly by showing the base after selecting it in the combo box
            baseLabel.Text = "(" + baseCombo.Text + ")";
            updateTipText();
        }

        private void operationCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ///make app user friendly by showing the operation type after selecting it in the combo box
            string[] operations = new string[] { "+", "-", "*", "/" };
            signLabel.Text = operations[operationCombo.SelectedIndex];
        }


        ////////////////////////////////////////////////////
        /// UI
        ////////////////////////////////////////////////////

        void printResult(string res)
        {
            answer.Text = res;
        }

        void updateTipText()
        {
            ///Tip text - shows which values user can introduce in the input field for a coresponding base
            ///Ex: if base 8 is selected:
            ///
            ///Tip: your 'N' may include only these values: 
            ///0, 1, 2, 3, 4, 5, 6, 7

            tip.Text = "";
            int cont = min(int.Parse(baseCombo.Text), 10);

            tip.Text = "Tip: your 'N' may include only these values: \n";
            for (int i = 0; i <= cont - 1; i++)
            {
                tip.Text += i.ToString();
                if (i != cont - 1)
                    tip.Text += ", ";
            }

            if (baseCombo.Text == "16")
                tip.Text += ", A, B, C, D, E, F";
        }

        void showWarning(int warningId)
        {
            ///Message Boxes with warnings when there are empty fields or the input format is not correct

            if (warningId == 1)
                MessageBox.Show("Empty fields !", "Error");
            if (warningId == 2)
                MessageBox.Show("Input format is not correct !", "Error");
            if (warningId == 3)
                MessageBox.Show("Negative result !", "Error");
        }

        string computeOperation(string number, string digit, int bNum)
        {
            ///ADDITON
            if (operationCombo.SelectedIndex == 0)
                return computeAddition(number, digit, bNum);

            ///SUBSTRACTION
            if (operationCombo.SelectedIndex == 1)
                return computeSubtraction(number, digit, bNum);

            ///MULTIPLICATION
            if (operationCombo.SelectedIndex == 2)
                return computeMultiplication(number, digit, bNum);

            ///DIVISON
            if (operationCombo.SelectedIndex == 3)
                return computeDivision(number, digit, bNum);

            return "";
        }


        ////////////////////////////////////////////////////
        /// FUNCTIONALITIES
        ////////////////////////////////////////////////////

        public string computeAddition(string x, string digit, int bNum)
        {

            string result = "";
            int rem = 0;
            int dig = getInt(digit[0]);

            for (int i = x.Length - 1; i >= 0; i--)
            {
                int aux = 0;

                if (i == x.Length - 1)
                    aux = dig;

                aux = aux + (getInt(x[i]) + rem);
                rem = aux / bNum;
                aux %= bNum;

                result += getChar(aux);
            }

            if (rem > 0)
                result += getChar(rem);

            return reversedString(result);
        }

        public string computeSubtraction(string x, string digit, int bNum)
        {

            string result = "";
            int rem = 0;
            int dig = getInt(digit[0]);

            if (int.Parse(x) < int.Parse(digit))
            {
                showWarning(3);
                return "";
            }

            for (int i = x.Length - 1; i >= 0; i--)
            {
                int aux = 0;

                if (i == x.Length - 1)
                    aux = -dig;

                aux = aux + (getInt(x[i]) - rem);

                if (aux < 0)
                {
                    rem = 1;
                    aux += bNum;
                }
                else
                    rem = 0;

                if(i != 0 || aux != 0)
                    result += getChar(aux);
            }

            return reversedString(result);
        }

        public string computeMultiplication(string x, string digit, int bNum)
        {

            string result = "";
            int rem = 0;
            int dig = getInt(digit[0]);

            for (int i = x.Length - 1; i >= 0; i--)
            {
                int aux = 0;

                aux = getInt(x[i]) * dig + rem;
                rem = aux / bNum;
                aux %= bNum;

                result += getChar(aux);
            }

            if (rem > 0)
                result += getChar(rem);

            return reversedString(result);
        }

        public string computeDivision(string x, string digit, int bNum)
        {

            string result = "";
            int rem = 0;
            int dig = getInt(digit[0]);

            for (int i = 0; i < x.Length; i++)
            {
                int aux = 0;

                aux = getInt(x[i]) + bNum * rem;

                rem = aux % dig;
                aux /= dig;

                if (i != 0 || aux != 0)
                    result += getChar(aux);
            }

            return result;
        }

        

        public string fromBaseToBase(int from, int to, string x)
        {
            ///from - source base
            ///to - destination base
            ///x - the input number as string

            int f = 1;
            int number = 0;

            ///CONVERSION FROM 'from' TO BASE 10
            for (int i = x.Length - 1; i >= 0; i--)
            {
                number += getInt(x[i]) * f;
                f *= from;
            }

            ///PARTICULAR CASE IF THE GIVEN NUMBER IS 0
            string res = "";
            if (number == 0)
                res = "0";

            ///CONVERSION TO THE CORESPONDING BASE 'to'
            while (number != 0)
            {
                int rem = number - (number / to) * to;
                res += getChar(rem);
                number /= to;
            }

            ///RETURN THE REVERSED STRING
            return reversedString(res);
        }


        ////////////////////////////////////////////////////
        /// VALIDATION
        ////////////////////////////////////////////////////

        bool emptyFields(int operationIndex, int baseIndex, string number, string digit)
        {
            ///checks if:
            ///-an operation is selected
            ///-a base is selected
            ///-input is given

            if (operationIndex == -1 || baseIndex == -1 || number == "" || digit == "")
                return true;
            return false;
        }


        bool inputValidation(string numar, string cifra, string nBase)
        {
            ///checks if input is in the correct format for the coresponding base

            ///available characters
            string baseStr = "0123456789ABCDEF";

            bool fineDigit = false;
            for (int i = 0; i < int.Parse(nBase); i++)
                if (cifra[0] == baseStr[i])
                    fineDigit = true;

            if (!fineDigit)
                return false;

            int baseCmb = int.Parse(nBase);

            ///check each character in numar string if it contains right chars
            for (int i = 0; i < numar.Length; i++)
            {
                bool fine = false;
                for (int j = 0; j < baseCmb; j++)
                    if (numar[i] == baseStr[j])
                        fine = true;

                if (!fine)
                    return false;
            }
            return true;
        }


        ////////////////////////////////////////////////////
        /// UTILS
        ////////////////////////////////////////////////////

        int max(int a, int b)
        {
            if (a > b)
                return a;
            return b;
        }

        int min(int a, int b)
        {
            if (a < b)
                return a;
            return b;
        }

        int getInt(char s)
        {
            ///get the coresponding number from a char or int
            ///ex: s = A 
            ///return 10
            ///
            ///ex: s = F
            ///return 15
            ///
            ///ex: s = 2
            ///return 2

            if (s <= '9')
                return s - '0';
            return 10 + s - 'A';
        }

        char getChar(int s)
        {
            ///get the coresponding char from an int
            ///ex: s = 2 
            ///return '2'
            ///
            ///ex: s = 15
            ///return 'F'
            ///
            ///ex: s = 10
            ///return 'A'

            if (s < 10)
                return (char)('0' + s);
            else
                return (char)('F' - (16 - s) + 1);
        }

        string reversedString(string s)
        {
            string res = "";

            for (int i = s.Length - 1; i >= 0; i--)
                res += s[i];
            
            return res;
        }
    }
}
