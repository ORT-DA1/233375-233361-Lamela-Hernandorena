﻿namespace UI
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
			this.cmbEntities.Location = new System.Drawing.Point(111, 122);
			this.cmbEntities.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.cmbEntities.Name = "cmbEntities";
			this.cmbEntities.Size = new System.Drawing.Size(160, 24);
			this.cmbEntities.TabIndex = 2;
			// 
			// radioButtonPositive
			// 
			this.radioButtonPositive.AutoSize = true;
			this.radioButtonPositive.Location = new System.Drawing.Point(8, 17);
			this.radioButtonPositive.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.radioButtonPositive.Name = "radioButtonPositive";
			this.radioButtonPositive.Size = new System.Drawing.Size(78, 21);
			this.radioButtonPositive.TabIndex = 10;
			this.radioButtonPositive.TabStop = true;
			this.radioButtonPositive.Text = "Positiva";
			this.radioButtonPositive.UseVisualStyleBackColor = true;
			// 
			// radioButtonNegative
			// 
			this.radioButtonNegative.AutoSize = true;
			this.radioButtonNegative.Location = new System.Drawing.Point(119, 16);
			this.radioButtonNegative.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.radioButtonNegative.Name = "radioButtonNegative";
			this.radioButtonNegative.Size = new System.Drawing.Size(85, 21);
			this.radioButtonNegative.TabIndex = 11;
			this.radioButtonNegative.TabStop = true;
			this.radioButtonNegative.Text = "Negativa";
			this.radioButtonNegative.UseVisualStyleBackColor = true;
			// 
			// textBoxQuantityPost
			// 
			this.textBoxQuantityPost.Location = new System.Drawing.Point(204, 262);
			this.textBoxQuantityPost.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.textBoxQuantityPost.Name = "textBoxQuantityPost";
			this.textBoxQuantityPost.Size = new System.Drawing.Size(145, 22);
			this.textBoxQuantityPost.TabIndex = 14;
			this.textBoxQuantityPost.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxQuantityPost_KeyPress);
			// 
			// textBoxQuantityTime
			// 
			this.textBoxQuantityTime.Location = new System.Drawing.Point(204, 330);
			this.textBoxQuantityTime.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.textBoxQuantityTime.Name = "textBoxQuantityTime";
			this.textBoxQuantityTime.Size = new System.Drawing.Size(145, 22);
			this.textBoxQuantityTime.TabIndex = 16;
			this.textBoxQuantityTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxQuantityTime_KeyPress);
			// 
			// radioButtonDays
			// 
			this.radioButtonDays.AutoSize = true;
			this.radioButtonDays.Location = new System.Drawing.Point(8, 17);
			this.radioButtonDays.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.radioButtonDays.Name = "radioButtonDays";
			this.radioButtonDays.Size = new System.Drawing.Size(57, 21);
			this.radioButtonDays.TabIndex = 17;
			this.radioButtonDays.TabStop = true;
			this.radioButtonDays.Text = "Dias";
			this.radioButtonDays.UseVisualStyleBackColor = true;
			// 
			// radioButtonHours
			// 
			this.radioButtonHours.AutoSize = true;
			this.radioButtonHours.Location = new System.Drawing.Point(95, 18);
			this.radioButtonHours.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.radioButtonHours.Name = "radioButtonHours";
			this.radioButtonHours.Size = new System.Drawing.Size(67, 21);
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
			this.btnAddAlarm.Location = new System.Drawing.Point(204, 398);
			this.btnAddAlarm.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnAddAlarm.Name = "btnAddAlarm";
			this.btnAddAlarm.Size = new System.Drawing.Size(205, 49);
			this.btnAddAlarm.TabIndex = 19;
			this.btnAddAlarm.UseVisualStyleBackColor = false;
			this.btnAddAlarm.Click += new System.EventHandler(this.BtnAddAlarm_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.groupBox1.Controls.Add(this.radioButtonPositive);
			this.groupBox1.Controls.Add(this.radioButtonNegative);
			this.groupBox1.Location = new System.Drawing.Point(231, 181);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.groupBox1.Size = new System.Drawing.Size(233, 48);
			this.groupBox1.TabIndex = 20;
			this.groupBox1.TabStop = false;
			// 
			// groupBox2
			// 
			this.groupBox2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.groupBox2.Controls.Add(this.radioButtonDays);
			this.groupBox2.Controls.Add(this.radioButtonHours);
			this.groupBox2.Location = new System.Drawing.Point(395, 319);
			this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.groupBox2.Size = new System.Drawing.Size(195, 48);
			this.groupBox2.TabIndex = 21;
			this.groupBox2.TabStop = false;
			// 
			// grdAlarms
			// 
			this.grdAlarms.BackgroundColor = System.Drawing.SystemColors.Control;
			this.grdAlarms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grdAlarms.Location = new System.Drawing.Point(20, 490);
			this.grdAlarms.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.grdAlarms.Name = "grdAlarms";
			this.grdAlarms.ReadOnly = true;
			this.grdAlarms.RowTemplate.Height = 24;
			this.grdAlarms.Size = new System.Drawing.Size(569, 206);
			this.grdAlarms.TabIndex = 22;
			// 
			// AddAlarm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.BackgroundImage = global::UI.Properties.Resources.AgregarAlarma1;
			this.Controls.Add(this.grdAlarms);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnAddAlarm);
			this.Controls.Add(this.textBoxQuantityTime);
			this.Controls.Add(this.textBoxQuantityPost);
			this.Controls.Add(this.cmbEntities);
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.Name = "AddAlarm";
			this.Size = new System.Drawing.Size(613, 785);
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
