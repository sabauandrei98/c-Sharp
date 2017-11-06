using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Licenta
{
    public partial class Form1 : Form
    {
        private OleDbConnection connection = new OleDbConnection();
        string numeclient;
        string prenumeclient;
        string telefonclient;

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Licenta.accdb;
Persist Security Info=False;";
            try
            {
                connection.Open();

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
                MessageBox.Show("Selectati tipul de login Administrator/Client");
            else
            if (comboBox1.SelectedItem.Equals("Client"))
            {
                {
                    connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Licenta.accdb;
Persist Security Info=False;";
                    connection.Open();
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    command.CommandText = "select * from Clienti where Username='" + textBox1.Text + "' and Password='" + textBox2.Text + "'";

                    OleDbDataReader reader = command.ExecuteReader();
                    int count = 0;
                    while (reader.Read())
                    {
                        count = count + 1;
                        numeclient = reader["Nume"].ToString();
                        prenumeclient = reader["Prenume"].ToString();
                        telefonclient = reader["Telefon"].ToString();

                    }
                    if (count == 1)
                    {
                        MessageBox.Show("User si parola sunt corecte!");

                        if (comboBox1.Text == "Client")
                        {
                            CreareContClient.Visible = true;


                        }

                        groupBox1.Visible = false;
                        dataGridView1.Visible = true;
                        groupBox2.Visible = true;
                        textBox3.Text = numeclient;
                        textBox4.Text = prenumeclient;
                        textBox5.Text = telefonclient;
                        OleDbCommand command2 = new OleDbCommand();
                        command2.Connection = connection;
                        command2.CommandText = "select * from Automobile";
                        OleDbDataReader reader2 = command2.ExecuteReader();
                        while (reader2.Read())
                        {
                            dataGridView1.Rows.Add(reader2["Marca"], reader2["Model"], reader2["AnFabricatie"], reader2["Combustibil"], reader2["PutereMotor"], reader2["CapCilindrica"], reader2["Acceleratie"], reader2["VitezaMaxima"], reader2["ConsumUrban"], reader2["ConsumMixt"], reader2["TipTransmisie"], reader2["Tractiune"], reader2["NumarUsi"], reader2["PretDDP"]);
                        }



                    }
                    else if (count > 1)
                    {
                        MessageBox.Show("User si parola sunt duplicate!");
                    }
                    else
                    {
                        MessageBox.Show("User sau parola introduse gresit!");
                    }
                    connection.Close();
                }
            }
            else
            if (comboBox1.SelectedItem.Equals("Administrator"))
            {
                {
                    connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Licenta.accdb;
Persist Security Info=False;";
                    connection.Open();
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    command.CommandText = "select * from Administrator where Username='" + textBox1.Text + "' and Password='" + textBox2.Text + "'";

                    OleDbDataReader reader = command.ExecuteReader();
                    int count = 0;
                    while (reader.Read())
                    {
                        count = count + 1;

                    }
                    if (count == 1)
                    {
                        MessageBox.Show("User si parola sunt corecte!");
                        groupBox1.Visible = false;
                        dataGridView1.Visible = true;
                        groupBox3.Visible = true;
                        groupBox4.Visible = true;

                        OleDbCommand command2 = new OleDbCommand();
                        command2.Connection = connection;
                        command2.CommandText = "select * from Automobile";
                        OleDbDataReader reader2 = command2.ExecuteReader();
                        while (reader2.Read())
                        {
                            dataGridView1.Rows.Add(reader2["Marca"], reader2["Model"], reader2["AnFabricatie"], reader2["Combustibil"], reader2["PutereMotor"], reader2["CapCilindrica"], reader2["Acceleratie"], reader2["VitezaMaxima"], reader2["ConsumUrban"], reader2["ConsumMixt"], reader2["TipTransmisie"], reader2["Tractiune"], reader2["NumarUsi"], reader2["PretDDP"]);
                        }

                        OleDbCommand command3 = new OleDbCommand();
                        command3.Connection = connection;
                        command3.CommandText = "select * from Programari";
                        OleDbDataReader reader3 = command3.ExecuteReader();
                        while (reader3.Read())
                        {
                            dataGridView2.Rows.Add(reader3["Nume"], reader3["Prenume"], reader3["Data"], reader3["Ora"], reader3["Telefon"]);
                        }
                    }
                    else if (count > 1)
                    {
                        MessageBox.Show("User si parola sunt duplicate!");
                    }
                    else
                    {
                        MessageBox.Show("User sau parola introduse gresit!");
                    }
                    connection.Close();
                }
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connection.Open();
            OleDbCommand command3 = new OleDbCommand();
            command3.Connection = connection;
            command3.CommandText = "INSERT into Programari(Nume, Prenume, Data, Ora, Telefon) values ('" + textBox3.Text + "', '" + textBox4.Text + "','" + dateTimePicker1.Text + "', '" + dateTimePicker2.Text + "', '" + textBox5.Text + "')";
            OleDbDataReader reader = command3.ExecuteReader();
            reader.Read();
            connection.Close();
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            connection.Open();
            OleDbCommand command3 = new OleDbCommand();
            command3.Connection = connection;
            command3.CommandText = "INSERT into Automobile(Marca, Model, AnFabricatie, Combustibil, PutereMotor, CapCilindrica, Acceleratie, VitezaMaxima, ConsumUrban, ConsumMixt, TipTransmisie, Tractiune, NumarUsi, PretDDP) values ('" + textBox6.Text + "', '" + textBox7.Text + "','" + textBox8.Text + "', '" + textBox9.Text + "', '" + textBox10.Text + "', '" + textBox11.Text + "','" + textBox12.Text + "', '" + textBox13.Text + "', '" + textBox14.Text + "', '" + textBox15.Text + "', '" + textBox16.Text + "', '" + textBox17.Text + "','" + textBox18.Text + "', '" + textBox19.Text + "')";
            OleDbDataReader reader = command3.ExecuteReader();
            reader.Read();
            connection.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            {
                dataGridView2.Rows.Clear();
                dataGridView2.Refresh();
                connection.Open();
                OleDbCommand command5 = new OleDbCommand();
                command5.Connection = connection;
                command5.CommandText = "INSERT into Programari(Nume, Prenume, Data, Ora, Telefon) values ('" + textBox3.Text + "', '" + textBox4.Text + "','" + dateTimePicker1.Text + "', '" + dateTimePicker2.Text + "', '" + textBox5.Text + "') WHERE Nume='" + textBox20.Text + "'";
                OleDbDataReader reader = command5.ExecuteReader();
                reader.Read();
                connection.Close();

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            connection.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = "INSERT into Clienti(Marca, Model, AnFabricatie, Combustibil, PutereMotor, CapCilindrica, Acceleratie, VitezaMaxima, ConsumUrban, ConsumMixt, TipTransmisie, Tractiune, NumarUsi, PretDDP) values ('" + textBox6.Text + "', '" + textBox7.Text + "','" + textBox8.Text + "', '" + textBox9.Text + "', '" + textBox10.Text + "', '" + textBox11.Text + "','" + textBox12.Text + "', '" + textBox13.Text + "', '" + textBox14.Text + "', '" + textBox15.Text + "', '" + textBox16.Text + "', '" + textBox17.Text + "','" + textBox18.Text + "', '" + textBox19.Text + "')";
            OleDbDataReader reader = command.ExecuteReader();
            reader.Read();
            connection.Close();
        }
    }
}
