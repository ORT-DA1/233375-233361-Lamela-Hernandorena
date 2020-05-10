namespace UI
{
	partial class ReportAnalysisPhrase
	{
		/// <summary> 
		/// Variable del diseñador necesaria.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Limpiar los recursos que se estén usando.
		/// </summary>
		/// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Código generado por el Diseñador de componentes

		/// <summary> 
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido de este método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
			this.grdPhrases = new System.Windows.Forms.DataGridView();
			this.labelPhrase = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.grdPhrases)).BeginInit();
			this.SuspendLayout();
			// 
			// grdPhrases
			// 
			this.grdPhrases.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grdPhrases.Location = new System.Drawing.Point(21, 95);
			this.grdPhrases.Name = "grdPhrases";
			this.grdPhrases.ReadOnly = true;
			this.grdPhrases.RowTemplate.Height = 24;
			this.grdPhrases.Size = new System.Drawing.Size(592, 450);
			this.grdPhrases.TabIndex = 0;
			// 
			// labelPhrase
			// 
			this.labelPhrase.AutoSize = true;
			this.labelPhrase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelPhrase.Location = new System.Drawing.Point(241, 27);
			this.labelPhrase.Name = "labelPhrase";
			this.labelPhrase.Size = new System.Drawing.Size(165, 25);
			this.labelPhrase.TabIndex = 1;
			this.labelPhrase.Text = "Reporte de frases";
			// 
			// ReportAnalysisPhrase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.labelPhrase);
			this.Controls.Add(this.grdPhrases);
			this.Name = "ReportAnalysisPhrase";
			this.Size = new System.Drawing.Size(680, 584);
			((System.ComponentModel.ISupportInitialize)(this.grdPhrases)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView grdPhrases;
		private System.Windows.Forms.Label labelPhrase;
	}
}
