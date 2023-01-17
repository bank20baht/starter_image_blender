using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace beginner_image_blender
{
    public partial class Form1 : Form
    {
        private Stopwatch stopWatch1 = new Stopwatch();
        private Bitmap image1;
        private Bitmap image2;
        private Bitmap dstImage;
        public bool image_loaded;

        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.stopWatch1.Reset();
                this.stopWatch1.Start();
                this.image1 = new Bitmap("lotus.jpg", true);
                this.stopWatch1.Stop();
                this.textBox1.AppendText("Time for reading the image from file = " + this.stopWatch1.ElapsedMilliseconds.ToString() + " mS\r\n");
                this.textBox1.AppendText("Successfully load the lotus image\r\n");
                this.pictureBox1.Image = (Image)this.image1;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                this.image_loaded = true;
            }
            catch (ArgumentException ex)
            {
                int num = (int)MessageBox.Show("There was an error. No lotus imageCheck the path to the image file.");
                this.image_loaded = false;
            }
            try
            {
                this.stopWatch1.Reset();
                this.stopWatch1.Start();
                this.image2 = new Bitmap("steve-jobs.jpg", true);
                this.stopWatch1.Stop();
                this.textBox1.AppendText("Time for reading the image from file = " + this.stopWatch1.ElapsedMilliseconds.ToString() + " mS\r\n");
                this.textBox1.AppendText("Successfully load the Steve-Job image\r\n");
                this.pictureBox2.Image = (Image)this.image2;
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch (ArgumentException ex)
            {
                int num = (int)MessageBox.Show("There was an error. No Steve-Jobs imageCheck the path to the image file.");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
