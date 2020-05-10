namespace UI
{
	partial class AddPhrase
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
			this.labelAddPhrase = new System.Windows.Forms.Label();
			this.labelPhrase = new System.Windows.Forms.Label();
			this.textBoxPhrase = new System.Windows.Forms.TextBox();
			this.btnAgregar = new System.Windows.Forms.Button();
			this.dateTimePickerPhraseDate = new System.Windows.Forms.DateTimePicker();
			this.labelDateTime = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// labelAddPhrase
			// 
			this.labelAddPhrase.AutoSize = true;
			this.labelAddPhrase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelAddPhrase.Location = new System.Drawing.Point(271, 29);
			this.labelAddPhrase.Name = "labelAddPhrase";
			this.labelAddPhrase.Size = new System.Drawing.Size(130, 25);
			this.labelAddPhrase.TabIndex = 0;
			this.labelAddPhrase.Text = "Agregar frase";
			// 
			// labelPhrase
			// 
			this.labelPhrase.AutoSize = true;
			this.labelPhrase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelPhrase.Location = new System.Drawing.Point(114, 70);
			this.labelPhrase.Name = "labelPhrase";
			this.labelPhrase.Size = new System.Drawing.Size(68, 25);
			this.labelPhrase.TabIndex = 1;
			this.labelPhrase.Text = "Frase:";
			// 
			// textBoxPhrase
			// 
			this.textBoxPhrase.Location = new System.Drawing.Point(203, 74);
			this.textBoxPhrase.Name = "textBoxPhrase";
			this.textBoxPhrase.Size = new System.Drawing.Size(276, 22);
			this.textBoxPhrase.TabIndex = 2;
			// 
			// btnAgregar
			// 
			this.btnAgregar.Location = new System.Drawing.Point(276, 201);
			this.btnAgregar.Name = "btnAgregar";
			this.btnAgregar.Size = new System.Drawing.Size(125, 42);
			this.btnAgregar.TabIndex = 3;
			this.btnAgregar.Text = "Agregar";
			this.btnAgregar.UseVisualStyleBackColor = true;
			this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
			// 
			// dateTimePickerPhraseDate
			// 
			this.dateTimePickerPhraseDate.Location = new System.Drawing.Point(203, 124);
			this.dateTimePickerPhraseDate.Name = "dateTimePickerPhraseDate";
			this.dateTimePickerPhraseDate.Size = new System.Drawing.Size(276, 22);
			this.dateTimePickerPhraseDate.TabIndex = 4;
			// 
			// labelDateTime
			// 
			this.labelDateTime.AutoSize = true;
			this.labelDateTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelDateTime.Location = new System.Drawing.Point(114, 122);
			this.labelDateTime.Name = "labelDateTime";
			this.labelDateTime.Size = new System.Drawing.Size(73, 25);
			this.labelDateTime.TabIndex = 5;
			this.labelDateTime.Text = "Fecha:";
			// 
			// AddPhrase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.labelDateTime);
			this.Controls.Add(this.dateTimePickerPhraseDate);
			this.Controls.Add(this.btnAgregar);
			this.Controls.Add(this.textBoxPhrase);
			this.Controls.Add(this.labelPhrase);
			this.Controls.Add(this.labelAddPhrase);
			this.Name = "AddPhrase";
			this.Size = new System.Drawing.Size(680, 584);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelAddPhrase;
		private System.Windows.Forms.Label labelPhrase;
		private System.Windows.Forms.TextBox textBoxPhrase;
		private System.Windows.Forms.Button btnAgregar;
		private System.Windows.Forms.DateTimePicker dateTimePickerPhraseDate;
		private System.Windows.Forms.Label labelDateTime;
	}
}
