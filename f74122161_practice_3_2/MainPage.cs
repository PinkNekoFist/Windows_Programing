using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace f74122161_practice_3_2
{
    public partial class MainPage : Form
    {

        public MainPage(String title)
        {
            InitializeComponent();
            this.title.Text = title;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            // check orders
            for (int i = 0; i < Form1.orders.Count; i++)
            {
                listBox1.Items.Add("訂單編號: " + Form1.orders[i].number + " 餐點: " + Form1.orders[i].food_name + " 數量: " + Form1.orders[i].count + " 由" + Form1.orders[i].user_name + "新增");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // logout
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // create new account
            this.Hide();
            AddAccount addAccount = new AddAccount();
            addAccount.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        public void changeTitle(String title)
        {
            this.title.Text = title;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddOrders addOrders = new AddOrders();
            addOrders.Show();
        }
    }
}
