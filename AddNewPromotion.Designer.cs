namespace S5_1_
{
    partial class AddNewPromotion
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
            this.inpPriority = new System.Windows.Forms.NumericUpDown();
            this.inpMinOrderValue = new System.Windows.Forms.NumericUpDown();
            this.inpDiscountValue = new System.Windows.Forms.NumericUpDown();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.dtEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtStartDate = new System.Windows.Forms.DateTimePicker();
            this.cbDiscountType = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.inpPromotionName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.inpPriority)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inpMinOrderValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inpDiscountValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // inpPriority
            // 
            this.inpPriority.Location = new System.Drawing.Point(144, 362);
            this.inpPriority.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.inpPriority.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.inpPriority.Name = "inpPriority";
            this.inpPriority.Size = new System.Drawing.Size(201, 20);
            this.inpPriority.TabIndex = 43;
            this.inpPriority.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // inpMinOrderValue
            // 
            this.inpMinOrderValue.DecimalPlaces = 2;
            this.inpMinOrderValue.Location = new System.Drawing.Point(144, 325);
            this.inpMinOrderValue.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.inpMinOrderValue.Name = "inpMinOrderValue";
            this.inpMinOrderValue.Size = new System.Drawing.Size(201, 20);
            this.inpMinOrderValue.TabIndex = 42;
            // 
            // inpDiscountValue
            // 
            this.inpDiscountValue.DecimalPlaces = 2;
            this.inpDiscountValue.Location = new System.Drawing.Point(144, 89);
            this.inpDiscountValue.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.inpDiscountValue.Name = "inpDiscountValue";
            this.inpDiscountValue.Size = new System.Drawing.Size(201, 20);
            this.inpDiscountValue.TabIndex = 41;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(144, 129);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBox1.Size = new System.Drawing.Size(201, 108);
            this.listBox1.TabIndex = 40;
            // 
            // dtEndDate
            // 
            this.dtEndDate.CustomFormat = " ";
            this.dtEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtEndDate.Location = new System.Drawing.Point(144, 292);
            this.dtEndDate.Name = "dtEndDate";
            this.dtEndDate.Size = new System.Drawing.Size(201, 20);
            this.dtEndDate.TabIndex = 39;
            this.dtEndDate.ValueChanged += new System.EventHandler(this.dtEndDate_ValueChanged);
            // 
            // dtStartDate
            // 
            this.dtStartDate.CustomFormat = " ";
            this.dtStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtStartDate.Location = new System.Drawing.Point(144, 256);
            this.dtStartDate.Name = "dtStartDate";
            this.dtStartDate.Size = new System.Drawing.Size(201, 20);
            this.dtStartDate.TabIndex = 38;
            this.dtStartDate.ValueChanged += new System.EventHandler(this.dtStartDate_ValueChanged);
            // 
            // cbDiscountType
            // 
            this.cbDiscountType.FormattingEnabled = true;
            this.cbDiscountType.Location = new System.Drawing.Point(144, 51);
            this.cbDiscountType.Name = "cbDiscountType";
            this.cbDiscountType.Size = new System.Drawing.Size(201, 21);
            this.cbDiscountType.TabIndex = 37;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(169, 400);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 38);
            this.btnSave.TabIndex = 36;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(260, 400);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 38);
            this.btnCancel.TabIndex = 35;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 364);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 34;
            this.label8.Text = "Priority:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 327);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 13);
            this.label7.TabIndex = 33;
            this.label7.Text = "Minimum Order Value:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 292);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 32;
            this.label6.Text = "End Date:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 256);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "Start Date:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Applicable Products:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Discount Value:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Discount Type:";
            // 
            // inpPromotionName
            // 
            this.inpPromotionName.Location = new System.Drawing.Point(144, 15);
            this.inpPromotionName.Name = "inpPromotionName";
            this.inpPromotionName.Size = new System.Drawing.Size(201, 20);
            this.inpPromotionName.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Promotion Name:";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // AddNewPromotion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 448);
            this.Controls.Add(this.inpPriority);
            this.Controls.Add(this.inpMinOrderValue);
            this.Controls.Add(this.inpDiscountValue);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.dtEndDate);
            this.Controls.Add(this.dtStartDate);
            this.Controls.Add(this.cbDiscountType);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.inpPromotionName);
            this.Controls.Add(this.label1);
            this.Name = "AddNewPromotion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add New Promotion";
            this.Load += new System.EventHandler(this.AddNewPromotion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.inpPriority)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inpMinOrderValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inpDiscountValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.NumericUpDown inpPriority;
        public System.Windows.Forms.NumericUpDown inpMinOrderValue;
        public System.Windows.Forms.NumericUpDown inpDiscountValue;
        public System.Windows.Forms.ListBox listBox1;
        public System.Windows.Forms.DateTimePicker dtEndDate;
        public System.Windows.Forms.DateTimePicker dtStartDate;
        public System.Windows.Forms.ComboBox cbDiscountType;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox inpPromotionName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}