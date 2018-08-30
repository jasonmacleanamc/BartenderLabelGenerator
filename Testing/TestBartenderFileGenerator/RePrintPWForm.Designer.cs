namespace TestBartenderFileGenerator
{
    partial class RePrintPWForm
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
            this.okBtn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.passwordMTB = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(369, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please Enter Password to Continue...";
            // 
            // okBtn
            // 
            this.okBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okBtn.Location = new System.Drawing.Point(426, 32);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(97, 37);
            this.okBtn.TabIndex = 1;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(426, 88);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(97, 37);
            this.button2.TabIndex = 2;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // passwordMTB
            // 
            this.passwordMTB.Location = new System.Drawing.Point(138, 72);
            this.passwordMTB.Name = "passwordMTB";
            this.passwordMTB.PasswordChar = '*';
            this.passwordMTB.Size = new System.Drawing.Size(206, 31);
            this.passwordMTB.TabIndex = 3;
            this.passwordMTB.UseSystemPasswordChar = true;
            this.passwordMTB.Enter += new System.EventHandler(this.passwordMTB_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Password:";
            // 
            // RePrintPWForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 181);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.passwordMTB);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.label1);
            this.Name = "RePrintPWForm";
            this.Text = "RePrintPWForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RePrintPWForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.MaskedTextBox passwordMTB;
        private System.Windows.Forms.Label label2;
    }
}