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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void password_TextChanged(object sender, EventArgs e)
        {
               
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void account_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void bntLogin_Click(object sender, EventArgs e)
        {
            if (account.Text == "admin" && password.Text == "admin")
            {
                MessageBox.Show("Login successfully");
                this.Hide();
                MainPage mainPage = new MainPage();
                mainPage.Show();
            }
            else
            {
                MessageBox.Show("Login failed");
                password.Clear();
                account.Clear();
            }
        }
    }
}
