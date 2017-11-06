using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Licenta
{
    public partial class Inregistrare : Form
    {
        public Inregistrare()
        {
            InitializeComponent();
            TextHelp();
        }

        void TextHelp()
        {
            textBox27.GotFocus += new EventHandler(this.TextGotFocus);
            textBox27.LostFocus += new EventHandler(this.TextLostFocus);
            textBox27.Text = "ex: GG123456";
            textBox27.ForeColor = Color.Gray;

        }

        
        OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Licenta.accdb;Persist Security Info=False;");
        OleDbCommand cmd;

        string getDate(string date)
        {
            string[] months = new string[] {"January", "February", "March", "April", "May", "June",
                        "July", "August", "September", "October", "November", "December"};

            string[] data = date.Split(',');

            string result = "";

            string[] mnth = data[1].Split(' ');
            int mn = 0;

            for (int i = 0; i < months.Length; i++)
                if (mnth[1] == months[i])
                    mn = i + 1;

            string year = "";
            for (int i = 1; i < data[2].Length; i++)
                year += data[2][i];

            result = mn.ToString() + "/" + mnth[2] + "/" + year;

            return result;
        }
        

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox21.Text == "" || textBox22.Text == "" || textBox23.Text == "" || textBox24.Text == "" || textBox25.Text == "" || textBox26.Text == "" ||
                comboBox2.Text == "" || textBox27.Text == "" || textBox28.Text == "" || textBox29.Text == "" || textBox30.Text == "" || textBox31.Text == "")
            {
                MessageBox.Show("Nu au fost completate toate campurile !");
                return;
            }
            else
                if (textBox28.Text.Length < 13)
                {
                    MessageBox.Show("CNP-ul nu este valid");
                    return;
                }
                
               
                if (textBox27.Text.Length < 8)
                {
                    MessageBox.Show("Seria de buletin nu este valida");
                    return;
                }

                bool ok = true;

                if (!char.IsLetter(textBox27.Text, 0) || !char.IsLetter(textBox27.Text, 1))
                    ok = false;

                for (int i = 2; i < 8; i++)
                    if (!char.IsDigit(textBox27.Text, i))
                        ok = false;

                if (ok == false)
                {
                    MessageBox.Show("Seria de buletin nu este valida");
                    return;
                }

                string year = getYear(dateTimePicker3.Text);
                int selected = Convert.ToInt32(year);
                if (2017 - selected < 18)
                {
                    MessageBox.Show("Trebuie sa aveti minim 18 ani !");
                    return;
                }
                
           
            
         

            string data = getDate(dateTimePicker3.Text);

            connection.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = "select * from Clienti where Username='" + textBox29.Text + "'";

            OleDbDataReader reader = command.ExecuteReader();
            int count = 0;
            while (reader.Read())
            {
                count = count + 1;
            }

            reader.Dispose();
            connection.Close();

            if (count > 0)
            {
                MessageBox.Show("Exista un asemenea user!");
            }
            else
            {
                connection.Open();
                string sex = comboBox2.Text;
                command.CommandText = "INSERT INTO Clienti(Nume, Prenume, DataNasterii, Tara, Judet, Localitate, Adresa, Sex, SerieBuletin, CNP, Username, Parola, Telefon) values ('" + textBox21.Text + "', '" + textBox22.Text + "','" + data + "', '" + textBox23.Text + "', '" + textBox24.Text + "', '" + textBox25.Text + "', '" + textBox26.Text + "', '" + sex[0] + "', '" + textBox27.Text + "', '" + textBox28.Text + "', '" + textBox29.Text + "', '" + textBox30.Text + "','" + textBox31.Text + "')";
                command.ExecuteNonQuery();
                connection.Close();

                MessageBox.Show("Cont inregistrat cu succes!");

                Inregistrare.ActiveForm.Close();
            }
            this.Validate();
        }

        public void TextGotFocus(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "ex: GG123456")
            {
                tb.Text = "";
                tb.ForeColor = Color.Black;
            }
        }

        public void TextLostFocus(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "")
            {
                tb.Text = "ex: GG123456";
                tb.ForeColor = Color.Gray;
            }
        }

        private void textBox28_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void textBox21_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void textBox22_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void textBox23_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void textBox24_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        private void textBox25_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        string getYear(string date)
        {
            string[] data = date.Split(',');
            string year = "";
            for (int i = 1; i < data[2].Length; i++)
                year += data[2][i];

            return year;
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            string year = getYear(dateTimePicker3.Text);
            int selected = Convert.ToInt32(year);
            if (2017 - selected < 18)
            {
                MessageBox.Show("Trebuie sa aveti minim 18 ani !");
            }
        }
    }
}
