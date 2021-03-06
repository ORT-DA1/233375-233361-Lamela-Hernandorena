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
            this.groupBoxTypeAlarm = new System.Windows.Forms.GroupBox();
            this.groupBoxTypeTime = new System.Windows.Forms.GroupBox();
            this.labelError = new System.Windows.Forms.Label();
            this.listBoxAlarms = new System.Windows.Forms.ListBox();
            this.groupBoxTypeAlarm.SuspendLayout();
            this.groupBoxTypeTime.SuspendLayout();
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
            this.cmbEntities.TabIndex = 1;
            // 
            // radioButtonPositive
            // 
            this.radioButtonPositive.AutoSize = true;
            this.radioButtonPositive.Checked = true;
            this.radioButtonPositive.Location = new System.Drawing.Point(6, 14);
            this.radioButtonPositive.Name = "radioButtonPositive";
            this.radioButtonPositive.Size = new System.Drawing.Size(62, 17);
            this.radioButtonPositive.TabIndex = 3;
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
            this.radioButtonNegative.TabIndex = 4;
            this.radioButtonNegative.Text = "Negativa";
            this.radioButtonNegative.UseVisualStyleBackColor = true;
            // 
            // textBoxQuantityPost
            // 
            this.textBoxQuantityPost.Location = new System.Drawing.Point(153, 213);
            this.textBoxQuantityPost.Name = "textBoxQuantityPost";
            this.textBoxQuantityPost.Size = new System.Drawing.Size(110, 20);
            this.textBoxQuantityPost.TabIndex = 5;
            this.textBoxQuantityPost.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxQuantityPost_KeyPress);
            // 
            // textBoxQuantityTime
            // 
            this.textBoxQuantityTime.Location = new System.Drawing.Point(153, 268);
            this.textBoxQuantityTime.Name = "textBoxQuantityTime";
            this.textBoxQuantityTime.Size = new System.Drawing.Size(110, 20);
            this.textBoxQuantityTime.TabIndex = 6;
            this.textBoxQuantityTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxQuantityTime_KeyPress);
            // 
            // radioButtonDays
            // 
            this.radioButtonDays.AutoSize = true;
            this.radioButtonDays.Checked = true;
            this.radioButtonDays.Location = new System.Drawing.Point(6, 14);
            this.radioButtonDays.Name = "radioButtonDays";
            this.radioButtonDays.Size = new System.Drawing.Size(46, 17);
            this.radioButtonDays.TabIndex = 8;
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
            this.radioButtonHours.TabIndex = 9;
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
            this.btnAddAlarm.TabIndex = 10;
            this.btnAddAlarm.UseVisualStyleBackColor = false;
            this.btnAddAlarm.Click += new System.EventHandler(this.BtnAddAlarm_Click);
            // 
            // groupBoxTypeAlarm
            // 
            this.groupBoxTypeAlarm.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBoxTypeAlarm.Controls.Add(this.radioButtonPositive);
            this.groupBoxTypeAlarm.Controls.Add(this.radioButtonNegative);
            this.groupBoxTypeAlarm.Location = new System.Drawing.Point(173, 147);
            this.groupBoxTypeAlarm.Name = "groupBoxTypeAlarm";
            this.groupBoxTypeAlarm.Size = new System.Drawing.Size(175, 39);
            this.groupBoxTypeAlarm.TabIndex = 2;
            this.groupBoxTypeAlarm.TabStop = false;
            // 
            // groupBoxTypeTime
            // 
            this.groupBoxTypeTime.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBoxTypeTime.Controls.Add(this.radioButtonDays);
            this.groupBoxTypeTime.Controls.Add(this.radioButtonHours);
            this.groupBoxTypeTime.Location = new System.Drawing.Point(296, 259);
            this.groupBoxTypeTime.Name = "groupBoxTypeTime";
            this.groupBoxTypeTime.Size = new System.Drawing.Size(146, 39);
            this.groupBoxTypeTime.TabIndex = 7;
            this.groupBoxTypeTime.TabStop = false;
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.ForeColor = System.Drawing.Color.Red;
            this.labelError.Location = new System.Drawing.Point(150, 307);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(0, 13);
            this.labelError.TabIndex = 22;
            // 
            // listBoxAlarms
            // 
            this.listBoxAlarms.FormattingEnabled = true;
            this.listBoxAlarms.HorizontalExtent = 1000;
            this.listBoxAlarms.HorizontalScrollbar = true;
            this.listBoxAlarms.Location = new System.Drawing.Point(31, 387);
            this.listBoxAlarms.Name = "listBoxAlarms";
            this.listBoxAlarms.Size = new System.Drawing.Size(411, 134);
            this.listBoxAlarms.TabIndex = 11;
            // 
            // AddAlarm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BackgroundImage = global::UI.Properties.Resources.AgregarAlarma1;
            this.Controls.Add(this.listBoxAlarms);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.groupBoxTypeTime);
            this.Controls.Add(this.groupBoxTypeAlarm);
            this.Controls.Add(this.btnAddAlarm);
            this.Controls.Add(this.textBoxQuantityTime);
            this.Controls.Add(this.textBoxQuantityPost);
            this.Controls.Add(this.cmbEntities);
            this.Name = "AddAlarm";
            this.Size = new System.Drawing.Size(460, 552);
            this.groupBoxTypeAlarm.ResumeLayout(false);
            this.groupBoxTypeAlarm.PerformLayout();
            this.groupBoxTypeTime.ResumeLayout(false);
            this.groupBoxTypeTime.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBoxTypeAlarm;
        private System.Windows.Forms.GroupBox groupBoxTypeTime;
		private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.ListBox listBoxAlarms;
    }
}
