﻿namespace Hotel
{
    partial class Otshot
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
            this.button2 = new System.Windows.Forms.Button();
            this.backButton3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(103, 168);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(203, 90);
            this.button1.TabIndex = 0;
            this.button1.Text = "Отчёт БД";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(447, 168);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(203, 90);
            this.button2.TabIndex = 1;
            this.button2.Text = "Построение графиков по БД";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // backButton3
            // 
            this.backButton3.Location = new System.Drawing.Point(12, 12);
            this.backButton3.Name = "backButton3";
            this.backButton3.Size = new System.Drawing.Size(75, 23);
            this.backButton3.TabIndex = 52;
            this.backButton3.Text = "Назад";
            this.backButton3.UseVisualStyleBackColor = true;
            // 
            // Otshot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.backButton3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Otshot";
            this.Text = "Otshot";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button backButton3;
    }
}