namespace TouristGuide
{
    partial class Arhitekt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Arhitekt));
            this.panel11 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.Save2PDF = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.panel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Size = new System.Drawing.Size(1461, 58);
            // 
            // panel11
            // 
            this.panel11.AccessibleRole = System.Windows.Forms.AccessibleRole.Pane;
            this.panel11.Controls.Add(this.label2);
            this.panel11.Controls.Add(this.Save2PDF);
            this.panel11.Controls.Add(this.pictureBox3);
            this.panel11.Controls.Add(this.pictureBox2);
            this.panel11.Controls.Add(this.richTextBox1);
            this.panel11.Location = new System.Drawing.Point(135, 247);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(1171, 706);
            this.panel11.TabIndex = 15;
            this.panel11.MouseEnter += new System.EventHandler(this.panel11_MouseEnter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label2.Location = new System.Drawing.Point(491, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Αρχιτεκτονική";
            // 
            // Save2PDF
            // 
            this.Save2PDF.BackColor = System.Drawing.Color.DodgerBlue;
            this.Save2PDF.Location = new System.Drawing.Point(788, 29);
            this.Save2PDF.Name = "Save2PDF";
            this.Save2PDF.Size = new System.Drawing.Size(75, 23);
            this.Save2PDF.TabIndex = 3;
            this.Save2PDF.Text = "Save";
            this.Save2PDF.UseVisualStyleBackColor = false;
            this.Save2PDF.Click += new System.EventHandler(this.Save2PDF_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Location = new System.Drawing.Point(46, 263);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(232, 189);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(46, 76);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(232, 162);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.richTextBox1.Location = new System.Drawing.Point(303, 76);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(706, 662);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            this.richTextBox1.MouseEnter += new System.EventHandler(this.richTextBox1_MouseEnter);
            // 
            // Arhitekt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1461, 990);
            this.Controls.Add(this.panel11);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Arhitekt";
            this.Text = "Arhitekt";
            this.Load += new System.EventHandler(this.Arhitekt_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel10, 0);
            this.Controls.SetChildIndex(this.panel7, 0);
            this.Controls.SetChildIndex(this.panel5, 0);
            this.Controls.SetChildIndex(this.panel6, 0);
            this.Controls.SetChildIndex(this.panel11, 0);
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Button Save2PDF;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        public System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label2;
    }
}