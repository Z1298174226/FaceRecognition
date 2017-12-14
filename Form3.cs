using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using Emgu.CV.GPU;


namespace FacesDetect
{
    public partial class FaceDetect : Form
    {
        public FaceDetect()
        {
            InitializeComponent();
        }
        private Image<Bgr, byte> currentImage;
        private void button1_Click(object sender, EventArgs e)
        {
            if (openPic.ShowDialog() == DialogResult.OK)
            {
                currentImage = new Image<Bgr, byte>(openPic.FileName);
                /*******************************
                Bitmap box1 = new Bitmap(pictureBox1.Image);
                Bitmap box2 = new Bitmap(pictureBox2.Image);
                int r, g, b, i, j, size, k1, k2, xres, yres;
                xres = pictureBox1.Image.Width;
                yres = pictureBox1.Image.Height;
                 * *****************************/
                pictureBox1.Image = new System.Drawing.Bitmap(currentImage.ToBitmap(),350,300);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (currentImage != null)
            {
                List<Rectangle> faces = new List<Rectangle>();
                List<Rectangle> eyes = new List<Rectangle>();
                long detectionTime;
                string facepath = Application.StartupPath + "\\Cascades\\haarcascade_frontalface_default.xml";
                string eyepath = Application.StartupPath + "\\Cascades\\haarcascade_eye.xml";
                //MessageBox.Show(facepath + "\r\n" + eyepath);
                DetectFace.Detect(currentImage, facepath, eyepath, faces, eyes, out detectionTime);
                foreach (Rectangle face in faces)
                    currentImage.Draw(face, new Bgr(Color.Red), 2);
                foreach (Rectangle eye in eyes)
                    currentImage.Draw(eye, new Bgr(Color.Blue), 2);
                pictureBox1.Image = new System.Drawing.Bitmap(currentImage.ToBitmap(), 350, 300);
                  //pictureBox1.Image = currentImage;
                this.Text = detectionTime.ToString();
            }
            else
            {
                MessageBox.Show("请先打开一张图片！");
            }
        }

        private void FaceDetect_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
