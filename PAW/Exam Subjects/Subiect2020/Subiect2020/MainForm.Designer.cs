namespace Subiect2020
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
            Subiect2020.Fleet fleet1 = new Subiect2020.Fleet();
            this.BtnAddVechicle = new System.Windows.Forms.Button();
            this.listView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnChart = new System.Windows.Forms.Button();
            this.barChart = new Subiect2020.barChart();
            this.SuspendLayout();
            // 
            // BtnAddVechicle
            // 
            this.BtnAddVechicle.Location = new System.Drawing.Point(12, 21);
            this.BtnAddVechicle.Name = "BtnAddVechicle";
            this.BtnAddVechicle.Size = new System.Drawing.Size(79, 27);
            this.BtnAddVechicle.TabIndex = 0;
            this.BtnAddVechicle.Text = "Add Vehicle";
            this.BtnAddVechicle.UseVisualStyleBackColor = true;
            this.BtnAddVechicle.Click += new System.EventHandler(this.BtnAddVechicle_Click);
            // 
            // listView
            // 
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(12, 63);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(604, 375);
            this.listView.TabIndex = 1;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Maker";
            this.columnHeader1.Width = 125;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Model";
            this.columnHeader2.Width = 131;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Capacity";
            this.columnHeader3.Width = 133;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Horse Power";
            this.columnHeader4.Width = 145;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(97, 21);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(79, 27);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnChart
            // 
            this.btnChart.Location = new System.Drawing.Point(507, 25);
            this.btnChart.Name = "btnChart";
            this.btnChart.Size = new System.Drawing.Size(75, 23);
            this.btnChart.TabIndex = 4;
            this.btnChart.Text = "See Chart";
            this.btnChart.UseVisualStyleBackColor = true;
            this.btnChart.Click += new System.EventHandler(this.btnChart_Click);
            // 
            // barChart
            // 
            this.barChart.Data = fleet1;
            this.barChart.Location = new System.Drawing.Point(622, 12);
            this.barChart.Name = "barChart";
            this.barChart.Size = new System.Drawing.Size(374, 426);
            this.barChart.TabIndex = 3;
            this.barChart.Text = "barChart1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 450);
            this.Controls.Add(this.btnChart);
            this.Controls.Add(this.barChart);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.BtnAddVechicle);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnAddVechicle;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button btnDelete;
        private barChart barChart;
        private System.Windows.Forms.Button btnChart;
    }
}

