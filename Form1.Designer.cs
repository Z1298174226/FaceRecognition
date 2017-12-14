namespace FacesDetect
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.start = new System.Windows.Forms.Button();
            this.openImage = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.resultText = new System.Windows.Forms.TextBox();
            this.point_X = new System.Windows.Forms.Label();
            this.point_Y = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.getHeadImg = new System.Windows.Forms.Button();
            this.close = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.FaceNumTxt = new System.Windows.Forms.TextBox();
            this.imageBox = new Emgu.CV.UI.ImageBox();
            this.flowImgContent = new System.Windows.Forms.FlowLayoutPanel();
            this.picget = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.saveImg = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picget)).BeginInit();
            this.SuspendLayout();
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(870, 435);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(75, 23);
            this.start.TabIndex = 0;
            this.start.Text = "启动摄像";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // openImage
            // 
            this.openImage.Location = new System.Drawing.Point(870, 392);
            this.openImage.Name = "openImage";
            this.openImage.Size = new System.Drawing.Size(75, 23);
            this.openImage.TabIndex = 1;
            this.openImage.Text = "打开图片";
            this.openImage.UseVisualStyleBackColor = true;
            this.openImage.Click += new System.EventHandler(this.openImage_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // resultText
            // 
            this.resultText.Enabled = false;
            this.resultText.Location = new System.Drawing.Point(111, 506);
            this.resultText.Name = "resultText";
            this.resultText.ReadOnly = true;
            this.resultText.Size = new System.Drawing.Size(187, 21);
            this.resultText.TabIndex = 3;
            // 
            // point_X
            // 
            this.point_X.AutoSize = true;
            this.point_X.Location = new System.Drawing.Point(680, 538);
            this.point_X.Name = "point_X";
            this.point_X.Size = new System.Drawing.Size(59, 12);
            this.point_X.TabIndex = 4;
            this.point_X.Text = "横坐标X：";
            // 
            // point_Y
            // 
            this.point_Y.AutoSize = true;
            this.point_Y.Location = new System.Drawing.Point(768, 538);
            this.point_Y.Name = "point_Y";
            this.point_Y.Size = new System.Drawing.Size(59, 12);
            this.point_Y.TabIndex = 5;
            this.point_Y.Text = "纵坐标Y：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 509);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "系统状态监控：";
            // 
            // getHeadImg
            // 
            this.getHeadImg.Location = new System.Drawing.Point(870, 310);
            this.getHeadImg.Name = "getHeadImg";
            this.getHeadImg.Size = new System.Drawing.Size(75, 23);
            this.getHeadImg.TabIndex = 7;
            this.getHeadImg.Text = "采集头像";
            this.getHeadImg.UseVisualStyleBackColor = true;
            this.getHeadImg.Click += new System.EventHandler(this.getHeadImg_Click);
            // 
            // close
            // 
            this.close.Location = new System.Drawing.Point(870, 531);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(75, 23);
            this.close.TabIndex = 8;
            this.close.Text = "退出";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(396, 509);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "识别人脸数目：";
            // 
            // FaceNumTxt
            // 
            this.FaceNumTxt.Enabled = false;
            this.FaceNumTxt.Location = new System.Drawing.Point(491, 506);
            this.FaceNumTxt.Name = "FaceNumTxt";
            this.FaceNumTxt.ReadOnly = true;
            this.FaceNumTxt.Size = new System.Drawing.Size(144, 21);
            this.FaceNumTxt.TabIndex = 10;
            // 
            // imageBox
            // 
            this.imageBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageBox.Location = new System.Drawing.Point(12, 12);
            this.imageBox.Name = "imageBox";
            this.imageBox.Size = new System.Drawing.Size(640, 480);
            this.imageBox.TabIndex = 2;
            this.imageBox.TabStop = false;
            // 
            // flowImgContent
            // 
            this.flowImgContent.BackColor = System.Drawing.Color.Turquoise;
            this.flowImgContent.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowImgContent.Location = new System.Drawing.Point(677, 12);
            this.flowImgContent.Name = "flowImgContent";
            this.flowImgContent.Size = new System.Drawing.Size(250, 280);
            this.flowImgContent.TabIndex = 11;
            // 
            // picget
            // 
            this.picget.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picget.Location = new System.Drawing.Point(679, 299);
            this.picget.Name = "picget";
            this.picget.Size = new System.Drawing.Size(160, 190);
            this.picget.TabIndex = 12;
            this.picget.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 540);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(377, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "Six_legs Robot   西安电子科技大学  物理与光电工程学院   赵旭东";
            // 
            // saveImg
            // 
            this.saveImg.Location = new System.Drawing.Point(870, 498);
            this.saveImg.Name = "saveImg";
            this.saveImg.Size = new System.Drawing.Size(75, 23);
            this.saveImg.TabIndex = 14;
            this.saveImg.Text = "数据入库";
            this.saveImg.UseVisualStyleBackColor = true;
            this.saveImg.Click += new System.EventHandler(this.saveImg_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(744, 500);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(93, 21);
            this.textBox1.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(680, 503);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 16;
            this.label4.Text = "图像人名：";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(870, 350);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 17;
            this.button2.Text = "图像比较";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(978, 566);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.saveImg);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.picget);
            this.Controls.Add(this.flowImgContent);
            this.Controls.Add(this.FaceNumTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.close);
            this.Controls.Add(this.getHeadImg);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.point_Y);
            this.Controls.Add(this.point_X);
            this.Controls.Add(this.resultText);
            this.Controls.Add(this.imageBox);
            this.Controls.Add(this.openImage);
            this.Controls.Add(this.start);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "基于OPEN CV 人脸识别追踪系统";
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picget)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Button openImage;
        private Emgu.CV.UI.ImageBox imageBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox resultText;
        private System.Windows.Forms.Label point_X;
        private System.Windows.Forms.Label point_Y;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button getHeadImg;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox FaceNumTxt;
        private System.Windows.Forms.FlowLayoutPanel flowImgContent;
        private System.Windows.Forms.PictureBox picget;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button saveImg;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
    }
}

