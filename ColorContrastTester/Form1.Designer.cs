namespace ColorContrastTester
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
            this.txtColor1 = new System.Windows.Forms.TextBox();
            this.color2btn = new System.Windows.Forms.Button();
            this.txtColor2 = new System.Windows.Forms.TextBox();
            this.btnPickColor = new System.Windows.Forms.Button();
            this.txtRatio = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.color1btn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtColor1
            // 
            this.txtColor1.Location = new System.Drawing.Point(339, 154);
            this.txtColor1.Name = "txtColor1";
            this.txtColor1.Size = new System.Drawing.Size(60, 20);
            this.txtColor1.TabIndex = 2;
            // 
            // color2btn
            // 
            this.color2btn.BackColor = System.Drawing.Color.DimGray;
            this.color2btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.color2btn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.color2btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.color2btn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.color2btn.Location = new System.Drawing.Point(446, 38);
            this.color2btn.Name = "color2btn";
            this.color2btn.Size = new System.Drawing.Size(100, 100);
            this.color2btn.TabIndex = 1;
            this.color2btn.Text = "Color 2";
            this.color2btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.color2btn.UseVisualStyleBackColor = false;
            this.color2btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.color2btn_MouseDown);
            this.color2btn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.color2btn_MouseUp);
            // 
            // txtColor2
            // 
            this.txtColor2.Location = new System.Drawing.Point(470, 154);
            this.txtColor2.Name = "txtColor2";
            this.txtColor2.Size = new System.Drawing.Size(60, 20);
            this.txtColor2.TabIndex = 3;
            // 
            // btnPickColor
            // 
            this.btnPickColor.BackColor = System.Drawing.Color.Transparent;
            this.btnPickColor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPickColor.Enabled = false;
            this.btnPickColor.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btnPickColor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnPickColor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnPickColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPickColor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnPickColor.Location = new System.Drawing.Point(20, 30);
            this.btnPickColor.Margin = new System.Windows.Forms.Padding(5);
            this.btnPickColor.Name = "btnPickColor";
            this.btnPickColor.Size = new System.Drawing.Size(200, 200);
            this.btnPickColor.TabIndex = 7;
            this.btnPickColor.TabStop = false;
            this.btnPickColor.UseVisualStyleBackColor = false;
            // 
            // txtRatio
            // 
            this.txtRatio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRatio.Location = new System.Drawing.Point(470, 196);
            this.txtRatio.Name = "txtRatio";
            this.txtRatio.Size = new System.Drawing.Size(57, 23);
            this.txtRatio.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Info;
            this.label1.Location = new System.Drawing.Point(318, 196);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Contrast Ratio";
            // 
            // color1btn
            // 
            this.color1btn.BackColor = System.Drawing.Color.Black;
            this.color1btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.color1btn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.color1btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.color1btn.ForeColor = System.Drawing.SystemColors.Control;
            this.color1btn.Location = new System.Drawing.Point(316, 38);
            this.color1btn.Name = "color1btn";
            this.color1btn.Size = new System.Drawing.Size(100, 100);
            this.color1btn.TabIndex = 0;
            this.color1btn.Text = "Color 1";
            this.color1btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.color1btn.UseVisualStyleBackColor = false;
            this.color1btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.color1btn_MouseDown);
            this.color1btn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.color1btn_MouseUp);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(530, 20);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(540, 2);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "X";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(558, 247);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRatio);
            this.Controls.Add(this.txtColor2);
            this.Controls.Add(this.txtColor1);
            this.Controls.Add(this.color2btn);
            this.Controls.Add(this.color1btn);
            this.Controls.Add(this.btnPickColor);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "ColorContrastTester";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtColor1;
        private System.Windows.Forms.Button color2btn;
        private System.Windows.Forms.Button color1btn;
        private System.Windows.Forms.TextBox txtColor2;
        private System.Windows.Forms.Button btnPickColor;
        private System.Windows.Forms.TextBox txtRatio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
    }
}

