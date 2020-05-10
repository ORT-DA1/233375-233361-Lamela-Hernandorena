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
            this.lblAddSentiment = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxSentiment = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.listBoxSentiment = new System.Windows.Forms.ListBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.radioButtonNegative = new System.Windows.Forms.RadioButton();
            this.radioButtonPositive = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // lblAddSentiment
            // 
            this.lblAddSentiment.AutoSize = true;
            this.lblAddSentiment.Location = new System.Drawing.Point(176, 13);
            this.lblAddSentiment.Name = "lblAddSentiment";
            this.lblAddSentiment.Size = new System.Drawing.Size(100, 13);
            this.lblAddSentiment.TabIndex = 0;
            this.lblAddSentiment.Text = "Agregar sentimiento";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Sentimiento";
            // 
            // textBoxSentiment
            // 
            this.textBoxSentiment.Location = new System.Drawing.Point(119, 51);
            this.textBoxSentiment.Name = "textBoxSentiment";
            this.textBoxSentiment.Size = new System.Drawing.Size(270, 20);
            this.textBoxSentiment.TabIndex = 2;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(174, 114);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(102, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Agregar";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // listBoxSentiment
            // 
            this.listBoxSentiment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxSentiment.FormattingEnabled = true;
            this.listBoxSentiment.Location = new System.Drawing.Point(109, 161);
            this.listBoxSentiment.Name = "listBoxSentiment";
            this.listBoxSentiment.Size = new System.Drawing.Size(245, 199);
            this.listBoxSentiment.TabIndex = 4;
            this.listBoxSentiment.SelectedIndexChanged += new System.EventHandler(this.listBoxSentiment_SelectedIndexChanged);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(174, 410);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(132, 23);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Eliminar";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // radioButtonNegative
            // 
            this.radioButtonNegative.AutoSize = true;
            this.radioButtonNegative.Location = new System.Drawing.Point(249, 77);
            this.radioButtonNegative.Name = "radioButtonNegative";
            this.radioButtonNegative.Size = new System.Drawing.Size(68, 17);
            this.radioButtonNegative.TabIndex = 8;
            this.radioButtonNegative.TabStop = true;
            this.radioButtonNegative.Text = "Negativo";
            this.radioButtonNegative.UseVisualStyleBackColor = true;
            // 
            // radioButtonPositive
            // 
            this.radioButtonPositive.AutoSize = true;
            this.radioButtonPositive.Location = new System.Drawing.Point(151, 77);
            this.radioButtonPositive.Name = "radioButtonPositive";
            this.radioButtonPositive.Size = new System.Drawing.Size(62, 17);
            this.radioButtonPositive.TabIndex = 9;
            this.radioButtonPositive.TabStop = true;
            this.radioButtonPositive.Text = "Positivo";
            this.radioButtonPositive.UseVisualStyleBackColor = true;
            // 
            // AddSentiment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.radioButtonPositive);
            this.Controls.Add(this.radioButtonNegative);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.listBoxSentiment);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.textBoxSentiment);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblAddSentiment);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AddSentiment";
            this.Size = new System.Drawing.Size(510, 474);
            this.Load += new System.EventHandler(this.AddSentiment_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblAddSentiment;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBoxSentiment;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.ListBox listBoxSentiment;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.RadioButton radioButtonNegative;
		private System.Windows.Forms.RadioButton radioButtonPositive;
	}
}
