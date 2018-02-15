namespace LabelCodePopulator
{
    partial class LabelCodeForm
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
            this.GoBtn = new System.Windows.Forms.Button();
            this.currentCB = new System.Windows.Forms.CheckBox();
            this.historyCB = new System.Windows.Forms.CheckBox();
            this.betaCB = new System.Windows.Forms.CheckBox();
            this.ProtoCB = new System.Windows.Forms.CheckBox();
            this.partNumberTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.singlePartCB = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tableNameLabel = new System.Windows.Forms.Label();
            this.versionLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelsCodeLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.partNumberLabel = new System.Windows.Forms.Label();
            this.countLabel = new System.Windows.Forms.Label();
            this.versionUD = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.versionUD)).BeginInit();
            this.SuspendLayout();
            // 
            // GoBtn
            // 
            this.GoBtn.Location = new System.Drawing.Point(214, 19);
            this.GoBtn.Name = "GoBtn";
            this.GoBtn.Size = new System.Drawing.Size(75, 23);
            this.GoBtn.TabIndex = 0;
            this.GoBtn.Text = "Go";
            this.GoBtn.UseVisualStyleBackColor = true;
            this.GoBtn.Click += new System.EventHandler(this.GoBtn_Click);
            // 
            // currentCB
            // 
            this.currentCB.AutoSize = true;
            this.currentCB.Location = new System.Drawing.Point(14, 19);
            this.currentCB.Name = "currentCB";
            this.currentCB.Size = new System.Drawing.Size(60, 17);
            this.currentCB.TabIndex = 1;
            this.currentCB.Text = "Current";
            this.currentCB.UseVisualStyleBackColor = true;
            // 
            // historyCB
            // 
            this.historyCB.AutoSize = true;
            this.historyCB.Location = new System.Drawing.Point(82, 19);
            this.historyCB.Name = "historyCB";
            this.historyCB.Size = new System.Drawing.Size(58, 17);
            this.historyCB.TabIndex = 2;
            this.historyCB.Text = "History";
            this.historyCB.UseVisualStyleBackColor = true;
            // 
            // betaCB
            // 
            this.betaCB.AutoSize = true;
            this.betaCB.Location = new System.Drawing.Point(82, 42);
            this.betaCB.Name = "betaCB";
            this.betaCB.Size = new System.Drawing.Size(48, 17);
            this.betaCB.TabIndex = 3;
            this.betaCB.Text = "Beta";
            this.betaCB.UseVisualStyleBackColor = true;
            // 
            // ProtoCB
            // 
            this.ProtoCB.AutoSize = true;
            this.ProtoCB.Location = new System.Drawing.Point(14, 42);
            this.ProtoCB.Name = "ProtoCB";
            this.ProtoCB.Size = new System.Drawing.Size(51, 17);
            this.ProtoCB.TabIndex = 4;
            this.ProtoCB.Text = "Proto";
            this.ProtoCB.UseVisualStyleBackColor = true;
            // 
            // partNumberTB
            // 
            this.partNumberTB.Location = new System.Drawing.Point(81, 48);
            this.partNumberTB.Name = "partNumberTB";
            this.partNumberTB.Size = new System.Drawing.Size(100, 20);
            this.partNumberTB.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Part Number:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(197, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Version:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.versionUD);
            this.groupBox1.Controls.Add(this.singlePartCB);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.partNumberTB);
            this.groupBox1.Location = new System.Drawing.Point(12, 96);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(308, 84);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Single Part Information";
            // 
            // singlePartCB
            // 
            this.singlePartCB.AutoSize = true;
            this.singlePartCB.Location = new System.Drawing.Point(9, 20);
            this.singlePartCB.Name = "singlePartCB";
            this.singlePartCB.Size = new System.Drawing.Size(77, 17);
            this.singlePartCB.TabIndex = 10;
            this.singlePartCB.Text = "Single Part";
            this.singlePartCB.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.GoBtn);
            this.groupBox2.Controls.Add(this.currentCB);
            this.groupBox2.Controls.Add(this.ProtoCB);
            this.groupBox2.Controls.Add(this.historyCB);
            this.groupBox2.Controls.Add(this.betaCB);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(308, 78);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Populate From";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.countLabel);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.tableNameLabel);
            this.groupBox3.Controls.Add(this.versionLabel);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.labelsCodeLabel);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.partNumberLabel);
            this.groupBox3.Location = new System.Drawing.Point(326, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(243, 168);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Processing Info";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Table:";
            // 
            // tableNameLabel
            // 
            this.tableNameLabel.AutoSize = true;
            this.tableNameLabel.Location = new System.Drawing.Point(81, 26);
            this.tableNameLabel.Name = "tableNameLabel";
            this.tableNameLabel.Size = new System.Drawing.Size(63, 13);
            this.tableNameLabel.TabIndex = 14;
            this.tableNameLabel.Text = "########";
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.Location = new System.Drawing.Point(81, 118);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(63, 13);
            this.versionLabel.TabIndex = 13;
            this.versionLabel.Text = "########";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Version:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Labels Code:";
            // 
            // labelsCodeLabel
            // 
            this.labelsCodeLabel.AutoSize = true;
            this.labelsCodeLabel.Location = new System.Drawing.Point(81, 139);
            this.labelsCodeLabel.Name = "labelsCodeLabel";
            this.labelsCodeLabel.Size = new System.Drawing.Size(63, 13);
            this.labelsCodeLabel.TabIndex = 10;
            this.labelsCodeLabel.Text = "########";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Part Number:";
            // 
            // partNumberLabel
            // 
            this.partNumberLabel.AutoSize = true;
            this.partNumberLabel.Location = new System.Drawing.Point(81, 97);
            this.partNumberLabel.Name = "partNumberLabel";
            this.partNumberLabel.Size = new System.Drawing.Size(63, 13);
            this.partNumberLabel.TabIndex = 0;
            this.partNumberLabel.Text = "########";
            // 
            // countLabel
            // 
            this.countLabel.AutoSize = true;
            this.countLabel.Location = new System.Drawing.Point(157, 26);
            this.countLabel.Name = "countLabel";
            this.countLabel.Size = new System.Drawing.Size(24, 13);
            this.countLabel.TabIndex = 16;
            this.countLabel.Text = "0/0";
            // 
            // versionUD
            // 
            this.versionUD.DecimalPlaces = 2;
            this.versionUD.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.versionUD.Location = new System.Drawing.Point(248, 48);
            this.versionUD.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            131072});
            this.versionUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.versionUD.Name = "versionUD";
            this.versionUD.Size = new System.Drawing.Size(41, 20);
            this.versionUD.TabIndex = 11;
            this.versionUD.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // LabelCodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 192);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "LabelCodeForm";
            this.Text = "Label Code";
            this.Load += new System.EventHandler(this.LabelCodeForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.versionUD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button GoBtn;
        private System.Windows.Forms.CheckBox currentCB;
        private System.Windows.Forms.CheckBox historyCB;
        private System.Windows.Forms.CheckBox betaCB;
        private System.Windows.Forms.CheckBox ProtoCB;
        private System.Windows.Forms.TextBox partNumberTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label partNumberLabel;
        private System.Windows.Forms.CheckBox singlePartCB;
        private System.Windows.Forms.Label labelsCodeLabel;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label tableNameLabel;
        private System.Windows.Forms.Label countLabel;
        private System.Windows.Forms.NumericUpDown versionUD;
    }
}

