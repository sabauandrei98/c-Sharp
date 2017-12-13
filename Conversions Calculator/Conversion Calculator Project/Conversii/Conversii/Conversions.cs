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
            ///checks if:
            ///-an operation is selected
            ///-a base is selected
            ///-input is given

            if (emptyFields())
            {
                showWarning(1);
                return;
            }

            ///checks if input is in the correct format for the coresponding base
            if (!inputValidation())
            {
                showWarning(2);
                return;
            }

            ///update the result textBox
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
            /// x - string, the result which will be printed
            resultTextBox.Text = x;
        }

        void updateTipText()
        {
            ///Tip text - shows which values user can introduce in the input field for a coresponding base
            ///Ex: if base 8 is selected:
            ///
            ///Tip: your 'N' may include only these values: 
            ///0, 1, 2, 3, 4, 5, 6, 7

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

            ///if base 16, concatenate the following
            if (fromBase.Text == "16")
                tip.Text += ", A, B, C, D, E, F";
        }

        void updateComboText()
        {
            ///update combo text for rapid conversions to show only the possible cases

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
            ///warningId - index of desired error type
            ///Message Boxes with warnings when there are empty fields or the input format is not correct

            if (warningId == 1)
                MessageBox.Show("Empty fields !", "Error");
            if (warningId == 2)
                MessageBox.Show("Input format is not correct !", "Error");
            if (warningId == 3)
                MessageBox.Show("Invalid base or destionation base !", "Error");
        }

        string computeOperation()
        {
            ///check which index was selected
            /// 0 - substitution
            /// 1 - succesive div
            /// 2 - rapid conv
            /// return a string containg the answer

            if (operationType.SelectedIndex == 0)
                return substitutionMethod(int.Parse(fromBase.Text), int.Parse(toBase.Text), inputTextBox.Text);

            if (operationType.SelectedIndex == 1)
                return successveDivisions(int.Parse(fromBase.Text), int.Parse(toBase.Text), inputTextBox.Text);

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
            /// from - int, current base
            /// to - int, destination base
            /// x - string, the value
            /// returns a string as result

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
            ///get the length of a pair
            int len = rapid[from, to];

            ///check if rapid conversion can be applied
            if (len == -1)
            {
                showWarning(3);
                return "";
            }


            ///destination base lower than current base
            if (from > to)
            {
                for (int i = 0; i < x.Length; i++)
                {
                    ///partial - string which represents a group which will be concatenated to the result
                    string partial = fromBaseToBase(from, to, x[i].ToString());
                    result += suffixZero(partial, len) + " ";
                }
            }
            else
            ///destination base greater than current base
            if (from < to)
            {
                ///make the pair full
                int aux = len;
                while (x.Length > aux)
                    aux += len;

                ///suffix the last pair with zeroes if its needed
                x = suffixZero(x, aux);


                ///get a pair and transform it to a single value
                for (int i = 0; i < x.Length; i += len)
                {
                    ///transform - represents a pair in the initial string which will be converted to a single value in the destination base
                    string transform = "";
                    for (int j = i; j <= i + len - 1; j++)
                        transform += x[j];

                    ///concatenate to te result
                    result += fromBaseToBase(from, to, transform);
                }
            }
            else
                ///currentBase = destinationBase
                result = x;

            /// return the result
            return result;
        }


        public string computeDivision(string x, string digit, int bNum)
        {
            /// x - string representing the input 
            /// digit - string representing the digit which will be used to perform arithmetic operations
            /// bNum - integer representing the base
            /// return - string representing the answer

            ///result - the string which will be returned
            ///rem - int remainder
            ///dig - integer digit
            string result = "";
            int rem = 0;
            int dig = getInt(digit[0]);

            /// 0 if number is less than digit
            if (int.Parse(fromBaseToBase(bNum, 10, x)) < dig)
                return "0";

            ///get each char from the number
            for (int i = 0; i < x.Length; i++)
            {
                int aux = 0;

                ///aux = value of digit from number after division
                aux = getInt(x[i]) + bNum * rem;

                ///build remainder for the next divisions
                ///ex: 3421(5) : 2(5)
                ///iteration 1:
                ///rem = 1 (3%2)
                ///dig = 1 (3/2)
                ///res = 1
                ///because of rem = 1, this will be moved to the next position

                ///iteration 2:
                ///because of the rem = 1 from the prev iteration
                ///rem = 1 (4 + 5)%2
                ///dig = 4 (4 + 5)/2
                ///res = 14
                ///and so on..
                rem = aux % dig;
                aux /= dig;

                ///avoid to put 0 on first position
                if (i != 0 || aux != 0)
                    result += getChar(aux);
            }
            ///return the result
            return result;
        }

        string successveDivisions(int from, int to, string x)
        {
            /// from - int, current base
            /// to - int, destination base
            /// x - string, the value
            /// returns a string as result

            string result = "";
            Int64 n = Int64.Parse(fromBaseToBase(from, 10, x));
            int rest = 0;
            Int64 aux;

            while (n != 0)
            {
                ///compute the division
                aux = n / to;

                ///find the remainder
                rest = (int)(n - aux * to);

                ///update n
                n = aux;

                ///concatenate the result
                result += getChar(rest);
                
            }

            ///return the reversed string
            return reversedString(result);
        }


        string substitutionMethod(int from, int to, string x)
        {
            /// from - int, current base
            /// to - int, destination base
            /// x - string, the value
            /// returns a string as result

            ///precondition, destination base must be greater
            if (from > to)
            {
                showWarning(4);
                return "";
            }

            Int64 sum = 0;
            int p = 1;

            ///get each char from the string
            for (int i = x.Length - 1; i >= 0; i--)
            {
                ///convert the number to base 10 using the powers of base
                sum += (x[i] - '0') * p;
                p *= from;
            }

            ///we have the result in base 10 -> convert it do destination base
            return fromBaseToBase(10, to, sum.ToString());
        }

        ////////////////////////////////////////////////////
        /// VALIDATION
        ////////////////////////////////////////////////////


        bool emptyFields()
        {
            ///checks if:
            ///-an operation is selected
            ///-a base is selected
            ///-input is given
            ///return true if all conditions are respected, false otherwise

            if (operationType.SelectedIndex == -1 || fromBase.SelectedIndex == -1 || toBase.SelectedIndex == -1 || inputTextBox.Text == "")
                return true;
            return false;
        }

        bool inputValidation()
        {
            ///checks if input is in the correct format for the coresponding base
            ///returns true if it is correct, false otherwise

            ///available characters
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
            ///x - string, the element which will be be modified
            ///len - int, the final length of x
            
            ///suffixes the string x with: len - len(x) zeroes
            ///ex: x = "111", len = 5
            ///return "00111"

            string zero = "";
            while (x.Length + zero.Length != len)
                zero += '0';

            return zero + x;
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
            ///s - string
            ///return - reversed string

            string res = "";

            for (int i = s.Length - 1; i >= 0; i--)
                res += s[i];

            return res;
        }

    }
}
