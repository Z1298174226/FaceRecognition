using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using Emgu.CV;
using Emgu.CV.UI;
using Emgu.Util;
using Emgu.CV.Structure;
using Emgu.CV.GPU;
using System.Threading;

namespace FacesDetect
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //private string haarXmlPath = @"haarcascade_frontalface_alt_tree.xml";
        private string haarXmlPath=Application.StartupPath + "\\Cascades\\haarcascade_frontalface_alt_tree.xml";
        private Image<Bgr, byte> currentImage;
        private Capture webcam;
        private bool webcamInUse = false;
        private HaarCascade haar;
        private Rectangle point;
        PictureBox pic = new PictureBox();
       // private CascadeClassifier haar;
        // list of faces history
        List<PictureBox> faceHistory = new List<PictureBox>();
        private void initWebCam(int index)
        {
            if (webcam != null)
                return;
            try
            {
                showMessage("初始化摄像头WebCam #" + index + "...");
                webcam = new Capture(index);
                showMessage("WebCam #" + index + " 摄像头初始化完成。");
                start.Enabled = true;
            }
            catch (Exception ex)
            {
                showMessage("摄像头启动失败！"+ex.Message);
                start.Enabled = false;
            }
        }
        private void progessCamera(object sender, EventArgs e)
        {
            currentImage = webcam.QueryFrame();
            currentImage = currentImage.Flip(Emgu.CV.CvEnum.FLIP.HORIZONTAL);
            processFaces(null, null);
            imageBox.Image = currentImage;
        }

        private void start_Click(object sender, EventArgs e)
        {
            if (webcam == null)
                return;
            if (webcamInUse)
            {
                Application.Idle -= new EventHandler(progessCamera);
                start.Text = "启动摄像";
               // getHeadImg.Enabled=false;
            }
            else
            {
                Application.Idle += new EventHandler(progessCamera);   
                start.Text = "停止摄像";
              //  getHeadImg.Enabled = true;
            }
            webcamInUse =!webcamInUse;
        }
        private void Form1_Activated(object sender, EventArgs e)
        {
            initiateHaar(haarXmlPath);
            initWebCam(0);
        }
        private void showMessage(string msg)
        {
            resultText.Text = msg;
            resultText.Update();
        }
        //采集图片上面的头像
        private void openImage_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                currentImage = new Image<Bgr, byte>(openFileDialog1.FileName);
               // imageBox.Image = currentImage;
                processFaces(null, null);
            }
        }
        // 初始化 HaarCascade obj.
        private void initiateHaar(string fileName)
        {
            if (haar != null)
                return;

            showMessage("正在载入哈尔级联数据...");
            haar = new HaarCascade(haarXmlPath);
            showMessage(haarXmlPath);
            showMessage("数据加载完毕！");
        }
        // faces进程
        private void processFaces(object sender, EventArgs arg)
        {
            markFaces(getFaces(currentImage, haar));
        }

        // 分析采集的头像数据
        private MCvAvgComp[] getFaces(Image<Bgr, byte> img, HaarCascade haar)
        {
            if (haar == null || img == null)
                return null;

            MCvAvgComp[] faces = haar.Detect(img.Convert<Gray, byte>());
            if (faces != null)
            {
                FaceNumTxt.Text = string.Format("本次识别 {0} 个人脸.", faces.Length);
            }
            return faces;
        }

        // 标记人脸
        private void markFaces(MCvAvgComp[] faces)
        {
            foreach (MCvAvgComp face in faces)//循环标记识别的人脸
            {
                currentImage.Draw(face.rect, new Bgr(Color.Lime), 2);//采用系统自定义颜色进行标记人脸
                point = new Rectangle(face.rect.X + face.rect.Width / 2, face.rect.Y + face.rect.Height / 2, 1, 1);//获取人脸识别图片的中心点
                currentImage.Draw(point, new Bgr(Color.Red), 3);//用红色画出中心点
                showPoint(point.X ,point.Y);//监控中点坐标 （用无线送到单片机）
                pic.Image = currentImage.Copy(face.rect).ToBitmap();
                pic.Image = new System.Drawing.Bitmap(pic.Image, 240, 270);
                pic.Width = pic.Image.Width;
                pic.Height = pic.Image.Height;
                faceHistory.Add(pic);
                showMessage(faceHistory.Count.ToString());
            }
            imageBox.Image = currentImage;//显示图像
        }

        private void showPoint(int X,int Y)
    {
        point_X.Text = "横坐标X：" + X.ToString(); //显示头像中点横坐标
        point_Y.Text = "纵坐标Y：" + Y.ToString(); //显示头像中点纵坐标
    }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();//退出程序！
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //imageBox.Image = new Image<Bgr, byte>(Application.StartupPath + @"bg.jpg");
           // getHeadImg.Enabled = false;
        }

        private void getHeadImg_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < faceHistory.Count; i++)
            {
                flowImgContent.Controls.Clear();
                flowImgContent.Controls.AddRange(faceHistory.ToArray());
                flowImgContent.ScrollControlIntoView(faceHistory[i]);
            }
            if (pic.Image != null)
            {
                picget.Image = new System.Drawing.Bitmap(pic.Image, 160, 190);
            }
            else
            {
                MessageBox.Show("对不起，请选择图片或开启摄像头后采集!");
            }
        }

        private void saveImg_Click(object sender, EventArgs e)
        {//C:\Users\Administrator\Documents\Visual Studio 2010\Projects\FacesDetect\FacesDetect\bin\Debug\HeadImgs\
            //C:\Users\Administrator\Documents\Visual Studio 2010\Projects\FacesDetect\FacesDetect\HeadImgs\
                string Mapath = Application.StartupPath.ToString()+"\\HeadImgs\\";
                MessageBox.Show(Mapath);
                
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
