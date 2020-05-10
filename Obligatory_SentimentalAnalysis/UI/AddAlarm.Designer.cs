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
			this.lblAddSentiment = new System.Windows.Forms.Label();
			this.cmbEntities = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.radioButtonPositive = new System.Windows.Forms.RadioButton();
			this.radioButtonNegative = new System.Windows.Forms.RadioButton();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.textBoxQuantityPost = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
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
			// lblAddSentiment
			// 
			this.lblAddSentiment.AutoSize = true;
			this.lblAddSentiment.Location = new System.Drawing.Point(278, 7);
			this.lblAddSentiment.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblAddSentiment.Name = "lblAddSentiment";
			this.lblAddSentiment.Size = new System.Drawing.Size(106, 17);
			this.lblAddSentiment.TabIndex = 1;
			this.lblAddSentiment.Text = "Agregar alarma";
			// 
			// cmbEntities
			// 
			this.cmbEntities.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbEntities.FormattingEnabled = true;
			this.cmbEntities.Location = new System.Drawing.Point(255, 76);
			this.cmbEntities.Margin = new System.Windows.Forms.Padding(4);
			this.cmbEntities.Name = "cmbEntities";
			this.cmbEntities.Size = new System.Drawing.Size(160, 24);
			this.cmbEntities.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(118, 80);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 17);
			this.label1.TabIndex = 3;
			this.label1.Text = "Entidad";
			// 
			// radioButtonPositive
			// 
			this.radioButtonPositive.AutoSize = true;
			this.radioButtonPositive.Location = new System.Drawing.Point(8, 17);
			this.radioButtonPositive.Margin = new System.Windows.Forms.Padding(4);
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
			this.radioButtonNegative.Margin = new System.Windows.Forms.Padding(4);
			this.radioButtonNegative.Name = "radioButtonNegative";
			this.radioButtonNegative.Size = new System.Drawing.Size(85, 21);
			this.radioButtonNegative.TabIndex = 11;
			this.radioButtonNegative.TabStop = true;
			this.radioButtonNegative.Text = "Negativa";
			this.radioButtonNegative.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(111, 140);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(103, 17);
			this.label2.TabIndex = 12;
			this.label2.Text = "Tipo de alarma";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(113, 190);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(122, 17);
			this.label3.TabIndex = 13;
			this.label3.Text = "Cantidad de posts";
			// 
			// textBoxQuantityPost
			// 
			this.textBoxQuantityPost.Location = new System.Drawing.Point(255, 187);
			this.textBoxQuantityPost.Margin = new System.Windows.Forms.Padding(4);
			this.textBoxQuantityPost.Name = "textBoxQuantityPost";
			this.textBoxQuantityPost.Size = new System.Drawing.Size(95, 22);
			this.textBoxQuantityPost.TabIndex = 14;
			this.textBoxQuantityPost.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxQuantityPost_KeyPress);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(113, 253);
			this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(109, 17);
			this.label4.TabIndex = 15;
			this.label4.Text = "Plazo de tiempo";
			// 
			// textBoxQuantityTime
			// 
			this.textBoxQuantityTime.Location = new System.Drawing.Point(255, 249);
			this.textBoxQuantityTime.Margin = new System.Windows.Forms.Padding(4);
			this.textBoxQuantityTime.Name = "textBoxQuantityTime";
			this.textBoxQuantityTime.Size = new System.Drawing.Size(95, 22);
			this.textBoxQuantityTime.TabIndex = 16;
			this.textBoxQuantityTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxQuantityTime_KeyPress);
			// 
			// radioButtonDays
			// 
			this.radioButtonDays.AutoSize = true;
			this.radioButtonDays.Location = new System.Drawing.Point(8, 17);
			this.radioButtonDays.Margin = new System.Windows.Forms.Padding(4);
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
			this.radioButtonHours.Margin = new System.Windows.Forms.Padding(4);
			this.radioButtonHours.Name = "radioButtonHours";
			this.radioButtonHours.Size = new System.Drawing.Size(67, 21);
			this.radioButtonHours.TabIndex = 18;
			this.radioButtonHours.TabStop = true;
			this.radioButtonHours.Text = "Horas";
			this.radioButtonHours.UseVisualStyleBackColor = true;
			// 
			// btnAddAlarm
			// 
			this.btnAddAlarm.Location = new System.Drawing.Point(231, 310);
			this.btnAddAlarm.Margin = new System.Windows.Forms.Padding(4);
			this.btnAddAlarm.Name = "btnAddAlarm";
			this.btnAddAlarm.Size = new System.Drawing.Size(136, 28);
			this.btnAddAlarm.TabIndex = 19;
			this.btnAddAlarm.Text = "Agregar";
			this.btnAddAlarm.UseVisualStyleBackColor = true;
			this.btnAddAlarm.Click += new System.EventHandler(this.BtnAddAlarm_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.radioButtonPositive);
			this.groupBox1.Controls.Add(this.radioButtonNegative);
			this.groupBox1.Location = new System.Drawing.Point(250, 120);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
			this.groupBox1.Size = new System.Drawing.Size(233, 48);
			this.groupBox1.TabIndex = 20;
			this.groupBox1.TabStop = false;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.radioButtonDays);
			this.groupBox2.Controls.Add(this.radioButtonHours);
			this.groupBox2.Location = new System.Drawing.Point(377, 237);
			this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
			this.groupBox2.Size = new System.Drawing.Size(195, 48);
			this.groupBox2.TabIndex = 21;
			this.groupBox2.TabStop = false;
			// 
			// grdAlarms
			// 
			this.grdAlarms.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
			this.grdAlarms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grdAlarms.Location = new System.Drawing.Point(47, 373);
			this.grdAlarms.Name = "grdAlarms";
			this.grdAlarms.ReadOnly = true;
			this.grdAlarms.RowTemplate.Height = 24;
			this.grdAlarms.Size = new System.Drawing.Size(586, 179);
			this.grdAlarms.TabIndex = 22;
			// 
			// AddAlarm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ButtonShadow;
			this.Controls.Add(this.grdAlarms);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnAddAlarm);
			this.Controls.Add(this.textBoxQuantityTime);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.textBoxQuantityPost);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cmbEntities);
			this.Controls.Add(this.lblAddSentiment);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "AddAlarm";
			this.Size = new System.Drawing.Size(680, 584);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdAlarms)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAddSentiment;
        private System.Windows.Forms.ComboBox cmbEntities;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButtonPositive;
        private System.Windows.Forms.RadioButton radioButtonNegative;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxQuantityPost;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxQuantityTime;
        private System.Windows.Forms.RadioButton radioButtonDays;
        private System.Windows.Forms.RadioButton radioButtonHours;
        private System.Windows.Forms.Button btnAddAlarm;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.DataGridView grdAlarms;
	}
}
