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
    public partial class MainPage : Form
    {
        public static int food1_count = 0;
        public static int food2_count = 0;
        public static int food3_count = 0;
        public static int num = 1000;
        public static List<Order> orders = new List<Order>();
        public MainPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // open addnewoffer

            addnewoffer addnewoffer = new addnewoffer();
            addnewoffer.Show();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // show order
            listBox1.Items.Clear();
            for (int i = 0; i < orders.Count; i++)
            {
                listBox1.Items.Add("訂單編號 " + orders[i].number + " " + orders[i].food_name + " x " + orders[i].count);
            }
        }
        
        public static void change_textBox1(String str)
        {
            // Get the instance of the MainPage form
            MainPage mainPage = Application.OpenForms.OfType<MainPage>().FirstOrDefault();
            if (mainPage != null)
            {
                mainPage.textBox1.Text = str;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
    public class Food
    {
        public string name;
        public int price;
        public int count;
        public Food(string name, int price, int count)
        {
            this.name = name;
            this.price = price;
            this.count = count;
        }
    }
    public class Order
    {
        public String food_name;
        public int count;
        public int number;
        public Order(String food_name, int count)
        {
            this.number = MainPage.num++;
            this.food_name = food_name;
            this.count = count;
        }
    }
}