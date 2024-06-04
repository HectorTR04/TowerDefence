using System.Windows.Forms;

namespace TowerDefence
{
    partial class PauseMenu
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
            Resume = new Button();
            Quit = new Button();
            SuspendLayout();
            // 
            // Resume
            // 
            Resume.BackColor = System.Drawing.SystemColors.Control;
            Resume.BackgroundImage = Properties.Resources.resumebutton;
            Resume.FlatAppearance.BorderSize = 0;
            Resume.FlatStyle = FlatStyle.Flat;
            Resume.Location = new System.Drawing.Point(183, 189);
            Resume.Margin = new Padding(0);
            Resume.Name = "Resume";
            Resume.Size = new System.Drawing.Size(112, 64);
            Resume.TabIndex = 0;
            Resume.UseVisualStyleBackColor = false;
            Resume.Click += Resume_Click;
            // 
            // Quit
            // 
            Quit.BackgroundImage = Properties.Resources.pausequit;
            Quit.FlatAppearance.BorderSize = 0;
            Quit.FlatStyle = FlatStyle.Flat;
            Quit.Location = new System.Drawing.Point(183, 301);
            Quit.Name = "Quit";
            Quit.Size = new System.Drawing.Size(112, 64);
            Quit.TabIndex = 2;
            Quit.UseVisualStyleBackColor = true;
            Quit.Click += Quit_Click;
            // 
            // PauseMenu
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.pausebackground;
            ClientSize = new System.Drawing.Size(474, 498);
            Controls.Add(Quit);
            Controls.Add(Resume);
            Name = "PauseMenu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Paused";
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button Resume;
        private System.Windows.Forms.Button Quit;
    }
}