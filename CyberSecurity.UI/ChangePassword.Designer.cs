namespace CyberSecurity.UI
{
    partial class ChangePassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangePassword));
            this.oldPassTxt = new System.Windows.Forms.TextBox();
            this.newPassTxt = new System.Windows.Forms.TextBox();
            this.newPassDupeTxt = new System.Windows.Forms.TextBox();
            this.txtPasswordStrength = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.passwordMatchtxt = new System.Windows.Forms.Label();
            this.passGenCheck = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // oldPassTxt
            // 
            this.oldPassTxt.Location = new System.Drawing.Point(119, 40);
            this.oldPassTxt.Name = "oldPassTxt";
            this.oldPassTxt.Size = new System.Drawing.Size(100, 20);
            this.oldPassTxt.TabIndex = 0;
            this.oldPassTxt.UseSystemPasswordChar = true;
            // 
            // newPassTxt
            // 
            this.newPassTxt.Location = new System.Drawing.Point(119, 78);
            this.newPassTxt.Name = "newPassTxt";
            this.newPassTxt.Size = new System.Drawing.Size(100, 20);
            this.newPassTxt.TabIndex = 1;
            this.newPassTxt.UseSystemPasswordChar = true;
            this.newPassTxt.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // newPassDupeTxt
            // 
            this.newPassDupeTxt.Location = new System.Drawing.Point(119, 111);
            this.newPassDupeTxt.Name = "newPassDupeTxt";
            this.newPassDupeTxt.Size = new System.Drawing.Size(100, 20);
            this.newPassDupeTxt.TabIndex = 2;
            this.newPassDupeTxt.UseSystemPasswordChar = true;
            this.newPassDupeTxt.TextChanged += new System.EventHandler(this.newPassDupeTxt_TextChanged);
            // 
            // txtPasswordStrength
            // 
            this.txtPasswordStrength.AutoSize = true;
            this.txtPasswordStrength.BackColor = System.Drawing.Color.Transparent;
            this.txtPasswordStrength.Location = new System.Drawing.Point(256, 43);
            this.txtPasswordStrength.Name = "txtPasswordStrength";
            this.txtPasswordStrength.Size = new System.Drawing.Size(99, 13);
            this.txtPasswordStrength.TabIndex = 3;
            this.txtPasswordStrength.Text = "Password Strength:";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(26, 163);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(137, 163);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(12, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "New Password:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(13, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Old Password:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(13, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Re-enter Password:";
            // 
            // passwordMatchtxt
            // 
            this.passwordMatchtxt.AutoSize = true;
            this.passwordMatchtxt.Location = new System.Drawing.Point(256, 78);
            this.passwordMatchtxt.Name = "passwordMatchtxt";
            this.passwordMatchtxt.Size = new System.Drawing.Size(0, 13);
            this.passwordMatchtxt.TabIndex = 9;
            // 
            // passGenCheck
            // 
            this.passGenCheck.AutoSize = true;
            this.passGenCheck.BackColor = System.Drawing.Color.Transparent;
            this.passGenCheck.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.passGenCheck.Location = new System.Drawing.Point(259, 13);
            this.passGenCheck.Name = "passGenCheck";
            this.passGenCheck.Size = new System.Drawing.Size(125, 18);
            this.passGenCheck.TabIndex = 10;
            this.passGenCheck.Text = "Generate Password";
            this.passGenCheck.UseVisualStyleBackColor = false;
            this.passGenCheck.CheckedChanged += new System.EventHandler(this.passGenCheck_CheckedChanged);
            // 
            // ChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(440, 198);
            this.Controls.Add(this.passGenCheck);
            this.Controls.Add(this.passwordMatchtxt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtPasswordStrength);
            this.Controls.Add(this.newPassDupeTxt);
            this.Controls.Add(this.newPassTxt);
            this.Controls.Add(this.oldPassTxt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ChangePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChangePassword";
            this.Load += new System.EventHandler(this.ChangePassword_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox oldPassTxt;
        private System.Windows.Forms.TextBox newPassTxt;
        private System.Windows.Forms.TextBox newPassDupeTxt;
        private System.Windows.Forms.Label txtPasswordStrength;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label passwordMatchtxt;
        private System.Windows.Forms.CheckBox passGenCheck;
    }
}