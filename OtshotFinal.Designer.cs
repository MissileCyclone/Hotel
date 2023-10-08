namespace Hotel
{
    partial class OtshotFinal
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
            this.buttonswitch = new System.Windows.Forms.Button();
            this.buttonprint = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.backButton3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonswitch
            // 
            this.buttonswitch.Location = new System.Drawing.Point(657, 347);
            this.buttonswitch.Name = "buttonswitch";
            this.buttonswitch.Size = new System.Drawing.Size(121, 35);
            this.buttonswitch.TabIndex = 1;
            this.buttonswitch.Text = "Switch Table";
            this.buttonswitch.UseVisualStyleBackColor = true;
            // 
            // buttonprint
            // 
            this.buttonprint.Location = new System.Drawing.Point(657, 388);
            this.buttonprint.Name = "buttonprint";
            this.buttonprint.Size = new System.Drawing.Size(121, 35);
            this.buttonprint.TabIndex = 2;
            this.buttonprint.Text = "Print";
            this.buttonprint.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 13);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(638, 425);
            this.dataGridView1.TabIndex = 3;
            // 
            // backButton3
            // 
            this.backButton3.Location = new System.Drawing.Point(713, 12);
            this.backButton3.Name = "backButton3";
            this.backButton3.Size = new System.Drawing.Size(75, 23);
            this.backButton3.TabIndex = 52;
            this.backButton3.Text = "Назад";
            this.backButton3.UseVisualStyleBackColor = true;
            // 
            // OtshotFinal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.backButton3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonprint);
            this.Controls.Add(this.buttonswitch);
            this.Name = "OtshotFinal";
            this.Text = "OtshotFinal";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonswitch;
        private System.Windows.Forms.Button buttonprint;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button backButton3;
    }
}