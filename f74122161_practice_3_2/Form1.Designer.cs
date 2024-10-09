namespace f74122161_practice_3_2
{
    partial class Form1
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
            this.bntStart = new System.Windows.Forms.Button();
            this.title = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // bntStart
            // 
            this.bntStart.Font = new System.Drawing.Font("PMingLiU", 48F);
            this.bntStart.Location = new System.Drawing.Point(154, 224);
            this.bntStart.Name = "bntStart";
            this.bntStart.Size = new System.Drawing.Size(476, 156);
            this.bntStart.TabIndex = 4;
            this.bntStart.Text = "START";
            this.bntStart.UseVisualStyleBackColor = true;
            this.bntStart.Click += new System.EventHandler(this.bntStart_Click);
            // 
            // title
            // 
            this.title.Font = new System.Drawing.Font("PMingLiU", 24F);
            this.title.Location = new System.Drawing.Point(205, 56);
            this.title.Name = "title";
            this.title.ReadOnly = true;
            this.title.Size = new System.Drawing.Size(378, 46);
            this.title.TabIndex = 3;
            this.title.Text = "Welcome to the shop";
            this.title.TextChanged += new System.EventHandler(this.title_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.bntStart);
            this.Controls.Add(this.title);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bntStart;
        private System.Windows.Forms.TextBox title;
    }
}

