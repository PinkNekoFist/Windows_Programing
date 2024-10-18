using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace f74122161_practice_4_1
{
    public partial class Form2 : Form
    {
        Form1 form;
        int i = 0;
        public Form2(Form1 form, int i)
        {
            InitializeComponent();
            this.form = form;
            this.MouseClick += new MouseEventHandler(Form_MouseClick);
            this.i = i;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        private void Form_MouseClick(object sender, MouseEventArgs e)
        {
            // Generate a random color
            Random random = new Random();
            Color color = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
            this.BackColor = color;
            Form1.changeColor(form, color, i);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
