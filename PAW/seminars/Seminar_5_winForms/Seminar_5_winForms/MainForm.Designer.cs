namespace Seminar_5_winForms
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
            this.tbOp1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbOp2 = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.tbSum = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbOp1
            // 
            this.tbOp1.Location = new System.Drawing.Point(28, 192);
            this.tbOp1.Name = "tbOp1";
            this.tbOp1.Size = new System.Drawing.Size(100, 22);
            this.tbOp1.TabIndex = 0;
            this.tbOp1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbOp1_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(186, 192);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "+";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // tbOp2
            // 
            this.tbOp2.Location = new System.Drawing.Point(269, 192);
            this.tbOp2.Name = "tbOp2";
            this.tbOp2.Size = new System.Drawing.Size(100, 22);
            this.tbOp2.TabIndex = 2;
            this.tbOp2.TextChanged += new System.EventHandler(this.op2_TextChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(157, 270);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "=";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // tbSum
            // 
            this.tbSum.Location = new System.Drawing.Point(144, 346);
            this.tbSum.Name = "tbSum";
            this.tbSum.ReadOnly = true;
            this.tbSum.Size = new System.Drawing.Size(100, 22);
            this.tbSum.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 460);
            this.Controls.Add(this.tbSum);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.tbOp2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbOp1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simple Calculator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbOp1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbOp2;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox tbSum;
    }
}

