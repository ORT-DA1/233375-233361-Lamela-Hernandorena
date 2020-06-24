namespace UI
{
    partial class AddAuthorAlarm
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
            this.groupBoxTypeAlarm = new System.Windows.Forms.GroupBox();
            this.radioButtonPositive = new System.Windows.Forms.RadioButton();
            this.radioButtonNegative = new System.Windows.Forms.RadioButton();
            this.textBoxQuantityPost = new System.Windows.Forms.TextBox();
            this.textBoxQuantityTime = new System.Windows.Forms.TextBox();
            this.listBoxAuthorAlarms = new System.Windows.Forms.ListBox();
            this.addAlarm = new System.Windows.Forms.Button();
            this.labelError = new System.Windows.Forms.Label();
            this.groupBoxTypeTime = new System.Windows.Forms.GroupBox();
            this.radioButtonDays = new System.Windows.Forms.RadioButton();
            this.radioButtonHours = new System.Windows.Forms.RadioButton();
            this.groupBoxTypeAlarm.SuspendLayout();
            this.groupBoxTypeTime.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxTypeAlarm
            // 
            this.groupBoxTypeAlarm.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBoxTypeAlarm.Controls.Add(this.radioButtonPositive);
            this.groupBoxTypeAlarm.Controls.Add(this.radioButtonNegative);
            this.groupBoxTypeAlarm.Location = new System.Drawing.Point(159, 76);
            this.groupBoxTypeAlarm.Name = "groupBoxTypeAlarm";
            this.groupBoxTypeAlarm.Size = new System.Drawing.Size(175, 39);
            this.groupBoxTypeAlarm.TabIndex = 1;
            this.groupBoxTypeAlarm.TabStop = false;
            // 
            // radioButtonPositive
            // 
            this.radioButtonPositive.AutoSize = true;
            this.radioButtonPositive.Checked = true;
            this.radioButtonPositive.Location = new System.Drawing.Point(6, 14);
            this.radioButtonPositive.Name = "radioButtonPositive";
            this.radioButtonPositive.Size = new System.Drawing.Size(62, 17);
            this.radioButtonPositive.TabIndex = 2;
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
            this.radioButtonNegative.TabIndex = 3;
            this.radioButtonNegative.Text = "Negativa";
            this.radioButtonNegative.UseVisualStyleBackColor = true;
            // 
            // textBoxQuantityPost
            // 
            this.textBoxQuantityPost.Location = new System.Drawing.Point(159, 130);
            this.textBoxQuantityPost.Name = "textBoxQuantityPost";
            this.textBoxQuantityPost.Size = new System.Drawing.Size(110, 20);
            this.textBoxQuantityPost.TabIndex = 4;
            // 
            // textBoxQuantityTime
            // 
            this.textBoxQuantityTime.Location = new System.Drawing.Point(159, 174);
            this.textBoxQuantityTime.Name = "textBoxQuantityTime";
            this.textBoxQuantityTime.Size = new System.Drawing.Size(110, 20);
            this.textBoxQuantityTime.TabIndex = 5;
            // 
            // listBoxAuthorAlarms
            // 
            this.listBoxAuthorAlarms.FormattingEnabled = true;
            this.listBoxAuthorAlarms.HorizontalExtent = 1000;
            this.listBoxAuthorAlarms.HorizontalScrollbar = true;
            this.listBoxAuthorAlarms.Location = new System.Drawing.Point(29, 300);
            this.listBoxAuthorAlarms.Name = "listBoxAuthorAlarms";
            this.listBoxAuthorAlarms.Size = new System.Drawing.Size(395, 186);
            this.listBoxAuthorAlarms.TabIndex = 9;
            // 
            // addAlarm
            // 
            this.addAlarm.BackColor = System.Drawing.Color.Transparent;
            this.addAlarm.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.addAlarm.FlatAppearance.BorderSize = 0;
            this.addAlarm.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.addAlarm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.addAlarm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addAlarm.Location = new System.Drawing.Point(152, 217);
            this.addAlarm.Name = "addAlarm";
            this.addAlarm.Size = new System.Drawing.Size(164, 41);
            this.addAlarm.TabIndex = 9;
            this.addAlarm.UseVisualStyleBackColor = false;
            this.addAlarm.Click += new System.EventHandler(this.addAlarm_Click);
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.ForeColor = System.Drawing.Color.Red;
            this.labelError.Location = new System.Drawing.Point(187, 265);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(33, 13);
            this.labelError.TabIndex = 10;
            // 
            // groupBoxTypeTime
            // 
            this.groupBoxTypeTime.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBoxTypeTime.Controls.Add(this.radioButtonDays);
            this.groupBoxTypeTime.Controls.Add(this.radioButtonHours);
            this.groupBoxTypeTime.Location = new System.Drawing.Point(300, 160);
            this.groupBoxTypeTime.Name = "groupBoxTypeTime";
            this.groupBoxTypeTime.Size = new System.Drawing.Size(146, 39);
            this.groupBoxTypeTime.TabIndex = 6;
            this.groupBoxTypeTime.TabStop = false;
            // 
            // radioButtonDays
            // 
            this.radioButtonDays.AutoSize = true;
            this.radioButtonDays.Checked = true;
            this.radioButtonDays.Location = new System.Drawing.Point(6, 14);
            this.radioButtonDays.Name = "radioButtonDays";
            this.radioButtonDays.Size = new System.Drawing.Size(46, 17);
            this.radioButtonDays.TabIndex = 7;
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
            this.radioButtonHours.TabIndex = 8;
            this.radioButtonHours.Text = "Horas";
            this.radioButtonHours.UseVisualStyleBackColor = true;
            // 
            // AddAuthorAlarm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::UI.Properties.Resources.AlarmaAutores;
            this.Controls.Add(this.groupBoxTypeTime);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.addAlarm);
            this.Controls.Add(this.listBoxAuthorAlarms);
            this.Controls.Add(this.textBoxQuantityTime);
            this.Controls.Add(this.textBoxQuantityPost);
            this.Controls.Add(this.groupBoxTypeAlarm);
            this.Name = "AddAuthorAlarm";
            this.Size = new System.Drawing.Size(460, 552);
            this.groupBoxTypeAlarm.ResumeLayout(false);
            this.groupBoxTypeAlarm.PerformLayout();
            this.groupBoxTypeTime.ResumeLayout(false);
            this.groupBoxTypeTime.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxTypeAlarm;
        private System.Windows.Forms.RadioButton radioButtonPositive;
        private System.Windows.Forms.RadioButton radioButtonNegative;
        private System.Windows.Forms.TextBox textBoxQuantityPost;
        private System.Windows.Forms.TextBox textBoxQuantityTime;
        private System.Windows.Forms.ListBox listBoxAuthorAlarms;
        private System.Windows.Forms.Button addAlarm;
        private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.GroupBox groupBoxTypeTime;
        private System.Windows.Forms.RadioButton radioButtonDays;
        private System.Windows.Forms.RadioButton radioButtonHours;
    }
}
