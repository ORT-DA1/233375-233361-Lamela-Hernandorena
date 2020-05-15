namespace UI
{
    partial class SelectAlarm
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
            this.panelAlarms = new System.Windows.Forms.Panel();
            this.cmbSelectTypeAlarm = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panelAlarms
            // 
            this.panelAlarms.Location = new System.Drawing.Point(3, 86);
            this.panelAlarms.Name = "panelAlarms";
            this.panelAlarms.Size = new System.Drawing.Size(460, 552);
            this.panelAlarms.TabIndex = 0;
            // 
            // cmbSelectTypeAlarm
            // 
            this.cmbSelectTypeAlarm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSelectTypeAlarm.FormattingEnabled = true;
            this.cmbSelectTypeAlarm.Location = new System.Drawing.Point(121, 39);
            this.cmbSelectTypeAlarm.Name = "cmbSelectTypeAlarm";
            this.cmbSelectTypeAlarm.Size = new System.Drawing.Size(121, 21);
            this.cmbSelectTypeAlarm.TabIndex = 1;
            this.cmbSelectTypeAlarm.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Seleccionar alarma";
            // 
            // SelectAlarm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbSelectTypeAlarm);
            this.Controls.Add(this.panelAlarms);
            this.Name = "SelectAlarm";
            this.Size = new System.Drawing.Size(460, 638);
            this.Load += new System.EventHandler(this.SelectAlarm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelAlarms;
        private System.Windows.Forms.ComboBox cmbSelectTypeAlarm;
        private System.Windows.Forms.Label label1;
    }
}
