namespace Hotel
{
    partial class ReportGraph
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartBookings = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartRevenue = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.backButton3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartBookings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRevenue)).BeginInit();
            this.SuspendLayout();
            // 
            // chartBookings
            // 
            chartArea1.Name = "ChartArea1";
            this.chartBookings.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartBookings.Legends.Add(legend1);
            this.chartBookings.Location = new System.Drawing.Point(45, 44);
            this.chartBookings.Name = "chartBookings";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartBookings.Series.Add(series1);
            this.chartBookings.Size = new System.Drawing.Size(300, 300);
            this.chartBookings.TabIndex = 0;
            this.chartBookings.Text = "chart1";
            // 
            // chartRevenue
            // 
            chartArea2.Name = "ChartArea1";
            this.chartRevenue.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartRevenue.Legends.Add(legend2);
            this.chartRevenue.Location = new System.Drawing.Point(398, 44);
            this.chartRevenue.Name = "chartRevenue";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartRevenue.Series.Add(series2);
            this.chartRevenue.Size = new System.Drawing.Size(300, 300);
            this.chartRevenue.TabIndex = 1;
            this.chartRevenue.Text = "chart2";
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
            // ReportGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.backButton3);
            this.Controls.Add(this.chartRevenue);
            this.Controls.Add(this.chartBookings);
            this.Name = "ReportGraph";
            this.Text = "ReportGraph";
            ((System.ComponentModel.ISupportInitialize)(this.chartBookings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRevenue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartBookings;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRevenue;
        private System.Windows.Forms.Button backButton3;
    }
}