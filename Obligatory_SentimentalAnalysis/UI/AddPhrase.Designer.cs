﻿

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddPhrase));
            this.textBoxPhrase = new System.Windows.Forms.TextBox();
            this.btnAddPhrase = new System.Windows.Forms.Button();
            this.dateTimePickerPhraseDate = new System.Windows.Forms.DateTimePicker();
            this.labelError = new System.Windows.Forms.Label();
            this.listBoxAuthors = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // textBoxPhrase
            // 
            this.textBoxPhrase.Location = new System.Drawing.Point(152, 101);
            this.textBoxPhrase.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxPhrase.Name = "textBoxPhrase";
            this.textBoxPhrase.Size = new System.Drawing.Size(208, 20);
            this.textBoxPhrase.TabIndex = 1;
            // 
            // btnAddPhrase
            // 
            this.btnAddPhrase.BackColor = System.Drawing.Color.Transparent;
            this.btnAddPhrase.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnAddPhrase.FlatAppearance.BorderSize = 0;
            this.btnAddPhrase.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAddPhrase.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAddPhrase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddPhrase.Location = new System.Drawing.Point(152, 569);
            this.btnAddPhrase.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddPhrase.Name = "btnAddPhrase";
            this.btnAddPhrase.Size = new System.Drawing.Size(158, 38);
            this.btnAddPhrase.TabIndex = 4;
            this.btnAddPhrase.UseVisualStyleBackColor = false;
            this.btnAddPhrase.Click += new System.EventHandler(this.btnAddPhrase_Click);
            // 
            // dateTimePickerPhraseDate
            // 
            this.dateTimePickerPhraseDate.Location = new System.Drawing.Point(152, 160);
            this.dateTimePickerPhraseDate.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePickerPhraseDate.Name = "dateTimePickerPhraseDate";
            this.dateTimePickerPhraseDate.Size = new System.Drawing.Size(208, 20);
            this.dateTimePickerPhraseDate.TabIndex = 2;
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.ForeColor = System.Drawing.Color.Red;
            this.labelError.Location = new System.Drawing.Point(149, 540);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(58, 13);
            this.labelError.TabIndex = 4;
            this.labelError.Visible = false;
            // 
            // listBoxAuthors
            // 
            this.listBoxAuthors.FormattingEnabled = true;
            this.listBoxAuthors.Location = new System.Drawing.Point(80, 228);
            this.listBoxAuthors.Name = "listBoxAuthors";
            this.listBoxAuthors.Size = new System.Drawing.Size(289, 290);
            this.listBoxAuthors.TabIndex = 3;
            // 
            // AddPhrase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.Controls.Add(this.listBoxAuthors);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.dateTimePickerPhraseDate);
            this.Controls.Add(this.btnAddPhrase);
            this.Controls.Add(this.textBoxPhrase);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AddPhrase";
            this.Size = new System.Drawing.Size(460, 638);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.TextBox textBoxPhrase;
		private System.Windows.Forms.Button btnAddPhrase;
		private System.Windows.Forms.DateTimePicker dateTimePickerPhraseDate;
		private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.ListBox listBoxAuthors;
    }
}
