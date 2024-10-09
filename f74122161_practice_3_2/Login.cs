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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void account_TextChanged(object sender, EventArgs e)
        {

        }

        private void password_TextChanged(object sender, EventArgs e)
        {

        }

        private void bntLogin_Click(object sender, EventArgs e)
        {
            if (Form1.accounts.ContainsKey(account.Text) && Form1.accounts[account.Text] == password.Text)
            {
                Form1.user = account.Text;
                this.Hide();
                MainPage mainPage = new MainPage("Welcome " + Form1.user);
                mainPage.Show();
            }
            else
            {
                textBox1.Text = "Login failed";
                // MessageBox.Show("Login failed");
                account.Text = "";
                password.Text = "";
            }
        }
    }
}
