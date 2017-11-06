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
using DGVPrinterHelper;
using System.Globalization;


namespace Licenta
{
    public partial class Form1 : Form
    {
        string numeclient;
        string prenumeclient;
        string telefonclient;
        string ID_Client;
        OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Licenta.accdb;Persist Security Info=False;");
        OleDbCommand cmd;
        
        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            ShowTabs(false);

            comboBox1.SelectedItem = comboBox1.Items[1];

            label37.Text = "";
            label38.Text = "";
            label39.Text = "";
            label4.Text = "";


            setMaxDates();

            this.clientiTableAdapter.Fill(this.licentaDataSet5.Clienti);
            // TODO: This line of code loads data into the 'licentaDataSet5.Programari' table. You can move, or remove it, as needed.
            this.programariTableAdapter.Fill(this.licentaDataSet5.Programari);
            // TODO: This line of code loads data into the 'licentaDataSet5.Automobile' table. You can move, or remove it, as needed.
            this.automobileTableAdapter.Fill(this.licentaDataSet5.Automobile);
        }

        void setMaxDates()
        {
            dateTimePicker1.MinDate = DateTime.Now;
            dateTimePicker2.MaxDate = DateTime.Now;
            dateTimePicker3.MaxDate = DateTime.Now;

            dateTimePicker4.Format = DateTimePickerFormat.Time;
            dateTimePicker4.ShowUpDown = true;

            dateTimePicker5.Format = DateTimePickerFormat.Time;
            dateTimePicker5.ShowUpDown = true;

            dateTimePicker6.MinDate = DateTime.Now;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }


