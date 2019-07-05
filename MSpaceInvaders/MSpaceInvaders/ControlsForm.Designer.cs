namespace MSpaceInvaders
{
    partial class ControlsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlsForm));
            this.button1 = new System.Windows.Forms.Button();
            this.pbLeftArrow = new System.Windows.Forms.PictureBox();
            this.pbRightArrow = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbLeftArrow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRightArrow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::MSpaceInvaders.Properties.Resources.Space;
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(508, 509);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 41);
            this.button1.TabIndex = 1;
            this.button1.Text = "Назад";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pbLeftArrow
            // 
            this.pbLeftArrow.BackColor = System.Drawing.Color.Transparent;
            this.pbLeftArrow.BackgroundImage = global::MSpaceInvaders.Properties.Resources.computer_key_Arrow_Left_T;
            this.pbLeftArrow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbLeftArrow.Location = new System.Drawing.Point(440, 86);
            this.pbLeftArrow.Name = "pbLeftArrow";
            this.pbLeftArrow.Size = new System.Drawing.Size(70, 50);
            this.pbLeftArrow.TabIndex = 2;
            this.pbLeftArrow.TabStop = false;
            // 
            // pbRightArrow
            // 
            this.pbRightArrow.BackColor = System.Drawing.Color.Transparent;
            this.pbRightArrow.BackgroundImage = global::MSpaceInvaders.Properties.Resources.computer_key_Arrow_Right_T;
            this.pbRightArrow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbRightArrow.Location = new System.Drawing.Point(542, 86);
            this.pbRightArrow.Name = "pbRightArrow";
            this.pbRightArrow.Size = new System.Drawing.Size(70, 50);
            this.pbRightArrow.TabIndex = 3;
            this.pbRightArrow.TabStop = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(12, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(413, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "Користи ги стрелките за да го движиш бродот лево и десно.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(12, 183);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(413, 43);
            this.label2.TabIndex = 5;
            this.label2.Text = "Со спејс копчето пукаш кон непријателите.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::MSpaceInvaders.Properties.Resources.computer_key_Space_bar_T;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(431, 176);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(182, 50);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(486, 255);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(70, 50);
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(12, 262);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(413, 43);
            this.label3.TabIndex = 7;
            this.label3.Text = "Со ескејп копчето можеш да се вратиш назад од играта до почетниот екран.";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ControlsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MSpaceInvaders.Properties.Resources.level2_bg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(624, 561);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbRightArrow);
            this.Controls.Add(this.pbLeftArrow);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ControlsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modern Space Invaders - Controls";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ControlsForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ControlsForm_FormClosed);
            this.Load += new System.EventHandler(this.ControlsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbLeftArrow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRightArrow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pbLeftArrow;
        private System.Windows.Forms.PictureBox pbRightArrow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label3;
    }
}