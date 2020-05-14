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
			this.groupBoxTypeSentiment = new System.Windows.Forms.GroupBox();
			this.labelError = new System.Windows.Forms.Label();
			this.groupBoxTypeSentiment.SuspendLayout();
			this.SuspendLayout();
			// 
			// textBoxSentiment
			// 
			this.textBoxSentiment.Location = new System.Drawing.Point(174, 74);
			this.textBoxSentiment.Name = "textBoxSentiment";
			this.textBoxSentiment.Size = new System.Drawing.Size(275, 20);
			this.textBoxSentiment.TabIndex = 1;
			// 
			// btnAdd
			// 
			this.btnAdd.BackColor = System.Drawing.Color.Transparent;
			this.btnAdd.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
			this.btnAdd.FlatAppearance.BorderSize = 0;
			this.btnAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnAdd.Location = new System.Drawing.Point(154, 184);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(150, 31);
			this.btnAdd.TabIndex = 5;
			this.btnAdd.UseVisualStyleBackColor = false;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// listBoxSentiment
			// 
			this.listBoxSentiment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listBoxSentiment.FormattingEnabled = true;
			this.listBoxSentiment.Location = new System.Drawing.Point(135, 302);
			this.listBoxSentiment.Name = "listBoxSentiment";
			this.listBoxSentiment.Size = new System.Drawing.Size(201, 199);
			this.listBoxSentiment.TabIndex = 6;
			// 
			// btnDelete
			// 
			this.btnDelete.BackColor = System.Drawing.Color.Transparent;
			this.btnDelete.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
			this.btnDelete.FlatAppearance.BorderSize = 0;
			this.btnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnDelete.Location = new System.Drawing.Point(154, 538);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(158, 33);
			this.btnDelete.TabIndex = 7;
			this.btnDelete.UseVisualStyleBackColor = false;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// radioButtonNegative
			// 
			this.radioButtonNegative.AutoSize = true;
			this.radioButtonNegative.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.radioButtonNegative.Location = new System.Drawing.Point(165, 9);
			this.radioButtonNegative.Name = "radioButtonNegative";
			this.radioButtonNegative.Size = new System.Drawing.Size(68, 17);
			this.radioButtonNegative.TabIndex = 4;
			this.radioButtonNegative.Text = "Negativo";
			this.radioButtonNegative.UseVisualStyleBackColor = false;
			// 
			// radioButtonPositive
			// 
			this.radioButtonPositive.AutoSize = true;
			this.radioButtonPositive.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.radioButtonPositive.Checked = true;
			this.radioButtonPositive.Location = new System.Drawing.Point(20, 9);
			this.radioButtonPositive.Name = "radioButtonPositive";
			this.radioButtonPositive.Size = new System.Drawing.Size(62, 17);
			this.radioButtonPositive.TabIndex = 3;
			this.radioButtonPositive.TabStop = true;
			this.radioButtonPositive.Text = "Positivo";
			this.radioButtonPositive.UseVisualStyleBackColor = false;
			// 
			// groupBoxTypeSentiment
			// 
			this.groupBoxTypeSentiment.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.groupBoxTypeSentiment.Controls.Add(this.radioButtonNegative);
			this.groupBoxTypeSentiment.Controls.Add(this.radioButtonPositive);
			this.groupBoxTypeSentiment.Location = new System.Drawing.Point(165, 122);
			this.groupBoxTypeSentiment.Name = "groupBoxTypeSentiment";
			this.groupBoxTypeSentiment.Size = new System.Drawing.Size(249, 26);
			this.groupBoxTypeSentiment.TabIndex = 2;
			this.groupBoxTypeSentiment.TabStop = false;
			// 
			// labelError
			// 
			this.labelError.AutoSize = true;
			this.labelError.ForeColor = System.Drawing.Color.Red;
			this.labelError.Location = new System.Drawing.Point(162, 168);
			this.labelError.Name = "labelError";
			this.labelError.Size = new System.Drawing.Size(28, 13);
			this.labelError.TabIndex = 8;
			this.labelError.Visible = false;
			// 
			// AddSentiment
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.BackgroundImage = global::UI.Properties.Resources.AgregarSentimientos;
			this.Controls.Add(this.labelError);
			this.Controls.Add(this.groupBoxTypeSentiment);
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.listBoxSentiment);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.textBoxSentiment);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "AddSentiment";
			this.Size = new System.Drawing.Size(466, 638);
			this.groupBoxTypeSentiment.ResumeLayout(false);
			this.groupBoxTypeSentiment.PerformLayout();
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
		private System.Windows.Forms.GroupBox groupBoxTypeSentiment;
		private System.Windows.Forms.Label labelError;
	}
}
