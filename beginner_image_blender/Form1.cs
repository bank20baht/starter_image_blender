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
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace beginner_image_blender
{
    public partial class Form1 : Form
    {
        private Stopwatch stopWatch1 = new Stopwatch();
        private Bitmap image1;
        private Bitmap image2;
        private Bitmap result_Image;
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.image_loaded)
            {
                this.stopWatch1.Reset();
                this.stopWatch1.Start();
                this.result_Image = new Bitmap(this.image1.Width, this.image1.Height);
                BitmapData bitmapdata1 = this.image1.LockBits(new Rectangle(0, 0, this.image1.Width, this.image1.Height), ImageLockMode.ReadWrite, this.image1.PixelFormat);
                BitmapData bitmapdata2 = this.image2.LockBits(new Rectangle(0, 0, this.image1.Width, this.image1.Height), ImageLockMode.ReadWrite, this.image1.PixelFormat);
                BitmapData bitmapdata3 = this.result_Image.LockBits(new Rectangle(0, 0, this.image1.Width, this.image1.Height), ImageLockMode.ReadWrite, this.image1.PixelFormat);
                IntPtr scan0_1 = bitmapdata1.Scan0;
                IntPtr scan0_2 = bitmapdata2.Scan0;
                IntPtr scan0_3 = bitmapdata3.Scan0;
                int length = Math.Abs(bitmapdata1.Stride) * this.image1.Height;
                byte[] numArray1 = new byte[length];
                byte[] numArray2 = new byte[length];
                byte[] numArray3 = new byte[length];
                Marshal.Copy(scan0_1, numArray1, 0, length);
                Marshal.Copy(scan0_2, numArray2, 0, length);
                Marshal.Copy(scan0_3, numArray3, 0, length);
                for (int index1 = 0; index1 < this.image1.Height; ++index1)
                {
                    int num1 = index1 * bitmapdata1.Stride;
                    for (int index2 = 0; index2 < this.image1.Width * 3; index2 += 3)
                    {
                        float num2 = (float)numArray1[index2 + num1];
                        float num3 = (float)numArray1[index2 + 1 + num1];
                        float num4 = (float)numArray1[index2 + 2 + num1];
                        float num5 = (float)numArray2[index2 + num1];
                        float num6 = (float)numArray2[index2 + 1 + num1];
                        float num7 = (float)numArray2[index2 + 2 + num1];
                        float num8 = (float)(((double)this.trackBar1.Value * (double)num5 + (100.0 - (double)this.trackBar1.Value) * (double)num2) / 100.0);
                        float num9 = (float)(((double)this.trackBar1.Value * (double)num6 + (100.0 - (double)this.trackBar1.Value) * (double)num3) / 100.0);
                        float num10 = (float)(((double)this.trackBar1.Value * (double)num7 + (100.0 - (double)this.trackBar1.Value) * (double)num4) / 100.0);
                        numArray3[index2 + num1] = (byte)num8;
                        numArray3[index2 + 1 + num1] = (byte)num9;
                        numArray3[index2 + 2 + num1] = (byte)num10;
                    }
                }
                Marshal.Copy(numArray1, 0, scan0_1, length);
                Marshal.Copy(numArray2, 0, scan0_2, length);
                Marshal.Copy(numArray3, 0, scan0_3, length);
                this.image1.UnlockBits(bitmapdata1);
                this.image2.UnlockBits(bitmapdata2);
                this.result_Image.UnlockBits(bitmapdata3);
                this.stopWatch1.Stop();
                this.pictureBox3.Image = (Image)this.result_Image;
                pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                this.textBox1.AppendText("Time for Blending these two images  = " + this.stopWatch1.ElapsedMilliseconds.ToString() + " mS\r\n");
            }
            else
                this.textBox1.AppendText("Please load the image before clicking this button\r\n");
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            this.textBox1.Text = string.Concat((object)this.trackBar1.Value);
            if (this.image_loaded)
                this.button3_Click(sender, e);
            else
                this.textBox1.Text += "\r\nPlease load the images";
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
