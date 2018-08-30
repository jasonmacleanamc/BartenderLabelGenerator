namespace TestBartenderFileGenerator
{
    partial class TestLabelGen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestLabelGen));
            this.GoBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.workcodeTB = new System.Windows.Forms.TextBox();
            this.printBtn = new System.Windows.Forms.Button();
            this.workCodeGB = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.clearBtn = new System.Windows.Forms.Button();
            this.singleFinalRB = new System.Windows.Forms.RadioButton();
            this.baseplateRB = new System.Windows.Forms.RadioButton();
            this.inProcessRB = new System.Windows.Forms.RadioButton();
            this.smtRB = new System.Windows.Forms.RadioButton();
            this.finalRB = new System.Windows.Forms.RadioButton();
            this.forcePrintNowCB = new System.Windows.Forms.CheckBox();
            this.checkAllChk = new System.Windows.Forms.CheckBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.labelInfoGB = new System.Windows.Forms.GroupBox();
            this.MainBtn = new System.Windows.Forms.Button();
            this.ScanTB = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.filterChk = new System.Windows.Forms.CheckBox();
            this.numItemsLbl = new System.Windows.Forms.Label();
            this.finalCB = new System.Windows.Forms.ComboBox();
            this.genericRB = new System.Windows.Forms.RadioButton();
            this.labelTypeGB = new System.Windows.Forms.GroupBox();
            this.workCodeCB = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.finalPrintBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.genericQtyUD = new System.Windows.Forms.NumericUpDown();
            this.stationGB = new System.Windows.Forms.GroupBox();
            this.rePrintChk = new System.Windows.Forms.CheckBox();
            this.rmaCB = new System.Windows.Forms.CheckBox();
            this.reset_btn = new System.Windows.Forms.Button();
            this.rememberCB = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.specialFinalGB = new System.Windows.Forms.GroupBox();
            this.specialFinalStatic = new System.Windows.Forms.Label();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.workCodeGB.SuspendLayout();
            this.labelInfoGB.SuspendLayout();
            this.labelTypeGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.genericQtyUD)).BeginInit();
            this.stationGB.SuspendLayout();
            this.specialFinalGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // GoBtn
            // 
            this.GoBtn.Location = new System.Drawing.Point(313, 76);
            this.GoBtn.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.GoBtn.Name = "GoBtn";
            this.GoBtn.Size = new System.Drawing.Size(149, 44);
            this.GoBtn.TabIndex = 0;
            this.GoBtn.Text = "Get";
            this.GoBtn.UseVisualStyleBackColor = true;
            this.GoBtn.Click += new System.EventHandler(this.GoBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 85);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Workcode:";
            // 
            // workcodeTB
            // 
            this.workcodeTB.Location = new System.Drawing.Point(145, 81);
            this.workcodeTB.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.workcodeTB.MaxLength = 5;
            this.workcodeTB.Name = "workcodeTB";
            this.workcodeTB.Size = new System.Drawing.Size(135, 31);
            this.workcodeTB.TabIndex = 2;
            this.workcodeTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.workcodeTB_KeyPress);
            // 
            // printBtn
            // 
            this.printBtn.Location = new System.Drawing.Point(1003, 748);
            this.printBtn.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.printBtn.Name = "printBtn";
            this.printBtn.Size = new System.Drawing.Size(181, 42);
            this.printBtn.TabIndex = 5;
            this.printBtn.Text = "Print Job";
            this.printBtn.UseVisualStyleBackColor = true;
            this.printBtn.Click += new System.EventHandler(this.printBtn_Click);
            // 
            // workCodeGB
            // 
            this.workCodeGB.Controls.Add(this.label9);
            this.workCodeGB.Controls.Add(this.clearBtn);
            this.workCodeGB.Controls.Add(this.GoBtn);
            this.workCodeGB.Controls.Add(this.label1);
            this.workCodeGB.Controls.Add(this.workcodeTB);
            this.workCodeGB.Location = new System.Drawing.Point(16, 686);
            this.workCodeGB.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.workCodeGB.Name = "workCodeGB";
            this.workCodeGB.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.workCodeGB.Size = new System.Drawing.Size(661, 138);
            this.workCodeGB.TabIndex = 13;
            this.workCodeGB.TabStop = false;
            this.workCodeGB.Text = "Workcode Information";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(24, 38);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(440, 25);
            this.label9.TabIndex = 14;
            this.label9.Text = "Read the Job information from the Database.";
            // 
            // clearBtn
            // 
            this.clearBtn.Location = new System.Drawing.Point(473, 76);
            this.clearBtn.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(149, 44);
            this.clearBtn.TabIndex = 7;
            this.clearBtn.Text = "Clear";
            this.clearBtn.UseVisualStyleBackColor = true;
            this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // singleFinalRB
            // 
            this.singleFinalRB.AutoSize = true;
            this.singleFinalRB.Location = new System.Drawing.Point(24, 125);
            this.singleFinalRB.Margin = new System.Windows.Forms.Padding(4);
            this.singleFinalRB.Name = "singleFinalRB";
            this.singleFinalRB.Size = new System.Drawing.Size(215, 29);
            this.singleFinalRB.TabIndex = 11;
            this.singleFinalRB.Text = "S&ingle Final Label";
            this.singleFinalRB.UseVisualStyleBackColor = true;
            this.singleFinalRB.CheckedChanged += new System.EventHandler(this.overrideCB_CheckedChanged);
            // 
            // baseplateRB
            // 
            this.baseplateRB.AutoSize = true;
            this.baseplateRB.Location = new System.Drawing.Point(271, 76);
            this.baseplateRB.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.baseplateRB.Name = "baseplateRB";
            this.baseplateRB.Size = new System.Drawing.Size(141, 29);
            this.baseplateRB.TabIndex = 2;
            this.baseplateRB.TabStop = true;
            this.baseplateRB.Text = "&BasePlate";
            this.baseplateRB.UseVisualStyleBackColor = true;
            this.baseplateRB.CheckedChanged += new System.EventHandler(this.baseplateRB_CheckedChanged);
            // 
            // inProcessRB
            // 
            this.inProcessRB.AutoSize = true;
            this.inProcessRB.Location = new System.Drawing.Point(119, 76);
            this.inProcessRB.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.inProcessRB.Name = "inProcessRB";
            this.inProcessRB.Size = new System.Drawing.Size(144, 29);
            this.inProcessRB.TabIndex = 1;
            this.inProcessRB.TabStop = true;
            this.inProcessRB.Text = "In &Process";
            this.inProcessRB.UseVisualStyleBackColor = true;
            this.inProcessRB.CheckedChanged += new System.EventHandler(this.inProcessRB_CheckedChanged);
            // 
            // smtRB
            // 
            this.smtRB.AutoSize = true;
            this.smtRB.Location = new System.Drawing.Point(24, 76);
            this.smtRB.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.smtRB.Name = "smtRB";
            this.smtRB.Size = new System.Drawing.Size(80, 29);
            this.smtRB.TabIndex = 0;
            this.smtRB.TabStop = true;
            this.smtRB.Text = "&Smt";
            this.smtRB.UseVisualStyleBackColor = true;
            this.smtRB.CheckedChanged += new System.EventHandler(this.smtRB_CheckedChanged);
            // 
            // finalRB
            // 
            this.finalRB.AutoSize = true;
            this.finalRB.Location = new System.Drawing.Point(416, 76);
            this.finalRB.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.finalRB.Name = "finalRB";
            this.finalRB.Size = new System.Drawing.Size(90, 29);
            this.finalRB.TabIndex = 3;
            this.finalRB.TabStop = true;
            this.finalRB.Text = "&Final";
            this.finalRB.UseVisualStyleBackColor = true;
            this.finalRB.CheckedChanged += new System.EventHandler(this.finalRB_CheckedChanged);
            // 
            // forcePrintNowCB
            // 
            this.forcePrintNowCB.AutoSize = true;
            this.forcePrintNowCB.Location = new System.Drawing.Point(147, 1044);
            this.forcePrintNowCB.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.forcePrintNowCB.Name = "forcePrintNowCB";
            this.forcePrintNowCB.Size = new System.Drawing.Size(197, 29);
            this.forcePrintNowCB.TabIndex = 7;
            this.forcePrintNowCB.Text = "Force Print Now";
            this.forcePrintNowCB.UseVisualStyleBackColor = true;
            // 
            // checkAllChk
            // 
            this.checkAllChk.AutoSize = true;
            this.checkAllChk.Location = new System.Drawing.Point(29, 751);
            this.checkAllChk.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.checkAllChk.Name = "checkAllChk";
            this.checkAllChk.Size = new System.Drawing.Size(134, 29);
            this.checkAllChk.TabIndex = 15;
            this.checkAllChk.Text = "Select All";
            this.checkAllChk.UseVisualStyleBackColor = true;
            this.checkAllChk.CheckedChanged += new System.EventHandler(this.checkAllChk_CheckedChanged);
            // 
            // listView1
            // 
            this.listView1.CheckBoxes = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView1.Location = new System.Drawing.Point(29, 85);
            this.listView1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1152, 590);
            this.listView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView1.TabIndex = 17;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            this.listView1.ItemActivate += new System.EventHandler(this.listView1_ItemActivate);
            this.listView1.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listView1_ItemChecked);
            this.listView1.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listView1_ItemSelectionChanged);
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.Enter += new System.EventHandler(this.listView1_Enter);
            this.listView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listView1_KeyDown);
            this.listView1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listView1_KeyUp);
            // 
            // labelInfoGB
            // 
            this.labelInfoGB.Controls.Add(this.MainBtn);
            this.labelInfoGB.Controls.Add(this.ScanTB);
            this.labelInfoGB.Controls.Add(this.label5);
            this.labelInfoGB.Controls.Add(this.textBox2);
            this.labelInfoGB.Controls.Add(this.printBtn);
            this.labelInfoGB.Controls.Add(this.label4);
            this.labelInfoGB.Controls.Add(this.label3);
            this.labelInfoGB.Controls.Add(this.textBox1);
            this.labelInfoGB.Controls.Add(this.filterChk);
            this.labelInfoGB.Controls.Add(this.numItemsLbl);
            this.labelInfoGB.Controls.Add(this.listView1);
            this.labelInfoGB.Controls.Add(this.checkAllChk);
            this.labelInfoGB.Location = new System.Drawing.Point(705, 15);
            this.labelInfoGB.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.labelInfoGB.Name = "labelInfoGB";
            this.labelInfoGB.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.labelInfoGB.Size = new System.Drawing.Size(1213, 809);
            this.labelInfoGB.TabIndex = 18;
            this.labelInfoGB.TabStop = false;
            this.labelInfoGB.Text = "Label Info";
            // 
            // MainBtn
            // 
            this.MainBtn.Location = new System.Drawing.Point(812, 748);
            this.MainBtn.Margin = new System.Windows.Forms.Padding(4);
            this.MainBtn.Name = "MainBtn";
            this.MainBtn.Size = new System.Drawing.Size(181, 42);
            this.MainBtn.TabIndex = 25;
            this.MainBtn.Text = "Modify Print Job";
            this.MainBtn.UseVisualStyleBackColor = true;
            this.MainBtn.Visible = false;
            this.MainBtn.Click += new System.EventHandler(this.MainBtn_Click);
            // 
            // ScanTB
            // 
            this.ScanTB.Location = new System.Drawing.Point(105, 698);
            this.ScanTB.Margin = new System.Windows.Forms.Padding(4);
            this.ScanTB.Name = "ScanTB";
            this.ScanTB.Size = new System.Drawing.Size(1076, 31);
            this.ScanTB.TabIndex = 26;
            this.ScanTB.TextChanged += new System.EventHandler(this.ScanTB_TextChanged);
            this.ScanTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ScanTB_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 698);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 25);
            this.label5.TabIndex = 25;
            this.label5.Text = "Scan:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(421, 40);
            this.textBox2.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(116, 31);
            this.textBox2.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(364, 44);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 25);
            this.label4.TabIndex = 22;
            this.label4.Text = "To:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(157, 44);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 25);
            this.label3.TabIndex = 21;
            this.label3.Text = "From:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(232, 40);
            this.textBox1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(116, 31);
            this.textBox1.TabIndex = 20;
            // 
            // filterChk
            // 
            this.filterChk.AutoSize = true;
            this.filterChk.Location = new System.Drawing.Point(29, 41);
            this.filterChk.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.filterChk.Name = "filterChk";
            this.filterChk.Size = new System.Drawing.Size(92, 29);
            this.filterChk.TabIndex = 19;
            this.filterChk.Text = "Filter";
            this.filterChk.UseVisualStyleBackColor = true;
            this.filterChk.CheckedChanged += new System.EventHandler(this.filterChk_CheckedChanged);
            // 
            // numItemsLbl
            // 
            this.numItemsLbl.AutoSize = true;
            this.numItemsLbl.Location = new System.Drawing.Point(997, 44);
            this.numItemsLbl.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.numItemsLbl.Name = "numItemsLbl";
            this.numItemsLbl.Size = new System.Drawing.Size(171, 25);
            this.numItemsLbl.TabIndex = 18;
            this.numItemsLbl.Text = "0 Items Selected";
            // 
            // finalCB
            // 
            this.finalCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.finalCB.FormattingEnabled = true;
            this.finalCB.Location = new System.Drawing.Point(97, 78);
            this.finalCB.Margin = new System.Windows.Forms.Padding(4);
            this.finalCB.Name = "finalCB";
            this.finalCB.Size = new System.Drawing.Size(524, 33);
            this.finalCB.TabIndex = 7;
            this.finalCB.SelectedIndexChanged += new System.EventHandler(this.finalCB_SelectedIndexChanged);
            // 
            // genericRB
            // 
            this.genericRB.AutoSize = true;
            this.genericRB.Location = new System.Drawing.Point(24, 166);
            this.genericRB.Margin = new System.Windows.Forms.Padding(4);
            this.genericRB.Name = "genericRB";
            this.genericRB.Size = new System.Drawing.Size(230, 29);
            this.genericRB.TabIndex = 6;
            this.genericRB.Text = "&Generic Final Label";
            this.genericRB.UseVisualStyleBackColor = true;
            this.genericRB.CheckedChanged += new System.EventHandler(this.finalCheckBox_CheckedChanged);
            // 
            // labelTypeGB
            // 
            this.labelTypeGB.Controls.Add(this.workCodeCB);
            this.labelTypeGB.Controls.Add(this.label8);
            this.labelTypeGB.Controls.Add(this.genericRB);
            this.labelTypeGB.Controls.Add(this.singleFinalRB);
            this.labelTypeGB.Location = new System.Drawing.Point(16, 224);
            this.labelTypeGB.Margin = new System.Windows.Forms.Padding(4);
            this.labelTypeGB.Name = "labelTypeGB";
            this.labelTypeGB.Padding = new System.Windows.Forms.Padding(4);
            this.labelTypeGB.Size = new System.Drawing.Size(661, 212);
            this.labelTypeGB.TabIndex = 22;
            this.labelTypeGB.TabStop = false;
            this.labelTypeGB.Text = "Label Type";
            // 
            // workCodeCB
            // 
            this.workCodeCB.AutoSize = true;
            this.workCodeCB.Location = new System.Drawing.Point(24, 84);
            this.workCodeCB.Margin = new System.Windows.Forms.Padding(4);
            this.workCodeCB.Name = "workCodeCB";
            this.workCodeCB.Size = new System.Drawing.Size(286, 29);
            this.workCodeCB.TabIndex = 13;
            this.workCodeCB.Text = "&Regular Job Print/RePrint";
            this.workCodeCB.UseVisualStyleBackColor = true;
            this.workCodeCB.CheckedChanged += new System.EventHandler(this.workCodeCB_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 36);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(306, 25);
            this.label8.TabIndex = 12;
            this.label8.Text = "Pick the Type of Label to Print.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 82);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 25);
            this.label6.TabIndex = 11;
            this.label6.Text = "Type:";
            // 
            // finalPrintBtn
            // 
            this.finalPrintBtn.Location = new System.Drawing.Point(473, 131);
            this.finalPrintBtn.Margin = new System.Windows.Forms.Padding(4);
            this.finalPrintBtn.Name = "finalPrintBtn";
            this.finalPrintBtn.Size = new System.Drawing.Size(149, 44);
            this.finalPrintBtn.TabIndex = 10;
            this.finalPrintBtn.Text = "Print";
            this.finalPrintBtn.UseVisualStyleBackColor = true;
            this.finalPrintBtn.Click += new System.EventHandler(this.finalPrintBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 141);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 25);
            this.label2.TabIndex = 9;
            this.label2.Text = "Qty:";
            // 
            // genericQtyUD
            // 
            this.genericQtyUD.Location = new System.Drawing.Point(97, 138);
            this.genericQtyUD.Margin = new System.Windows.Forms.Padding(4);
            this.genericQtyUD.Name = "genericQtyUD";
            this.genericQtyUD.Size = new System.Drawing.Size(85, 31);
            this.genericQtyUD.TabIndex = 8;
            this.genericQtyUD.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // stationGB
            // 
            this.stationGB.Controls.Add(this.rePrintChk);
            this.stationGB.Controls.Add(this.rmaCB);
            this.stationGB.Controls.Add(this.reset_btn);
            this.stationGB.Controls.Add(this.rememberCB);
            this.stationGB.Controls.Add(this.label7);
            this.stationGB.Controls.Add(this.baseplateRB);
            this.stationGB.Controls.Add(this.smtRB);
            this.stationGB.Controls.Add(this.inProcessRB);
            this.stationGB.Controls.Add(this.finalRB);
            this.stationGB.Location = new System.Drawing.Point(16, 15);
            this.stationGB.Margin = new System.Windows.Forms.Padding(4);
            this.stationGB.Name = "stationGB";
            this.stationGB.Padding = new System.Windows.Forms.Padding(4);
            this.stationGB.Size = new System.Drawing.Size(661, 182);
            this.stationGB.TabIndex = 23;
            this.stationGB.TabStop = false;
            this.stationGB.Text = "Station";
            // 
            // rePrintChk
            // 
            this.rePrintChk.AutoSize = true;
            this.rePrintChk.Location = new System.Drawing.Point(24, 125);
            this.rePrintChk.Name = "rePrintChk";
            this.rePrintChk.Size = new System.Drawing.Size(122, 29);
            this.rePrintChk.TabIndex = 26;
            this.rePrintChk.Text = "Re-Print";
            this.rePrintChk.UseVisualStyleBackColor = true;
            // 
            // rmaCB
            // 
            this.rmaCB.AutoSize = true;
            this.rmaCB.Location = new System.Drawing.Point(271, 125);
            this.rmaCB.Margin = new System.Windows.Forms.Padding(4);
            this.rmaCB.Name = "rmaCB";
            this.rmaCB.Size = new System.Drawing.Size(113, 29);
            this.rmaCB.TabIndex = 25;
            this.rmaCB.Text = "Is RMA";
            this.rmaCB.UseVisualStyleBackColor = true;
            // 
            // reset_btn
            // 
            this.reset_btn.Location = new System.Drawing.Point(473, 125);
            this.reset_btn.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.reset_btn.Name = "reset_btn";
            this.reset_btn.Size = new System.Drawing.Size(149, 44);
            this.reset_btn.TabIndex = 24;
            this.reset_btn.Text = "Reset";
            this.reset_btn.UseVisualStyleBackColor = true;
            this.reset_btn.Click += new System.EventHandler(this.reset_btn_Click);
            // 
            // rememberCB
            // 
            this.rememberCB.AutoSize = true;
            this.rememberCB.Enabled = false;
            this.rememberCB.Location = new System.Drawing.Point(400, 44);
            this.rememberCB.Margin = new System.Windows.Forms.Padding(4);
            this.rememberCB.Name = "rememberCB";
            this.rememberCB.Size = new System.Drawing.Size(221, 29);
            this.rememberCB.TabIndex = 5;
            this.rememberCB.Text = "Remember Choice";
            this.rememberCB.UseVisualStyleBackColor = true;
            this.rememberCB.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 32);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(400, 25);
            this.label7.TabIndex = 4;
            this.label7.Text = "Pick the Area you want the label to Print.";
            // 
            // specialFinalGB
            // 
            this.specialFinalGB.Controls.Add(this.specialFinalStatic);
            this.specialFinalGB.Controls.Add(this.label6);
            this.specialFinalGB.Controls.Add(this.genericQtyUD);
            this.specialFinalGB.Controls.Add(this.finalCB);
            this.specialFinalGB.Controls.Add(this.finalPrintBtn);
            this.specialFinalGB.Controls.Add(this.label2);
            this.specialFinalGB.Location = new System.Drawing.Point(16, 469);
            this.specialFinalGB.Margin = new System.Windows.Forms.Padding(4);
            this.specialFinalGB.Name = "specialFinalGB";
            this.specialFinalGB.Padding = new System.Windows.Forms.Padding(4);
            this.specialFinalGB.Size = new System.Drawing.Size(661, 201);
            this.specialFinalGB.TabIndex = 24;
            this.specialFinalGB.TabStop = false;
            this.specialFinalGB.Text = "Special Final Lables";
            // 
            // specialFinalStatic
            // 
            this.specialFinalStatic.AutoSize = true;
            this.specialFinalStatic.Location = new System.Drawing.Point(24, 35);
            this.specialFinalStatic.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.specialFinalStatic.Name = "specialFinalStatic";
            this.specialFinalStatic.Size = new System.Drawing.Size(36, 25);
            this.specialFinalStatic.TabIndex = 14;
            this.specialFinalStatic.Text = "....";
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Location = new System.Drawing.Point(35, 840);
            this.StatusLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(36, 25);
            this.StatusLabel.TabIndex = 25;
            this.StatusLabel.Text = "....";
            // 
            // TestLabelGen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1940, 884);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.specialFinalGB);
            this.Controls.Add(this.stationGB);
            this.Controls.Add(this.labelTypeGB);
            this.Controls.Add(this.forcePrintNowCB);
            this.Controls.Add(this.workCodeGB);
            this.Controls.Add(this.labelInfoGB);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.MaximizeBox = false;
            this.Name = "TestLabelGen";
            this.Text = "Label Printer Generator V.35";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.workCodeGB.ResumeLayout(false);
            this.workCodeGB.PerformLayout();
            this.labelInfoGB.ResumeLayout(false);
            this.labelInfoGB.PerformLayout();
            this.labelTypeGB.ResumeLayout(false);
            this.labelTypeGB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.genericQtyUD)).EndInit();
            this.stationGB.ResumeLayout(false);
            this.stationGB.PerformLayout();
            this.specialFinalGB.ResumeLayout(false);
            this.specialFinalGB.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button GoBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox workcodeTB;
        private System.Windows.Forms.Button printBtn;
        private System.Windows.Forms.GroupBox workCodeGB;
        private System.Windows.Forms.CheckBox checkAllChk;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.GroupBox labelInfoGB;
        private System.Windows.Forms.Label numItemsLbl;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox filterChk;
        private System.Windows.Forms.RadioButton finalRB;
        private System.Windows.Forms.RadioButton baseplateRB;
        private System.Windows.Forms.RadioButton inProcessRB;
        private System.Windows.Forms.RadioButton smtRB;
        private System.Windows.Forms.CheckBox forcePrintNowCB;
        private System.Windows.Forms.ComboBox finalCB;
        private System.Windows.Forms.RadioButton genericRB;
        private System.Windows.Forms.GroupBox labelTypeGB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown genericQtyUD;
        private System.Windows.Forms.Button clearBtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button finalPrintBtn;
        private System.Windows.Forms.RadioButton singleFinalRB;
        private System.Windows.Forms.GroupBox stationGB;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton workCodeCB;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox specialFinalGB;
        private System.Windows.Forms.CheckBox rememberCB;
        private System.Windows.Forms.Label specialFinalStatic;
        private System.Windows.Forms.Button reset_btn;
        private System.Windows.Forms.Button MainBtn;
		private System.Windows.Forms.TextBox ScanTB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.CheckBox rmaCB;
        private System.Windows.Forms.CheckBox rePrintChk;
    }
}

