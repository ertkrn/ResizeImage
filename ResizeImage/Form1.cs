using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ResizeImage;
namespace ResizeImage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (DialogResult.OK == dialog.ShowDialog())
            {
                pictureBox1.ImageLocation = dialog.FileName;
                string path = pictureBox1.ImageLocation;
                pictureBox1.Image = Image.FromFile(path);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown1.Enabled = true;
            numericUpDown2.Enabled = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown2.Enabled = true;
            numericUpDown1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                int width = (int)(numericUpDown1.Value);
                pictureBox2.Image = ResizeImg.Resize(pictureBox1.Image, 0, width);
                pictureBox2.Image.Save(@"C:\Users\ERTUGRUL\Desktop\newImg.jpg");
            }
            else if (radioButton2.Checked)
            {
                int height = (int)(numericUpDown2.Value);
                pictureBox2.Image = ResizeImg.Resize(pictureBox1.Image, height, 0);
            }
            else
            {
                MessageBox.Show("Make a Choice!");
            }
        }
    }
}
