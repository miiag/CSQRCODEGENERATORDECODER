using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;

namespace CSQRCODEGENERATORDECODER
{
    public partial class main_menu : Form
    {
        public QrCodeEncodingOptions options4QR;
        public main_menu()
        {
            if (!String.IsNullOrEmpty(Properties.Settings.Default.Lan1))
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(Properties.Settings.Default.Lan1);
                System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo(Properties.Settings.Default.Lan1);
            }
            InitializeComponent();
            options4QR = new QrCodeEncodingOptions()//параметры кодировки (coding parameters)
            {
                DisableECI = true, //usefil
                CharacterSet = "UTF-8",//type of coding
                Width = l,//user input
                Height = f,//user input
            };
            var cscodewriter = new BarcodeWriter();
            cscodewriter.Format = BarcodeFormat.QR_CODE;
            cscodewriter.Options = options4QR;
        }
        public int l = Convert.ToInt32(Class1.name);
        public int f = Convert.ToInt32(Class1.address);
        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBox1.Text) || String.IsNullOrEmpty(textBox1.Text))
            {
                pictureBox1.Image = null;
                MessageBox.Show("Image not found/ Изображение не найдено", "Sorry, user/ Извините, пользователь", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var QRCODE = new ZXing.BarcodeWriter();//coding picture in picturebox
                QRCODE.Options = options4QR;
                QRCODE.Format = ZXing.BarcodeFormat.QR_CODE;
                var resultofwork = new Bitmap(QRCODE.Write(textBox1.Text.Trim()));
                pictureBox1.Image = resultofwork;
                textBox1.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap QRMAP = new Bitmap(pictureBox1.Image);
                BarcodeReader reader = new BarcodeReader { AutoRotate = true, TryInverted = true };
                Result result = reader.Decode(QRMAP);
                string decodedQR = result.ToString().Trim();
                textBox1.Text = decodedQR;
            }
            catch (Exception)
            {
                MessageBox.Show("I cant find your image!/ Я не могу найти вашу картинку", "Sorry, user/ Извините, пользователь", MessageBoxButtons.OK, MessageBoxIcon.Error);//no pic in picturebox
            }
        }
        Settings set;
        private void resolutionOfQRCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            set = new Settings();
            set.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Image not found/ Картинка не найдена", "Извините, пользователь", MessageBoxButtons.OK, MessageBoxIcon.Error);// no pic in picturebox
            }
            else//saving bitmap (QR code)
            {
                SaveFileDialog SAVEIT = new SaveFileDialog();
                SAVEIT.CreatePrompt = true;
                SAVEIT.OverwritePrompt = true;
                SAVEIT.FileName = "Yourownnewqr";
                SAVEIT.Filter = "All files (*.*)|*.*|Images(*.jpg)|*.jpg|BMP(*.bmp)|*.bmp|PNG(*.png)|.png";
                if (SAVEIT.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    pictureBox1.Image.Save(SAVEIT.FileName);
                    SAVEIT.InitialDirectory = Environment.GetFolderPath
                                (Environment.SpecialFolder.Desktop);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openQR = new OpenFileDialog();
            if (openQR.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var QRCODE = new ZXing.BarcodeWriter();
                QRCODE.Options = options4QR;
                QRCODE.Format = ZXing.BarcodeFormat.QR_CODE;
                pictureBox1.ImageLocation = openQR.FileName;
            }
        }

        private void main_menu_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        About_author ab;
        private void aboutAuthorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ab = new About_author();
            ab.Show();
        }
        Git git;
        private void githubLinkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            git = new Git();
            git.Show();
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (l == 0 && f == 0)
                {
                    pictureBox1.Image = null;
                    MessageBox.Show("Please, input numbers in settings window/ Пожалуйста, введите числа в окне настроек", "Error/ Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
