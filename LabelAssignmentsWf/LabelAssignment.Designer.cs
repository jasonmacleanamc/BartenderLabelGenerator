namespace LabelAssignmentsWf
{
    partial class LabelAssignment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LabelAssignment));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.goBtn = new System.Windows.Forms.Button();
            this.versionTB = new System.Windows.Forms.NumericUpDown();
            this.partNumberTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.allLabelsListView = new System.Windows.Forms.ListView();
            this.finalListView = new System.Windows.Forms.ListView();
            this.smtListView = new System.Windows.Forms.ListView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.inProcessListView = new System.Windows.Forms.ListView();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.basePlateListView = new System.Windows.Forms.ListView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.versionTB)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.goBtn);
            this.groupBox1.Controls.Add(this.versionTB);
            this.groupBox1.Controls.Add(this.partNumberTB);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(473, 56);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Part Information";
            // 
            // goBtn
            // 
            this.goBtn.Location = new System.Drawing.Point(385, 20);
            this.goBtn.Name = "goBtn";
            this.goBtn.Size = new System.Drawing.Size(75, 23);
            this.goBtn.TabIndex = 4;
            this.goBtn.Text = "Go";
            this.goBtn.UseVisualStyleBackColor = true;
            this.goBtn.Click += new System.EventHandler(this.goBtn_Click);
            // 
            // versionTB
            // 
            this.versionTB.DecimalPlaces = 2;
            this.versionTB.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.versionTB.Location = new System.Drawing.Point(310, 21);
            this.versionTB.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            131072});
            this.versionTB.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.versionTB.Name = "versionTB";
            this.versionTB.Size = new System.Drawing.Size(52, 20);
            this.versionTB.TabIndex = 3;
            this.versionTB.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // partNumberTB
            // 
            this.partNumberTB.Location = new System.Drawing.Point(88, 21);
            this.partNumberTB.Name = "partNumberTB";
            this.partNumberTB.Size = new System.Drawing.Size(138, 20);
            this.partNumberTB.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(258, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Version:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Part Number:";
            // 
            // allLabelsListView
            // 
            this.allLabelsListView.Location = new System.Drawing.Point(6, 18);
            this.allLabelsListView.MultiSelect = false;
            this.allLabelsListView.Name = "allLabelsListView";
            this.allLabelsListView.Size = new System.Drawing.Size(434, 418);
            this.allLabelsListView.TabIndex = 2;
            this.allLabelsListView.UseCompatibleStateImageBehavior = false;
            this.allLabelsListView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDown);
            this.allLabelsListView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseMove);
            // 
            // finalListView
            // 
            this.finalListView.AllowDrop = true;
            this.finalListView.Location = new System.Drawing.Point(10, 19);
            this.finalListView.MultiSelect = false;
            this.finalListView.Name = "finalListView";
            this.finalListView.Size = new System.Drawing.Size(580, 200);
            this.finalListView.TabIndex = 3;
            this.finalListView.UseCompatibleStateImageBehavior = false;
            this.finalListView.DragDrop += new System.Windows.Forms.DragEventHandler(this.listView2_DragDrop);
            this.finalListView.DragEnter += new System.Windows.Forms.DragEventHandler(this.listView2_DragEnter);
            // 
            // smtListView
            // 
            this.smtListView.AllowDrop = true;
            this.smtListView.Location = new System.Drawing.Point(8, 19);
            this.smtListView.MultiSelect = false;
            this.smtListView.Name = "smtListView";
            this.smtListView.Size = new System.Drawing.Size(125, 97);
            this.smtListView.TabIndex = 4;
            this.smtListView.UseCompatibleStateImageBehavior = false;
            this.smtListView.DragDrop += new System.Windows.Forms.DragEventHandler(this.smtListView_DragDrop);
            this.smtListView.DragEnter += new System.Windows.Forms.DragEventHandler(this.smtListView_DragEnter);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.smtListView);
            this.groupBox3.Location = new System.Drawing.Point(13, 27);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(143, 122);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "SMT";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.inProcessListView);
            this.groupBox4.Location = new System.Drawing.Point(176, 27);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(143, 122);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "In Process";
            // 
            // inProcessListView
            // 
            this.inProcessListView.AllowDrop = true;
            this.inProcessListView.Location = new System.Drawing.Point(8, 19);
            this.inProcessListView.MultiSelect = false;
            this.inProcessListView.Name = "inProcessListView";
            this.inProcessListView.Size = new System.Drawing.Size(125, 97);
            this.inProcessListView.TabIndex = 4;
            this.inProcessListView.UseCompatibleStateImageBehavior = false;
            this.inProcessListView.DragDrop += new System.Windows.Forms.DragEventHandler(this.InProcessListView_DragDrop);
            this.inProcessListView.DragEnter += new System.Windows.Forms.DragEventHandler(this.InProcessListView_DragEnter);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.finalListView);
            this.groupBox5.Location = new System.Drawing.Point(13, 155);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(601, 236);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Final";
            // 
            // basePlateListView
            // 
            this.basePlateListView.AllowDrop = true;
            this.basePlateListView.Location = new System.Drawing.Point(8, 19);
            this.basePlateListView.MultiSelect = false;
            this.basePlateListView.Name = "basePlateListView";
            this.basePlateListView.Size = new System.Drawing.Size(260, 97);
            this.basePlateListView.TabIndex = 4;
            this.basePlateListView.UseCompatibleStateImageBehavior = false;
            this.basePlateListView.DragDrop += new System.Windows.Forms.DragEventHandler(this.basePlateListView_DragDrop);
            this.basePlateListView.DragEnter += new System.Windows.Forms.DragEventHandler(this.basePlateListView_DragEnter);
            this.basePlateListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.basePlateListView_MouseDoubleClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.basePlateListView);
            this.groupBox2.Location = new System.Drawing.Point(335, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(281, 122);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "BasePlate";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.groupBox3);
            this.groupBox6.Controls.Add(this.groupBox2);
            this.groupBox6.Controls.Add(this.groupBox4);
            this.groupBox6.Controls.Add(this.groupBox5);
            this.groupBox6.Location = new System.Drawing.Point(12, 74);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(636, 406);
            this.groupBox6.TabIndex = 8;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Assignments";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.allLabelsListView);
            this.groupBox7.Location = new System.Drawing.Point(654, 12);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(459, 467);
            this.groupBox7.TabIndex = 9;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Availible Labels";
            // 
            // LabelAssignment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1123, 491);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LabelAssignment";
            this.Text = "Label Assignments";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.versionTB)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox partNumberTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown versionTB;
        private System.Windows.Forms.ListView allLabelsListView;
        private System.Windows.Forms.ListView finalListView;
        private System.Windows.Forms.ListView smtListView;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListView inProcessListView;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ListView basePlateListView;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button goBtn;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox7;
    }
}

