namespace lab_12_customControls
{
    partial class MainForm
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
            this.btnUpdateChart = new System.Windows.Forms.Button();
            this.barChartControl1 = new ControlLibrary.BarChartControl();
            this.textBoxComposite1 = new ControlLibrary.textBoxComposite();
            this.SuspendLayout();
            // 
            // btnUpdateChart
            // 
            this.btnUpdateChart.Location = new System.Drawing.Point(326, 379);
            this.btnUpdateChart.Name = "btnUpdateChart";
            this.btnUpdateChart.Size = new System.Drawing.Size(164, 39);
            this.btnUpdateChart.TabIndex = 1;
            this.btnUpdateChart.Text = "updateChart";
            this.btnUpdateChart.UseVisualStyleBackColor = true;
            this.btnUpdateChart.Click += new System.EventHandler(this.btnUpdateChart_Click);
            // 
            // barChartControl1
            // 
            this.barChartControl1.Location = new System.Drawing.Point(22, 12);
            this.barChartControl1.Name = "barChartControl1";
            this.barChartControl1.Size = new System.Drawing.Size(398, 286);
            this.barChartControl1.TabIndex = 0;
            this.barChartControl1.Text = "barChartControl1";
            // 
            // textBoxComposite1
            // 
            this.textBoxComposite1.Location = new System.Drawing.Point(426, 22);
            this.textBoxComposite1.Name = "textBoxComposite1";
            this.textBoxComposite1.Size = new System.Drawing.Size(364, 128);
            this.textBoxComposite1.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBoxComposite1);
            this.Controls.Add(this.btnUpdateChart);
            this.Controls.Add(this.barChartControl1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private ControlLibrary.BarChartControl barChartControl1;
        private System.Windows.Forms.Button btnUpdateChart;
        private ControlLibrary.textBoxComposite textBoxComposite1;
    }
}

