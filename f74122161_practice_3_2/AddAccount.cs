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
    public partial class AddAccount : Form
    {
        public AddAccount()
        {
            InitializeComponent();
        }

        private void bntLogin_Click(object sender, EventArgs e)
        {
            if (Form1.accounts.ContainsKey(account.Text))
            {
                textBox1.Text = "Account already exists";
                // MessageBox.Show("Account already exists");
                return;
            }
            if (account.Text == "" || password.Text == "")
            {
                textBox1.Text = "Please enter account and password";
                // MessageBox.Show("Please enter account and password");
                return;
            }
            Form1.accounts.Add(account.Text, password.Text);
            Form1.user = account.Text;
            this.Hide();
            MainPage mainPage = new MainPage("Welcome " + Form1.user);
            mainPage.Show();
        }
    }
}
