using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace f74122161_practice_5_1
{
    public partial class Form1 : Form
    {
        private Timer fruitTimer;
        int x = 0;
        Plate p;
        public int catched = 0;
        public int notCatched = 0;
        public Form1()
        {
            InitializeComponent();
        }
        private void InitializeFruitTimer()
        {
            fruitTimer = new Timer();
            fruitTimer.Interval = 1000; // 1 second
            fruitTimer.Tick += FruitTimer_Tick;
            fruitTimer.Start();
        }

        private void FruitTimer_Tick(object sender, EventArgs e)
        {
            textBox1.Text = "Catched: " + catched + "/ Not catched: " + notCatched;
            fruit newFruit = new fruit(x, p, this);
            x += 20;
            if (x > this.Size.Width - 50)
            {
                x = 0;
            }
            this.Controls.Add(newFruit);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            InitializeFruitTimer();
            // add Plate
            p = new Plate();
            this.Controls.Add(p);
            this.button1.Hide();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (p == null)
                return;
            int s = 10;
            if (e.Shift == true)
            {
                s = 20;
            }
            else
            {
                s = 10;    //移動點數為1點
            }
            if (p.Location.X >= 10 && (e.KeyCode == Keys.Left || e.KeyCode == Keys.A))
                p.Location = new Point(p.Location.X - s, p.Location.Y);
            else if (p.Location.X <= this.Size.Width - p.Size.Width - 20 && (e.KeyCode == Keys.Right || e.KeyCode == Keys.D))
                p.Location = new Point(p.Location.X + s, p.Location.Y);
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //int s = 10;

            //switch (e.KeyChar)        // 根據e.KeyChar分別執行
            //{
            //    case (char)Keys.Left:      // 若按向左鍵
            //    case 'A':         // 若按A鍵
            //    case 'a':
            //        if (p.Location.X - s >= 0) // Add this condition to prevent the plate from moving out of the form
            //            p.Location = new Point(p.Location.X - s, p.Location.Y);
            //        break;
            //    case (char)Keys.Right:     // 若按向右鍵
            //    case 'D':         // 若按D鍵
            //    case 'd':
            //        if (p.Location.X + s <= this.Size.Width - p.Size.Width) // Add this condition to prevent the plate from moving out of the form
            //            p.Location = new Point(p.Location.X + s, p.Location.Y);
            //        break;
            //}
        }
    }

    public class fruit : PictureBox
    {
        private Timer fallTimer;
        private Plate p;
        public Form1 fr;
        public fruit(int x, Plate p, Form1 form) // Change the constructor to public
        {
            this.p = p;
            this.fr = form;
            this.Image = Image.FromFile("../../fruit1.png");
            this.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Size = new Size(50, 50);
            this.Location = new Point(x, 10);
            InitializeFallTimer();
        }

        private void InitializeFallTimer()
        {
            fallTimer = new Timer();
            fallTimer.Interval = 50; // Adjust the interval for smooth falling
            fallTimer.Tick += FallTimer_Tick;
            fallTimer.Start();
        }

        private void FallTimer_Tick(object sender, EventArgs e)
        {
            this.Location = new Point(this.Location.X, this.Location.Y + 5); // Move the fruit down by 5 pixels
            if (this.Location.Y > this.fr.Size.Height - 50) // Stop the fruit when it reaches the bottom of the form
            {
                fallTimer.Stop();
                fallTimer.Dispose();
                fr.notCatched += 1;
                this.Hide();
            }
            else if (this.Location.X + this.Size.Width > p.Location.X &&
                    this.Location.X < p.Location.X + 8 * p.Size.Height &&
                    this.Location.Y + this.Height > p.Location.Y &&
                    this.Location.Y < p.Location.Y + p.Size.Height)
            {
                fr.catched += 1;
                fallTimer.Stop();
                fallTimer.Dispose();
                this.Hide();
            }
        }
    }

    public class Plate : PictureBox
    {
        public Plate()
        {
            this.BackColor = Color.Pink;
            this.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Size = new Size(150, 20);
            this.Location = new Point(250, 350);
            this.Show();
        }
    }
}
