using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using Emgu.CV.GPU;
using Emgu.CV.CvEnum;

namespace FacesDetect
{
    public partial class VideoForm : Form
    {
        #region variables 设置变量
        Image<Gray, byte> result = null;//返回帧
        Image<Gray, byte> gray_frame = null;//灰度帧
        //public HaarCascade Face = new HaarCascade(Application.StartupPath + "\\Cascades\\haarcascade_frontalface_alt2.xml");//载入训练库数据
        //private Image<Bgr, byte> currentImage;//设置当前画面
        public CascadeClassifier Face = new CascadeClassifier(Application.StartupPath + "\\Cascades\\haarcascade_frontalface_default.xml");//载入训练库数据
        MCvFont font = new MCvFont(FONT.CV_FONT_HERSHEY_COMPLEX, 0.5, 0.5);//设置摄像头字体
        //Classifier with default training location
        Classifier_Train Eigen_Recog = new Classifier_Train();//实例化一个分类训练器
       // Image<Bgr, Byte> currentFrame;  //当前帧
      //  Image<Gray, byte> result, TrainedFace = null;//返回帧
        //Image<Gray, byte> gray_frame = null;//灰度帧
        //Classifier_Train Eigen_Recog = new Classifier_Train();//实例化一个分类训练器

        private Rectangle point;
        private Image<Bgr, byte> currentImage;
        string facepath = Application.StartupPath + "\\Cascades\\haarcascade_frontalface_default.xml";
        string eyepath = Application.StartupPath + "\\Cascades\\haarcascade_eye.xml";

       // Main_Form1 Parent3;
        #endregion
        public VideoForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.timer1.Enabled = true;
            start_cam();
           // Application.Idle += new EventHandler(FrameGrabber_Parrellel);

        }
        
        private void showVideo(object sender, EventArgs e)
        {
            string sourceURL = this.textBox1.Text;
            byte[] buffer = new byte[1000000];
            int read, total = 0;
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(sourceURL);
            //req.Credentials = new NetworkCredential("root", "admin");
            WebResponse resp = req.GetResponse();
            System.IO.Stream stream = resp.GetResponseStream();
            while ((read = stream.Read(buffer, total, 400000)) != 0)
            {
                total += read;
            }
           Bitmap bmp = (Bitmap)Bitmap.FromStream(new MemoryStream(buffer, 0, total));
            currentImage = new Image<Bgr, byte>((Bitmap)Bitmap.FromStream(new MemoryStream(buffer, 0, total)));
            markFace(currentImage);
            pictureBox1.Image = new System.Drawing.Bitmap(currentImage.ToBitmap(), 850, 660);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            start_cam();
        }
        /*******************************************************************
        private Image<Bgr, byte> markFace(Image<Bgr, byte> pic)
        {
            long detectionTime;
            List<Rectangle> faces = new List<Rectangle>();
            List<Rectangle> eyes = new List<Rectangle>();
            DetectFace.Detect(pic, facepath, eyepath, faces, eyes, out detectionTime);
            foreach (Rectangle face in faces)
                currentImage.Draw(face, new Bgr(Color.Yellow), 1);
            foreach (Rectangle eye in eyes)
                currentImage.Draw(eye, new Bgr(Color.Blue), 1);
            return pic;
        }
        ****************************************************/
        private Image<Bgr, byte> markFace(Image<Bgr, byte> pic)
        {
            currentImage = currentImage.Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
            //Convert it to Grayscale
           
            if (currentImage != null)
             
            {
                gray_frame = currentImage.Convert<Gray, Byte>();
            /***************************************************************
                //Face Detector
                MCvAvgComp[][] facesDetected = gray_frame.DetectHaarCascade(Face, 1.2, 10, Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(50, 50));

                //Action for each element detected
                foreach (MCvAvgComp face_found in facesDetected[0])
                {
                    result = currentImage.Copy(face_found.rect).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                    //draw the face detected in the 0th (gray) channel with blue color
                    currentImage.Draw(face_found.rect, new Bgr(Color.Red), 2);

                    if (Eigen_Recog.IsTrained)
                    {
                        string name = Eigen_Recog.Recognise(result);
                        int match_value = (int)Eigen_Recog.Get_Eigen_Distance;

                        //Draw the label for each face detected and recognized
                        currentImage.Draw(name + " ", ref font, new Point(face_found.rect.X - 2, face_found.rect.Y - 2), new Bgr(Color.LightGreen));
                   
             }
                }
             * ***********************************************/
               Rectangle[] facesDetected = Face.DetectMultiScale(gray_frame, 1.2, 10, new Size(50, 50), Size.Empty);

                //Action for each element detected
               for (int i = 0; i < facesDetected.Length; i++)// (Rectangle face_found in facesDetected)
               {
                   //This will focus in on the face from the haar results its not perfect but it will remove a majoriy
                   //of the background noise
                   facesDetected[i].X += (int)(facesDetected[i].Height * 0.15);
                   facesDetected[i].Y += (int)(facesDetected[i].Width * 0.22);
                   facesDetected[i].Height -= (int)(facesDetected[i].Height * 0.3);
                   facesDetected[i].Width -= (int)(facesDetected[i].Width * 0.35);

                   result = currentImage.Copy(facesDetected[i]).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                   result._EqualizeHist();
                   //draw the face detected in the 0th (gray) channel with blue color
                   currentImage.Draw(facesDetected[i], new Bgr(Color.Blue), 1);
                   point = new Rectangle(facesDetected[i].X + facesDetected[i].Width / 2, facesDetected[i].Y + facesDetected[i].Height / 2, 1, 1);//获取人脸识别图片的中心点
                   currentImage.Draw(point, new Bgr(Color.Red), 1);//用红色画出中心点
                   showPoint(point.X, point.Y);//监控中点坐标 （用无线送到单片机）

                   if (Eigen_Recog.IsTrained)
                   {
                       string name = Eigen_Recog.Recognise(result);
                       int match_value = (int)Eigen_Recog.Get_Eigen_Distance;

                       //Draw the label for each face detected and recognized
                       currentImage.Draw(name + " ", ref font, new Point(facesDetected[i].X - 2, facesDetected[i].Y - 2), new Bgr(Color.LightGreen));
                       //ADD_Face_Found(result, name, match_value);
                       //Show the faces procesed and recognized
                   }
               }
                pictureBox1.Image = currentImage.ToBitmap();
            }
            return pic;
        }

        private void VideoForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            stop_cam();
            Training_Form TF1 = new Training_Form(this);//以本窗体为父窗体打开训练窗体
            //Training_Form TF1 = new Training_Form(this);
            TF1.Show();
            
        }
        public void retrain()//重新加载数据
        {

            Eigen_Recog = new Classifier_Train();
            if (Eigen_Recog.IsTrained)
            {
                  message_bar.Text = "训练图像数据加载完毕！";
            }
            else
            {
                 message_bar.Text = "训练数据无法找到, 请通过训练菜单选项进行训练！";
            }
        }
        public void start_cam()
        {
            Application.Idle += new EventHandler(showVideo);
        }
        private void stop_cam()
        {
            Application.Idle -= new EventHandler(showVideo);

            if (currentImage != null)
            {
                currentImage.Dispose();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            stop_cam();
            this.Hide();
            
        }
        private void showPoint(int X, int Y)
        {
            point_X.Text = "横坐标X：" + X.ToString(); //显示头像中点横坐标
            point_Y.Text = "纵坐标Y：" + Y.ToString(); //显示头像中点纵坐标
        }
        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();//退出程序！
        }
       
    }
}
