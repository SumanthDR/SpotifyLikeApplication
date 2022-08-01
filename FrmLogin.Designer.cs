namespace StunningDisco
{
    partial class FrmLogin
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtbx_userId = new System.Windows.Forms.TextBox();
            this.txtbx_password = new System.Windows.Forms.TextBox();
            this.btn_login = new System.Windows.Forms.Button();
            this.linklbl_registerUser = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Rage Italic", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(107, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(224, 44);
            this.label2.TabIndex = 1;
            this.label2.Text = "Stunning Disco";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(64, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "User ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(54, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "Password";
            // 
            // txtbx_userId
            // 
            this.txtbx_userId.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbx_userId.Location = new System.Drawing.Point(128, 127);
            this.txtbx_userId.Name = "txtbx_userId";
            this.txtbx_userId.Size = new System.Drawing.Size(203, 24);
            this.txtbx_userId.TabIndex = 4;
            // 
            // txtbx_password
            // 
            this.txtbx_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbx_password.Location = new System.Drawing.Point(128, 172);
            this.txtbx_password.Name = "txtbx_password";
            this.txtbx_password.PasswordChar = '.';
            this.txtbx_password.Size = new System.Drawing.Size(203, 24);
            this.txtbx_password.TabIndex = 5;
            // 
            // btn_login
            // 
            this.btn_login.Location = new System.Drawing.Point(256, 224);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(75, 23);
            this.btn_login.TabIndex = 6;
            this.btn_login.Text = "Login";
            this.btn_login.UseVisualStyleBackColor = true;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // linklbl_registerUser
            // 
            this.linklbl_registerUser.AutoSize = true;
            this.linklbl_registerUser.Location = new System.Drawing.Point(54, 229);
            this.linklbl_registerUser.Name = "linklbl_registerUser";
            this.linklbl_registerUser.Size = new System.Drawing.Size(96, 13);
            this.linklbl_registerUser.TabIndex = 7;
            this.linklbl_registerUser.TabStop = true;
            this.linklbl_registerUser.Text = "Register New User";
            this.linklbl_registerUser.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklbl_registerUser_LinkClicked);
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 321);
            this.Controls.Add(this.linklbl_registerUser);
            this.Controls.Add(this.btn_login);
            this.Controls.Add(this.txtbx_password);
            this.Controls.Add(this.txtbx_userId);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtbx_userId;
        private System.Windows.Forms.TextBox txtbx_password;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.LinkLabel linklbl_registerUser;
    }
}

