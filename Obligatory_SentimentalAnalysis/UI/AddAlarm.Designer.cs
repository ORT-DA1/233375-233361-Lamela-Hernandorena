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
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblAddSentiment
            // 
            this.lblAddSentiment.AutoSize = true;
            this.lblAddSentiment.Location = new System.Drawing.Point(267, 17);
            this.lblAddSentiment.Name = "lblAddSentiment";
            this.lblAddSentiment.Size = new System.Drawing.Size(78, 13);
            this.lblAddSentiment.TabIndex = 1;
            this.lblAddSentiment.Text = "Agregar alarma";
            this.lblAddSentiment.Click += new System.EventHandler(this.LblAddSentiment_Click);
            // 
            // cmbEntities
            // 
            this.cmbEntities.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEntities.FormattingEnabled = true;
            this.cmbEntities.Location = new System.Drawing.Point(250, 73);
            this.cmbEntities.Name = "cmbEntities";
            this.cmbEntities.Size = new System.Drawing.Size(121, 21);
            this.cmbEntities.TabIndex = 2;
            this.cmbEntities.SelectedIndexChanged += new System.EventHandler(this.CmbEntities_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(147, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Entidad";
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(142, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Tipo de alarma";
            this.label2.Click += new System.EventHandler(this.Label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(143, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Cantidad de posts";
            this.label3.Click += new System.EventHandler(this.Label3_Click);
            // 
            // textBoxQuantityPost
            // 
            this.textBoxQuantityPost.Location = new System.Drawing.Point(250, 163);
            this.textBoxQuantityPost.Name = "textBoxQuantityPost";
            this.textBoxQuantityPost.Size = new System.Drawing.Size(72, 20);
            this.textBoxQuantityPost.TabIndex = 14;
            this.textBoxQuantityPost.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxQuantityPost_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(143, 217);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Plazo de tiempo";
            // 
            // textBoxQuantityTime
            // 
            this.textBoxQuantityTime.Location = new System.Drawing.Point(250, 214);
            this.textBoxQuantityTime.Name = "textBoxQuantityTime";
            this.textBoxQuantityTime.Size = new System.Drawing.Size(72, 20);
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
            this.btnAddAlarm.Location = new System.Drawing.Point(230, 277);
            this.btnAddAlarm.Name = "btnAddAlarm";
            this.btnAddAlarm.Size = new System.Drawing.Size(102, 23);
            this.btnAddAlarm.TabIndex = 19;
            this.btnAddAlarm.Text = "Agregar";
            this.btnAddAlarm.UseVisualStyleBackColor = true;
            this.btnAddAlarm.Click += new System.EventHandler(this.BtnAddAlarm_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonPositive);
            this.groupBox1.Controls.Add(this.radioButtonNegative);
            this.groupBox1.Location = new System.Drawing.Point(246, 109);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(175, 39);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButtonDays);
            this.groupBox2.Controls.Add(this.radioButtonHours);
            this.groupBox2.Location = new System.Drawing.Point(341, 204);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(146, 39);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            // 
            // AddAlarm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
            this.Name = "AddAlarm";
            this.Size = new System.Drawing.Size(680, 584);
            this.Load += new System.EventHandler(this.AddAlarm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
    }
}
