namespace TestBartenderFileGenerator
{
    partial class RMAData
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
            this.versionLbl = new System.Windows.Forms.Label();
            this.versionUP = new System.Windows.Forms.NumericUpDown();
            this.dateCodeLbl = new System.Windows.Forms.Label();
            this.dateCodeTB = new System.Windows.Forms.TextBox();
            this.modifyBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.partNumberTB = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.versionUP)).BeginInit();
            this.SuspendLayout();
            // 
            // versionLbl
            // 
            this.versionLbl.AutoSize = true;
            this.versionLbl.Location = new System.Drawing.Point(63, 52);
            this.versionLbl.Name = "versionLbl";
            this.versionLbl.Size = new System.Drawing.Size(67, 20);
            this.versionLbl.TabIndex = 0;
            this.versionLbl.Text = "Version:";
            // 
            // versionUP
            // 
            this.versionUP.DecimalPlaces = 2;
            this.versionUP.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.versionUP.Location = new System.Drawing.Point(155, 52);
            this.versionUP.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            131072});
            this.versionUP.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.versionUP.Name = "versionUP";
            this.versionUP.Size = new System.Drawing.Size(120, 26);
            this.versionUP.TabIndex = 1;
            this.versionUP.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // dateCodeLbl
            // 
            this.dateCodeLbl.AutoSize = true;
            this.dateCodeLbl.Location = new System.Drawing.Point(63, 117);
            this.dateCodeLbl.Name = "dateCodeLbl";
            this.dateCodeLbl.Size = new System.Drawing.Size(90, 20);
            this.dateCodeLbl.TabIndex = 2;
            this.dateCodeLbl.Text = "Date Code:";
            // 
            // dateCodeTB
            // 
            this.dateCodeTB.Location = new System.Drawing.Point(181, 110);
            this.dateCodeTB.Name = "dateCodeTB";
            this.dateCodeTB.Size = new System.Drawing.Size(140, 26);
            this.dateCodeTB.TabIndex = 3;
            // 
            // modifyBtn
            // 
            this.modifyBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.modifyBtn.Location = new System.Drawing.Point(235, 181);
            this.modifyBtn.Name = "modifyBtn";
            this.modifyBtn.Size = new System.Drawing.Size(86, 42);
            this.modifyBtn.TabIndex = 4;
            this.modifyBtn.Text = "Modify";
            this.modifyBtn.UseVisualStyleBackColor = true;
            this.modifyBtn.Click += new System.EventHandler(this.modifyBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(347, 185);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(92, 35);
            this.cancelBtn.TabIndex = 5;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 287);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Part Number:";
            // 
            // partNumberTB
            // 
            this.partNumberTB.Location = new System.Drawing.Point(181, 284);
            this.partNumberTB.Name = "partNumberTB";
            this.partNumberTB.Size = new System.Drawing.Size(187, 26);
            this.partNumberTB.TabIndex = 7;
            // 
            // RMAData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1192, 604);
            this.Controls.Add(this.partNumberTB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.modifyBtn);
            this.Controls.Add(this.dateCodeTB);
            this.Controls.Add(this.dateCodeLbl);
            this.Controls.Add(this.versionUP);
            this.Controls.Add(this.versionLbl);
            this.Name = "RMAData";
            this.Text = "RMAData";
            ((System.ComponentModel.ISupportInitialize)(this.versionUP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label versionLbl;
        private System.Windows.Forms.NumericUpDown versionUP;
        private System.Windows.Forms.Label dateCodeLbl;
        private System.Windows.Forms.TextBox dateCodeTB;
        private System.Windows.Forms.Button modifyBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox partNumberTB;
    }
}