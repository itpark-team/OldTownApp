namespace OldTownApp
{
    partial class FormMasterMain
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
            this.maskedTextBoxUserPhone = new System.Windows.Forms.MaskedTextBox();
            this.buttonUpdateUserPhone = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelUserName = new System.Windows.Forms.Label();
            this.checkedListBoxMasterServices = new System.Windows.Forms.CheckedListBox();
            this.buttonUpdateMasterServices = new System.Windows.Forms.Button();
            this.dataGridViewRecords = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonExitProfile = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRecords)).BeginInit();
            this.SuspendLayout();
            // 
            // maskedTextBoxUserPhone
            // 
            this.maskedTextBoxUserPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.maskedTextBoxUserPhone.Location = new System.Drawing.Point(12, 170);
            this.maskedTextBoxUserPhone.Mask = "+7(999) 000-00-00";
            this.maskedTextBoxUserPhone.Name = "maskedTextBoxUserPhone";
            this.maskedTextBoxUserPhone.Size = new System.Drawing.Size(213, 31);
            this.maskedTextBoxUserPhone.TabIndex = 13;
            // 
            // buttonUpdateUserPhone
            // 
            this.buttonUpdateUserPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonUpdateUserPhone.Location = new System.Drawing.Point(12, 207);
            this.buttonUpdateUserPhone.Name = "buttonUpdateUserPhone";
            this.buttonUpdateUserPhone.Size = new System.Drawing.Size(213, 59);
            this.buttonUpdateUserPhone.TabIndex = 12;
            this.buttonUpdateUserPhone.Text = "Обновить телефон";
            this.buttonUpdateUserPhone.UseVisualStyleBackColor = true;
            this.buttonUpdateUserPhone.Click += new System.EventHandler(this.buttonUpdateUserPhone_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(11, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 25);
            this.label2.TabIndex = 11;
            this.label2.Text = "Здравствуйте";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(11, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 25);
            this.label3.TabIndex = 10;
            this.label3.Text = "Ваш телефон";
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelUserName.Location = new System.Drawing.Point(11, 42);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(53, 25);
            this.labelUserName.TabIndex = 9;
            this.labelUserName.Text = "Имя";
            // 
            // checkedListBoxMasterServices
            // 
            this.checkedListBoxMasterServices.FormattingEnabled = true;
            this.checkedListBoxMasterServices.Location = new System.Drawing.Point(16, 294);
            this.checkedListBoxMasterServices.Name = "checkedListBoxMasterServices";
            this.checkedListBoxMasterServices.Size = new System.Drawing.Size(209, 184);
            this.checkedListBoxMasterServices.TabIndex = 14;
            // 
            // buttonUpdateMasterServices
            // 
            this.buttonUpdateMasterServices.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonUpdateMasterServices.Location = new System.Drawing.Point(16, 488);
            this.buttonUpdateMasterServices.Name = "buttonUpdateMasterServices";
            this.buttonUpdateMasterServices.Size = new System.Drawing.Size(209, 59);
            this.buttonUpdateMasterServices.TabIndex = 15;
            this.buttonUpdateMasterServices.Text = "Обновить услуги";
            this.buttonUpdateMasterServices.UseVisualStyleBackColor = true;
            this.buttonUpdateMasterServices.Click += new System.EventHandler(this.buttonUpdateMasterServices_Click);
            // 
            // dataGridViewRecords
            // 
            this.dataGridViewRecords.AllowUserToAddRows = false;
            this.dataGridViewRecords.AllowUserToDeleteRows = false;
            this.dataGridViewRecords.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRecords.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.dataGridViewRecords.Location = new System.Drawing.Point(231, 42);
            this.dataGridViewRecords.MultiSelect = false;
            this.dataGridViewRecords.Name = "dataGridViewRecords";
            this.dataGridViewRecords.ReadOnly = true;
            this.dataGridViewRecords.Size = new System.Drawing.Size(799, 505);
            this.dataGridViewRecords.TabIndex = 17;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Id";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Клиент";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Телефон Клиента";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Услуга";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Цена";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Дата-Время";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(508, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 25);
            this.label1.TabIndex = 16;
            this.label1.Text = "Список моих записей";
            // 
            // buttonExitProfile
            // 
            this.buttonExitProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonExitProfile.Location = new System.Drawing.Point(12, 70);
            this.buttonExitProfile.Name = "buttonExitProfile";
            this.buttonExitProfile.Size = new System.Drawing.Size(213, 57);
            this.buttonExitProfile.TabIndex = 23;
            this.buttonExitProfile.Text = "Выйти из профиля";
            this.buttonExitProfile.UseVisualStyleBackColor = true;
            this.buttonExitProfile.Click += new System.EventHandler(this.buttonExitProfile_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(12, 269);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(216, 25);
            this.label4.TabIndex = 24;
            this.label4.Text = "Список Ваших услуг";
            // 
            // FormMasterMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 559);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonExitProfile);
            this.Controls.Add(this.dataGridViewRecords);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonUpdateMasterServices);
            this.Controls.Add(this.checkedListBoxMasterServices);
            this.Controls.Add(this.maskedTextBoxUserPhone);
            this.Controls.Add(this.buttonUpdateUserPhone);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelUserName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "FormMasterMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OldTown Окно Мастера";
            this.Load += new System.EventHandler(this.FormMasterMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRecords)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox maskedTextBoxUserPhone;
        private System.Windows.Forms.Button buttonUpdateUserPhone;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.CheckedListBox checkedListBoxMasterServices;
        private System.Windows.Forms.Button buttonUpdateMasterServices;
        private System.Windows.Forms.DataGridView dataGridViewRecords;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonExitProfile;
        private System.Windows.Forms.Label label4;
    }
}