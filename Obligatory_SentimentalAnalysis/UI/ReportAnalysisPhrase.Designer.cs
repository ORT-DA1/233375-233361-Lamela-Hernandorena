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
			((System.ComponentModel.ISupportInitialize)(this.grdPhrases)).BeginInit();
			this.SuspendLayout();
			// 
			// grdPhrases
			// 
			this.grdPhrases.BackgroundColor = System.Drawing.SystemColors.Control;
			this.grdPhrases.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grdPhrases.Location = new System.Drawing.Point(2, 78);
			this.grdPhrases.Margin = new System.Windows.Forms.Padding(2);
			this.grdPhrases.Name = "grdPhrases";
			this.grdPhrases.ReadOnly = true;
			this.grdPhrases.RowTemplate.Height = 24;
			this.grdPhrases.Size = new System.Drawing.Size(450, 440);
			this.grdPhrases.TabIndex = 0;
			// 
			// ReportAnalysisPhrase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = global::UI.Properties.Resources.AnalisisDeFrase;
			this.Controls.Add(this.grdPhrases);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "ReportAnalysisPhrase";
			this.Size = new System.Drawing.Size(460, 638);
			((System.ComponentModel.ISupportInitialize)(this.grdPhrases)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView grdPhrases;
	}
}
