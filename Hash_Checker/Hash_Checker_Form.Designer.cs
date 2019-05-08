namespace Hash_checker
{
    partial class HashCheckerForm
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
            this.select_file = new System.Windows.Forms.Button();
            this.file_name_lbl = new System.Windows.Forms.Label();
            this.calculate_md5 = new System.Windows.Forms.Button();
            this.hash_lbl = new System.Windows.Forms.Label();
            this.verify_hash_checkbox = new System.Windows.Forms.CheckBox();
            this.expected_hash = new System.Windows.Forms.TextBox();
            this.expected_lbl = new System.Windows.Forms.Label();
            this.verification_lbl = new System.Windows.Forms.Label();
            this.hash_textbox = new System.Windows.Forms.TextBox();
            this.hash_dropdown = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // select_file
            // 
            this.select_file.Location = new System.Drawing.Point(44, 83);
            this.select_file.Name = "select_file";
            this.select_file.Size = new System.Drawing.Size(124, 29);
            this.select_file.TabIndex = 0;
            this.select_file.Text = "Select File ...";
            this.select_file.UseVisualStyleBackColor = true;
            this.select_file.Click += new System.EventHandler(this.SelectFile_OnClick);
            // 
            // file_name_lbl
            // 
            this.file_name_lbl.AutoSize = true;
            this.file_name_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.file_name_lbl.Location = new System.Drawing.Point(189, 83);
            this.file_name_lbl.Name = "file_name_lbl";
            this.file_name_lbl.Size = new System.Drawing.Size(118, 24);
            this.file_name_lbl.TabIndex = 1;
            this.file_name_lbl.Text = "Not Selected";
            // 
            // calculate_md5
            // 
            this.calculate_md5.Location = new System.Drawing.Point(74, 291);
            this.calculate_md5.Name = "calculate_md5";
            this.calculate_md5.Size = new System.Drawing.Size(124, 29);
            this.calculate_md5.TabIndex = 2;
            this.calculate_md5.Text = "Calculate Hash";
            this.calculate_md5.UseVisualStyleBackColor = true;
            this.calculate_md5.Click += new System.EventHandler(this.CalculateHash_OnClick);
            // 
            // hash_lbl
            // 
            this.hash_lbl.AutoSize = true;
            this.hash_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hash_lbl.Location = new System.Drawing.Point(223, 291);
            this.hash_lbl.Name = "hash_lbl";
            this.hash_lbl.Size = new System.Drawing.Size(80, 24);
            this.hash_lbl.TabIndex = 3;
            this.hash_lbl.Text = "hash_lbl";
            this.hash_lbl.Visible = false;
            // 
            // verify_hash_checkbox
            // 
            this.verify_hash_checkbox.AutoSize = true;
            this.verify_hash_checkbox.Location = new System.Drawing.Point(74, 165);
            this.verify_hash_checkbox.Name = "verify_hash_checkbox";
            this.verify_hash_checkbox.Size = new System.Drawing.Size(80, 17);
            this.verify_hash_checkbox.TabIndex = 4;
            this.verify_hash_checkbox.Text = "Verify Hash";
            this.verify_hash_checkbox.UseVisualStyleBackColor = true;
            this.verify_hash_checkbox.CheckedChanged += new System.EventHandler(this.VerifyCheckbox_OnChanged);
            // 
            // expected_hash
            // 
            this.expected_hash.Location = new System.Drawing.Point(297, 204);
            this.expected_hash.Name = "expected_hash";
            this.expected_hash.Size = new System.Drawing.Size(234, 20);
            this.expected_hash.TabIndex = 5;
            this.expected_hash.Visible = false;
            this.expected_hash.TextChanged += new System.EventHandler(this.CalculateHash_OnClick);
            // 
            // expected_lbl
            // 
            this.expected_lbl.AutoSize = true;
            this.expected_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expected_lbl.Location = new System.Drawing.Point(70, 200);
            this.expected_lbl.Name = "expected_lbl";
            this.expected_lbl.Size = new System.Drawing.Size(221, 24);
            this.expected_lbl.TabIndex = 6;
            this.expected_lbl.Text = "Enter the expected hash:";
            this.expected_lbl.Visible = false;
            // 
            // verification_lbl
            // 
            this.verification_lbl.AutoSize = true;
            this.verification_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.verification_lbl.Location = new System.Drawing.Point(293, 240);
            this.verification_lbl.Name = "verification_lbl";
            this.verification_lbl.Size = new System.Drawing.Size(108, 24);
            this.verification_lbl.TabIndex = 7;
            this.verification_lbl.Text = "verify_result";
            this.verification_lbl.Visible = false;
            // 
            // hash_textbox
            // 
            this.hash_textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hash_textbox.Location = new System.Drawing.Point(227, 291);
            this.hash_textbox.Name = "hash_textbox";
            this.hash_textbox.ReadOnly = true;
            this.hash_textbox.Size = new System.Drawing.Size(454, 29);
            this.hash_textbox.TabIndex = 8;
            this.hash_textbox.Visible = false;
            // 
            // hash_dropdown
            // 
            this.hash_dropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.hash_dropdown.FormattingEnabled = true;
            this.hash_dropdown.Items.AddRange(new object[] {
            "MD5",
            "SHA1",
            "SHA256",
            "SHA512"});
            this.hash_dropdown.Location = new System.Drawing.Point(208, 35);
            this.hash_dropdown.Name = "hash_dropdown";
            this.hash_dropdown.Size = new System.Drawing.Size(193, 21);
            this.hash_dropdown.TabIndex = 9;
            this.hash_dropdown.SelectedIndexChanged += new System.EventHandler(this.HashDropdown_OnSelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 24);
            this.label1.TabIndex = 10;
            this.label1.Text = "Algorithm To Use:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.hash_dropdown);
            this.Controls.Add(this.hash_textbox);
            this.Controls.Add(this.verification_lbl);
            this.Controls.Add(this.expected_lbl);
            this.Controls.Add(this.expected_hash);
            this.Controls.Add(this.verify_hash_checkbox);
            this.Controls.Add(this.hash_lbl);
            this.Controls.Add(this.calculate_md5);
            this.Controls.Add(this.file_name_lbl);
            this.Controls.Add(this.select_file);
            this.Name = "Form1";
            this.Text = "Hash Checker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button select_file;
        private System.Windows.Forms.Label file_name_lbl;
        private System.Windows.Forms.Button calculate_md5;
        private System.Windows.Forms.Label hash_lbl;
        private System.Windows.Forms.CheckBox verify_hash_checkbox;
        private System.Windows.Forms.TextBox expected_hash;
        private System.Windows.Forms.Label expected_lbl;
        private System.Windows.Forms.Label verification_lbl;
        private System.Windows.Forms.TextBox hash_textbox;
        private System.Windows.Forms.ComboBox hash_dropdown;
        private System.Windows.Forms.Label label1;
    }
}

