namespace TestBartenderFileGenerator
{
    partial class SmtForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.workCodeTB = new System.Windows.Forms.TextBox();
            this.smtCountUD = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.smtCountUD)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(346, 54);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 41);
            this.button1.TabIndex = 1;
            this.button1.Text = "Print";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Label Quantity:";
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(473, 54);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 41);
            this.button2.TabIndex = 3;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "WorkCode:";
            // 
            // workCodeTB
            // 
            this.workCodeTB.Location = new System.Drawing.Point(204, 33);
            this.workCodeTB.MaxLength = 5;
            this.workCodeTB.Name = "workCodeTB";
            this.workCodeTB.Size = new System.Drawing.Size(100, 31);
            this.workCodeTB.TabIndex = 4;
            // 
            // smtCountUD
            // 
            this.smtCountUD.Location = new System.Drawing.Point(204, 80);
            this.smtCountUD.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.smtCountUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.smtCountUD.Name = "smtCountUD";
            this.smtCountUD.Size = new System.Drawing.Size(120, 31);
            this.smtCountUD.TabIndex = 6;
            this.smtCountUD.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // SmtForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 169);
            this.Controls.Add(this.smtCountUD);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.workCodeTB);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "SmtForm";
            this.Text = "SmtForm";
            ((System.ComponentModel.ISupportInitialize)(this.smtCountUD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox workCodeTB;
        private System.Windows.Forms.NumericUpDown smtCountUD;
    }
}