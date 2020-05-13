using System.Drawing;

namespace UI
{
	partial class AddSentiment
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
			this.textBoxSentiment = new System.Windows.Forms.TextBox();
			this.btnAdd = new System.Windows.Forms.Button();
			this.listBoxSentiment = new System.Windows.Forms.ListBox();
			this.btnDelete = new System.Windows.Forms.Button();
			this.radioButtonNegative = new System.Windows.Forms.RadioButton();
			this.radioButtonPositive = new System.Windows.Forms.RadioButton();
			this.SuspendLayout();
			// 
			// textBoxSentiment
			// 
			this.textBoxSentiment.Location = new System.Drawing.Point(232, 91);
			this.textBoxSentiment.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.textBoxSentiment.Name = "textBoxSentiment";
			this.textBoxSentiment.Size = new System.Drawing.Size(365, 22);
			this.textBoxSentiment.TabIndex = 2;
			this.textBoxSentiment.TextChanged += new System.EventHandler(this.TextBoxSentiment_TextChanged);
			// 
			// btnAdd
			// 
			this.btnAdd.BackColor = System.Drawing.Color.Transparent;
			this.btnAdd.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
			this.btnAdd.FlatAppearance.BorderSize = 0;
			this.btnAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnAdd.Location = new System.Drawing.Point(205, 226);
			this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(200, 38);
			this.btnAdd.TabIndex = 3;
			this.btnAdd.UseVisualStyleBackColor = false;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// listBoxSentiment
			// 
			this.listBoxSentiment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listBoxSentiment.FormattingEnabled = true;
			this.listBoxSentiment.ItemHeight = 16;
			this.listBoxSentiment.Location = new System.Drawing.Point(180, 372);
			this.listBoxSentiment.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.listBoxSentiment.Name = "listBoxSentiment";
			this.listBoxSentiment.Size = new System.Drawing.Size(267, 244);
			this.listBoxSentiment.TabIndex = 4;
			this.listBoxSentiment.SelectedIndexChanged += new System.EventHandler(this.listBoxSentiment_SelectedIndexChanged);
			// 
			// btnDelete
			// 
			this.btnDelete.BackColor = System.Drawing.Color.Transparent;
			this.btnDelete.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
			this.btnDelete.FlatAppearance.BorderSize = 0;
			this.btnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnDelete.Location = new System.Drawing.Point(205, 662);
			this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(211, 41);
			this.btnDelete.TabIndex = 5;
			this.btnDelete.UseVisualStyleBackColor = false;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// radioButtonNegative
			// 
			this.radioButtonNegative.AutoSize = true;
			this.radioButtonNegative.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.radioButtonNegative.Location = new System.Drawing.Point(460, 155);
			this.radioButtonNegative.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.radioButtonNegative.Name = "radioButtonNegative";
			this.radioButtonNegative.Size = new System.Drawing.Size(85, 21);
			this.radioButtonNegative.TabIndex = 8;
			this.radioButtonNegative.TabStop = true;
			this.radioButtonNegative.Text = "Negativo";
			this.radioButtonNegative.UseVisualStyleBackColor = false;
			// 
			// radioButtonPositive
			// 
			this.radioButtonPositive.AutoSize = true;
			this.radioButtonPositive.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.radioButtonPositive.Location = new System.Drawing.Point(252, 155);
			this.radioButtonPositive.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.radioButtonPositive.Name = "radioButtonPositive";
			this.radioButtonPositive.Size = new System.Drawing.Size(78, 21);
			this.radioButtonPositive.TabIndex = 9;
			this.radioButtonPositive.TabStop = true;
			this.radioButtonPositive.Text = "Positivo";
			this.radioButtonPositive.UseVisualStyleBackColor = false;
			// 
			// AddSentiment
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.BackgroundImage = global::UI.Properties.Resources.AgregarSentimientos;
			this.Controls.Add(this.radioButtonPositive);
			this.Controls.Add(this.radioButtonNegative);
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.listBoxSentiment);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.textBoxSentiment);
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Name = "AddSentiment";
			this.Size = new System.Drawing.Size(621, 785);
			this.Load += new System.EventHandler(this.AddSentiment_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.TextBox textBoxSentiment;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.ListBox listBoxSentiment;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.RadioButton radioButtonNegative;
		private System.Windows.Forms.RadioButton radioButtonPositive;
	}
}
