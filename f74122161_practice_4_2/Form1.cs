using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace f74122161_practice_4_2
{
    
    public partial class Form1 : Form
    {
        static Image dog, cat;
        List<Image> s = new List<Image>();
        int i, st;
        bool isPlaying = false;
        public static Color color1 = Color.FromArgb(255, 255, 255);
        public static Color color2 = Color.FromArgb(255, 255, 255);
        public Form1()
        {
            InitializeComponent();
            st = 0;
            i = 1;
            // Load an image from file or resource
            s.Add(Image.FromFile("../../Practice4_Images/Images/0.png")); // Change the image as needed
            s.Add(Image.FromFile("../../Practice4_Images/Images/1.png")); // Change the image as needed
            s.Add(Image.FromFile("../../Practice4_Images/Images/2.png")); // Change the image as needed
            s.Add(Image.FromFile("../../Practice4_Images/Images/3.png")); // Change the image as needed
            s.Add(Image.FromFile("../../Practice4_Images/Images/4.png")); // Change the image as needed
            s.Add(Image.FromFile("../../Practice4_Images/Images/5.png")); // Change the image as needed
            dog = Image.FromFile("../../Practice4_Images/Images/dog.png"); // Change the image as needed
            cat = Image.FromFile("../../Practice4_Images/Images/cat.png"); // Change the image as needed

            this.MouseDoubleClick += new MouseEventHandler(Form_MouseDoubleClick_1);
            this.tabControl1.SelectedIndexChanged += new EventHandler(TabControl1_SelectedIndexChanged_1);
        }

        private void Form_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // Open Form2 on double-click
            Form2 form2 = new Form2(this, i);
            form2.Show();
        }

        private void rb_Click(object sender, EventArgs e)
        {
            if (input2.Text == "") return;
            if (input2.Text == "喵！")
            {
                sent_message("喵！", false);
                sent_message("汪", true);
            }
            else
            {
                sent_message(input2.Text, false);
            }
            input2.Text = "";
        }
        private void sticker1_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(this, true);
            form3.Show();
        }

        private void sticker2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(this, false);
            form3.Show();
        }


        private void lb_Click(object sender, EventArgs e)
        {
            if (input1.Text == "") return;
            if (isPlaying)
            {
                isPlaying = false;
                if (input1.Text == "剪刀")
                {
                    sent_message("剪刀", true);
                    sent_message("布", false);
                }
                else if (input1.Text == "石頭")
                {
                    sent_message("石頭", true);
                    sent_message("剪刀", false);
                }
                else if (input1.Text == "布")
                {
                    sent_message("布", true);
                    sent_message("石頭", false);
                }
                else
                {
                    isPlaying = true;
                    input1.Text = "";
                    return;
                }
                input1.Text = "";
                rb.Enabled = true;
                input2.Enabled = true;
                sticker2.Enabled = true;
                sticker1.Enabled = true;
                return;
            }
            if (input1.Text == "猜拳")
            {
                isPlaying = true;
                sent_message("猜拳", true);
                sent_message("遊戲開始", false);
                rb.Enabled = false;
                input2.Enabled = false;
                sticker2.Enabled = false;
                sticker1.Enabled = false;
            }
            else if (input1.Text == "汪！")
            {
                sent_message("汪！", true);
                sent_message("喵", false);
            }
            else
            {
                sent_message(input1.Text, true);
            }
            input1.Text = "";
        }

        void sent_message(string message, bool b)
        {
            if (b)
            {
                message = "斗哥 ：" + message;
                rtb2.SelectionAlignment = HorizontalAlignment.Left;
                InsertImage(rtb2, dog);
                rtb2.AppendText(message + "\r\n");
                rtb1.SelectionAlignment = HorizontalAlignment.Right;
                InsertImage(rtb1, dog);
                rtb1.AppendText(message + "\r\n");
            }
            else
            {
                message = "楷特 :" + message;
                rtb1.SelectionAlignment = HorizontalAlignment.Left;
                InsertImage(rtb1, cat);
                rtb1.AppendText(message + "\r\n");
                rtb2.SelectionAlignment = HorizontalAlignment.Right;
                InsertImage(rtb2, cat);
                rtb2.AppendText(message + "\r\n");
            }
        }
        private void TabControl1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            TabControl tabControl = sender as TabControl;
            if (tabControl != null)
            {
                if (i == 2) i = 1;
                else i = 2;
            }
            if (i == 1)
            {
                this.BackColor = color1;
                this.rtb1.BackColor = color1;
            }
            else if (i == 2)
            {
                this.BackColor = color2;
                this.rtb2.BackColor = color2;
            }
        }
        public static void changeColor(Form1 form, Color color, int i)
        {
            if (i == 1)
            {
                form.BackColor = color;
                form.rtb1.BackColor = color;
                color1 = color;
            }
            else if (i == 2)
            {
                form.BackColor = color;
                form.rtb2.BackColor = color;
                color2 = color;
            }
        }

        public void sentSticker1(Form1 form, int st)
        {
                    rtb1.SelectionAlignment = HorizontalAlignment.Right;
                    InsertImage(rtb1, dog);
                    rtb1.AppendText("斗哥 : ");
                    InsertImage(rtb1, s[st - 1]);
                    rtb1.AppendText("\r\b");
                    rtb2.SelectionAlignment = HorizontalAlignment.Left;
                    InsertImage(rtb2, dog);
                    rtb2.AppendText("斗哥 : ");
                    InsertImage(rtb2, s[st - 1]);
                    rtb2.AppendText("\r\b");
        }

        public void sentSticker2(Form1 form, int st)
        {
            rtb1.SelectionAlignment = HorizontalAlignment.Left;
            InsertImage(rtb1, cat);
            rtb1.AppendText("楷特 : ");
            InsertImage(rtb1, s[st - 1]);
            rtb1.AppendText("\r\b");
            rtb2.SelectionAlignment = HorizontalAlignment.Right;
            InsertImage(rtb2, cat);
            rtb2.AppendText("楷特 : ");
            InsertImage(rtb2, s[st - 1]);
            rtb2.AppendText("\r\b");
        }
        private string GetRtfImage(byte[] imageBytes, int width, int height)
        {
            StringBuilder rtf = new StringBuilder();
            rtf.Append(@"{\rtf1{\pict\pngblip\picw");
            rtf.Append(width);
            rtf.Append(@"\pich");
            rtf.Append(height);
            rtf.Append(" ");
            rtf.Append(BitConverter.ToString(imageBytes).Replace("-", string.Empty));
            rtf.Append("}}");
            return rtf.ToString();
        }

        public void InsertImage(RichTextBox richTextBox, Image image)
        {
            if (image == null)
                throw new ArgumentNullException(nameof(image));

            using (MemoryStream stream = new MemoryStream())
            {
                image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                byte[] imgBytes = stream.ToArray();
                string rtfImage = GetRtfImage(imgBytes, image.Width / 2, image.Height / 2);

                richTextBox.ReadOnly = false;
                richTextBox.SelectedRtf = rtfImage;
                richTextBox.ReadOnly = true;
            }
        }
        private void Form_MouseDoubleClick_1(object sender, MouseEventArgs e)
        {
            // Open Form2 on double-click
            Form2 form2 = new Form2(this, i);
            form2.Show();
        }
    }
}
