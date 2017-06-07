namespace CyberSecurity.UI
{
    partial class CreateUserFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateUserFrm));
            this.createUserBtn = new System.Windows.Forms.Button();
            this.usernameTxt = new System.Windows.Forms.TextBox();
            this.passwordTxt = new System.Windows.Forms.TextBox();
            this.passwordStrengthLbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.generatePassCheck = new System.Windows.Forms.CheckBox();
            this.specialCharsTxt = new System.Windows.Forms.Label();
            this.retypedPassTxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.passwordsMatchTxt = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // createUserBtn
            // 
            this.createUserBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.createUserBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.createUserBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createUserBtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.createUserBtn.Location = new System.Drawing.Point(12, 120);
            this.createUserBtn.Name = "createUserBtn";
            this.createUserBtn.Size = new System.Drawing.Size(103, 37);
            this.createUserBtn.TabIndex = 0;
            this.createUserBtn.Text = "Create User";
            this.createUserBtn.UseVisualStyleBackColor = false;
            this.createUserBtn.Click += new System.EventHandler(this.createUserBtn_Click);
            // 
            // usernameTxt
            // 
            this.usernameTxt.Location = new System.Drawing.Point(74, 42);
            this.usernameTxt.Name = "usernameTxt";
            this.usernameTxt.Size = new System.Drawing.Size(144, 20);
            this.usernameTxt.TabIndex = 1;
            this.usernameTxt.TextChanged += new System.EventHandler(this.usernameTxt_TextChanged);
            // 
            // passwordTxt
            // 
            this.passwordTxt.Location = new System.Drawing.Point(74, 68);
            this.passwordTxt.Name = "passwordTxt";
            this.passwordTxt.PasswordChar = '*';
            this.passwordTxt.Size = new System.Drawing.Size(144, 20);
            this.passwordTxt.TabIndex = 2;
            this.passwordTxt.UseSystemPasswordChar = true;
            this.passwordTxt.TextChanged += new System.EventHandler(this.passwordTxt_TextChanged);
            // 
            // passwordStrengthLbl
            // 
            this.passwordStrengthLbl.AutoSize = true;
            this.passwordStrengthLbl.BackColor = System.Drawing.Color.Transparent;
            this.passwordStrengthLbl.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.passwordStrengthLbl.Location = new System.Drawing.Point(255, 42);
            this.passwordStrengthLbl.Name = "passwordStrengthLbl";
            this.passwordStrengthLbl.Size = new System.Drawing.Size(99, 13);
            this.passwordStrengthLbl.TabIndex = 4;
            this.passwordStrengthLbl.Text = "Password Strength:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(13, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Username:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(15, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Password:";
            // 
            // cancelBtn
            // 
            this.cancelBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.cancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelBtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cancelBtn.Location = new System.Drawing.Point(123, 120);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(103, 36);
            this.cancelBtn.TabIndex = 8;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = false;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(119, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Register";
            // 
            // generatePassCheck
            // 
            this.generatePassCheck.AutoSize = true;
            this.generatePassCheck.BackColor = System.Drawing.Color.Transparent;
            this.generatePassCheck.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.generatePassCheck.Location = new System.Drawing.Point(258, 70);
            this.generatePassCheck.Name = "generatePassCheck";
            this.generatePassCheck.Size = new System.Drawing.Size(119, 17);
            this.generatePassCheck.TabIndex = 10;
            this.generatePassCheck.Text = "Generate Password";
            this.generatePassCheck.UseVisualStyleBackColor = false;
            this.generatePassCheck.CheckedChanged += new System.EventHandler(this.generatePassCheck_CheckedChanged);
            // 
            // specialCharsTxt
            // 
            this.specialCharsTxt.AutoSize = true;
            this.specialCharsTxt.Location = new System.Drawing.Point(258, 140);
            this.specialCharsTxt.Name = "specialCharsTxt";
            this.specialCharsTxt.Size = new System.Drawing.Size(0, 13);
            this.specialCharsTxt.TabIndex = 11;
            // 
            // retypedPassTxt
            // 
            this.retypedPassTxt.BackColor = System.Drawing.SystemColors.Window;
            this.retypedPassTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.retypedPassTxt.Location = new System.Drawing.Point(74, 94);
            this.retypedPassTxt.Name = "retypedPassTxt";
            this.retypedPassTxt.PasswordChar = '*';
            this.retypedPassTxt.Size = new System.Drawing.Size(144, 20);
            this.retypedPassTxt.TabIndex = 12;
            this.retypedPassTxt.UseSystemPasswordChar = true;
            this.retypedPassTxt.TextChanged += new System.EventHandler(this.retypedPassTxt_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(12, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Retype:";
            // 
            // passwordsMatchTxt
            // 
            this.passwordsMatchTxt.AutoSize = true;
            this.passwordsMatchTxt.BackColor = System.Drawing.Color.Transparent;
            this.passwordsMatchTxt.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.passwordsMatchTxt.Location = new System.Drawing.Point(276, 101);
            this.passwordsMatchTxt.Name = "passwordsMatchTxt";
            this.passwordsMatchTxt.Size = new System.Drawing.Size(0, 13);
            this.passwordsMatchTxt.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(258, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(229, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Password Example: APasswordExample1993!#";
            // 
            // CreateUserFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(550, 169);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.passwordsMatchTxt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.retypedPassTxt);
            this.Controls.Add(this.specialCharsTxt);
            this.Controls.Add(this.generatePassCheck);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.passwordStrengthLbl);
            this.Controls.Add(this.passwordTxt);
            this.Controls.Add(this.usernameTxt);
            this.Controls.Add(this.createUserBtn);
            this.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CreateUserFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CreateUser";
            this.Load += new System.EventHandler(this.CreateUser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button createUserBtn;
        private System.Windows.Forms.TextBox usernameTxt;
        private System.Windows.Forms.TextBox passwordTxt;
        private System.Windows.Forms.Label passwordStrengthLbl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox generatePassCheck;
        private System.Windows.Forms.Label specialCharsTxt;
        private System.Windows.Forms.TextBox retypedPassTxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label passwordsMatchTxt;
        private System.Windows.Forms.Label label5;
    }
}