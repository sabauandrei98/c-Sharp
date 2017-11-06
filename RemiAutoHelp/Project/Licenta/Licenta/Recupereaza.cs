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
    public partial class Recupereaza : Form
    {
        public Recupereaza()
        {
            InitializeComponent();
        }

        OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Licenta.accdb;Persist Security Info=False;");
        OleDbCommand cmd;

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Nu au fost completate toate campurile !");
                return;
            }
            else
            if (textBox1.Text.Length < 13)
            {
                MessageBox.Show("CNP-ul nu este valid");
                return;
            }

            connection.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = "select Parola from Clienti where CNP = '" + textBox1.Text + "' AND Username='" + textBox2.Text + "'";

            OleDbDataReader reader = command.ExecuteReader();
            int count = 0;
            string parola = "";
            while (reader.Read())
            {
                count = count + 1;
                parola = reader[0].ToString();
            }

            reader.Dispose();
            connection.Close();

            if (count == 0)
            {
                MessageBox.Show("Posibile erori: \n 1. Datele introduse nu sunt valide \n 2. User-ul/CNP-ul nu exista in baza de date");
            }

            if (count > 0)
            {
                MessageBox.Show("Parola dumneavoastra este: " + parola);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
