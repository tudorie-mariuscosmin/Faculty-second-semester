namespace DevConfrence
{
    partial class StatisticsForm
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
            this.barChart1 = new DevConfrence.barChart();
            this.SuspendLayout();
            // 
            // barChart1
            // 
            this.barChart1.Data = new int[] {
        1};
            this.barChart1.Location = new System.Drawing.Point(12, 24);
            this.barChart1.Name = "barChart1";
            this.barChart1.Size = new System.Drawing.Size(776, 400);
            this.barChart1.TabIndex = 0;
            this.barChart1.Text = "barChart1";
            // 
            // StatisticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.barChart1);
            this.Name = "StatisticsForm";
            this.Text = "StatisticsForm";
            this.Load += new System.EventHandler(this.StatisticsForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private barChart barChart1;
    }
}