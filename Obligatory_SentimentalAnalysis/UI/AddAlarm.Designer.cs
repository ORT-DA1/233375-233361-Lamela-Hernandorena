namespace UI
{
    partial class AddAlarm
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.cmbEntities = new System.Windows.Forms.ComboBox();
			this.radioButtonPositive = new System.Windows.Forms.RadioButton();
			this.radioButtonNegative = new System.Windows.Forms.RadioButton();
			this.textBoxQuantityPost = new System.Windows.Forms.TextBox();
			this.textBoxQuantityTime = new System.Windows.Forms.TextBox();
			this.radioButtonDays = new System.Windows.Forms.RadioButton();
			this.radioButtonHours = new System.Windows.Forms.RadioButton();
			this.btnAddAlarm = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.grdAlarms = new System.Windows.Forms.DataGridView();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdAlarms)).BeginInit();
			this.SuspendLayout();
			// 
			// cmbEntities
			// 
			this.cmbEntities.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.cmbEntities.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbEntities.FormattingEnabled = true;
			this.cmbEntities.Location = new System.Drawing.Point(83, 99);
			this.cmbEntities.Name = "cmbEntities";
			this.cmbEntities.Size = new System.Drawing.Size(121, 21);
			this.cmbEntities.TabIndex = 2;
			// 
			// radioButtonPositive
			// 
			this.radioButtonPositive.AutoSize = true;
			this.radioButtonPositive.Location = new System.Drawing.Point(6, 14);
			this.radioButtonPositive.Name = "radioButtonPositive";
			this.radioButtonPositive.Size = new System.Drawing.Size(62, 17);
			this.radioButtonPositive.TabIndex = 10;
			this.radioButtonPositive.TabStop = true;
			this.radioButtonPositive.Text = "Positiva";
			this.radioButtonPositive.UseVisualStyleBackColor = true;
			// 
			// radioButtonNegative
			// 
			this.radioButtonNegative.AutoSize = true;
			this.radioButtonNegative.Location = new System.Drawing.Point(89, 13);
			this.radioButtonNegative.Name = "radioButtonNegative";
			this.radioButtonNegative.Size = new System.Drawing.Size(68, 17);
			this.radioButtonNegative.TabIndex = 11;
			this.radioButtonNegative.TabStop = true;
			this.radioButtonNegative.Text = "Negativa";
			this.radioButtonNegative.UseVisualStyleBackColor = true;
			// 
			// textBoxQuantityPost
			// 
			this.textBoxQuantityPost.Location = new System.Drawing.Point(153, 213);
			this.textBoxQuantityPost.Name = "textBoxQuantityPost";
			this.textBoxQuantityPost.Size = new System.Drawing.Size(110, 20);
			this.textBoxQuantityPost.TabIndex = 14;
			this.textBoxQuantityPost.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxQuantityPost_KeyPress);
			// 
			// textBoxQuantityTime
			// 
			this.textBoxQuantityTime.Location = new System.Drawing.Point(153, 268);
			this.textBoxQuantityTime.Name = "textBoxQuantityTime";
			this.textBoxQuantityTime.Size = new System.Drawing.Size(110, 20);
			this.textBoxQuantityTime.TabIndex = 16;
			this.textBoxQuantityTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxQuantityTime_KeyPress);
			// 
			// radioButtonDays
			// 
			this.radioButtonDays.AutoSize = true;
			this.radioButtonDays.Location = new System.Drawing.Point(6, 14);
			this.radioButtonDays.Name = "radioButtonDays";
			this.radioButtonDays.Size = new System.Drawing.Size(46, 17);
			this.radioButtonDays.TabIndex = 17;
			this.radioButtonDays.TabStop = true;
			this.radioButtonDays.Text = "Dias";
			this.radioButtonDays.UseVisualStyleBackColor = true;
			// 
			// radioButtonHours
			// 
			this.radioButtonHours.AutoSize = true;
			this.radioButtonHours.Location = new System.Drawing.Point(71, 15);
			this.radioButtonHours.Name = "radioButtonHours";
			this.radioButtonHours.Size = new System.Drawing.Size(53, 17);
			this.radioButtonHours.TabIndex = 18;
			this.radioButtonHours.TabStop = true;
			this.radioButtonHours.Text = "Horas";
			this.radioButtonHours.UseVisualStyleBackColor = true;
			// 
			// btnAddAlarm
			// 
			this.btnAddAlarm.BackColor = System.Drawing.Color.Transparent;
			this.btnAddAlarm.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
			this.btnAddAlarm.FlatAppearance.BorderSize = 0;
			this.btnAddAlarm.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.btnAddAlarm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.btnAddAlarm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnAddAlarm.Location = new System.Drawing.Point(153, 323);
			this.btnAddAlarm.Name = "btnAddAlarm";
			this.btnAddAlarm.Size = new System.Drawing.Size(154, 40);
			this.btnAddAlarm.TabIndex = 19;
			this.btnAddAlarm.UseVisualStyleBackColor = false;
			this.btnAddAlarm.Click += new System.EventHandler(this.BtnAddAlarm_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.groupBox1.Controls.Add(this.radioButtonPositive);
			this.groupBox1.Controls.Add(this.radioButtonNegative);
			this.groupBox1.Location = new System.Drawing.Point(173, 147);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(175, 39);
			this.groupBox1.TabIndex = 20;
			this.groupBox1.TabStop = false;
			// 
			// groupBox2
			// 
			this.groupBox2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.groupBox2.Controls.Add(this.radioButtonDays);
			this.groupBox2.Controls.Add(this.radioButtonHours);
			this.groupBox2.Location = new System.Drawing.Point(296, 259);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(146, 39);
			this.groupBox2.TabIndex = 21;
			this.groupBox2.TabStop = false;
			// 
			// grdAlarms
			// 
			this.grdAlarms.BackgroundColor = System.Drawing.SystemColors.Control;
			this.grdAlarms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grdAlarms.Location = new System.Drawing.Point(15, 398);
			this.grdAlarms.Margin = new System.Windows.Forms.Padding(2);
			this.grdAlarms.Name = "grdAlarms";
			this.grdAlarms.ReadOnly = true;
			this.grdAlarms.RowTemplate.Height = 24;
			this.grdAlarms.Size = new System.Drawing.Size(427, 167);
			this.grdAlarms.TabIndex = 22;
			// 
			// AddAlarm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.BackgroundImage = global::UI.Properties.Resources.AgregarAlarma;
			this.Controls.Add(this.grdAlarms);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnAddAlarm);
			this.Controls.Add(this.textBoxQuantityTime);
			this.Controls.Add(this.textBoxQuantityPost);
			this.Controls.Add(this.cmbEntities);
			this.Name = "AddAlarm";
			this.Size = new System.Drawing.Size(460, 638);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdAlarms)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbEntities;
        private System.Windows.Forms.RadioButton radioButtonPositive;
        private System.Windows.Forms.RadioButton radioButtonNegative;
        private System.Windows.Forms.TextBox textBoxQuantityPost;
        private System.Windows.Forms.TextBox textBoxQuantityTime;
        private System.Windows.Forms.RadioButton radioButtonDays;
        private System.Windows.Forms.RadioButton radioButtonHours;
        private System.Windows.Forms.Button btnAddAlarm;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.DataGridView grdAlarms;
	}
}
