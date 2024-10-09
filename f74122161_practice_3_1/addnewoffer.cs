using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace f74122161_practice_3_1
{
    public partial class addnewoffer : Form
    {
        public addnewoffer()
        {
            InitializeComponent();
        }
        int food_type = 0;


        private void count_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 企鵝
            food_type = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 炸豬排
            food_type = 2;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // 炸蝦
            food_type = 3;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (food_type == 1)
            {
                MainPage.food1_count += int.Parse(count.Text);
                MainPage.orders.Add(new Order("企鵝", int.Parse(count.Text)));
            }
            else if (food_type == 2)
            {
                MainPage.food2_count += int.Parse(count.Text);
                MainPage.orders.Add(new Order("炸豬排", int.Parse(count.Text)));
            }
            else if (food_type == 3)
            {
                MainPage.food3_count += int.Parse(count.Text);
                MainPage.orders.Add(new Order("炸蝦", int.Parse(count.Text)));
            }
            MainPage.change_textBox1("新增訂單成功, 訂單編號:" + (MainPage.num - 1));

            this.Hide();
        }
    }
}
