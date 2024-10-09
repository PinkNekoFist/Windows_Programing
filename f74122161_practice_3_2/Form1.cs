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
    public partial class Form1 : Form
    {
        public static int num = 1000;
        public static Dictionary<string, string> accounts = new Dictionary<string, string>();
        public static List<Order> orders = new List<Order>();
        public static String user = "";
        public Form1()
        {
            InitializeComponent();
            accounts.Add("admin", "admin");
        }

        private void title_TextChanged(object sender, EventArgs e)
        {

        }

        private void bntStart_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
            // MainPage mainPage = new MainPage();
            // mainPage.Show();
        }
    }
    public class Order
    {
        public String food_name;
        public int count;
        public int number;
        public String user_name;
        public Order(String food_name, int count, int num, String user)
        {
            this.number = num;
            this.food_name = food_name;
            this.count = count;
            this.user_name = user;
        }
    }
}
