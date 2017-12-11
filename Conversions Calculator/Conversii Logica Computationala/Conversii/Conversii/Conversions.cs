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
    public partial class Conversions : Form
    {
        public Conversions()
        {
            InitializeComponent();
            
        }

        ////////////////////////////////////////////////////
        /// OTHER FUNCTIONS
        ////////////////////////////////////////////////////


        private void convert_Click(object sender, EventArgs e)
        {
            if (emptyFields())
            {
                showWarning(1);
                return;
            }
            if (!inputValidation())
            {
                showWarning(2);
                return;
            }

            printResult(computeOperation());
        }

        private void operationType_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateComboText();
        }

        private void fromBase_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateTipText();
            updateFromBaseLabel();
        }

        private void toBase_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateToBaseLabel();
        }

        ////////////////////////////////////////////////////
        /// UI
        ////////////////////////////////////////////////////

        void printResult(string x)
        {
            resultTextBox.Text = x;
        }

        void updateTipText()
        {
            tip.Text = "";
            int cont = int.Parse(fromBase.Text);
            if (cont == 16)
                cont = 10;

            tip.Text = "Tip: your input may include only these values: \n";
            for (int i = 0; i <= cont - 1; i++)
            {
                tip.Text += i.ToString();
                if (i != cont - 1)
                    tip.Text += ", ";
            }

            if (fromBase.Text == "16")
                tip.Text += ", A, B, C, D, E, F";
        }

        void updateComboText()
        {
            fromBase.Enabled = true;
            toBase.Enabled = true;

            if (operationType.SelectedIndex != 2)
            {
                fromBase.Items.Clear();
                toBase.Items.Clear();

                for (int i = 2; i <= 10; i++)
                {
                    fromBase.Items.Add(i);
                    toBase.Items.Add(i);
                }
                fromBase.Items.Add(16);
                toBase.Items.Add(16);
            }
            else
            {
                fromBase.Items.Clear();
                fromBase.Items.Add(2);
                fromBase.Items.Add(4);
                fromBase.Items.Add(8);
                fromBase.Items.Add(16);

                toBase.Items.Clear();
                toBase.Items.Add(2);
                toBase.Items.Add(4);
                toBase.Items.Add(8);
                toBase.Items.Add(16);
            }
        }

        void updateFromBaseLabel()
        {
            fromBaseLabel.Text = "(" + fromBase.Text + ")";
        }

        void updateToBaseLabel()
        {
            toBaseLabel.Text = "(" + toBase.Text + ")";
        }

        void showWarning(int warningId)
        {
            if (warningId == 1)
                MessageBox.Show("Empty fields !", "Error");
            if (warningId == 2)
                MessageBox.Show("Input format is not correct !", "Error");
            if (warningId == 3)
                MessageBox.Show("Invalid base or destionation base !", "Error");
        }

        string computeOperation()
        {
            if (operationType.SelectedIndex == 0)
                return substitutionMethod(int.Parse(fromBase.Text), int.Parse(toBase.Text), inputTextBox.Text);


            if (operationType.SelectedIndex == 2)
                return rapidConversion(int.Parse(fromBase.Text), int.Parse(toBase.Text), inputTextBox.Text);

            return "";  
        }

        ////////////////////////////////////////////////////
        /// FUNCTIONALITIES
        ////////////////////////////////////////////////////

        string fromBaseToBase(int from, int to, string x)
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
                return "0";

            ///CONVERSION TO THE CORESPONDING BASE 'to'
            while (number != 0)
            {
                int rem = number - (number / to) * to;
                res += getChar(rem);
                number /= to;
            }
            return reversedString(res);
        }

        string rapidConversion(int from, int to, string x)
        {
            int[,] rapid = new int[20,20];
            ///PREDEFINITED VALUES
            for (int i = 2; i <= 16; i += 2)
                for (int j = 2; j <= 16; j += 2)
                    rapid[i, j] = -1;

            /// base < dest
            rapid[2, 4] = 2;
            rapid[2, 8] = 3;
            rapid[2, 16] = 4;
            rapid[4, 16] = 2;

            /// base > dest
            rapid[16, 2] = 4;
            rapid[16, 4] = 2;
            rapid[8, 2] = 3;
            rapid[4, 2] = 2;

            /// base = dest
            rapid[from, from] = 0;

            string result = "";
            int len = rapid[from, to];

            if (len == -1)
            {
                showWarning(3);
                return "";
            }

            if (from > to)
            {
                for (int i = 0; i < x.Length; i++)
                {
                    string partial = fromBaseToBase(from, to, x[i].ToString());
                    result += suffixZero(partial, len) + " ";
                }
            }
            else
            if (from < to)
            {
                int aux = len;
                while (x.Length > aux)
                    aux += len;

                x = suffixZero(x, aux);

                for (int i = 0; i < x.Length; i += len)
                {
                    string transform = "";
                    for (int j = i; j <= i + len - 1; j++)
                        transform += x[j];

                    result += fromBaseToBase(from, to, transform);
                }
            }
            else
                result = x;

            return result;
        }


        string substitutionMethod(int from, int to, string x)
        {
            if (from > to)
            {
                showWarning(4);
                return "";
            }

            Int64 sum = 0;
            int p = 1;

            for (int i = x.Length - 1; i >= 0; i--)
            {
                sum += (x[i] - '0') * p;
                p *= from;
            }
            return fromBaseToBase(10, to, sum.ToString());
        }

        ////////////////////////////////////////////////////
        /// VALIDATION
        ////////////////////////////////////////////////////


        bool emptyFields()
        {
            if (operationType.SelectedIndex == -1 || fromBase.SelectedIndex == -1 || toBase.SelectedIndex == -1 || inputTextBox.Text == "")
                return true;
            return false;
        }

        bool inputValidation()
        {
            string input = inputTextBox.Text;
            string baseStr = "0123456789ABCDEF";
            int baseCmb = int.Parse(fromBase.Text);

            for (int i = 0; i < input.Length; i++)
            {
                bool fine = false;
                for (int j = 0; j < baseCmb; j++)
                    if (input[i] == baseStr[j])
                        fine = true;

                if (!fine)
                {
                    
                    showWarning(4);
                    return false;
                }
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


        string suffixZero(string x, int len)
        {
            string zero = "";
            while (x.Length + zero.Length != len)
                zero += '0';

            return zero + x;
        }

        char getChar(int s)
        {
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
