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
            this.button1 = new System.Windows.Forms.Button();
            this.pbLeftArrow = new System.Windows.Forms.PictureBox();
            this.pbRightArrow = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbLeftArrow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRightArrow)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::MSpaceInvaders.Properties.Resources.Space;
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(451, 314);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 41);
            this.button1.TabIndex = 1;
            this.button1.Text = "Nazad";
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
            this.label1.AutoSize = true;
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
            // ControlsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MSpaceInvaders.Properties.Resources.level2_bg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(624, 561);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbRightArrow);
            this.Controls.Add(this.pbLeftArrow);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ControlsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ControlsForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ControlsForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ControlsForm_FormClosed);
            this.Load += new System.EventHandler(this.ControlsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbLeftArrow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRightArrow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pbLeftArrow;
        private System.Windows.Forms.PictureBox pbRightArrow;
        private System.Windows.Forms.Label label1;
    }
}