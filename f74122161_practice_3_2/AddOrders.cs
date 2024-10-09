using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace f74122161_practice_3_2
{
    public partial class AddOrders : Form
    {
        public AddOrders()
        {
            InitializeComponent();
        }

        private int food_type = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            // 企鵝
            food_type = 1;
            button1.Text = "企鵝(已選擇)";
            button2.Text = "炸豬排";
            button3.Text = "炸蝦";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 炸豬排
            food_type = 2;
            button2.Text = "炸豬排(已選擇)";
            button1.Text = "企鵝";
            button3.Text = "炸蝦";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // 炸蝦
            food_type = 3;
            button3.Text = "炸蝦(已選擇)";
            button1.Text = "企鵝";
            button2.Text = "炸豬排";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // check number
            if (food_type == 0)
            {
                textBox3.Text = "請選擇餐點";
                // MessageBox.Show("請選擇餐點");
                return;
            }
            // if count is not a number
            if (!int.TryParse(count.Text, out int n))
            {
                textBox3.Text = "請輸入數字";
                // MessageBox.Show("請輸入數字");
                count.Text = "";
                return;
            }

            // count < 1
            if (int.Parse(count.Text) < 1)
            {
                textBox3.Text = "數量需大於0";
                count.Text = "";
                // MessageBox.Show("數量需大於0");
                return;
            }

            if (count.Text == "")
            {
                textBox3.Text = "請輸入數量";
                // MessageBox.Show("請輸入數量");
                return;
            }

            if (food_type == 1)
            {
                Form1.orders.Add(new Order("企鵝", int.Parse(count.Text), Form1.num++, Form1.user));
            }
            else if (food_type == 2)
            {
                Form1.orders.Add(new Order("炸豬排", int.Parse(count.Text), Form1.num++, Form1.user));
            }
            else if (food_type == 3)
            {
                Form1.orders.Add(new Order("炸蝦", int.Parse(count.Text), Form1.num++, Form1.user));
            }

            // Create an instance of MainPage to call the non-static method
            MainPage mainPage = new MainPage("新增訂單成功, 訂單編號:" + (Form1.num - 1));
            mainPage.Show();
            this.Hide();
        }
    }
}
