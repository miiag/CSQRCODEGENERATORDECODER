using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSQRCODEGENERATORDECODER
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            if (!String.IsNullOrEmpty(Properties.Settings.Default.Lan1))
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(Properties.Settings.Default.Lan1);
                System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo(Properties.Settings.Default.Lan1);
            }
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = new System.Globalization.CultureInfo[]
            {
                System.Globalization.CultureInfo.GetCultureInfo("ru"),
                System.Globalization.CultureInfo.GetCultureInfo("en"),
            };
            comboBox1.DisplayMember = "Native name";
            comboBox1.ValueMember = "Name";
            if(!String.IsNullOrEmpty(Properties.Settings.Default.Lan1))
            {
                comboBox1.SelectedValue = Properties.Settings.Default.Lan1;
            }
            this.ControlBox = false;
        }
        main_menu Mainmenu;
        private void button1_Click(object sender, EventArgs e)
        {
            Mainmenu = new main_menu();
            Mainmenu.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Lan1 = comboBox1.SelectedValue.ToString();
            Properties.Settings.Default.Save();
        }
    }
}
