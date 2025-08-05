namespace S5_1_
{
    partial class ConflictResolution4
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDateRange = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtNewStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtNewEndDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lstBxProducts = new System.Windows.Forms.ListBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblResolved = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Step 4: Date/Product Adjustment";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Date Adjustment";
            // 
            // lblDateRange
            // 
            this.lblDateRange.AutoSize = true;
            this.lblDateRange.Location = new System.Drawing.Point(15, 66);
            this.lblDateRange.Name = "lblDateRange";
            this.lblDateRange.Size = new System.Drawing.Size(108, 13);
            this.lblDateRange.TabIndex = 5;
            this.lblDateRange.Text = "Current Date Range: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "New Start Date:";
            // 
            // dtNewStartDate
            // 
            this.dtNewStartDate.CustomFormat = " ";
            this.dtNewStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtNewStartDate.Location = new System.Drawing.Point(104, 90);
            this.dtNewStartDate.Name = "dtNewStartDate";
            this.dtNewStartDate.Size = new System.Drawing.Size(163, 20);
            this.dtNewStartDate.TabIndex = 7;
            this.dtNewStartDate.ValueChanged += new System.EventHandler(this.dtNewStartDate_ValueChanged);
            // 
            // dtNewEndDate
            // 
            this.dtNewEndDate.CustomFormat = " ";
            this.dtNewEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtNewEndDate.Location = new System.Drawing.Point(376, 90);
            this.dtNewEndDate.Name = "dtNewEndDate";
            this.dtNewEndDate.Size = new System.Drawing.Size(163, 20);
            this.dtNewEndDate.TabIndex = 9;
            this.dtNewEndDate.ValueChanged += new System.EventHandler(this.dtNewEndDate_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(287, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "New End Date:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Product Removal";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 157);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(224, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Select products to remove from the promotion:";
            // 
            // lstBxProducts
            // 
            this.lstBxProducts.FormattingEnabled = true;
            this.lstBxProducts.Location = new System.Drawing.Point(18, 174);
            this.lstBxProducts.Name = "lstBxProducts";
            this.lstBxProducts.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstBxProducts.Size = new System.Drawing.Size(314, 186);
            this.lstBxProducts.TabIndex = 12;
            this.lstBxProducts.SelectedIndexChanged += new System.EventHandler(this.lstBxProducts_SelectedIndexChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(417, 405);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(112, 33);
            this.btnCancel.TabIndex = 29;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(544, 405);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(112, 33);
            this.btnBack.TabIndex = 28;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(671, 405);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(112, 33);
            this.btnSave.TabIndex = 27;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblResolved
            // 
            this.lblResolved.AutoSize = true;
            this.lblResolved.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResolved.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblResolved.Location = new System.Drawing.Point(15, 372);
            this.lblResolved.Name = "lblResolved";
            this.lblResolved.Size = new System.Drawing.Size(331, 13);
            this.lblResolved.TabIndex = 30;
            this.lblResolved.Text = "Conflict resolved! You can proceed to save the changes.";
            this.lblResolved.Visible = false;
            // 
            // ConflictResolution4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblResolved);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lstBxProducts);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtNewEndDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtNewStartDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblDateRange);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ConflictResolution4";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Promotion Conflict Resolution Wizard";
            this.Load += new System.EventHandler(this.ConflictResolution4_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblDateRange;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtNewStartDate;
        private System.Windows.Forms.DateTimePicker dtNewEndDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox lstBxProducts;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblResolved;
    }
}