namespace Project_SupplyBusiness
{
    partial class GoodForm
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbCategoty = new System.Windows.Forms.ComboBox();
            this.tbGoodName = new System.Windows.Forms.TextBox();
            this.tbPrice = new System.Windows.Forms.TextBox();
            this.checkBoxTaxable = new System.Windows.Forms.CheckBox();
            this.rtbDescription = new System.Windows.Forms.RichTextBox();
            this.BtnAddGood = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Product Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Price";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(320, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Category";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "description";
            // 
            // cbCategoty
            // 
            this.cbCategoty.FormattingEnabled = true;
            this.cbCategoty.Items.AddRange(new object[] {
            "Food",
            "Electronics",
            "Furniture",
            "Pharmaceutical",
            "Clothing",
            "Tools",
            "CigarettesOrAlcohool"});
            this.cbCategoty.Location = new System.Drawing.Point(323, 55);
            this.cbCategoty.Name = "cbCategoty";
            this.cbCategoty.Size = new System.Drawing.Size(219, 24);
            this.cbCategoty.TabIndex = 5;
            // 
            // tbGoodName
            // 
            this.tbGoodName.Location = new System.Drawing.Point(31, 55);
            this.tbGoodName.Name = "tbGoodName";
            this.tbGoodName.Size = new System.Drawing.Size(219, 22);
            this.tbGoodName.TabIndex = 6;
            this.tbGoodName.Validating += new System.ComponentModel.CancelEventHandler(this.tbGoodName_Validating);
            this.tbGoodName.Validated += new System.EventHandler(this.tbGoodName_Validated);
            // 
            // tbPrice
            // 
            this.tbPrice.Location = new System.Drawing.Point(31, 124);
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.Size = new System.Drawing.Size(219, 22);
            this.tbPrice.TabIndex = 7;
            // 
            // checkBoxTaxable
            // 
            this.checkBoxTaxable.AutoSize = true;
            this.checkBoxTaxable.Location = new System.Drawing.Point(323, 124);
            this.checkBoxTaxable.Name = "checkBoxTaxable";
            this.checkBoxTaxable.Size = new System.Drawing.Size(80, 21);
            this.checkBoxTaxable.TabIndex = 8;
            this.checkBoxTaxable.Text = "Taxable";
            this.checkBoxTaxable.UseVisualStyleBackColor = true;
            // 
            // rtbDescription
            // 
            this.rtbDescription.Location = new System.Drawing.Point(31, 195);
            this.rtbDescription.Name = "rtbDescription";
            this.rtbDescription.Size = new System.Drawing.Size(511, 96);
            this.rtbDescription.TabIndex = 9;
            this.rtbDescription.Text = "";
            this.rtbDescription.Validating += new System.ComponentModel.CancelEventHandler(this.rtbDescription_Validating);
            this.rtbDescription.Validated += new System.EventHandler(this.rtbDescription_Validated);
            // 
            // BtnAddGood
            // 
            this.BtnAddGood.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnAddGood.Location = new System.Drawing.Point(323, 312);
            this.BtnAddGood.Name = "BtnAddGood";
            this.BtnAddGood.Size = new System.Drawing.Size(127, 33);
            this.BtnAddGood.TabIndex = 10;
            this.BtnAddGood.Text = "AddGood";
            this.BtnAddGood.UseVisualStyleBackColor = true;
            this.BtnAddGood.Click += new System.EventHandler(this.BtnAddGood_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(123, 312);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(127, 33);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // GoodForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 357);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.BtnAddGood);
            this.Controls.Add(this.rtbDescription);
            this.Controls.Add(this.checkBoxTaxable);
            this.Controls.Add(this.tbPrice);
            this.Controls.Add(this.tbGoodName);
            this.Controls.Add(this.cbCategoty);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "GoodForm";
            this.Text = "Good";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbCategoty;
        private System.Windows.Forms.TextBox tbGoodName;
        private System.Windows.Forms.TextBox tbPrice;
        private System.Windows.Forms.CheckBox checkBoxTaxable;
        private System.Windows.Forms.RichTextBox rtbDescription;
        private System.Windows.Forms.Button BtnAddGood;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}