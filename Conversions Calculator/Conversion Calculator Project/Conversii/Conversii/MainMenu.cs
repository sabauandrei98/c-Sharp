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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void arithmetic_Click(object sender, EventArgs e)
        {
            Form arithmetic = new Arithmetic();
            arithmetic.Show();
            
        }

        private void conversions_Click(object sender, EventArgs e)
        {
            Form conversions = new Conversions();
            conversions.Show();
        }


    }
}
