namespace UI
{
    partial class ReportOfAuthors
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
            this.cmbCriterion = new System.Windows.Forms.ComboBox();
            this.radioButtonAsc = new System.Windows.Forms.RadioButton();
            this.radioButtonDesc = new System.Windows.Forms.RadioButton();
            this.btnGenerateReport = new System.Windows.Forms.Button();
            this.grdReport = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.grdReport)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbCriterion
            // 
            this.cmbCriterion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCriterion.FormattingEnabled = true;
            this.cmbCriterion.Location = new System.Drawing.Point(202, 86);
            this.cmbCriterion.Name = "cmbCriterion";
            this.cmbCriterion.Size = new System.Drawing.Size(182, 21);
            this.cmbCriterion.TabIndex = 1;
            // 
            // radioButtonAsc
            // 
            this.radioButtonAsc.AutoSize = true;
            this.radioButtonAsc.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.radioButtonAsc.Location = new System.Drawing.Point(186, 142);
            this.radioButtonAsc.Name = "radioButtonAsc";
            this.radioButtonAsc.Size = new System.Drawing.Size(82, 17);
            this.radioButtonAsc.TabIndex = 2;
            this.radioButtonAsc.TabStop = true;
            this.radioButtonAsc.Text = "Ascendente";
            this.radioButtonAsc.UseVisualStyleBackColor = false;
            // 
            // radioButtonDesc
            // 
            this.radioButtonDesc.AutoSize = true;
            this.radioButtonDesc.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.radioButtonDesc.Location = new System.Drawing.Point(295, 142);
            this.radioButtonDesc.Name = "radioButtonDesc";
            this.radioButtonDesc.Size = new System.Drawing.Size(89, 17);
            this.radioButtonDesc.TabIndex = 3;
            this.radioButtonDesc.TabStop = true;
            this.radioButtonDesc.Text = "Descendente";
            this.radioButtonDesc.UseVisualStyleBackColor = false;
            // 
            // btnGenerateReport
            // 
            this.btnGenerateReport.BackColor = System.Drawing.Color.Transparent;
            this.btnGenerateReport.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnGenerateReport.FlatAppearance.BorderSize = 0;
            this.btnGenerateReport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnGenerateReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnGenerateReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerateReport.Location = new System.Drawing.Point(141, 178);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(182, 51);
            this.btnGenerateReport.TabIndex = 4;
            this.btnGenerateReport.UseVisualStyleBackColor = false;
            this.btnGenerateReport.Click += new System.EventHandler(this.btnGenerateReport_Click);
            // 
            // grdReport
            // 
            this.grdReport.AllowUserToDeleteRows = false;
            this.grdReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdReport.Location = new System.Drawing.Point(22, 273);
            this.grdReport.Name = "grdReport";
            this.grdReport.ReadOnly = true;
            this.grdReport.Size = new System.Drawing.Size(416, 288);
            this.grdReport.TabIndex = 4;
            // 
            // ReportOfAuthors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::UI.Properties.Resources.ReporteAutor;
            this.Controls.Add(this.grdReport);
            this.Controls.Add(this.btnGenerateReport);
            this.Controls.Add(this.radioButtonDesc);
            this.Controls.Add(this.radioButtonAsc);
            this.Controls.Add(this.cmbCriterion);
            this.Name = "ReportOfAuthors";
            this.Size = new System.Drawing.Size(460, 638);
            ((System.ComponentModel.ISupportInitialize)(this.grdReport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbCriterion;
        private System.Windows.Forms.RadioButton radioButtonAsc;
        private System.Windows.Forms.RadioButton radioButtonDesc;
        private System.Windows.Forms.Button btnGenerateReport;
        private System.Windows.Forms.DataGridView grdReport;
    }
}
