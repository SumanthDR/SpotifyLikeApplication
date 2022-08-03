namespace StunningDisco
{
    partial class FrmAddSong
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
            this.btn_reset = new System.Windows.Forms.Button();
            this.btn_submit = new System.Windows.Forms.Button();
            this.txtbx_songName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chkLstArtist = new System.Windows.Forms.CheckedListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_addArtist = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_upload = new System.Windows.Forms.Button();
            this.dateTimePicker_DOR = new System.Windows.Forms.DateTimePicker();
            this.btn_reload = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_reset
            // 
            this.btn_reset.Location = new System.Drawing.Point(317, 468);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(75, 23);
            this.btn_reset.TabIndex = 27;
            this.btn_reset.Text = "Reset";
            this.btn_reset.UseVisualStyleBackColor = true;
            // 
            // btn_submit
            // 
            this.btn_submit.Location = new System.Drawing.Point(413, 468);
            this.btn_submit.Name = "btn_submit";
            this.btn_submit.Size = new System.Drawing.Size(75, 23);
            this.btn_submit.TabIndex = 26;
            this.btn_submit.Text = "Submit";
            this.btn_submit.UseVisualStyleBackColor = true;
            this.btn_submit.Click += new System.EventHandler(this.btn_submit_Click);
            // 
            // txtbx_songName
            // 
            this.txtbx_songName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbx_songName.Location = new System.Drawing.Point(215, 145);
            this.txtbx_songName.Name = "txtbx_songName";
            this.txtbx_songName.Size = new System.Drawing.Size(273, 24);
            this.txtbx_songName.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(95, 198);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 18);
            this.label3.TabIndex = 19;
            this.label3.Text = "Date of Release";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(112, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 18);
            this.label4.TabIndex = 18;
            this.label4.Text = "Song Name *";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(42, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 24);
            this.label1.TabIndex = 17;
            this.label1.Text = "Add Song";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Rage Italic", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(207, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(224, 44);
            this.label2.TabIndex = 16;
            this.label2.Text = "Stunning Disco";
            // 
            // chkLstArtist
            // 
            this.chkLstArtist.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkLstArtist.FormattingEnabled = true;
            this.chkLstArtist.Location = new System.Drawing.Point(215, 253);
            this.chkLstArtist.Name = "chkLstArtist";
            this.chkLstArtist.Size = new System.Drawing.Size(273, 118);
            this.chkLstArtist.TabIndex = 28;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(124, 253);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 18);
            this.label5.TabIndex = 29;
            this.label5.Text = "Artist Name";
            // 
            // btn_addArtist
            // 
            this.btn_addArtist.Location = new System.Drawing.Point(494, 348);
            this.btn_addArtist.Name = "btn_addArtist";
            this.btn_addArtist.Size = new System.Drawing.Size(75, 23);
            this.btn_addArtist.TabIndex = 30;
            this.btn_addArtist.Text = "Add";
            this.btn_addArtist.UseVisualStyleBackColor = true;
            this.btn_addArtist.Click += new System.EventHandler(this.btn_addArtist_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(117, 392);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 18);
            this.label6.TabIndex = 31;
            this.label6.Text = "Cover Photo";
            // 
            // btn_upload
            // 
            this.btn_upload.Location = new System.Drawing.Point(215, 392);
            this.btn_upload.Name = "btn_upload";
            this.btn_upload.Size = new System.Drawing.Size(75, 23);
            this.btn_upload.TabIndex = 33;
            this.btn_upload.Text = "Upload";
            this.btn_upload.UseVisualStyleBackColor = true;
            this.btn_upload.Click += new System.EventHandler(this.btn_upload_Click);
            // 
            // dateTimePicker_DOR
            // 
            this.dateTimePicker_DOR.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_DOR.Location = new System.Drawing.Point(215, 198);
            this.dateTimePicker_DOR.Name = "dateTimePicker_DOR";
            this.dateTimePicker_DOR.Size = new System.Drawing.Size(273, 24);
            this.dateTimePicker_DOR.TabIndex = 34;
            // 
            // btn_reload
            // 
            this.btn_reload.Location = new System.Drawing.Point(494, 319);
            this.btn_reload.Name = "btn_reload";
            this.btn_reload.Size = new System.Drawing.Size(75, 23);
            this.btn_reload.TabIndex = 35;
            this.btn_reload.Text = "Reload";
            this.btn_reload.UseVisualStyleBackColor = true;
            this.btn_reload.Click += new System.EventHandler(this.btn_reload_Click);
            // 
            // FrmAddSong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 514);
            this.Controls.Add(this.btn_reload);
            this.Controls.Add(this.dateTimePicker_DOR);
            this.Controls.Add(this.btn_upload);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btn_addArtist);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.chkLstArtist);
            this.Controls.Add(this.btn_reset);
            this.Controls.Add(this.btn_submit);
            this.Controls.Add(this.txtbx_songName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAddSong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmAddSong_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_reset;
        private System.Windows.Forms.Button btn_submit;
        private System.Windows.Forms.TextBox txtbx_songName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox chkLstArtist;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_addArtist;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_upload;
        private System.Windows.Forms.DateTimePicker dateTimePicker_DOR;
        private System.Windows.Forms.Button btn_reload;
    }
}