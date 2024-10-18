using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace f74122161_practice_4_2
{
    public partial class Form3 : Form
    {
        public static int st = 0;
        bool b;
        Form1 form1;
        public Form3(Form1 form1, bool b)
        {
            this.b = b;
            this.form1 = form1; 
            InitializeComponent();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (b)
            {
                if (st == 0) return;
                form1.sentSticker1(form1, st);
            }
            else
            {
                if (st == 0) return;
                form1.sentSticker2(form1, st);
            }
            this.Hide();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            st = 1;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            st = 2;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            st = 3;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            st = 4;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            st = 5;
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            st = 6;
        }
    }
}
