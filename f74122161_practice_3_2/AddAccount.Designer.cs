namespace f74122161_practice_3_2
{
    partial class AddAccount
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.account = new System.Windows.Forms.TextBox();
            this.bntLogin = new System.Windows.Forms.Button();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // account
            // 
            this.account.Location = new System.Drawing.Point(252, 261);
            this.account.Name = "account";
            this.account.Size = new System.Drawing.Size(337, 22);
            this.account.TabIndex = 18;
            // 
            // bntLogin
            // 
            this.bntLogin.Font = new System.Drawing.Font("PMingLiU", 18F);
            this.bntLogin.Location = new System.Drawing.Point(619, 261);
            this.bntLogin.Name = "bntLogin";
            this.bntLogin.Size = new System.Drawing.Size(169, 96);
            this.bntLogin.TabIndex = 17;
            this.bntLogin.Text = "新增帳號";
            this.bntLogin.UseVisualStyleBackColor = true;
            this.bntLogin.Click += new System.EventHandler(this.bntLogin_Click);
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(159, 335);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(50, 22);
            this.textBox5.TabIndex = 16;
            this.textBox5.Text = "密碼";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(159, 261);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(50, 22);
            this.textBox4.TabIndex = 15;
            this.textBox4.Text = "帳號";
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(252, 335);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(337, 22);
            this.password.TabIndex = 14;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("PMingLiU", 24F);
            this.textBox1.Location = new System.Drawing.Point(129, 89);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(625, 46);
            this.textBox1.TabIndex = 13;
            this.textBox1.Text = "歡迎 ! 請輸入帳號和密碼";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // AddAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.account);
            this.Controls.Add(this.bntLogin);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.password);
            this.Controls.Add(this.textBox1);
            this.Name = "AddAccount";
            this.Text = "AddAccount";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox account;
        private System.Windows.Forms.Button bntLogin;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.TextBox textBox1;
    }
}