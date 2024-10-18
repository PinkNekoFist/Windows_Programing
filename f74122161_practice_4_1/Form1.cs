using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace f74122161_practice_4_1
{
    public partial class Form1 : Form
    {
        public List<string> k = new List<string>();
        public List<string> d = new List<string>();
        public static Color color1 = Color.FromArgb(255, 255, 255);
        public static Color color2 = Color.FromArgb(255, 255, 255);
        int i = 1;
        int index = 0;
        private bool isUser1 = true;
        public Form1()
        {
            InitializeComponent();
            this.MouseDoubleClick += new MouseEventHandler(Form_MouseDoubleClick);
            tabPage3.SelectedIndexChanged += new EventHandler(TabControl1_SelectedIndexChanged);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") return;
            if (index >= 10) removeFirstLine();
            user2Sent(textBox1.Text);
            user1Sent("汪！");
            index++;

            textBox1.Clear();
        }

        private void user2Sent(string str)
        {
            txtUser12.AppendText("楷特：" + str + "\r\n");
            txtUser11.AppendText("\r\n");
            txtUser21.Text += "\r\n";
            txtUser22.Text += "楷特：" + str + "\r\n";
        }

        private void user1Sent(string str)
        {
            txtUser11.Text += "斗哥：" + str + "\r\n";
            txtUser12.Text += "\r\n";
            txtUser22.Text += "\r\n";
            txtUser21.Text += "斗哥：" + str + "\r\n";
        }

        private void removeFirstLine()
        {
            var lines = txtUser11.Lines.ToList();
            lines.RemoveAt(0);
            lines.RemoveAt(0);
            txtUser11.Lines = lines.ToArray();

            lines = txtUser12.Lines.ToList();
            lines.RemoveAt(0);
            lines.RemoveAt(0);
            txtUser12.Lines = lines.ToArray();

            lines = txtUser21.Lines.ToList();
            lines.RemoveAt(0);
            lines.RemoveAt(0);
            txtUser21.Lines = lines.ToArray();

            lines = txtUser22.Lines.ToList();
            lines.RemoveAt(0);
            lines.RemoveAt(0);
            txtUser22.Lines = lines.ToArray();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public static void changeColor(Form1 form, Color color, int i)
        {
            if (i == 1)
            {
                form.BackColor = color;
                form.txtUser21.BackColor = color;
                form.txtUser22.BackColor = color;
                color1 = color;
            }
            else if (i == 2)
            {
                form.BackColor = color;
                form.txtUser11.BackColor = color;
                form.txtUser12.BackColor = color;
                color2 = color;
            }
        }
        private void Form_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // new form
            Form2 form2 = new Form2(this, i);
            form2.Show();
        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
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
                this.txtUser21.BackColor = color1;
                this.txtUser22.BackColor = color1;
            }
            else if (i == 2)
            {
                this.BackColor = color2;
                this.txtUser12.BackColor = color2;
                this.txtUser11.BackColor = color2;
            }
        }



        private void txtUser21_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
