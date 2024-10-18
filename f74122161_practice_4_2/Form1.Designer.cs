namespace f74122161_practice_4_2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lb = new System.Windows.Forms.Button();
            this.sticker1 = new System.Windows.Forms.Button();
            this.input1 = new System.Windows.Forms.TextBox();
            this.rtb1 = new System.Windows.Forms.RichTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.rb = new System.Windows.Forms.Button();
            this.sticker2 = new System.Windows.Forms.Button();
            this.input2 = new System.Windows.Forms.TextBox();
            this.rtb2 = new System.Windows.Forms.RichTextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(63, 28);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(616, 386);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Tag = "";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lb);
            this.tabPage1.Controls.Add(this.sticker1);
            this.tabPage1.Controls.Add(this.input1);
            this.tabPage1.Controls.Add(this.rtb1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(608, 360);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "斗哥";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lb
            // 
            this.lb.Location = new System.Drawing.Point(563, 311);
            this.lb.Name = "lb";
            this.lb.Size = new System.Drawing.Size(39, 36);
            this.lb.TabIndex = 4;
            this.lb.Text = "送出";
            this.lb.UseVisualStyleBackColor = true;
            this.lb.Click += new System.EventHandler(this.lb_Click);
            // 
            // sticker1
            // 
            this.sticker1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("sticker1.BackgroundImage")));
            this.sticker1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.sticker1.Image = ((System.Drawing.Image)(resources.GetObject("sticker1.Image")));
            this.sticker1.Location = new System.Drawing.Point(509, 311);
            this.sticker1.Name = "sticker1";
            this.sticker1.Size = new System.Drawing.Size(38, 36);
            this.sticker1.TabIndex = 3;
            this.sticker1.UseVisualStyleBackColor = true;
            this.sticker1.Click += new System.EventHandler(this.sticker1_Click);
            // 
            // input1
            // 
            this.input1.Location = new System.Drawing.Point(29, 320);
            this.input1.Name = "input1";
            this.input1.Size = new System.Drawing.Size(458, 22);
            this.input1.TabIndex = 2;
            // 
            // rtb1
            // 
            this.rtb1.Location = new System.Drawing.Point(25, 27);
            this.rtb1.Name = "rtb1";
            this.rtb1.ReadOnly = true;
            this.rtb1.Size = new System.Drawing.Size(564, 274);
            this.rtb1.TabIndex = 0;
            this.rtb1.Text = "";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.rb);
            this.tabPage2.Controls.Add(this.sticker2);
            this.tabPage2.Controls.Add(this.input2);
            this.tabPage2.Controls.Add(this.rtb2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(608, 360);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "楷特";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // rb
            // 
            this.rb.Location = new System.Drawing.Point(551, 321);
            this.rb.Name = "rb";
            this.rb.Size = new System.Drawing.Size(39, 36);
            this.rb.TabIndex = 7;
            this.rb.Text = "送出";
            this.rb.UseVisualStyleBackColor = true;
            this.rb.Click += new System.EventHandler(this.rb_Click);
            // 
            // sticker2
            // 
            this.sticker2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("sticker2.BackgroundImage")));
            this.sticker2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.sticker2.Image = ((System.Drawing.Image)(resources.GetObject("sticker2.Image")));
            this.sticker2.Location = new System.Drawing.Point(507, 324);
            this.sticker2.Name = "sticker2";
            this.sticker2.Size = new System.Drawing.Size(38, 36);
            this.sticker2.TabIndex = 6;
            this.sticker2.UseVisualStyleBackColor = true;
            this.sticker2.Click += new System.EventHandler(this.sticker2_Click);
            // 
            // input2
            // 
            this.input2.Location = new System.Drawing.Point(23, 327);
            this.input2.Name = "input2";
            this.input2.Size = new System.Drawing.Size(458, 22);
            this.input2.TabIndex = 5;
            // 
            // rtb2
            // 
            this.rtb2.Location = new System.Drawing.Point(23, 23);
            this.rtb2.Name = "rtb2";
            this.rtb2.ReadOnly = true;
            this.rtb2.Size = new System.Drawing.Size(567, 290);
            this.rtb2.TabIndex = 2;
            this.rtb2.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RichTextBox rtb1;
        private System.Windows.Forms.RichTextBox rtb2;
        private System.Windows.Forms.TextBox input1;
        private System.Windows.Forms.Button lb;
        private System.Windows.Forms.Button sticker1;
        private System.Windows.Forms.Button rb;
        private System.Windows.Forms.Button sticker2;
        private System.Windows.Forms.TextBox input2;
    }
}

