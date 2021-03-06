﻿namespace MSpaceInvaders
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.enemyMovement = new System.Windows.Forms.Timer(this.components);
            this.mvLeft = new System.Windows.Forms.Timer(this.components);
            this.mvRight = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lbDifficulty = new System.Windows.Forms.Label();
            this.pSpeed = new System.Windows.Forms.Label();
            this.maxB = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 75;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // enemyMovement
            // 
            this.enemyMovement.Enabled = true;
            this.enemyMovement.Interval = 200;
            this.enemyMovement.Tick += new System.EventHandler(this.enemyMovement_Tick);
            // 
            // mvLeft
            // 
            this.mvLeft.Interval = 40;
            this.mvLeft.Tick += new System.EventHandler(this.mvLeft_Tick);
            // 
            // mvRight
            // 
            this.mvRight.Interval = 40;
            this.mvRight.Tick += new System.EventHandler(this.mvRight_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Montserrat", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(39, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            this.label1.Paint += new System.Windows.Forms.PaintEventHandler(this.label1_Paint);
            // 
            // panel1
            // 
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.CausesValidation = false;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lbDifficulty);
            this.panel1.Controls.Add(this.pSpeed);
            this.panel1.Controls.Add(this.maxB);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.ForeColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(0, 526);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(624, 35);
            this.panel1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(302, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 22);
            this.label2.TabIndex = 6;
            this.label2.Text = "0";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Paint += new System.Windows.Forms.PaintEventHandler(this.label2_Paint);
            // 
            // lbDifficulty
            // 
            this.lbDifficulty.AutoSize = true;
            this.lbDifficulty.BackColor = System.Drawing.Color.Transparent;
            this.lbDifficulty.Font = new System.Drawing.Font("Montserrat", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDifficulty.ForeColor = System.Drawing.Color.White;
            this.lbDifficulty.Location = new System.Drawing.Point(161, 10);
            this.lbDifficulty.Name = "lbDifficulty";
            this.lbDifficulty.Size = new System.Drawing.Size(72, 16);
            this.lbDifficulty.TabIndex = 4;
            this.lbDifficulty.Text = "Difficulty : ";
            this.lbDifficulty.Paint += new System.Windows.Forms.PaintEventHandler(this.lbDifficulty_Paint);
            // 
            // pSpeed
            // 
            this.pSpeed.AutoSize = true;
            this.pSpeed.BackColor = System.Drawing.Color.Transparent;
            this.pSpeed.Font = new System.Drawing.Font("Montserrat", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pSpeed.ForeColor = System.Drawing.Color.White;
            this.pSpeed.Location = new System.Drawing.Point(501, 10);
            this.pSpeed.Name = "pSpeed";
            this.pSpeed.Size = new System.Drawing.Size(111, 16);
            this.pSpeed.TabIndex = 3;
            this.pSpeed.Text = "Projectile Speed: ";
            this.pSpeed.Click += new System.EventHandler(this.pSpeed_Click);
            this.pSpeed.Paint += new System.Windows.Forms.PaintEventHandler(this.pSpeed_Paint);
            // 
            // maxB
            // 
            this.maxB.AutoSize = true;
            this.maxB.BackColor = System.Drawing.Color.Transparent;
            this.maxB.Font = new System.Drawing.Font("Montserrat", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxB.ForeColor = System.Drawing.Color.White;
            this.maxB.Location = new System.Drawing.Point(396, 10);
            this.maxB.Name = "maxB";
            this.maxB.Size = new System.Drawing.Size(81, 16);
            this.maxB.TabIndex = 2;
            this.maxB.Text = "Max bullets :";
            this.maxB.Paint += new System.Windows.Forms.PaintEventHandler(this.maxB_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::MSpaceInvaders.Properties.Resources.heart;
            this.pictureBox1.Location = new System.Drawing.Point(3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(624, 561);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modern Space Invaders (Ingame)";
            this.TransparencyKey = System.Drawing.Color.Coral;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer enemyMovement;
        private System.Windows.Forms.Timer mvLeft;
        private System.Windows.Forms.Timer mvRight;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label maxB;
        public System.Windows.Forms.Label pSpeed;
        public System.Windows.Forms.Label lbDifficulty;
        public System.Windows.Forms.Label label2;
    }
}