        void ShowTabs(bool type)
        {
            if (type == false)
            {
                tabControl1.TabPages.Remove(tabPage2);
                tabControl1.TabPages.Remove(tabPage3);
                tabControl1.TabPages.Remove(tabPage4);
                tabControl1.TabPages.Remove(tabPage5);
                tabControl1.TabPages.Remove(tabPage6);
            }
            else
            {
                tabControl1.TabPages.Add(tabPage2);
                tabControl1.TabPages.Add(tabPage3);
                tabControl1.TabPages.Add(tabPage4);
                tabControl1.TabPages.Add(tabPage5);
                tabControl1.TabPages.Add(tabPage6);
            
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowTabs(false);

            
            textBox4.Text = "";
            textBox5.Text = "";

            if (comboBox1.Text == "")
                MessageBox.Show("Selectati tipul de login Administrator/Client");
            else
                if (textBox1.Text == "" || textBox2.Text == "")
                    MessageBox.Show("Nu au fost completate toate campurile !");
                else
                    if (comboBox1.SelectedItem.Equals("Client"))
                    {
                        {
                            connection.Open();
                            OleDbCommand command = new OleDbCommand();
                            command.Connection = connection;
                            command.CommandText = "select * from Clienti where Username='" + textBox1.Text + "' and Parola='" + textBox2.Text + "'";

                            OleDbDataReader reader = command.ExecuteReader();
                            int count = 0;
                            while (reader.Read())
                            {
                                count = count + 1;
                                numeclient = reader["Nume"].ToString();
                                prenumeclient = reader["Prenume"].ToString();
                                telefonclient = reader["Telefon"].ToString();
                                ID_Client = reader["IDClient"].ToString();

                            }
                            if (count == 1)
                            {
                                MessageBox.Show("User si parola sunt corecte!");
                                ShowTabs(true);

                                groupBox3.Visible = false;
                                groupBox5.Visible = false;
                                groupBox6.Visible = false;
                                groupBox8.Visible = false;

                                textBox5.Enabled = false;
                                textBox8.Enabled = false;
                                textBox21.Enabled = false;

                                button6.Text = "Cauta";
                                button7.Text = "Sterge cautarea";
                                button14.Visible = false;

                                automobileDataGridView.ReadOnly = true;
                                programariDataGridView.ReadOnly = true;
                                tabControl1.TabPages.Remove(tabPage2);
                                tabControl1.TabPages.Remove(tabPage4);
                                tabControl1.TabPages.Remove(tabPage6);

                                //textBox3.Text = numeclient;
                                textBox4.Text = prenumeclient;
                                textBox5.Text = telefonclient;

                                label37.Text = "Nume: " + numeclient;
                                label38.Text = "Prenume: " + prenumeclient;
                                label39.Text = "Telefon: " + telefonclient;
                                label4.Text = "ID Client: " + ID_Client;
                                textBox8.Text = ID_Client;
                                textBox5.Text = telefonclient;

                                tabControl1.SelectedTab = tabControl1.TabPages[2];

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
                                connection.Open();
                                OleDbCommand command = new OleDbCommand();
                                command.Connection = connection;
                                command.CommandText = "select * from Administrator where Username='" + textBox1.Text + "' and password='" + textBox2.Text + "'";

                                OleDbDataReader reader = command.ExecuteReader();
                                int count = 0;
                                while (reader.Read())
                                {
                                    count = count + 1;
                                }
                                if (count == 1)
                                {
                                    MessageBox.Show("User si parola sunt corecte!");
                                    label37.Text = "Conectat ca administrator.";
                                    label38.Text = "";
                                    label39.Text = "";
                                    label4.Text = "";

                                    textBox5.Enabled = true;
                                    textBox8.Enabled = true;
                                    textBox21.Enabled = true;

                                    groupBox3.Visible = true;
                                    //groupBox5.Visible = true;
                                    groupBox6.Visible = true;
                                    groupBox8.Visible = true;

                                    button6.Text = "Genereaza raport";
                                    button7.Text = "Sterge raport";
                                    button14.Visible = true;

                                    ShowTabs(true);
                                    tabControl1.SelectedTab = tabControl1.TabPages[1];
                                }
                                else
                                {
                                    MessageBox.Show("User sau parola introduse gresit!");
                                }
                                connection.Close();
                            }
                        }
            
        }

        int minim(int a, int b)
        {
            if (a < b)
                return a;
            return b;
        }

        bool comp(string a, string b)
        {
           
            for (int i = 0; i < minim(a.Length, b.Length); i++)
                if (a[i] > b[i])
                    return false;
            return true;    
        }

        int abs(int a)
        {
            if (a < 0)
                return -a;
            return a;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*
            string[] data = dateTimePicker4.Text.Split(':');
            string[] per = dateTimePicker4.Text.Split(' ');

            if (per[1] == "AM")
            {

            }
            else
            {

            }
    
            connection.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            //command.CommandText = "select * from Programari where Ora='" + textBox34.Text + "' ";

            OleDbDataReader reader = command.ExecuteReader();
            int count = 0;
            while (reader.Read())
            {
                count = count + 1;
            }
            if (count == 1)
            {
                MessageBox.Show("Acest loc este ocupat ! Va rugam sa selectati alta data/ora");
                reader.Dispose();
                connection.Close();
                return;
            }
            reader.Dispose();
            connection.Close();
            */

            if (textBox5.Text == "" || textBox8.Text == "" || textBox21.Text == "")
            {
                MessageBox.Show("Nu au fost completate toate campurile !");
                return;
            }

            

            string[] tt = dateTimePicker4.Text.Split(' ');
            string[] hh = dateTimePicker4.Text.Split(':');

            int min = Int32.Parse(dateTimePicker4.Value.Hour.ToString()) * 60 + Int32.Parse(dateTimePicker4.Value.Minute.ToString());

            //MessageBox.Show(dateTimePicker4.Value.Hour.ToString() + " " + dateTimePicker4.Value.Minute.ToString());


            string fs = dateTimePicker1.Value.Month + "/" + dateTimePicker1.Value.Day + "/" + dateTimePicker1.Value.Year;

            connection.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = "select * from Programari";

            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                
                string[] dt = reader[1].ToString().Split(' ');
                string[] hr = dt[1].Split(':');

                
                int mn = Int32.Parse(hr[0]) * 60 + Int32.Parse(hr[1]);
                if (dt[2] == "PM")
                    mn += 12 * 60;

                //MessageBox.Show(min.ToString() + " " + mn.ToString());
                //MessageBox.Show(fs + " " + dt[0]);

                if (abs(mn - min) < 30 && dt[0] == fs)
                {
                    MessageBox.Show("Trebuie sa fie cel putin 30 de minute intre programari \nProgramarea : " + reader[1].ToString() + " nu permite aceasta inregistrare");
                    reader.Dispose();
                    connection.Close();
                    return;
                }

            }

            connection.Close();


            if (tt[1] == "AM")
            {
                if (Int32.Parse(hh[0]) < 7)
                {
                    MessageBox.Show("Programarea trebuie sa fie in intervalul 7:00 - 19:00");
                    return;
                }
            }
            else
            {
                if (Int32.Parse(hh[0]) > 6)
                {
                    MessageBox.Show("Programarea trebuie sa fie in intervalul 7:00 - 19:00");
                    return;
                }
            }

            connection.Open();


            //string data = dateTimePicker1.Text + " " + dateTimePicker4.Text;
            //data = data.Replace('-', '/');

            string data = dateTimePicker1.Value.Month.ToString() + "/" + dateTimePicker1.Value.Day.ToString() + "/" + dateTimePicker1.Value.Year.ToString() + " " + dateTimePicker4.Text;
            

            OleDbCommand command3 = new OleDbCommand();
            command3.Connection = connection;

            command3.CommandText = "INSERT into Programari(Data, Ora, Telefon, IDClient, IDA) values ('" + data + "', '" + dateTimePicker4.Text + "', @tele, @idc, @ida)";
            command3.Parameters.AddWithValue("@tele", Int32.Parse(textBox5.Text));
            command3.Parameters.AddWithValue("@idc", Int32.Parse(textBox8.Text));
            command3.Parameters.AddWithValue("@ida", Int32.Parse(textBox21.Text));
    
            command3.ExecuteNonQuery();
            connection.Close();

            MessageBox.Show("Programarea este in curs de procesare, va rugam sa asteptati.. ");

            this.Validate();
            this.programariBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.licentaDataSet5);

            this.programariTableAdapter.Fill(this.licentaDataSet5.Programari);  
           
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (textBox6.Text == "" || textBox7.Text == "" ||  textBox9.Text == "" || textBox10.Text == "" ||
                textBox11.Text == "" ||  textBox12.Text == "" ||  textBox13.Text == "" || textBox14.Text == "" ||
                textBox15.Text == ""  || textBox16.Text == "" ||  textBox17.Text == "" ||  textBox18.Text == "" || textBox19.Text == "")
            {
                MessageBox.Show("Nu au fost completate toate campurile !");
                return;
            }
            

            connection.Open();
            OleDbCommand command3 = new OleDbCommand();
            command3.Connection = connection;

            string q;
            if (checkBox1.Checked == true)
                q = "1";
            else
                q = "0";
            string data = getDate(dateTimePicker2.Text);
            command3.CommandText = "INSERT into Automobile(Marca, Model, DataFabricatie, Combustibil, PutereMotor, CapCilindrica, Acceleratie, VitezaMaxima, ConsumUrban, ConsumMixt, TipTransmisie, Tractiune, NumarUsi, PretEuro, Valabilitate) values ('" + textBox6.Text + "', '" + textBox7.Text + "','" + data + "', '" + textBox9.Text + "', '" + textBox10.Text + "', '" + textBox11.Text + "','" + textBox12.Text + "', '" + textBox13.Text + "', '" + textBox14.Text + "', '" + textBox15.Text + "', '" + textBox16.Text + "', '" + textBox17.Text + "','" + textBox18.Text + "', '" + textBox19.Text + "', '" + q + "')";
            command3.ExecuteNonQuery();

            connection.Close();

            this.Validate();
            this.automobileBindingSource1.EndEdit();
            this.tableAdapterManager.UpdateAll(this.licentaDataSet5);

            this.automobileTableAdapter.Fill(this.licentaDataSet5.Automobile);  
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox20.Text == "")
                MessageBox.Show("Campul este gol");
            else
            {
                string t = textBox20.Text;
                dataGridView2.Rows.Clear();

                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "select * from Programari";

                OleDbDataReader reader = command.ExecuteReader();
               

                while (reader.Read())
                {
     
                    bool ok = false;
                    for (int i = 0; i < reader.FieldCount; i++)
                    {

                        string g = reader[i].ToString();
                        if (g == t)
                            ok = true;
                    }
                    if (ok == true)
                    {
                        dataGridView2.Rows.Add(reader[0], reader[1], reader[3], reader[4], reader[5]);
                    }
                }

                connection.Close();

            }
        }


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
                    mn = i+1;

            string year = "";
            for (int i = 1; i < data[2].Length; i++)
                year += data[2][i];

            result = mn.ToString() + "/" + mnth[2] + "/" + year;

            return result;
        }

        

        private void automobileBindingSource1BindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.automobileBindingSource1.EndEdit();
            this.tableAdapterManager.UpdateAll(this.licentaDataSet5);

        }

        private void automobileBindingSource1BindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.automobileBindingSource1.EndEdit();
            this.tableAdapterManager.UpdateAll(this.licentaDataSet5);

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'licentaDataSet5.Clienti' table. You can move, or remove it, as needed.

            
            // TODO: This line of code loads data into the 'licentaDataSet3.Clienti' table. You can move, or remove it, as needed.


        }


        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox32.Text == "")
                MessageBox.Show("Campul este gol");
            else
            {
                string t = textBox32.Text;
                dataGridView1.Rows.Clear();

                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "select * from Automobile";

                OleDbDataReader reader = command.ExecuteReader();


                bool found = false;
                while (reader.Read())
                {
                 
                    bool ok = false;
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                       
                        string g = reader[i].ToString();
                        if (g == t)
                            ok = true;
                    }
                    if (ok == true && reader[15].ToString() == "True")
                    {
                        found = true;
                        string[] data = reader[3].ToString().Split(' ');
                        dataGridView1.Rows.Add(reader[0], reader[1], reader[2], data[0], reader[4], reader[5], reader[6],
                            reader[7], reader[8], reader[9], reader[10], reader[11], reader[12], reader[13], reader[14], reader[15]);
                    }
                    
                        
                }

                if (found == false)
                {
                    MessageBox.Show("(" + t + ") nu a fost gasit sau nu este disponibil momentan!");
                }
                connection.Close();

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            dataGridView3.Rows.Clear();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox33.Text == "")
                MessageBox.Show("Campul este gol");
            else
            {
                string t = textBox33.Text;
                dataGridView3.Rows.Clear();

                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "select * from Clienti";

                OleDbDataReader reader = command.ExecuteReader();

                int l = -1;
                while (reader.Read())
                {
                    l++;
                    bool ok = false;
                    for (int i = 0; i < reader.FieldCount; i++)
                    {

                        string g = reader[i].ToString();
                        if (g == t)
                            ok = true;
                    }
                    if (ok == true)
                    {
                        string[] data = reader[3].ToString().Split(' ');
                        dataGridView3.Rows.Add(reader[0], reader[1], reader[2], data[0], reader[4], reader[5], reader[6],
                            reader[7], reader[8], reader[9], reader[10], reader[11], reader[12], reader[13]);
                    }
                }

                connection.Close();

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

        private void button11_Click(object sender, EventArgs e)
        {


            string year = getYear(dataNasteriiDateTimePicker.Text);
            int selected = Convert.ToInt32(year);
            if (2017 - selected < 18)
            {
                MessageBox.Show("Trebuie sa aveti minim 18 ani !");
                return;
            }

            connection.Open();
            OleDbCommand command = new OleDbCommand();

            command.Connection = connection;

            command.CommandText = "UPDATE Clienti SET Nume = '" + numeTextBox.Text + "', Prenume = '" + prenumeTextBox.Text + "', DataNasterii = '" + getDate(dataNasteriiDateTimePicker.Text) + "', Tara = '" + taraTextBox.Text + "', Judet = '" + judetTextBox.Text + "', Localitate = '" + localitateTextBox.Text + "', Adresa ='" + adresaTextBox.Text + "' , Sex = '" + sexTextBox.Text + "', SerieBuletin = '" + serieBuletinTextBox.Text + "', CNP = '" + cNPTextBox.Text + "', Username = '" + usernameTextBox.Text + "', Parola ='" + parolaTextBox.Text + "' , Telefon = '" + telefonTextBox.Text + "' where IDClient = @id";
            command.Parameters.AddWithValue("@id", int.Parse(iDClientTextBox.Text));

            command.ExecuteNonQuery();
            
            connection.Close();
          
            this.Validate();
            this.clientiBindingSource.EndEdit();
            this.clientiTableAdapter.Fill(this.licentaDataSet5.Clienti);  

        }

        private void button12_Click(object sender, EventArgs e)
        {

            string[] tt = dateTimePicker5.Text.Split(' ');
            string[] hh = dateTimePicker5.Text.Split(':');


            if (tt[1] == "AM")
            {
                if (Int32.Parse(hh[0]) < 7)
                {
                    MessageBox.Show("Programarea trebuie sa fie in intervalul 7:00 - 19:00");
                    return;
                }
            }
            else
            {
                if (Int32.Parse(hh[0]) > 6)
                {
                    MessageBox.Show("Programarea trebuie sa fie in intervalul 7:00 - 19:00");
                    return;
                }
            }

            connection.Open();
            OleDbCommand command = new OleDbCommand();

            command.Connection = connection;


            string data = dateTimePicker6.Text + " " + dateTimePicker5.Text;
            data = "11/11/2018 5:25:00 PM";


            command.CommandText = "UPDATE Programari SET Data = '" + data + "', Ora = '" + data + "', Telefon = @tele, IDClient = @idc, IDA = @ida where IDP = @id";
            command.Parameters.AddWithValue("@id", int.Parse(iDPTextBox.Text));
            command.Parameters.AddWithValue("@tele", Int32.Parse(textBox5.Text));
            command.Parameters.AddWithValue("@idc", Int32.Parse(textBox8.Text));
            command.Parameters.AddWithValue("@ida", Int32.Parse(textBox21.Text));
 

            command.ExecuteNonQuery();

            connection.Close();

            this.Validate();
            this.programariBindingSource.EndEdit();   
            this.programariTableAdapter.Fill(this.licentaDataSet5.Programari);  
        }

        private void button13_Click(object sender, EventArgs e)
        {
            connection.Open();
            OleDbCommand command = new OleDbCommand();
            string q;
            if (valabilitateCheckBox.Checked == true)
                q = "1";
            else
                q = "0";
            command.Connection = connection;
            command.CommandText = "UPDATE Automobile SET Marca = '" + marcaTextBox.Text + "', Model = '" + modelTextBox.Text + "', DataFabricatie = '" + getDate(dateTimePicker3.Text) + "', Combustibil = '" + combustibilTextBox.Text + "', PutereMotor = '" + putereMotorTextBox.Text + "', CapCilindrica = '" + capCilindricaTextBox.Text + "', Acceleratie = '" + acceleratieTextBox.Text + "', VitezaMaxima = '" + vitezaMaximaTextBox.Text + "', ConsumUrban = '" + consumUrbanTextBox.Text + "', ConsumMixt = '" + consumMixtTextBox.Text + "', TipTransmisie = '" + tipTransmisieTextBox.Text + "', Tractiune = '" + tractiuneTextBox.Text + "', NumarUsi = '" + numarUsiTextBox.Text + "', PretEuro = '" + pretDDPTextBox.Text + "', Valabilitate = '" + q + "' where IDA = @id";
            command.Parameters.AddWithValue("@id", int.Parse(iDATextBox.Text));

            command.ExecuteNonQuery();

            connection.Close();

            this.Validate();
            this.automobileBindingSource1.EndEdit();
            //this.tableAdapterManager.UpdateAll(this.licentaDataSet5);

            this.automobileTableAdapter.Fill(this.licentaDataSet5.Automobile);  
        }

        private void button14_Click(object sender, EventArgs e)
        {

            DGVPrinter printer = new DGVPrinter();

            printer.Title = textBox32.Text + " Report";

            printer.SubTitle = "RemiAutoHelp Report";

            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit |

                                          StringFormatFlags.NoClip;

            printer.PageNumbers = true;

            printer.PageNumberInHeader = false;

            printer.PorportionalColumns = true;

            printer.HeaderCellAlignment = StringAlignment.Near;

            printer.Footer = "RemiAutoHelp";

            printer.FooterSpacing = 15;



            printer.PrintDataGridView(dataGridView1);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();

            printer.Title = textBox33.Text + " Report";

            printer.SubTitle = "RemiAutoHelp Report";

            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit |

                                          StringFormatFlags.NoClip;

            printer.PageNumbers = true;

            printer.PageNumberInHeader = false;

            printer.PorportionalColumns = true;

            printer.HeaderCellAlignment = StringAlignment.Near;

            printer.Footer = "RemiAutoHelp";

            printer.FooterSpacing = 15;



            printer.PrintDataGridView(dataGridView3);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();

            printer.Title = textBox20.Text + " Report";

            printer.SubTitle = "RemiAutoHelp Report";

            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit |

                                          StringFormatFlags.NoClip;

            printer.PageNumbers = true;

            printer.PageNumberInHeader = false;

            printer.PorportionalColumns = true;

            printer.HeaderCellAlignment = StringAlignment.Near;

            printer.Footer = "RemiAutoHelp";

            printer.FooterSpacing = 15;



            printer.PrintDataGridView(dataGridView2);
        }

        private void automobileBindingSource1BindingNavigatorSaveItem_Click_2(object sender, EventArgs e)
        {
            this.Validate();
            this.automobileBindingSource1.EndEdit();
            this.tableAdapterManager.UpdateAll(this.licentaDataSet5);

        }

        private void button17_Click(object sender, EventArgs e)
        {
            Inregistrare inreg = new Inregistrare();
            inreg.StartPosition = FormStartPosition.CenterScreen;
            inreg.Show();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Recupereaza recup = new Recupereaza();
            recup.StartPosition = FormStartPosition.CenterScreen;
            recup.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Contact con = new Contact();
            con.StartPosition = FormStartPosition.CenterScreen;
            con.Show();
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void textBox13_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void textBox14_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void textBox15_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        private void textBox18_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        private void textBox19_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
  
        }

        private void dataNasteriiDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            string year = getYear(dataNasteriiDateTimePicker.Text);
            int selected = Convert.ToInt32(year);
            if (2017 - selected < 18)
            {
                MessageBox.Show("Trebuie sa aveti minim 18 ani !");
             
            }
        }

        private void dateTimePicker4_ValueChanged(object sender, EventArgs e)
        {
            string[] tt = dateTimePicker4.Text.Split(' ');
            string[] hh = dateTimePicker4.Text.Split(':');


            if (tt[1] == "AM")
            {
                if (Int32.Parse(hh[0]) < 7)
                {
                    MessageBox.Show("Programarea trebuie sa fie in intervalul 7:00 - 19:00");
                    return;
                }
            }
            else
            {
                if (Int32.Parse(hh[0]) > 6)
                {
                    MessageBox.Show("Programarea trebuie sa fie in intervalul 7:00 - 19:00");
                    return;
                }
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            var accounts = new Dictionary<string, int>();

            dataGridView4.Rows.Clear();

            connection.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = "select * from Automobile where Valabilitate = False";

            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                accounts[reader[1].ToString()] = 0;
            }

            reader.Dispose();
            connection.Close();



            connection.Open();
            command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = "select * from Automobile where Valabilitate = False";
            reader = command.ExecuteReader();
            int best = 0;
            string marca = "";
  
            while (reader.Read())
            {
                accounts[reader[1].ToString()]++;
                
                if (accounts[reader[1].ToString()] > best)
                {
                    best = accounts[reader[1].ToString()];
                    marca = reader[1].ToString();
                }
                
            }
            connection.Close();

            connection.Open();
            command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = "select * from Automobile where Marca = '" + marca + "' ";

            reader = command.ExecuteReader();

            while (reader.Read())
            {
                string[] data = reader[3].ToString().Split(' ');
                    dataGridView4.Rows.Add(reader[0], reader[1], reader[2], data[0], reader[4], reader[5], reader[14]);
        
            }
            connection.Close();

            MessageBox.Show(marca + " vanduta de -> " + best.ToString() + " ori");
        }

        private void button20_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();

            printer.Title = "Cea mai vanduta marca de autoturism";

            printer.SubTitle = "RemiAutoHelp Report";

            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit |

                                          StringFormatFlags.NoClip;

            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "RemiAutoHelp";
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(dataGridView4);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text == "")
            {
                MessageBox.Show("Nu ati selectat tipul de combustibil");
                return;
            }

            dataGridView5.Rows.Clear();

            connection.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = "select * from Automobile where Combustibil = '" +comboBox2.Text + "'";
            OleDbDataReader reader = command.ExecuteReader();
            int best = 0;
            

            while (reader.Read())
            {
                best++;
                string[] data = reader[3].ToString().Split(' ');
                dataGridView5.Rows.Add(reader[0], reader[1], reader[2], data[0], reader[4], reader[5], reader[14]);
            }
            connection.Close();
            MessageBox.Show("Masini pe " + comboBox2.Text + " -> " + best.ToString());
        }

        private void button22_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();

            printer.Title = "Evidenta automobile in functie de combustibil";

            printer.SubTitle = "RemiAutoHelp Report";

            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit |

                                          StringFormatFlags.NoClip;

            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "RemiAutoHelp";
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(dataGridView5);
        }

        private void button23_Click(object sender, EventArgs e)
        {

            dataGridView6.Rows.Clear();
            connection.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = "select * from Programari";
            OleDbDataReader reader = command.ExecuteReader();

            int[] programari = new int[1000];

            for (int i = 0; i < 1000; i++)
                programari[i] = 0;

            while (reader.Read())
            {
                programari[Int32.Parse(reader[4].ToString())]++;
            }
            connection.Close();



            connection.Open();
            command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = "select * from Clienti";
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                string prog = programari[Int32.Parse(reader[0].ToString())].ToString();

                dataGridView6.Rows.Add(reader[0], reader[1], reader[2], reader[5], reader[6], reader[13], prog);
            }
            connection.Close();

            this.dataGridView6.Sort(this.dataGridView6.Columns["Column47"], ListSortDirection.Descending);
        }

        private void button24_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();

            printer.Title = "Evidenta pentru clientii cu cele mai multe programari";

            printer.SubTitle = "RemiAutoHelp Report";

            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit |

                                          StringFormatFlags.NoClip;

            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "RemiAutoHelp";
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(dataGridView6);
        }

        private void dateTimePicker5_ValueChanged(object sender, EventArgs e)
        {
            string[] tt = dateTimePicker5.Text.Split(' ');
            string[] hh = dateTimePicker5.Text.Split(':');

           
            if (tt[1] == "AM")
            {
                if (Int32.Parse(hh[0]) < 7)
                {
                    MessageBox.Show("Programarea trebuie sa fie in intervalul 7:00 - 19:00");
                    return;
                }
            }
            else
            {
                if (Int32.Parse(hh[0]) > 6)
                {
                    MessageBox.Show("Programarea trebuie sa fie in intervalul 7:00 - 19:00");
                    return;
                }
            }
        }

        private void dateTimePicker6_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void automobileDataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                //MessageBox.Show(senderGrid.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString());

                if (senderGrid.Rows[e.RowIndex].Cells[e.ColumnIndex-1].Value.ToString() == "True")
                {
                    MessageBox.Show("Masina este disponibila! \nVeti fi redirectionat catre pagina de programari");
                    textBox21.Text = senderGrid.Rows[e.RowIndex].Cells[0].Value.ToString();
                    tabControl1.SelectedTab = tabControl1.TabPages["tabPage3"];
                }
                else
                {
                    MessageBox.Show("Masina nu este disponibila momentan! \nVa rugam sa incercati mai tarziu");
                }
            }
        }

        int getMonth(string cuv)
        {
            string[] months = new string[] { "Ianuarie", "Februarie", "Martie", "Aprilie", "Mai", "Iunie", "Iulie", "August", "Septembrie", "Octombrie", "Noiembrie", "Decembrie" };
            for (int i = 0; i < months.Length; i++)
                if (cuv == months[i])
                    return i + 1;

            return 0;
        }

        private void button25_Click(object sender, EventArgs e)
        {
            int f = getMonth(comboBox3.Text);
            int s = getMonth(comboBox4.Text);

            if (comboBox3.Text == "" || comboBox4.Text == "")
            {
                MessageBox.Show("Va rugam sa selectati o perioada");
                return;
            }

            if (f > s)
            {
                MessageBox.Show("Va rugam sa selectati un interval valid");
                return;
            }

            dataGridView7.Rows.Clear();
            connection.Open();
            OleDbCommand command = new OleDbCommand();
            OleDbCommand command2 = new OleDbCommand();
            command.Connection = connection;
            command2.Connection = connection;
            command.CommandText = "select * from Programari";
            
            OleDbDataReader reader = command.ExecuteReader();

            int nr = 0;
            while (reader.Read())
            {
                
                string[] data = reader[1].ToString().Split('/');
                int fs = Int32.Parse(data[0]);

                if (f <= fs && fs <= s)
                {
                    nr ++;
                    dataGridView7.Rows.Add(reader[0], reader[1], reader[3], reader[4], reader[5]);
                }
            }

            MessageBox.Show("Din luna [" + comboBox3.Text + "] pana in [" + comboBox4.Text + "] s-au inregistrat " + nr.ToString() + " programari");
            connection.Close();

        }

        private void button26_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();

            printer.Title = "Programari in perioada " + comboBox3.Text + " - " + comboBox4.Text + "";

            printer.SubTitle = "RemiAutoHelp Report";

            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit |

                                          StringFormatFlags.NoClip;

            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "RemiAutoHelp";
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(dataGridView7);
        }
    }
}
